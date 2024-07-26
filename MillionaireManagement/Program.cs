using System;
using System.Collections.Generic;
using System.IO;
using MillionaireShared;
using static MillionaireShared.Enums;

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

                    AnswerChoice correctAnswer;
                    var validInputs = Enum.GetNames(typeof(AnswerChoice))
                              .Select(name => name.ToLower())
                              .ToArray();


                    while (true)
                    {
                        Console.Write($"Enter the letter of the correct answer ({string.Join(',', validInputs)}): ");
                        string input = Console.ReadLine().ToLower();

                        try
                        {
                            correctAnswer = input switch
                            {
                                "a" => AnswerChoice.A,
                                "b" => AnswerChoice.B,
                                "c" => AnswerChoice.C,
                                "d" => AnswerChoice.D,
                                _ => throw new ArgumentException($"Invalid input. Please enter one of the following: {string.Join(',', validInputs)}.")
                            };
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }

                        break;
                    }
                    
                    Console.Write("Enter the monetary value of the question (e.g., $7,000): ");
                    string value = Console.ReadLine();

                    Question question = new Question(questionText, answers, correctAnswer, value);
                    questionManager.AddQuestion(question);

                    Console.WriteLine("Question added successfully!");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }
    }
}