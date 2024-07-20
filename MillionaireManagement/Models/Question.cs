using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireManagement.Models
{
    public class Question
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public int Cost { get; set; }
    }

}
