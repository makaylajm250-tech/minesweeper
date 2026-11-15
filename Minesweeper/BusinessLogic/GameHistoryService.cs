
using Minesweeper.Models;
using Minesweeper.DataAccess;

namespace Minesweeper.BusinessLogic;

public class GameHistoryService
{
    private List<GameStat> results = new List<GameStat>();
    private readonly GameStatFileStore fileStore;
    public bool HasUnsavedChanges { get; private set; }

    public GameHistoryService(GameStatFileStore fileStore)
    {
        this.fileStore = fileStore;
    }

    public List<GameStat> GetResults()
    {
        return new List<GameStat>(results);
    }

    public void AddResult(
        string playerName,
        int score,
        double elapsedSeconds,
        DateTime playedAt)
    {
        playerName = playerName?.Trim() ?? "";

        if (playerName.Length < 1 || playerName.Length > 50)
            throw new ArgumentException(
                "Player name must contain 1-50 characters.");

        if (score < 0)
            throw new ArgumentException("Score cannot be negative.");

        if (!double.IsFinite(elapsedSeconds) ||
            elapsedSeconds < 0)
            throw new ArgumentException("Invalid elapsed time.");

        if (playedAt == default)
            throw new ArgumentException("Invalid played date.");

        int nextId = results.Count == 0
            ? 1
            : checked(results.Max(r => r.Id) + 1);

        GameStat result = new GameStat
        {
            Id = nextId,
            PlayerName = playerName,
            Score = score,
            ElapsedSeconds = elapsedSeconds,
            PlayedAt = playedAt
        };

        results.Add(result);
        HasUnsavedChanges = true;
    }

    public void SortByName()
    {
        results = results
            .OrderBy(r => r.PlayerName,
                StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    public void SortByScore()
    {
        results = results
            .OrderByDescending(r => r.Score)
            .ToList();
    }

    public void SortByDate()
    {
        results = results
            .OrderByDescending(r => r.PlayedAt)
            .ToList();
    }

    public void SaveHistory(string path)
    {
        fileStore.Save(path, results);
        HasUnsavedChanges = false;
    }

    public void LoadHistory(string path)
    {
        // Load and validate before replacing existing history.
        List<GameStat> loaded = fileStore.Load(path);

        results = loaded;

        HasUnsavedChanges = false;
    }

}





