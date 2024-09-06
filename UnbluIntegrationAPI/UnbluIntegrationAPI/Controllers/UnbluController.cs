using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using UnbluIntegrationAPI.Models;

namespace UnbluIntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnbluController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _authToken;

        public UnbluController(HttpClient httpClient)
        {
            _httpClient = httpClient;

            var username = "dylancnk@gmail.com";
            var password = "3bHmQsZWZta5d8";
            _authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        }

        private void AddBasicAuthHeader()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _authToken);
        }

        [HttpPost("createWithRandomPassword")]
        public async Task<IActionResult> CreateWithRandomPassword(CreateWithRandomPasswordModel createWithRandomPasswordModel)
        {
            var json = JsonConvert.SerializeObject(createWithRandomPasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            AddBasicAuthHeader();

            var response = await _httpClient.PostAsync("https://services8.unblu.com/app/rest/v4/users/createWithRandomPassword", content);

            var agentUser = await response.Content.ReadAsStringAsync();

            return Ok(agentUser);
        }

        //with file

        [HttpPost("createWithRandomPasswordWithFile")]
        public async Task<IActionResult> CreateWithRandomPasswordWithFile()
        {
            string filePath = @"C:\Users\dylan\source\repos\Unblu-WEBAPI-\UnbluIntegrationAPI\UnbluIntegrationAPI\Files\file.txt";

            List<CreateWithRandomPasswordModel> users = new List<CreateWithRandomPasswordModel>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var parts = line.Split(',');

                    if (parts.Length == 6)
                    {
                        var user = new CreateWithRandomPasswordModel
                        {
                            email = parts[0].Trim(),
                            username = parts[1].Trim(),
                            accountId = parts[2].Trim(),
                            firstName = parts[3].Trim(),
                            lastName = parts[4].Trim(),
                            authorizationRole = parts[5].Trim()
                        };

                        users.Add(user);
                    }
                }
            }

            foreach (var user in users)
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                AddBasicAuthHeader();
                var response = await _httpClient.PostAsync("https://services8.unblu.com/app/rest/v4/users/createWithRandomPassword", content);

                var result = await response.Content.ReadAsStringAsync();
            }

            return Ok("Files processed");
        }


        [HttpGet("persons/getBySource")]
        public async Task<IActionResult> GetPersonBySource(string personSource, string sourceId)
        {
            AddBasicAuthHeader();

            var query = $"?personSource={personSource}&sourceId={sourceId}";
            var requestUrl = $"https://services8.unblu.com/app/rest/v4/persons/getBySource{query}";

            var response = await _httpClient.GetAsync(requestUrl);
            var person = await response.Content.ReadAsStringAsync();

            return Ok(person);
        }

        [HttpPost("conversation/create")]
        public async Task<IActionResult> CreateConversation(CreateConversationModel createConversationModel)
        {
            var json = JsonConvert.SerializeObject(createConversationModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            AddBasicAuthHeader();

            var response = await _httpClient.PostAsync("https://services8.unblu.com/app/rest/v4/conversations/create", content);

            var agentUser = await response.Content.ReadAsStringAsync();

            return Ok(agentUser);
        }

        [HttpPost("invitations/search")]
        public async Task<IActionResult> InvitationSearch(InvitationSearchModel invitationSearchModel)
        {
            var json = JsonConvert.SerializeObject(invitationSearchModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            AddBasicAuthHeader();

            var response = await _httpClient.PostAsync("https://services8.unblu.com/app/rest/v4/invitations/search", content);

            var agentUser = await response.Content.ReadAsStringAsync();

            return Ok(agentUser);
        }

        [HttpPost("/conversationhistory/{conversationId}/exportMessageLog")]
        public async Task<IActionResult> MessageExport(string conversationId,DateTime minimum,DateTime maximum, [FromBody] MessageExportModel messageExportModel)
        {

            long minimumTimestamp = new DateTimeOffset(minimum).ToUnixTimeMilliseconds();
            long maximumTimestamp = new DateTimeOffset(maximum).ToUnixTimeMilliseconds();

            var messageExportQuery = new MessageExportModel
            {
                SearchFilters = new List<SearchFilterQuery>
        {
            new SearchFilterQuery
            {
                Type = "SendTimestampMessageExportFilter",
                Field = "SEND_TIMESTAMP",
                Operator = new OperatorQuery
                {
                    Type = "EqualsTimestampOperator",
                    OperatorType = "IN_RANGE",
                    Minimum = minimumTimestamp,
                    Maximum = maximumTimestamp
                }
            }
        },
                OrderBy = new List<OrderByQuery>
        {
            new OrderByQuery
            {
                Type = "MessageExportOrderBy",
                Field = "ID",
                Order = "ASCENDING"
            }
        },
                Offset = 0,
                Limit = 1000
            };

            var json = JsonConvert.SerializeObject(messageExportQuery);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            AddBasicAuthHeader();
            var response = await _httpClient.PostAsync($"https://services8.unblu.com/app/rest/v4/conversationhistory/{conversationId}/exportMessageLog", content);

            var historyexport = await response.Content.ReadAsStringAsync();
            return Ok(historyexport); 
        }
    }
}
