using MillionaireManagement;
using System;
using System.Collections.Generic;
using MillionaireShared;

namespace MillionaireGame
{
    public class Program
    {
        public static void Main()
        {
            QuestionManager questionManager = new QuestionManager();
            GameHistory gameHistory = new GameHistory();
            Game game = new Game(questionManager, gameHistory);

            // Start the game
            game.Start();
        }
    }
}