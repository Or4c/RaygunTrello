using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaygunTrello.Models
{
    public interface ITrelloRepository
    {

        Task<IEnumerable<TrelloBoard>> GetUserBoardsAsync(string userToken);
        Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, string boardId);
        Task<TrelloCard> GetCardAsync(string userToken, string cardId);
        Task<IEnumerable<TrelloComment>> GetCardCommentsAsync(string userToken, string cardId);
        Task AddCommentToCardAsync(string userToken, string cardId, string comment);
        Task<bool> ValidateUserTokenAsync(string userToken);
    }
}
