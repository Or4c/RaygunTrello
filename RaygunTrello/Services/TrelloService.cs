using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RaygunTrello.Models;

namespace RaygunTrello.Services
{
    public class TrelloService : ITrelloService
    {
        private ITrelloRepository _repo;

        public TrelloService()
        {
            _repo = ServiceLocator.GetService<ITrelloRepository>();
        }

        public async Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, int boardId)
        {
            return await _repo.GetCardsForBoardAsync(userToken, boardId);
        }

        public async Task AddCommentToCardAsync(string userToken, int cardId, string comment)
        {
            await _repo.AddCommentToCardAsync(userToken, cardId, comment);
        }

        public async Task<bool> ValidateUserTokenAsync(string userToken)
        {
            var member = await _repo.GetMemberForTokenAsync(userToken);
            return await Task.FromResult(member != null);
        }

        public async Task<IEnumerable<TrelloBoard>> GetUserBoardsAsync(string userToken)
        {
            return await _repo.GetBoardsForUserAsync(userToken);
        }
    }
}