using System;
using System.Collections.Generic;
using System.Text;
using Minesweeper.BusinessLogic;
using Minesweeper.DataAccess;
using Minesweeper.Models;
using Xunit;

namespace Minesweeper.Tests
{
    public class GameHistoryServiceTests
    {
        [Fact]
        public void AddResult_AfterLoadedRecords_AssignsNextAvailableId()
        {
            // Arrange
            string path = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".json");

            GameStatFileStore fileStore = new GameStatFileStore();
            GameHistoryService history = new GameHistoryService(fileStore);

            List<GameStat> existingResults = new List<GameStat>
        {
        new GameStat
        {
            Id = 2,
            PlayerName = "Alex",
            Score = 500,
            ElapsedSeconds = 20,
            PlayedAt = DateTime.Now
        },
        new GameStat
        {
            Id = 5,
            PlayerName = "Jordan",
            Score = 700,
            ElapsedSeconds = 15,
            PlayedAt = DateTime.Now
        }
        };

            fileStore.Save(path, existingResults);
            history.LoadHistory(path);

            // Act
            history.AddResult("Taylor", 900, 10, DateTime.Now);

            // Assert
            List<GameStat> results = history.GetResults();

            Assert.Equal(3, results.Count);
            Assert.Equal(6, results[2].Id);

            // Cleanup
            File.Delete(path);
        }

        [Fact]
        public void SortByName_OrdersPlayersAlphabetically()
        {
            // Arrange
            GameHistoryService history =
                new GameHistoryService(new GameStatFileStore());

            history.AddResult("Taylor", 500, 20, DateTime.Now);
            history.AddResult("alex", 600, 18, DateTime.Now);
            history.AddResult("Jordan", 700, 15, DateTime.Now);

            // Act
            history.SortByName();

            // Assert
            List<GameStat> results = history.GetResults();

            Assert.Equal("alex", results[0].PlayerName);
            Assert.Equal("Jordan", results[1].PlayerName);
            Assert.Equal("Taylor", results[2].PlayerName);
        }

        [Fact]
        public void SortByScore_OrdersHighestScoreFirst()
        {
            // Arrange
            GameHistoryService history =
                new GameHistoryService(new GameStatFileStore());

            history.AddResult("Alex", 500, 20, DateTime.Now);
            history.AddResult("Jordan", 900, 15, DateTime.Now);
            history.AddResult("Taylor", 700, 18, DateTime.Now);

            // Act
            history.SortByScore();

            // Assert
            List<GameStat> results = history.GetResults();

            Assert.Equal(900, results[0].Score);
            Assert.Equal(700, results[1].Score);
            Assert.Equal(500, results[2].Score);
        }

        [Fact]
        public void LoadHistory_Twice_DoesNotDuplicateResults()
        {
            // Arrange
            string path = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".json");

            GameStatFileStore fileStore = new GameStatFileStore();
            GameHistoryService history = new GameHistoryService(fileStore);

            history.AddResult("Alex", 500, 20, DateTime.Now);
            history.AddResult("Jordan", 700, 15, DateTime.Now);

            history.SaveHistory(path);

            // Act
            history.LoadHistory(path);
            history.LoadHistory(path);

            // Assert
            List<GameStat> results = history.GetResults();

            Assert.Equal(2, results.Count);
            Assert.Equal("Alex", results[0].PlayerName);
            Assert.Equal("Jordan", results[1].PlayerName);

            // Cleanup
            File.Delete(path);
        }

        [Fact]
        public void LoadHistory_InvalidFile_PreservesExistingResults()
        {
            // Arrange
            string path = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".json");

            GameHistoryService history =
                new GameHistoryService(new GameStatFileStore());

            history.AddResult("Alex", 500, 20, DateTime.Now);

            File.WriteAllText(path, "{ invalid json }");

            // Act and Assert
            Assert.Throws<System.Text.Json.JsonException>(
                () => history.LoadHistory(path));

            List<GameStat> results = history.GetResults();

            Assert.Single(results);
            Assert.Equal("Alex", results[0].PlayerName);

            // Cleanup
            File.Delete(path);
        }

        [Fact]
        public void SortByDate_OrdersNewestFirst()
        {
            // Arrange
            GameHistoryService history =
                new GameHistoryService(new GameStatFileStore());

            DateTime olderDate = new DateTime(2026, 1, 1);
            DateTime newerDate = new DateTime(2026, 5, 1);

            history.AddResult("Alex", 500, 20, olderDate);
            history.AddResult("Jordan", 700, 15, newerDate);

            // Act
            history.SortByDate();

            // Assert
            List<GameStat> results = history.GetResults();

            Assert.Equal("Jordan", results[0].PlayerName);
            Assert.Equal("Alex", results[1].PlayerName);
        }


    }
}
