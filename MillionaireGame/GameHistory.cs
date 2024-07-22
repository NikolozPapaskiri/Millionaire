using MillionaireShared; // Ensure the correct namespace is included
using System;
using System.IO;

namespace MillionaireGame
{
    public class GameHistory
    {
        private readonly string _gameHistoryFilePath;

        public GameHistory()
        {
            _gameHistoryFilePath = ConfigurationHelper.GetFilePath("GameHistoryFilePath");
        }

        public void SaveGameHistory(DateTime startDate, int totalQuestions, int correctAnswers, int wrongAnswers, int amountWon)
        {
            using (StreamWriter writer = new StreamWriter(_gameHistoryFilePath, true))
            {
                writer.WriteLine($"Start Date: {startDate}");
                writer.WriteLine($"Total Questions: {totalQuestions}");
                writer.WriteLine($"Correct Answers: {correctAnswers}");
                writer.WriteLine($"Wrong Answers: {wrongAnswers}");
                writer.WriteLine($"Amount Won: {amountWon}");
                writer.WriteLine();
            }
        }
    }
}
