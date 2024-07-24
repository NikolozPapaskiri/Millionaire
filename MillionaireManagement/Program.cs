using System;
using System.Collections.Generic;
using System.IO;
using MillionaireGame;

namespace MillionaireManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuestionManager questionManager = new QuestionManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Question Management System");
                Console.WriteLine("1. Add a new question");
                Console.WriteLine("2. Delete existing questions");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if(choice == "3")
                {
                    break;
                }

                if (choice == "2")
                {
                    questionManager.ClearQuestions();
                    Console.WriteLine("Questions deleted");
                    Thread.Sleep(1000);
                    continue;
                }

                if(choice == "1")
                {
                    Console.Write("Enter the queston: ");
                    string questionText = Console.ReadLine();
                    while (string.IsNullOrEmpty(questionText))
                    {
                        Console.Write("Input can't be empty: ");
                        questionText = Console.ReadLine();
                    }

                    List<string> answers = new List<string>();
                    for(int i = 0; i < 4; i++)
                    {
                        Console.Write($"Enter answer {(char)('A' + i)}: ");
                        string input = Console.ReadLine();
                        while (string.IsNullOrEmpty(input))
                        {
                            Console.Write("Input can't be empty: ");
                            input = Console.ReadLine();
                        }
                        answers.Add(input);
                    }

                    int correctAnswerIndex;

                    while (true)
                    {
                        Console.Write("Enter the index of the correct answer (0-3): ");
                        if (int.TryParse(Console.ReadLine(), out correctAnswerIndex) && correctAnswerIndex >= 0 && correctAnswerIndex < 4)
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 3.");
                    }

                    Console.Write("Enter the monetary value of the question (e.g., $7,000): ");
                    string value = Console.ReadLine();

                    Question question = new Question(questionText, answers, correctAnswerIndex, value);
                    questionManager.AddQuestion(question);

                    Console.WriteLine("Question added successfully!");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }
    }
}