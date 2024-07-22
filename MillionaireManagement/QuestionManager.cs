using MillionaireGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MillionaireShared;

namespace MillionaireManagement
{
    public class QuestionManager
    {
        private readonly string _questionsFilePath;

        public QuestionManager()
        {
            // Initialize the file path using the configuration helper
            _questionsFilePath = ConfigurationHelper.GetFilePath("QuestionsFilePath");
        }

        public void AddQuestion(Question question)
        {
            List<Question> questions = LoadQuestions();
            questions.Add(question);
            SaveQuestions(questions);
        }

        public List<Question> LoadQuestions()
        {
            if (!File.Exists(_questionsFilePath))
            {
                return new List<Question>();
            }

            string encryptedData = File.ReadAllText(_questionsFilePath);
            string decryptedData = EncryptionHelper.Decrypt(encryptedData);
            return DeserializeQuestions(decryptedData);
        }

        private void SaveQuestions(List<Question> questions)
        {
            string serializedData = SerializeQuestions(questions);
            string encryptedData = EncryptionHelper.Encrypt(serializedData);
            File.WriteAllText(_questionsFilePath, encryptedData);
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
}
