﻿using System;
using Xunit;
using Rhino.Mocks;
using SKBKontur.TaskManagerClient;
using SKBKontur.TaskManagerClient.BusinessObjects.TaskManager;
using SKBKontur.Treller.Logger;
using SKBKontur.Treller.WebApplication.Implementation.Services.News.Domain.Builders;
using SKBKontur.Treller.WebApplication.Implementation.Services.News.Domain.Models;
using Assert = SKBKontur.Treller.Tests.UnitWrappers.Assert;

namespace SKBKontur.Treller.Tests.Tests.UnitTests.News.Domain.Builders
{
    public class AgingBoardCardBuilderTest : UnitTest
    {
        private readonly ITaskManagerClient taskManagerClient;
        private readonly OutdatedBoardCardBuilder outdatedBoardCardBuilder;
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger logger;

        public AgingBoardCardBuilderTest()
        {
            taskManagerClient = mock.Create<ITaskManagerClient>();
            loggerFactory = mock.Create<ILoggerFactory>();
            logger = mock.Create<ILogger>();

            outdatedBoardCardBuilder = new OutdatedBoardCardBuilder(taskManagerClient, loggerFactory);
        }

        [Fact]
        public void TestyTryBuildButNeworkExceptionOccured()
        {
            var cardId = DataGenerator.GenEnglishString(15);

            using (mock.Record())
            {
                taskManagerClient.Expect(f => f.GetCard(cardId)).Throw(new Exception());
                loggerFactory.Expect(f => f.Get<OutdatedBoardCardBuilder>()).Return(logger);
                logger.Expect(f => f.LogError(Arg<string>.Is.NotNull));
            }

            var actual = outdatedBoardCardBuilder.TryBuildModel(cardId);
            Assert.False(actual.HasValue);
        }

        [Fact]
        public void TestTryBuildWhenBoardListIsUndefined()
        {
            var cardId = DataGenerator.GenEnglishString(15);
            var boardId = DataGenerator.GenEnglishString(12);
            var card = new BoardCard
            {
                Id = cardId,
                BoardId = boardId
            };

            using (mock.Record())
            {
                taskManagerClient.Expect(f => f.GetCard(cardId)).Return(card);
                taskManagerClient.Expect(f => f.GetBoardLists(Arg<string[]>.Matches(arg => arg.Length == 1 && arg[0].Equals(boardId)))).Return(new BoardList[0]);
                loggerFactory.Expect(f => f.Get<OutdatedBoardCardBuilder>()).Return(logger);
                logger.Expect(f => f.LogError(Arg<string>.Is.NotNull));
            }

            var actual = outdatedBoardCardBuilder.TryBuildModel(cardId);
            Assert.False(actual.HasValue);
        }

        [Fact]
        public void TestTryBuildSuccessfully()
        {
            var cardId = DataGenerator.GenEnglishString(15);
            var boardId = DataGenerator.GenEnglishString(12);
            var boardListId = DataGenerator.GenEnglishString(14);
            var listName = DataGenerator.GenEnglishString(10);
            var lastActivity = DateTime.Now;
            var card = new BoardCard
            {
                Id = cardId,
                BoardId = boardId,
                BoardListId = boardListId,
                IsArchived = true,
                LastActivity = lastActivity
            };
            var boardList = new BoardList
            {
                Id = boardListId,
                Name = listName
            };

            using (mock.Record())
            {
                taskManagerClient.Expect(f => f.GetCard(cardId)).Return(card);
                taskManagerClient.Expect(f => f.GetBoardLists(Arg<string[]>.Matches(arg => arg.Length == 1 && arg[0].Equals(boardId)))).Return(new[] {boardList});
            }

            var expected = new OutdatedBoardCardModel
            {
                CardId = cardId,
                IsArchived = true,
                BoardListName = listName,
                LastActivity = lastActivity,
                ExpirationPeriod = TimeSpan.FromDays(3)
            };
            var actual = outdatedBoardCardBuilder.TryBuildModel(cardId);
            Assert.True(actual.HasValue);
            UnitWrappers.Assert.AreDeepEqual(actual, expected);
        }
    }
}