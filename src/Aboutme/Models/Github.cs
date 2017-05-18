using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aboutme.Models
{
    [Table("Githubs")]
    public class Github
    {
        public int GithubId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Html_Url { get; set; }

        public static List<Github> GetGithub(string project)
        {
            var client = new RestClient("https://api.github.com/users");
            var request = new RestRequest("dvillars/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", "dvillars");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            var jsonReply = JsonConvert.DeserializeObject<JArray>(response.Content);

            string jsonOutput = jsonReply.ToString();

            var githublList = JsonConvert.DeserializeObject<List<Github>>(jsonOutput);

            return githublList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
