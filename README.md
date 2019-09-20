# UNIFI Project Analytics API Sample

This C# WPF application is a simple example of using the UNIFI Project Analytics REST API. With this application, users can review the historical data collected by Project Analytics. Additionally, users may choose to automatically generate a changelog to identify which Revit families were added or removed from a model as of any point in time.

Refer to https://apidocs.unifilabs.com/?version=latest for the full the UNIFI API documentation.

## Usage
Note that all UNIFI users who use this appliction must have Project Analytics API access. For more information or to request access to the Project Analytics API, contact [sales@unifilabs.com](mailto:sales@unifilabs.com).

### Log In
After launching the application, enter your UNIFI username and password. Once logged in, the application will populate the Projects dropdown menu with all of the Project Analytics projects in your company.

![](https://imgur.com/aG3hilE.png)

> This action makes an API call to the `/login` endpoint to retrieve an `access_token` and the `/projects` endpoint to retrieve all projects associated with the logged in user's company.

### Review Revit Family Parameter Data
*To demonstrate how to retrieve a subset of the data that UNIFI is collecting, we've built the ability to select any model snapshot (a specific sync to central) and review the Revit family instances and their parameter values as of that day and time.*

![](https://imgur.com/YNpDDSV.png)

**1. Select a project from the Projects dropdown menu. If the selected project has models assigned, the Models dropdown menu appears and is populated with the models that are assigned to the selected project.**

> This action makes an API call to the `/models` endpoint to retrieve all models from the selected project.

**2. Select a model from the Models dropdown menu to populate the Model Snapshots column with the snapshots (i.e., syncs to central) of the selected model.**

> This action makes an API call to the `/models/{id}/commits` endpoint to retrieve all commits for the selected model.

**3. Select a snapshot (i.e., commit) to populate the Assets column with all of the assets (i.e., family instances) that were placed in the model at the time of the selected sync.**

> This action makes an API call to the `/models/{id}/commmits/{eventId}` endpoint to retrieve the data for that specific commit.

**4. Select an asset from the Assets column to populate the Data grid to review the parameter values of that particular family instance.**

> This action does not make an API call because the data was previously collected from the `/models/{id}/commits/{eventId}` endpoint.

### Generate a Changelog
*Users may also generate a changelog which compares a selected snapshot to the current snapshot and exports a markdown (MD) formatted text file.*

![](https://imgur.com/Be9rvsP.png)

Once a Snapshot is selected in the Model Snapshots column, the Generate Changelog button appears. This button will generate the report after prompting the user to save the file. Currently, the report identifies which families were added or deleted since the snapshot. Note the number in square brackets is the element ID of the family instance within the model.

> This action does not make an API call because the data was previously collected from the `/models/{id}/commits/{eventId}` endpoint.

## Meta

Developed by: [Jay Merlan](https://www.linkedin.com/in/jmerlan/) with [UNIFI Labs](http://unifilabs.com)

## Contributing

1. Fork it (<https://github.com/unifilabs/UNIFI-ProjectAnalytics-API-Sample>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request