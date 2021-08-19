using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RestSharp;

namespace SpotifyProject.RestDelete
{
    [TestClass]
    public class RestAddItem
    {
        string Authorization = "Bearer BQBN3IR1FVS1kQLFEaIB2YXTY8AjjQ3-xcmbUDdMpZuBc7WiWHIpv9IfEbwyuiHeBPaA1pWvaqlVQf7HAkCaqtsFtW4JxGXI4vrm9fbV2ujZr2_XLTTZcQvbXzM8VeGFfZN4xktDa0D4V3C1DraVz77beiAs6muk4g8AFOu8yoL3sm7r4zfyXK21ZTYAUfNsSpCfgy_YPHImXi5KghRWmR-Glbw_q8U303PnWQxRDzuXaP4rXPETekLdP5XYGqQsHdKjDmjdrEl5zU-52VNV1gnt1zH9w6lArCy_y4jh";

        private string postUrl = "https://api.spotify.com/v1/playlists/7KQNokUMKyOVbYpVncLeHK/tracks?uris=spotify%3Atrack%3A7mtYsNBYTDPa8Mscf166hg";

        //string json = "spotify%3Atrack%3A7mtYsNBYTDPa8Mscf166hg";

        private static IRestResponse restResponse { get; set; }

        [TestMethod]

        public void TestPostAddItem()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(postUrl);

            restRequest.AddHeader("Authorization", "token" + Authorization);

           // restRequest.AddParameter("tracks", "json" + json);

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
