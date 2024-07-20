using System;
using System.Collections.Generic;
using System.IO;

namespace MillionaireManagement
{
    public class Program
    {
        static void main(string[] args)
        {
            QuestionManager questionManager = new QuestionManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Question Management System");
                Console.WriteLine("1. Add a new question");
                Console.WriteLine("2. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if(choice == "2")
                {
                    break;
                }

                if(choice == "1")
                {
                    Console.Write("Enter the queston: ");
                    string questionText = Console.ReadLine();

                    List<string> answers = new List<string>();
                    for(int i = 0; i < 4; i++)
                    {
                        Console.Write($"Enter answer {(char)('A' + i)}: ");
                        answers.Add(Console.ReadLine());
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
                }
            }
        }
    }
}