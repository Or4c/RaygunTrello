using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace RaygunTrello.Models
{
    public class TrelloRepository : ITrelloRepository
    {
        private HttpClient _httpClient;
        private string _applicationKey;


        public TrelloRepository()
        {
            _httpClient = new HttpClient();
            _applicationKey = WebConfigurationManager.AppSettings["TrelloApplicationKey"];
        }

        public async Task<IEnumerable<TrelloBoard>> GetBoardsForUserAsync(string userToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, int boardId)
        {
            throw new NotImplementedException();
        }

        public async Task AddCommentToCardAsync(string userToken, int cardId, string comment)
        {
            throw new NotImplementedException();
        }

        public async Task<TrelloMember> GetMemberForTokenAsync(string userToken)
        {
            throw new NotImplementedException();
        }
    }
}