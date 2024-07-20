using MillionaireManagement.Helpers;
using MillionaireManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Manages the loading, saving, and encryption of questions.
/// </summary>
public class QuestionManager
{
    private const string QuestionsFilePath = "questions.txt";

    /// <summary>
    /// Adds a new question to the list and saves it.
    /// </summary>
    /// <param name="question">The question to add.</param>
    public void AddQuestion(Question question)
    {
        List<Question> questions = LoadQuestions();
        questions.Add(question);
        SaveQuestions(questions);
    }

    /// <summary>
    /// Loads the list of questions from the encrypted file.
    /// </summary>
    /// <returns>A list of questions.</returns>
    public List<Question> LoadQuestions()
    {
        if (!File.Exists(QuestionsFilePath))
        {
            return new List<Question>();
        }

        string encryptedData = File.ReadAllText(QuestionsFilePath);
        string decryptedData = EncryptionHelper.Decrypt(encryptedData);
        return DeserializeQuestions(decryptedData);
    }

    /// <summary>
    /// Saves the list of questions to the encrypted file.
    /// </summary>
    /// <param name="questions">The list of questions to save.</param>
    private void SaveQuestions(List<Question> questions)
    {
        string serializedData = SerializeQuestions(questions);
        string encryptedData = EncryptionHelper.Encrypt(serializedData);
        File.WriteAllText(QuestionsFilePath, encryptedData);
    }

    /// <summary>
    /// Serializes the list of questions into a string format.
    /// </summary>
    /// <param name="questions">The list of questions to serialize.</param>
    /// <returns>A serialized string representing the list of questions.</returns>
    private string SerializeQuestions(List<Question> questions)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var question in questions)
        {
            sb.AppendLine($"{question.Text}|{string.Join(";", question.Answers)}|{question.CorrectAnswerIndex}|{question.Value}");
        }
        return sb.ToString();
    }

    /// <summary>
    /// Deserializes a string into a list of questions.
    /// </summary>
    /// <param name="data">The string data to deserialize.</param>
    /// <returns>A list of questions.</returns>
    private List<Question> DeserializeQuestions(string data)
    {
        List<Question> questions = new List<Question>();
        string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split('|');
            List<string> answers = new List<string>(parts[1].Split(';'));
            questions.Add(new Question(parts[0], answers, int.Parse(parts[2]), parts[3]));
        }
        return questions;
    }
}
