using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RestSharp;


namespace SpotifyProject.RestPost
{
    [TestClass]
    public class RestPostEndPoint
    {
        private string Authorization = "Bearer BQCw6gNNsX6f7a2iGVSCfqjSqC7Bm2eYsnit1nsHFicwNU9y3H7Zt2jmbzlJ5VvEV093BM5l96NGZxxEEQD0KaLHPoFyDRmxOUp9rYvrIlB33X1-ZTDn2zxEggBA0wZ8TOCL-eXk1u2bg9Zvfj29j-ctkgcQ5XQ6LhDq_Xv35ORZ91mPMWlF8O-RnwP7j7eV8XNlYQ50qBBRgB7XeIt8DAZn6jRmADb4uKjfpXMzMCSGpRg9q0SY8_0d9Y0XmymhvHKPVIbcyKdf6A5NkTcije1I8P2K3puUnSmEdR1z";
        

        private string postUrl = "https://api.spotify.com/v1/users/xkaido0xyg6r28b0t150opk9b/playlists";
       
        private static IRestResponse restResponse { get; set; }


        [TestMethod]
        public void TestPostJsonData()
        {
           
            string JsonData = "{" +
                                    "\"name\": \"vedhashni's songs list\"," +
                                    "\"description\": \"New playlist created\"," +
                                    "\"public\" : \"false\""+
                                    "}";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(postUrl);
            
            restRequest.AddHeader("Authorization", "token" + Authorization);

            //restRequest.AddHeader("content-Type", "application/json");
            restRequest.AddJsonBody(JsonData);
            restRequest.AddHeader("content-Type", "application/json");

            restResponse = restClient.Post(restRequest);
            Assert.AreEqual(201,202,(int)restResponse.StatusCode);
            Console.WriteLine(restResponse.StatusCode);
            Console.WriteLine(restResponse.Content);
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
