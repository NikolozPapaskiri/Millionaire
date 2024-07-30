using System;
using System.Collections.Generic;
using MillionaireManagement; // Ensure the correct namespace is imported
using MillionaireShared;
using static MillionaireShared.Enums;

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

        public void LoadQuestions()
        {
            _questions = _questionManager.LoadQuestions();

            // Debug output to ensure questions are loaded
            Console.WriteLine("Questions loaded:");
            foreach (var question in _questions)
            {
                Console.WriteLine($"Question: {question.Text}");
                Console.WriteLine($"Answers: {string.Join(", ", question.Answers)}");
                Console.WriteLine($"Correct Answer: {question.CorrectAnswer}");
                Console.WriteLine($"Value: {question.Value}");
            }
        }

        public void Start()
        {
            var validInputs = Enum.GetNames(typeof(AnswerChoice))
                              .Select(name => name.ToLower())
                              .ToArray();
            if (_questions.Count == 0)
            {
                Console.WriteLine("No questions available. Exiting the game.");
                return;
            }

            while (_currentQuestionIndex < _questions.Count)
            {
                Console.Clear();
                DisplayQuestion(_questions[_currentQuestionIndex]);
                DisplayAvailableTips();

                Console.Write("Type your answer: ");
                string userInput = Console.ReadLine();

                while (userInput == null)
                {
                    Console.Write("Type your answer: ");
                    userInput = Console.ReadLine();
                }

                while (!IsValidInput(userInput))
                {
                    Console.WriteLine($"Invalid input. Please choose {validInputs}");
                    Console.Write("Type your answer: ");
                    userInput = Console.ReadLine();
                }

                if (IsAnswerCorrect(userInput) )
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

            Console.WriteLine($"Correct answers: {_correctAnswers} \nWrong answers: {_wrongAnswers} \nWon: {_amountWon}$");
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

        private void DisplayAvailableTips()
        {
            Console.WriteLine("__Other Optins__");
            Console.WriteLine("1. 50:50");
            Console.WriteLine("2. Phone a friend");
            Console.WriteLine("3. Ask the audience");
        }

        private bool IsValidInput(string answeruserInput)
        {
            return answeruserInput.ToUpper() == "A" || answeruserInput.ToUpper() == "B" || answeruserInput.ToUpper() == "C" || answeruserInput.ToUpper() == "D";
        }

        private AnswerChoice IsAnswerCorrect(string userAnswer)
        {
            AnswerChoice answerIndex;
            return answerIndex = _questions[_currentQuestionIndex].CorrectAnswer;
        }
    }
}
