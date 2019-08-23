using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using RestSharp;

namespace ProjectAnalytics
{
    class Unifi
    {
        /// <summary>
        /// Retrieve an access token using basic authentication by passing a UNIFI username and password.
        /// </summary>
        /// <param name="username">UNIFI username</param>
        /// <param name="password">UNIFI password</param>
        /// <returns>The UNIFI access token.</returns>
        public static string GetAccessToken(string username, string password)
        {
            // Check that the developer has modified the default username and password in Secrets.cs
            if (Secrets.UnifiUsername != "USERNAME" && Secrets.UnifiPassword != "PASSWORD")
            {
                var client = new RestClient("https://api.unifilabs.com/login");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", JsonConvert.SerializeObject(new { username, password }), ParameterType.RequestBody);
                var response = client.Execute(request);

                // Deserialize JSON response to a dynamic object to retrieve the access token
                var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);

                // Return the access_token value as a string
                return obj.access_token;
            }
            else
            {
                MessageBox.Show(
                    "In order to use this sample application, you must add your " +
                    "UNIFI username and password to \"Secrets.cs\" in this repository.",
                    "Configuration Needed"
                    );

                return null;
            }

        }

        /// <summary>
        /// Retrieve all projects.
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <returns>A list of Project objects.</returns>
        public static List<Entities.Project> GetProjects(string accessToken)
        {
            var _projects = new List<Entities.Project>();

            var client = new RestClient("https://api.unifilabs.com/projects");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            // Deserialize JSON response to a List of Library objects
            _projects = JsonConvert.DeserializeObject<List<Entities.Project>>(response.Content);

            return _projects;
        }

        /// <summary>
        /// Retrieve all models.
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <returns>A list of all Model objects.</returns>
        public static List<Entities.Model> GetModels(string accessToken)
        {
            var _models = new List<Entities.Model>();

            var client = new RestClient("https://api.unifilabs.com/models");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            // Deserialize JSON response to a List of Library objects
            _models = JsonConvert.DeserializeObject<List<Entities.Model>>(response.Content);

            return _models;
        }

        /// <summary>
        /// Retrieve a model from it's model ID.
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <param name="modelId">The modelId of the model.</param>
        /// <returns>A Model object.</returns>
        public static Entities.Model GetModelById(string accessToken, Guid modelId)
        {
            var _model = new Entities.Model();

            var client = new RestClient("https://api.unifilabs.com/models/" + modelId.ToString());
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            // Deserialize JSON response to a Model object
            _model = JsonConvert.DeserializeObject<Entities.Model>(response.Content);

            return _model;
        }

        /// <summary>
        /// Retrieve all commits for a model from a Model ID.
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <param name="modelId">The ID of the model to retrieve the commits from.</param>
        /// <returns>A list of Commit objects.</returns>
        public static List<Entities.Commit> GetCommitsByModelId(string accessToken, Guid modelId)
        {
            var _commits = new List<Entities.Commit>();

            var client = new RestClient("https://api.unifilabs.com/models/" + modelId.ToString() + "/commits");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            // Deserialize JSON response to a Model object
            _commits = JsonConvert.DeserializeObject<List<Entities.Commit>>(response.Content);

            return _commits;
        }

        /// <summary>
        /// Retrieve meta data about a commit.
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <param name="model">The model of the commit.</param>
        /// <param name="eventId">The ID of the event.</param>
        /// <returns></returns>
        public static Uri GetSecureUrl(string accessToken, Entities.Model model, string eventId)
        {
            // First retrieve the signed URL
            var client = new RestClient("https://api.unifilabs.com/models/" + model.ModelId.ToString() + "/commits/" + eventId);
            var request = new RestRequest(Method.GET);
            //request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            // Deserialize JSON response to a Event object
            var eventObj = JsonConvert.DeserializeObject<Entities.Event>(response.Content);
            var eventUrl= new Uri(eventObj.Url.AbsoluteUri);

            return eventUrl;
        }

        /// <summary>
        /// Retrieve event data.
        /// </summary>
        /// <param name="eventUrl">The secure URL from a response to /models/{modelId}/commits/{eventId}.</param>
        /// <returns>A specific event's dataset.</returns>
        public static Entities.Event GetEventData(Uri eventUrl)
        {
            var _event = new Entities.Event();

            var client = new RestClient(eventUrl);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Deserialize JSON response to a Event object
            try
            {
                _event = JsonConvert.DeserializeObject<Entities.Event>(response.Content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return _event;
        }

        /// <summary>
        /// Retrieve a family's parameters from a family instance.
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <param name="familyInstance">The family instance to retrieve parameters from.</param>
        /// <param name="familyTypes">A list of family types (symbols) to search through. 
        /// This is typically passed from the projectFamilies.familySymbols array of a commit.</param>
        /// <param name="typeId">The ID of the family type (symbol).</param>
        /// <returns></returns>
        public static List<Entities.Parameter> GetParametersByTypeId(
            string accessToken, 
            Entities.FamilyInstance familyInstance, 
            List<Entities.Symbol> familyTypes, 
            string typeId
            )
        {
            // Instantiate a list for storing parameters
            var _parameters = new List<Entities.Parameter>();

            // Loop through all symbols in the list of family types (symbols)
            foreach (var symbol in familyTypes)
            {
                // Find the symbol which has a matching ID to the family instance
                if (symbol.Id == familyInstance.FamilySymbolId)
                {
                    // Add all parameters to the parameters list
                    foreach (var param in symbol.TypeParameters)
                    {
                        _parameters.Add(param);
                    }
                }
            }

            // Sort the parameters by name
            _parameters = _parameters.OrderBy(o => o.Name).ToList();

            return _parameters;
        }

        /// <summary>
        /// Get a specific Content by its FileRevisionId
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <param name="revisionId">The FileRevisionId property of the content.</param>
        /// <param name="libraryId">The ID of a library the content belongs to.</param>
        /// <returns></returns>
        public static ContentManagement.Entities.Content GetContentByRevisionId(string accessToken, Guid revisionId, Guid libraryId)
        {
            var content = new List<ContentManagement.Entities.Content>();

            var client = new RestClient("https://api.unifilabs.com/search");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(
                new
                {
                    terms = "*",
                    parameters = new[] { new { FileRevisionId = revisionId }
                    },
                    libraries = new[] { libraryId },
                    @return = "with-parameters"
                }
                ),
            ParameterType.RequestBody
            );
            var response = client.Execute(request);

            // Deserialize JSON response to a Content object
            try
            {
                content = JsonConvert.DeserializeObject<List<ContentManagement.Entities.Content>>(response.Content);
            }
            catch (Exception ex)
            {
                // Display debug info if exception is caught
                MessageBox.Show(ex.ToString(), "Exception");
                MessageBox.Show(response.Content, "Exception");
            }

            // TODO: Ensure that only one content is returned rather than hardcoding the first item in list
            if (content.Count > 1) { MessageBox.Show("Warning, more than one piece of content matches this query.", "Warning"); }

            return content[0];
        }

        /// <summary>
        /// Get a specific Content by its name.
        /// </summary>
        /// <param name="accessToken">UNIFI access token.</param>
        /// <param name="name">The name of the Content to search for.</param>
        /// <returns></returns>
        public static ContentManagement.Entities.Content GetContentByName(string accessToken, string name)
        {
            var content = new List<ContentManagement.Entities.Content>();

            var client = new RestClient("https://api.unifilabs.com/search");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(new { terms = name, @return = "with-parameters" }), ParameterType.RequestBody);
            var response = client.Execute(request);

            // Deserialize JSON response to a Content object
            try
            {
                content = JsonConvert.DeserializeObject<List<ContentManagement.Entities.Content>>(response.Content);
            }
            catch (Exception ex)
            {
                // Display debug info if exception is caught
                MessageBox.Show(ex.ToString(), "Exception");
                MessageBox.Show(response.Content, "Exception");
            }

            // TODO: Ensure that only one content is returned rather than hardcoding the first item in list
            if (content.Count > 1) {
                MessageBox.Show("Warning, more than one piece of content matches this query.", "Warning");
                return content[0];
            }
            else
            {
                MessageBox.Show("Error loading content.");
                return new ContentManagement.Entities.Content();
            }

        }

    }
}
