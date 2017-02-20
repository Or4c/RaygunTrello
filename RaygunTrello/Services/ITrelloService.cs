using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaygunTrello.Models;

namespace RaygunTrello.Services
{
    public interface ITrelloService
    {
        Task<IEnumerable<TrelloBoard>> GetUserBoardsAsync(string userToken);
        Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, string boardId);
        Task<List<TrelloComment>> GetCardCommentsAsync(string userToken, string cardId);
        Task AddCommentToCardAsync(string userToken, string cardId, string comment);
        Task<bool> ValidateUserTokenAsync(string userToken);
    }
}
