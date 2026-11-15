using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper.Models
{
    public class GameStat
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; }
        public double ElapsedSeconds { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}
