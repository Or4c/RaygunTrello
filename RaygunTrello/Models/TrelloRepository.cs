using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaygunTrello.Services;

namespace RaygunTrello.Models
{
    public class TrelloRepository : ITrelloRepository
    {
        private readonly ITrelloService _trelloService;

        public TrelloRepository()
        {
            _trelloService = ServiceLocator.GetService<ITrelloService>();
        }

        public async Task<IEnumerable<TrelloBoard>> GetUserBoardsAsync(string userToken)
        {
            // First get username
            var memberResult = await _trelloService.GetMemberDataAsync(userToken);
            if (!memberResult.Success) return null;

            var member = GetTrelloObject<TrelloMember>(memberResult);
            if (member == null) return null;

            var result = await _trelloService.GetUserBoardsAsync(userToken, member.UserName);
            return GetTrelloObject<IEnumerable<TrelloBoard>>(result);
        }

        public async Task<IEnumerable<TrelloCard>> GetCardsForBoardAsync(string userToken, string boardId)
        {
            var result = await _trelloService.GetCardsForBoardAsync(userToken, boardId);
            return GetTrelloObject<IEnumerable<TrelloCard>>(result);

        }

        public async Task<TrelloCard> GetCardAsync(string userToken, string cardId)
        {
            var result = await _trelloService.GetCardAsync(userToken, cardId);
            return GetTrelloObject<TrelloCard>(result);
        }

        public async Task<IEnumerable<TrelloComment>> GetCardCommentsAsync(string userToken, string cardId)
        {
            var result = await _trelloService.GetCardCommentsAsync(userToken, cardId);
            return GetTrelloObject<IEnumerable<TrelloComment>>(result);
        }

        public async Task AddCommentToCardAsync(string userToken, string cardId, string comment)
        {
            await _trelloService.AddCommentToCardAsync(userToken, cardId, comment);
        }

        public async Task<bool> ValidateUserTokenAsync(string userToken)
        {
            var memberData = await _trelloService.GetMemberDataAsync(userToken);
            return memberData.Success;
        }

        private static T GetTrelloObject<T>(ITrelloServiceResponse response)
        {
            try
            {
                if (!response.Success) return default(T);
                var jsonObject = JsonConvert.DeserializeObject<T>(response.Data);
                return jsonObject;
            }
            catch (JsonException)
            {
                return default(T);
            }
        }
    }
}