using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace RaygunTrello.Services
{
    public class TrelloService : ITrelloService, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _applicationKey;
        private const string TrelloEndpoint = "https://api.trello.com/1/";

        public class ServiceResponse : ITrelloServiceResponse
        {
            public string Data { get; set; }
            public bool Success { get; set; }
        }

        public TrelloService()
        {
            _httpClient = new HttpClient();
            _applicationKey = WebConfigurationManager.AppSettings["TrelloApplicationKey"];
        }

        public async Task<ITrelloServiceResponse> GetCardsForBoardAsync(string userToken, string boardId)
        {
            var cards = await DoRequest(
                $"boards/{boardId}/cards",
                userToken,
                "open",
                "name,desc,url"
                );
            return cards;
        }

        public async Task<ITrelloServiceResponse> GetCardCommentsAsync(string userToken, string cardId)
        {
            var comments = await DoRequest(
                $"cards/{cardId}/actions",
                userToken,
                "commentCard"
                );
            return comments;
        }

        public async Task AddCommentToCardAsync(string userToken, string cardId, string comment)
        {
            var uri =
                $"{TrelloEndpoint}cards/{cardId}/actions/comments?key={_applicationKey}&token={userToken}&text={comment}";
            await _httpClient.PostAsync(uri, null);
        }

        public async Task<ITrelloServiceResponse> GetUserBoardsAsync(string userToken, string username)
        {
            var boards = await DoRequest(
                $"members/{username}/boards", 
                userToken, 
                "open", 
                "name,desc"
                );

            return boards;
        }

        public async Task<ITrelloServiceResponse> GetMemberDataAsync(string userToken)
        {
            var member = await DoRequest(
                "members/me", 
                userToken,
                fields: "username,uiBoards"
                );

            return member;
        }
        

        public async Task<ITrelloServiceResponse> GetCardAsync(string userToken, string cardId)
        {
            var card = await DoRequest(
                $"cards/{cardId}",
                userToken,
                fields:"name,desc,url"
                );

            return card;
        }

        private async Task<ITrelloServiceResponse> DoRequest(
            string endpoint,
            string userToken,
            string filters = "all",
            string fields = "all"
        )
        {
            var response = await _httpClient.GetAsync($"{TrelloEndpoint}{endpoint}?key={_applicationKey}&token={userToken}&filter={filters}&fields={fields}");

            var success = (response.StatusCode == HttpStatusCode.OK);
            var data = await response.Content.ReadAsStringAsync();

            return new ServiceResponse {Data = data, Success = success};
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

       
    }

   
}