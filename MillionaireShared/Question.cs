using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MillionaireShared.Enums;

namespace MillionaireShared
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public AnswerChoice CorrectAnswer { get; set; }
        public string Value { get; set; }

        public Question(string text, List<string> answers, AnswerChoice correctAnswer, string value)
        {
            Text = text;
            Answers = answers;
            CorrectAnswer = correctAnswer;
            Value = value;
        }
    }

}
