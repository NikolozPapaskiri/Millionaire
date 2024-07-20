using System;
using System.Collections.Generic;
using MillionaireManagement;

namespace MillionaireGame
{
    public class Game
    {
        private readonly QuestionManager _questionManager;
        private readonly GameHistory _gameHistory;
        private List<Question> _questions;
        private int _currentQuestionIndex;
        private int _correctAnswers;
        private int _wrongAnswers;
        private int _amountWon;

        public Game(QuestionManager questionManager, GameHistory gameHistory)
        {
            _questionManager = questionManager;
            _gameHistory = gameHistory;
            _questions = _questionManager.LoadQuestions(); // Use QuestionManager from MillionaireManagement
            _currentQuestionIndex = 0;
            _correctAnswers = 0;
            _wrongAnswers = 0;
            _amountWon = 0;
        }

        public void Start()
        {
            while (_currentQuestionIndex < _questions.Count)
            {
                Console.Clear();
                DisplayQuestion(_questions[_currentQuestionIndex]);

                string userAnswer = Console.ReadLine();
                if (IsAnswerCorrect(userAnswer))
                {
                    _correctAnswers++;
                    _amountWon = int.Parse(_questions[_currentQuestionIndex].Value.Replace("$", "").Replace(",", ""));
                }
                else
                {
                    _wrongAnswers++;
                }

                _currentQuestionIndex++;
            }

            _gameHistory.SaveGameHistory(DateTime.Now, _questions.Count, _correctAnswers, _wrongAnswers, _amountWon);
        }

        private void DisplayQuestion(Question question)
        {
            Console.WriteLine($"Question for {question.Value}:");
            Console.WriteLine(question.Text);
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)}. {question.Answers[i]}");
            }
        }

        private bool IsAnswerCorrect(string userAnswer)
        {
            int answerIndex = userAnswer.ToUpper()[0] - 'A';
            return answerIndex == _questions[_currentQuestionIndex].CorrectAnswerIndex;
        }
    }
}
