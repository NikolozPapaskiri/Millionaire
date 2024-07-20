using System;
using System.IO;

namespace MillionaireGame
{
    /// <summary>
    /// Manages the saving of game history to a file.
    /// </summary>
    public class GameHistory
    {
        private const string GameHistoryFilePath = "game-history.txt";

        /// <summary>
        /// Saves the game history to the file.
        /// </summary>
        /// <param name="startDate">The start date of the game.</param>
        /// <param name="totalQuestions">The total number of questions.</param>
        /// <param name="correctAnswers">The total number of correct answers.</param>
        /// <param name="wrongAnswers">The total number of wrong answers.</param>
        /// <param name="amountWon">The amount of money won by the player.</param>
        public void SaveGameHistory(DateTime startDate, int totalQuestions, int correctAnswers, int wrongAnswers, int amountWon)
        {
            string gameHistory = $"{startDate}, {totalQuestions}, {correctAnswers}, {wrongAnswers}, {amountWon}";
            File.AppendAllText(GameHistoryFilePath, gameHistory + Environment.NewLine);
        }
    }
}
