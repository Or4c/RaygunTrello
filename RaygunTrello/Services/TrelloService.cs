﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        public async Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, int boardId)
        {
            //var cards = await GetTrelloObjectAsync<List<TrelloCard>>(
            //    $"boards/{boardId}/cards",
            //    userToken,
            //    "open"
            //    );
            throw new NotImplementedException();
        }

        public async Task AddCommentToCardAsync(string userToken, int cardId, string comment)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateUserTokenAsync(string userToken)
        {
            return await GetMemberData(userToken) == null;
        }

        public async Task<IEnumerable<TrelloBoard>> GetUserBoardsAsync(string userToken)
        {
            var member = await GetMemberData(userToken);
            if (member == null) return null;

            var boards = await GetTrelloObjectAsync<List<TrelloBoard>>(
                $"members/{member.UserName}", 
                userToken, 
                "open", 
                "name,desc"
                );

            return boards;
        }

        private async Task<TrelloMember> GetMemberData(string userToken)
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
                await _httpClient.GetAsync($"{TrelloEndpoint}{endpoint}?key={_applicationKey}&token={userToken}&filters={filters}&fields={fields}");
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(response.Content.ToString()) : default(T);
        }

    }
}