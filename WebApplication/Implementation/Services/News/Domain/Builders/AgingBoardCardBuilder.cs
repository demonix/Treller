using System;
using System.Linq;
using SKBKontur.Infrastructure.Common;
using SKBKontur.Infrastructure.Sugar;
using SKBKontur.TaskManagerClient;
using SKBKontur.Treller.WebApplication.Implementation.Services.ErrorService;
using SKBKontur.Treller.WebApplication.Implementation.Services.News.Domain.Models;

namespace SKBKontur.Treller.WebApplication.Implementation.Services.News.Domain.Builders
{
    public class AgingBoardCardBuilder : IAgingBoardCardBuilder
    {
        private readonly ITaskManagerClient taskManagerClient;
        private readonly IDateTimeFactory dateTimeFactory;
        private readonly IErrorService errorService;

        public AgingBoardCardBuilder(
            ITaskManagerClient taskManagerClient,
            IDateTimeFactory dateTimeFactory,
            IErrorService errorService)
        {
            this.taskManagerClient = taskManagerClient;
            this.dateTimeFactory = dateTimeFactory;
            this.errorService = errorService;
        }

        public Maybe<AgingBoardCardModel> TryBuildModel(string cardId)
        {
            try
            {
                var boardCard = taskManagerClient.GetCard(cardId);
                var boardList = taskManagerClient.GetBoardLists(boardCard.BoardId)
                                                 .FirstOrDefault(x => x.Id == boardCard.BoardListId);
                if (boardList == null)
                {
                    errorService.SendError($"Fail to find board list with id {boardCard.BoardListId} at board {boardCard.BoardId} for card {cardId}.");
                    return null;
                }

                var expirationTime = dateTimeFactory.UtcNow.AddDays(3);
                return new AgingBoardCardModel
                {
                    CardId = cardId,
                    IsArchived = boardCard.IsArchived,
                    BoardListName = boardList.Name,
                    LastActivity = boardCard.LastActivity,
                    ExpirationTime = expirationTime
                };
            }
            catch (Exception e)
            {
                errorService.SendError("Fail to build model due to network or integration errors.", e);
                return null;
            }
        }
    }
}