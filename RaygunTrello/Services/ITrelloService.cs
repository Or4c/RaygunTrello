using System.Collections.Generic;
using System.Threading.Tasks;
using RaygunTrello.Models;

namespace RaygunTrello.Services
{
    public interface ITrelloService
    {
        Task<ITrelloServiceResponse> GetUserBoardsAsync(string userToken, string username);
        Task<ITrelloServiceResponse> GetCardsForBoardAsync(string userToken, string boardId);
        Task<ITrelloServiceResponse> GetCardAsync(string userToken, string cardId);
        Task<ITrelloServiceResponse> GetCardCommentsAsync(string userToken, string cardId);
        Task<ITrelloServiceResponse> GetMemberDataAsync(string userToken);
        Task AddCommentToCardAsync(string userToken, string cardId, string comment);
    }

    public interface ITrelloServiceResponse
    {
        string Data { get; set; }
        bool Success { get; set; }
    }
}
