using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContentManagement;
using ProjectAnalytics;
using ProjectAnalytics.Entities;

namespace UnifiLabs.Samples.ProjectAnalytics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Get an access token using basic authentication (username and password)
        // Optionally create a file named "Secrets.cs" and add fields called UnifiUsername and UnifiPassword and add your credentials for the below code to work.
        // Don't forget to ensure that this file is added to your .gitignore file.
        string unifiToken = Unifi.GetAccessToken(Secrets.UnifiUsername, Secrets.UnifiPassword);

        // Instantiate objects for user selection
        //public Commit commit = new Commit();
        //public Event eventData = new Event();
        public List<Symbol> symbols = new List<Symbol>();
        public List<FamilyInstance> familyInstances = new List<FamilyInstance>();

        public MainWindow()
        {
            InitializeComponent();

            // Hide overlay UI elements
            InfoUiVisible(false);

            // Hide the info button until a project is seleceted
            buttonProjectInfo.Visibility = Visibility.Hidden;

            // Hide models UI until a project that contains models is selected
            comboModels.Visibility = Visibility.Hidden;
            labelModels.Visibility = Visibility.Hidden;

            // Get all projects to display in combobox
            var projects = Unifi.GetProjects(unifiToken);

            // Sort the projects by name
            projects = projects.OrderBy(o => o.Name).ToList();

            // Add each project to the combobox as items
            foreach (var project in projects)
                comboProjects.Items.Add(project);

            // Get all models to display in combobox
            var models = Unifi.GetModels(unifiToken);

            // Sort the models by filename
            models = models.OrderBy(o => o.Filename).ToList();

        }

        /// <summary>
        /// Display or hide the overlay UI elements which display the info textbox
        /// </summary>
        /// <param name="isVisible">If true, the info UI elements will be displayed.</param>
        public void InfoUiVisible(bool isVisible)
        {
            if (isVisible == true)
            {
                // Show models UI
                gridOverlay.Visibility = Visibility.Visible;
                gridInfo.Visibility = Visibility.Visible;
            }
            else
            {
                // Hide models UI
                gridOverlay.Visibility = Visibility.Hidden;
                gridInfo.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Clear the secondary data. Typically used when selections change.
        /// </summary>
        public void ClearSecondaryData()
        {
            // Clear parameter datagrid
            dataGridFamilyData.ItemsSource = null;

            // Clear secondary navigation and family instances
            familyInstances.Clear();
            listboxSecondary.ItemsSource = null;

            symbols.Clear();
        }

        /// <summary>
        /// Clear the primary data. Typically used when selections change.
        /// </summary>
        public void ClearPrimaryData()
        {
            // Clear commits
            listboxCommits.Items.Clear();

            // Clear models
            comboModels.Items.Clear();

        }

        private void ComboProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboProjects.SelectedItem != null)
            {
                // Show the info button
                buttonProjectInfo.Visibility = Visibility.Visible;

                // Store all model objects in a list
                var models = new List<Model>();

                // Get selected item as a project object
                var project = new Project();
                project = comboProjects.SelectedItem as Project;

                // Always clear data when selection changes
                ClearPrimaryData();
                ClearPrimaryData();
                ClearSecondaryData();

                // Hide models UI when selection changes
                comboModels.Visibility = Visibility.Hidden;
                labelModels.Visibility = Visibility.Hidden;


                // Construct a string from Project data
                textBoxInfo.Text = string.Empty;
                textBoxInfo.Text += "Project ID: " + project.ProjectId + "\n";
                textBoxInfo.Text += "Analytics: " + project.Analytics + "\n";
                textBoxInfo.Text += "Status: " + project.Phase + "\n";
                textBoxInfo.Text += "Project Phase: " + project.DesignPhase + "\n";
                textBoxInfo.Text += "Office Location: " + project.OfficeLocationId + "\n";

                // Display model IDs if the project contains models.
                if (project.ModelIds.Count() > 0)
                {
                    // Enable combobox to select model
                    labelModels.Visibility = Visibility.Visible;
                    comboModels.Visibility = Visibility.Visible;

                    textBoxInfo.Text += "Model IDs: \n";

                    foreach (var modelId in project.ModelIds)
                    {
                        textBoxInfo.Text += "  - " + modelId + "\n";

                        models.Add(Unifi.GetModelById(unifiToken, modelId));
                    }

                    // Add each project to the combobox as items
                    foreach (var model in models)
                    {
                        comboModels.Items.Add(model);
                    }
                }
                // If there are no models, display a message.
                else
                {
                    textBoxInfo.Text += "This project has no models assigned.";
                }
            }
        }

        private void ComboModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboModels.SelectedItem != null)
            {
                // Store all commits in a list
                var commits = new List<Commit>();

                // Clear data when model selection changes
                listboxCommits.Items.Clear();
                ClearSecondaryData();

                // Get model object from combobox
                var model = new Model();
                model = comboModels.SelectedItem as Model;

                // Retrieve all commits of the selected model
                try
                {
                    commits = Unifi.GetCommitsByModelId(unifiToken, model.ModelId);

                    // Sort the commits by date (newest first)
                    if (commits.Count() > 0)
                    {
                        commits = commits.OrderByDescending(o => o.Timestamp).ToList();
                    }

                    // Add each commit to the listbox
                    foreach (var commit in commits)
                    {
                        listboxCommits.Items.Add(commit);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void buttonProjectInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoUiVisible(true);
        }

        private void buttonCloseOverlay_Click(object sender, RoutedEventArgs e)
        {
            InfoUiVisible(false);
        }

        private void ListboxCommits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear data when selection changes
            ClearSecondaryData();

            // Get model from selected item
            var model = new Model();
            model = comboModels.SelectedItem as Model;

            // Set commit object from selection
            var commit = listboxCommits.SelectedItem as Commit;

            // Get secureUrl from event as object
            if (commit != null)
            {
                var eventUrl = new Uri(Unifi.GetSecureUrl(unifiToken, model, commit.EventId).ToString());

                // Set event data from event URL
                var eventData = Unifi.GetEventData(eventUrl);

                // Set all commit symbols
                foreach (var symbol in eventData.Data.ProjectFamilies.FamilySymbols)
                {
                    symbols.Add(symbol);
                }

                // Add family instances as items on listbox
                foreach (var instance in eventData.Data.ProjectFamilies.FamilyInstances)
                {
                    familyInstances.Add(instance);
                }

                listboxSecondary.ItemsSource = familyInstances;
            }
        }

        private void ListboxSecondary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear data in datagrid
            dataGridFamilyData.ItemsSource = null;

            if (listboxCommits.SelectedItems.Count > 0)
            {
                // Get the content object from selection
                var instance = listboxSecondary.SelectedItem as FamilyInstance;

                if (instance != null)
                {
                    // Only one symbol should be found with the unie ID, so we store the number of symbols that match for debugging and data validation
                    int numberOfSymbols = 0;

                    // Find the family type (symbol) from the familyInstance's typeId property
                    foreach (var symbol in symbols)
                    {
                        if (instance.FamilySymbolId == symbol.Id)
                        {
                            // Count one for a found symbol
                            numberOfSymbols += 1;

                            var parameters = Unifi.GetParametersByTypeId(unifiToken, instance, symbols, symbol.Id);

                            dataGridFamilyData.ItemsSource = parameters;
                        }
                    }

                    // If more than one symbol with the same ID are found or if no symbols are found, display a warning
                    if (numberOfSymbols > 1 || numberOfSymbols == 0)
                    {
                        MessageBox.Show("WARNING: " + numberOfSymbols + " symbols found.");
                    }

                }

                //// Get selected item as Symbol object
                //var symbol = listboxSecondary.SelectedItem as Symbol;

                //// Generate a list of all type parameters from selected symbol
                //List<TypeParameter> typeParams = new List<TypeParameter>();

                //foreach (var param in symbol.TypeParameters)
                //{
                //    typeParams.Add(param);
                //}

                //// Display parameters on datagrid
                //dataGridFamilyData.ItemsSource = typeParams;

            }

            //var content = Unifi.GetContentByName(unifiToken, instance.Name);

            //content = Unifi.GetContentByRevisionId(unifiToken, content.CurrentRevisionId, content.Libraries[0].Id);

        }
    }
}
