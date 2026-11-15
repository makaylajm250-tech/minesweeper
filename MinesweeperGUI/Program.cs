using Minesweeper.BusinessLogic;
using Minesweeper.DataAccess;

namespace MinesweeperGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            GameStatFileStore fileStore = new GameStatFileStore();
            GameHistoryService history = new GameHistoryService(fileStore);

            Application.Run(new Form1(history));
        }
    }
}