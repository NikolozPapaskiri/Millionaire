using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireManagement
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public AnswerChoice CorrectAnswer { get; set; }
        public string Value { get; set; }

        public Question(string text, List<string> answers, int correctAnswerIndex, string value)
        {
            Text = text;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
            Value = value;
        }
    }

}
