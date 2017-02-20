using System.Collections.Generic;
using System.Threading.Tasks;
using RaygunTrello.Models;

namespace RaygunTrello.Services
{
    public interface ITrelloService
    {
        Task<IEnumerable<TrelloBoard>> GetUserBoardsAsync(string userToken);
        Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, string boardId);
        Task<IEnumerable<TrelloComment>> GetCardCommentsAsync(string userToken, string cardId);
        Task AddCommentToCardAsync(string userToken, string cardId, string comment);
        Task<bool> ValidateUserTokenAsync(string userToken);
    }
}
