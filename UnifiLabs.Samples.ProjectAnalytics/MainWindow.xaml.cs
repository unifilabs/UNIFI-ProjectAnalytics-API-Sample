using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UnifiLabs.Samples.ProjectAnalytics.Entities;

namespace UnifiLabs.Samples.ProjectAnalytics {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        // Get an access token using basic authentication (username and password)
        // Optionally create a file named "Secrets.cs" and add fields called UnifiUsername and UnifiPassword and add your credentials for the below code to work.
        private readonly string _unifiToken = Unifi.GetAccessToken(Secrets.UnifiUsername, Secrets.UnifiPassword);
        public List<FamilyInstance> FamilyInstances = new List<FamilyInstance>();

        // Instantiate objects for user selection
        public List<Symbol> Symbols = new List<Symbol>();

        // Instantiate the selected commit
        public Event SelectedEvent;

        // Get the most recent commit from the selected model
        public Commit LatestCommit;

        public MainWindow() {
            // Only launch application if an access token was granted
            if (_unifiToken.Length > 0) {
                InitializeComponent();

                // Hide overlay UI elements
                InfoUiVisible(false);

                // Hide the info button until a project is seleceted
                ButtonProjectInfo.Visibility = Visibility.Hidden;

                // Hide models UI until a project that contains models is selected
                ComboModels.Visibility = Visibility.Hidden;
                LabelModels.Visibility = Visibility.Hidden;

                // Get all projects to display in combobox
                var projects = Unifi.GetProjects(_unifiToken);

                // Sort the projects by name
                projects = projects.OrderBy(o => o.Name).ToList();

                // Add each project to the combobox as items
                foreach (var project in projects) { ComboProjects.Items.Add(project); }
            }
            else {
                // Show a dialog box if an access token was not granted
                MessageBox.Show(
                    "Could not retrieve an access token. " +
                    "Please verify that your username and password are correct in Secrets.cs",
                    "Error"
                );

                // Close the application if an access token was not granted
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        ///     Display or hide the overlay UI elements which display the info textbox
        /// </summary>
        /// <param name="isVisible">If true, the info UI elements will be displayed.</param>
        public void InfoUiVisible(bool isVisible) {
            if (isVisible) {
                // Show models UI
                GridOverlay.Visibility = Visibility.Visible;
                GridInfo.Visibility = Visibility.Visible;
            }
            else {
                // Hide models UI
                GridOverlay.Visibility = Visibility.Hidden;
                GridInfo.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        ///     Clear the secondary data. Typically used when selections change.
        /// </summary>
        public void ClearSecondaryData() {
            // Clear parameter datagrid
            DataGridFamilyData.ItemsSource = null;

            // Clear secondary navigation and family instances
            FamilyInstances.Clear();
            ListboxSecondary.ItemsSource = null;

            Symbols.Clear();
        }

        /// <summary>
        ///     Clear the primary data. Typically used when selections change.
        /// </summary>
        public void ClearPrimaryData() {
            // Clear commits
            ListboxCommits.Items.Clear();

            // Clear models
            ComboModels.Items.Clear();
        }

        private void ComboProjects_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ComboProjects.SelectedItem != null) {
                // Show the info button
                ButtonProjectInfo.Visibility = Visibility.Visible;

                // Store all model objects in a list
                var models = new List<Model>();

                // Get selected item as a project object
                var project = ComboProjects.SelectedItem as Project;

                // Always clear data when selection changes
                ClearPrimaryData();
                ClearPrimaryData();
                ClearSecondaryData();

                // Hide models UI when selection changes
                ComboModels.Visibility = Visibility.Hidden;
                LabelModels.Visibility = Visibility.Hidden;

                // Construct a string from Project data
                TextBoxInfo.Text = string.Empty;
                if (project != null) {
                    TextBoxInfo.Text += "Project ID: " + project.ProjectId + "\n";
                    TextBoxInfo.Text += "Analytics: " + project.Analytics + "\n";
                    TextBoxInfo.Text += "Status: " + project.Phase + "\n";
                    TextBoxInfo.Text += "Project Phase: " + project.DesignPhase + "\n";
                    TextBoxInfo.Text += "Office Location: " + project.OfficeLocationId + "\n";

                    // Display model IDs if the project contains models.
                    if (project.ModelIds.Any()) {
                        // Enable combobox to select model
                        LabelModels.Visibility = Visibility.Visible;
                        ComboModels.Visibility = Visibility.Visible;

                        TextBoxInfo.Text += "Model IDs: \n";

                        foreach (var modelId in project.ModelIds) {
                            TextBoxInfo.Text += "  - " + modelId + "\n";

                            models.Add(Unifi.GetModelById(_unifiToken, modelId));
                        }

                        // Add each project to the combobox as items
                        foreach (var model in models) { ComboModels.Items.Add(model); }
                    }
                    // If there are no models, display a message.
                    else { TextBoxInfo.Text += "This project has no models assigned."; }
                }
            }
        }

        private void ComboModels_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ComboModels.SelectedItem != null) {
                // Store all commits in a list
                var commits = new List<Commit>();

                // Clear data when model selection changes
                ListboxCommits.Items.Clear();
                ClearSecondaryData();

                // Get model object from combobox
                var model = ComboModels.SelectedItem as Model;

                // Retrieve all commits of the selected model
                try {
                    if (model != null) { commits = Unifi.GetCommitsByModelId(_unifiToken, model.ModelId); }

                    // Sort the commits by date (newest first)
                    if (commits.Any()) { commits = commits.OrderByDescending(o => o.Timestamp).ToList(); }

                    // Store the latest commit in field
                    LatestCommit = commits[0];

                    // Add each commit to the listbox
                    foreach (var commit in commits) { ListboxCommits.Items.Add(commit); }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void buttonProjectInfo_Click(object sender, RoutedEventArgs e) { InfoUiVisible(true); }

        private void buttonCloseOverlay_Click(object sender, RoutedEventArgs e) { InfoUiVisible(false); }

        private void ListboxCommits_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // Clear data when selection changes
            ClearSecondaryData();

            // Get model from selected item
            var model = ComboModels.SelectedItem as Model;

            // Get secureUrl from event as object
            if (ListboxCommits.SelectedItem is Commit commit) {
                var eventUrl = new Uri(Unifi.GetSecureUrl(_unifiToken, model, commit.EventId).ToString());

                // Set event data from event URL
                SelectedEvent = Unifi.GetEventData(eventUrl);

                // Set all commit symbols
                foreach (var symbol in SelectedEvent.Data.ProjectFamilies.FamilySymbols) { Symbols.Add(symbol); }

                // Add family instances as items in listbox
                foreach (var instance in SelectedEvent.Data.ProjectFamilies.FamilyInstances) { FamilyInstances.Add(instance); }

                ListboxSecondary.ItemsSource = FamilyInstances;
            }
        }

        private void ListboxSecondary_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // Clear data in datagrid
            DataGridFamilyData.ItemsSource = null;

            if (ListboxCommits.SelectedItems.Count > 0) {
                if (ListboxSecondary.SelectedItem is FamilyInstance instance) {
                    // Only one symbol should be found with the unie ID, so we store the number of symbols that match for debugging and data validation
                    var numberOfSymbols = 0;

                    // Find the family type (symbol) from the familyInstance's typeId property
                    foreach (var symbol in Symbols) {
                        if (instance.FamilySymbolId == symbol.Id) {
                            // Count one for a found symbol
                            numberOfSymbols += 1;

                            // Get parameters by type ID
                            var parameters = Unifi.GetParametersByTypeId(_unifiToken, instance, Symbols, symbol.Id);

                            // Display parameters and their values in the data grid
                            DataGridFamilyData.ItemsSource = parameters;
                        }
                    }

                    // If more than one symbol with the same ID are found or if no symbols are found, display a warning
                    if (numberOfSymbols > 1 || numberOfSymbols == 0) { MessageBox.Show("WARNING: " + numberOfSymbols + " symbols found."); }
                }
            }
        }

        private void BtnCompareChanges_Click(object sender, RoutedEventArgs e) {
            // Get model from selected item
            var model = ComboModels.SelectedItem as Model;

            // Get secureUrl from event as object
            var latestEventUrl = new Uri(Unifi.GetSecureUrl(_unifiToken, model, LatestCommit.EventId).ToString());

            // Set event data from event URL
            var latestEvent = Unifi.GetEventData(latestEventUrl);

            // Get latest and selected event families as lists
            var latestEventFamilies = latestEvent.Data.ProjectFamilies.FamilyInstances.ToList();
            var selectedEventFamilies = SelectedEvent.Data.ProjectFamilies.FamilyInstances.ToList();

            // Retrieves all of the families that have been added to the project model since the selected sync
            var addedFamilies = Unifi.GetNewFamilies(selectedEventFamilies, latestEventFamilies);

            // Retrieves all of the families that have been deleted from the project model since the selected sync
            var deletedFamilies = Unifi.GetDeletedFamilies(selectedEventFamilies, latestEventFamilies);

            // Calculate the elapsed time between syncs
            var elapsedTime = latestEvent.CollectionTime.Subtract(SelectedEvent.CollectionTime);

            // Store the results of the test in a string
            var reportData = "# Revit Model Changelog\n";

            // Add a summary of data regarding the report
            reportData += "This report was generated using the UNIFI Project Analytics API. For access to the source code, visit " +
                          "[https://github.com/unifilabs/UNIFI-ProjectAnalytics-API-Sample]." +
                          "\n---\n" +
                          "*Model:* " + (ComboModels.SelectedItem as Model).Filename + "\n" +
                          "*Dates Compared:* " +
                          SelectedEvent.CollectionTime.LocalDateTime + " => " + latestEvent.CollectionTime.LocalDateTime + "\n" +
                          "*Time elapsed:* " + elapsedTime.Days + " days, " + elapsedTime.Hours + " hours, " + elapsedTime.Minutes +
                          " minutes, " + elapsedTime.Seconds + " seconds";

            reportData += "\n---\n";

            // Add the added families to the report string
            reportData += "## Families Added\n";

            if (addedFamilies.Count() != 0) {
                // Create a counter the generate an ordered list
                var counter = 1;

                reportData += String.Format("{0:n0}", addedFamilies.Count()) + " families have been added.\n\n";

                // Add an ordered list item for each family in the list
                foreach (var fam in addedFamilies) {
                    // Write data to a line in the report
                    reportData += counter + ". [" + fam.ElementId + "] " + fam.Name + "\n";

                    // Increase the counter by one to continue the ordered list
                    counter += 1;
                }
            }
            else { reportData += "No families were added.\n"; }

            reportData += "\n---\n";

            // Add the deleted families to the report string
            reportData += "## Families Deleted\n";

            if (deletedFamilies.Count() != 0) {
                // Create a counter the generate an ordered list
                var counter = 1;

                reportData += String.Format("{0:n0}", deletedFamilies.Count()) + " families have been deleted.\n\n";

                // Add an ordered list item for each family in the list
                foreach (var fam in deletedFamilies) {
                    // Write data to a line in the report
                    reportData += counter + ". [" + fam.ElementId + "] " + fam.Name + "\n";

                    // Increase the counter by one to continue the ordered list
                    counter += 1;
                }
            }
            else { reportData += "No families were deleted.\n"; }

            reportData += "\n---\n";

            // Save the string as a text file
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "UNIFI Project Analytics Changelog";
            save.Filter = "Markdown Text File | *.md";

            if (save.ShowDialog() == true) {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                writer.Write(reportData);
                writer.Dispose();
                writer.Close();

                MessageBox.Show("Report saved to: " + save.FileName);
            }
        }
    }
}