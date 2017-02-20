using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using RaygunTrello.Models;
using Newtonsoft.Json;

namespace RaygunTrello.Services
{
    public class TrelloService : ITrelloService
    {
        private readonly HttpClient _httpClient;
        private readonly string _applicationKey;
        private const string TrelloEndpoint = "https://api.trello.com/1/";

        public TrelloService()
        {
            _httpClient = new HttpClient();
            _applicationKey = WebConfigurationManager.AppSettings["TrelloApplicationKey"];
        }

        public async Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, string boardId)
        {
            var cards = await GetTrelloObjectAsync<List<TrelloCard>>(
                $"boards/{boardId}/cards",
                userToken,
                "open",
                "name,desc,url"
                );
            return cards;
        }

        public async Task<IEnumerable<TrelloComment>> GetCardCommentsAsync(string userToken, string cardId)
        {
            var comments = await GetTrelloObjectAsync<List<TrelloComment>>(
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

        public async Task<bool> ValidateUserTokenAsync(string userToken)
        {
            return await GetMemberDataAsync(userToken) == null;
        }

        public async Task<IEnumerable<TrelloBoard>> GetUserBoardsAsync(string userToken)
        {
            var member = await GetMemberDataAsync(userToken);
            if (member == null) return null;

            var boards = await GetTrelloObjectAsync<List<TrelloBoard>>(
                $"members/{member.UserName}/boards", 
                userToken, 
                "open", 
                "name,desc"
                );

            return boards;
        }

        private async Task<TrelloMember> GetMemberDataAsync(string userToken)
        {
            var member = await GetTrelloObjectAsync<TrelloMember>(
                "members/me", 
                userToken,
                fields: "username,uiBoards"
                );

            return member;
        }

        private async Task<T> GetTrelloObjectAsync<T>(
            string endpoint, 
            string userToken, 
            string filters = "all",
            string fields = "all"
            )
        {
            var response =
                await _httpClient.GetAsync($"{TrelloEndpoint}{endpoint}?key={_applicationKey}&token={userToken}&filter={filters}&fields={fields}");

            var jsonContent = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(jsonContent) : default(T);
        }

        public async Task<TrelloCard> GetCardAsync(string userToken, string cardId)
        {
            var card = await GetTrelloObjectAsync<TrelloCard>(
                $"cards/{cardId}",
                userToken,
                fields:"name,desc,url"
                );

            return card;
        }
    }
}