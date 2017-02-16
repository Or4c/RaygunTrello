using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RaygunTrello.Models
{
    public interface ITrelloRepository
    {
        Task<IEnumerable<TrelloBoard>> GetBoardsForUserAsync(string userToken);
        Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, int boardId);
        Task AddCommentToCardAsync(string userToken, int cardId, string comment);
        Task<TrelloMember> GetMemberForTokenAsync(string userToken);
    }
}