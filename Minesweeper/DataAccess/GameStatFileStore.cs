
using Minesweeper.Models;
using System.Text.Json;

namespace Minesweeper.DataAccess
{
    public class GameStatFileStore
    {
        public List<GameStat> Load(string path)
        {
            string json = File.ReadAllText(path);

            List<GameStat>? results =
                JsonSerializer.Deserialize<List<GameStat>>(json);

            Validate(results);

            return results!;
        }

        public void Save(string path, List<GameStat> results)
        {
            Validate(results);

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            string json =
                JsonSerializer.Serialize(results, options);

            File.WriteAllText(path, json);
        }

        private static void Validate(List<GameStat>? results)
        {
            if (results == null)
                throw new InvalidDataException(
                    "The history file does not contain a valid result collection.");

            HashSet<int> usedIds = new();

            foreach (GameStat? result in results)
            {
                if (result == null)
                    throw new InvalidDataException(
                        "A result cannot be null.");

                if (result.Id <= 0 || !usedIds.Add(result.Id))
                    throw new InvalidDataException(
                        "IDs must be positive and unique.");

                if (string.IsNullOrWhiteSpace(result.PlayerName) ||
                    result.PlayerName.Trim().Length > 50)
                    throw new InvalidDataException(
                        "Player name must contain 1-50 characters.");

                if (result.Score < 0)
                    throw new InvalidDataException(
                        "Score cannot be negative.");

                if (!double.IsFinite(result.ElapsedSeconds) ||
                    result.ElapsedSeconds < 0)
                    throw new InvalidDataException(
                        "Elapsed seconds must be finite and nonnegative.");

                if (result.PlayedAt == default)
                    throw new InvalidDataException(
                        "Played date cannot be empty.");
            }
        }
    }
}

