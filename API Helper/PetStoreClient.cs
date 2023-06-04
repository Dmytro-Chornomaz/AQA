using RestSharp;

namespace API_Helper
{
    public class PetStoreClient
    {
        RestClient client = new RestClient("https://petstore.swagger.io/v2");

        public string CreatePet()
        {
            RestRequest request = new RestRequest("/pet", Method.Post);

            request.AddHeader("content-type", "application/json");

            string json = @"{
  ""id"": 3232,
  ""category"": {
    ""id"": 0,
    ""name"": ""Peach""
  },
  ""name"": ""lazy cat"",
  ""photoUrls"": [
    ""string""
  ],
  ""tags"": [
    {
      ""id"": 0,
      ""name"": ""string""
    }
  ],
  ""status"": ""available""
}";

            request.AddBody(json);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Return wrong status code");
            }

            return response.Content;
        }

        public string GetPetById(int id)
        {
            RestRequest request = new RestRequest($"/pet/{id}", Method.Get);

            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("You have mistake");
            }

            else if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
            {
                throw new Exception($"Service Unavailable \n {response.StatusCode}");

            }

            return response.Content;
        }
    }
}

