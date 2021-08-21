using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RestSharp;

namespace SpotifyProject.RestDelete
{
    [TestClass]
    public class RestAddItem
    {
        string Authorization = "Bearer BQDb37K9MouIfsIhP0gYY_sQMllr4nvs21fUEHnwKS6IhDB24r2hCkORk6tKsP7KuUcsyUD3UVP5p1YFGllWVedY7Ds14xBwhasEet19ee7X9wCzJeE8ZtIw9dTH5OSiDLhzfIVxKB9o9ZE673nFjrPzpwEAOThaW-9M7tTgZYENYnXrljgrDYU1O3swKSlg7wUvpkyg72q_xsYL_6oXKnnQ4MB6pMZC3PF1m0z3cJZy-hLYmFBXu6rSd1UiYTqMTDkIZ__ceQmGRQiVvILnEIRCCMX8Aq1Lj1emH9VI";

        static string uri = "spotify:track:7mtYsNBYTDPa8Mscf166hg";
        
        private string postUrl = "https://api.spotify.com/v1/playlists/7KQNokUMKyOVbYpVncLeHK/tracks?uris=" + uri;

        //string json = "spotify%3Atrack%3A7mtYsNBYTDPa8Mscf166hg";

        private static IRestResponse restResponse { get; set; }

        [TestMethod]

        public void TestPostAddItem()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(postUrl);

            restRequest.AddHeader("Authorization", "token" + Authorization);

           restRequest.AddParameter("uris",uri);

            restResponse = restClient.Post(restRequest);
            Assert.AreEqual(201,202,(int)restResponse.StatusCode);

            Console.WriteLine((int)restResponse.StatusCode);

            if (restResponse.IsSuccessful)
            {
                Console.WriteLine(restResponse.StatusCode);
                Console.WriteLine(restResponse.Content);
            }
            else
            {
                Console.WriteLine(restResponse.ErrorMessage);
                Console.WriteLine(restResponse.ErrorException);
            }
        }
    }
}
