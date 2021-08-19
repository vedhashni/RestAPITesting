using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RestSharp;

namespace SpotifyProject.RestDelete
{
    [TestClass]
    public class RestDeleteEndPoint
    {
        string Authorization = "Bearer BQDsIMZoVZITmAbGQfh0Ovmo4cAKsouUJEmD0kfwgF8XpUCFV0wShyWS36-6En9szNAv0BnURoE1Zl3qzmLBTpW74JQr0CK2PSvuqMY-w6E8CTHLVdcWho964LuiwTA-P-TIPiVxl-SdcPS2d4xeeDb8g5XyS27CoTR6fcN4hveRLD0ETGiFws3hdL4VlTKiqZSIC_1FXjIh7OwiwaHOkKlwCktwIlBGpq6ox9fpAwN1g-NAA8yE9qDURDLoDw9BMVbDnOxVJQTkousW_MzVAkZYsFf1_cy4NASPaCZ4";

        string deleteUrl = "https://api.spotify.com/v1/playlists/7KQNokUMKyOVbYpVncLeHK/tracks";

        string json = "{ \"tracks\":" +
                         "[{ \"uri\": \"spotify:track:7mtYsNBYTDPa8Mscf166hg\"}]}";

        private static IRestResponse restResponse { get; set; }

        [TestMethod]

        public void TestDeleteWithJson()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(deleteUrl);

            restRequest.AddHeader("Authorization", "token" + Authorization);

            restRequest.AddJsonBody(json);

            restResponse = restClient.Delete(restRequest);

            Assert.AreEqual(200, (int)restResponse.StatusCode);

            if (restResponse.IsSuccessful)
            {
                Console.WriteLine((int)restResponse.StatusCode);
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
