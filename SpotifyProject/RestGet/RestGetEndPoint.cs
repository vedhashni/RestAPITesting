using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RestSharp;

namespace SpotifyProject.RestGet
{
    [TestClass]
    public class RestGetEndPoint
    {
        private string Authorization = "Bearer BQChmtZMXQ4v7CWrMeVYW-3GMlZzrU9hFs8tgCCjPy5a5lqGtLSCPWftXtTf0HHeWz15zIyleT7bRYg8wfWHJo0mU5L74qx3AO6daFzUjWDAhSY4DlzZ_Q4NRwaRJWAJnEHJK92grZlk8guPtKDVxXbaqMA9X6tZkJCSgs832ggJg98FdNU6odwpXYgp3F-nPxfg3K4d-cKykTaMg7ZHxHEZt_S2s7mNPMfwKrE9yykEndRRoLhJu2q6kLq4KK7jo9wa4NZgkTblUDItPq6Ty_VyCaGhE6uX3emnk3so";
        private string getUrl = "https://api.spotify.com/v1/me";

        [TestMethod]

        public void TestGetUsingRestSharp()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl);
            //to check statuscode and content 
            restRequest.AddHeader("Authorization", "token" + Authorization);
            IRestResponse restResponse = restClient.Get(restRequest);
            //Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine(restResponse.StatusCode);
                Console.WriteLine(restResponse.Content);
            }
            Console.WriteLine(restResponse.ErrorMessage);
            Console.WriteLine(restResponse.ErrorException);
        }

        [TestMethod]
        public void TestGetJsonDeserialize()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl);
            restRequest.AddHeader("Authorization", "token" + Authorization);
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<JsonObjects>> restResponse = restClient.Get<List<JsonObjects>>(restRequest);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine(restResponse.StatusCode);
                Console.WriteLine(restResponse.Data.Count);
            }
            else
            {
                Console.WriteLine(restResponse.ErrorMessage);
                Console.WriteLine(restResponse.ErrorException);
            }
        }
    }
}
