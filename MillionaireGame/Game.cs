using System;
using System.Collections.Generic;
using MillionaireManagement; // Ensure the correct namespace is imported

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
            LoadQuestions(); // Call method to load questions
        }

        private void LoadQuestions()
        {
            _questions = _questionManager.LoadQuestions();

            // Debug output to ensure questions are loaded
            Console.WriteLine("Questions loaded:");
            foreach (var question in _questions)
            {
                Console.WriteLine($"Question: {question.Text}");
                Console.WriteLine($"Answers: {string.Join(", ", question.Answers)}");
                Console.WriteLine($"Correct Answer Index: {question.CorrectAnswerIndex}");
                Console.WriteLine($"Value: {question.Value}");
            }
        }

        public void Start()
        {
            if (_questions.Count == 0)
            {
                Console.WriteLine("No questions available. Exiting the game.");
                return;
            }

            while (_currentQuestionIndex < _questions.Count)
            {
                //Console.Clear();
                DisplayQuestion(_questions[_currentQuestionIndex]);

                Console.Write("Type your answer: ");
                string userAnswer = Console.ReadLine();

                while (userAnswer == null)
                {
                    Console.Write("Type your answer: ");
                    userAnswer = Console.ReadLine();
                }

                while (!IsValidInput(userAnswer))
                {
                    Console.WriteLine("Invalid input. Please choose a, b, c, or d");
                    Console.Write("Type your answer: ");
                    userAnswer = Console.ReadLine();
                }

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

            Console.WriteLine($"Correct answers: {_correctAnswers} \nWrong answers: {_wrongAnswers}");
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

        private bool IsValidInput(string answeruserInput)
        {
            return answeruserInput.ToUpper() == "A" || answeruserInput.ToUpper() == "B" || answeruserInput.ToUpper() == "C" || answeruserInput.ToUpper() == "C";
        }

        private bool IsAnswerCorrect(string userAnswer)
        {
            int answerIndex = userAnswer.ToUpper()[0] - 'A';
            return answerIndex == _questions[_currentQuestionIndex].CorrectAnswerIndex;
        }
    }
}
