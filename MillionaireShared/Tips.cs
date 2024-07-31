using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MillionaireShared.Enums;

namespace MillionaireShared
{
    internal class Tips
    {
        public static char[] Arr = new char[101];
        public static int askTheAudience = 0;
        public static int phoneAFriend = 0;
        public static int fiftyFifty = 0;
        public static List<char> askAudienceList = new List<char>(Arr);

        public void UseTip(GameTip tip, Question question)
        {
            switch (tip)
            {
                case GameTip.FiftyFifty:
                    ApplyFiftyFiftyTip(question);
                    break;
                case GameTip.PhoneAFriend:
                    ApplyPhoneAFriendTip(question);
                    break;
                case GameTip.AskTheAudience:
                    ApplyAskTheAudienceTip(question);
                    break;
                default:
                    throw new ArgumentException("Invalid tip.");
            }
        }

        public static void ApplyFiftyFiftyTip(char answer, List<string> answers, int questionumber)
        {
            Random rnd = new Random();
            int suggestion1 = rnd.Next(0, 3);
            char[] suggestion = { 'A', 'B', 'C', 'D' };
            suggestion = suggestion.Where(val => val != answer).ToArray();
            char first = answer, Second = suggestion[suggestion1];
            int random = rnd.Next(3, 50);
            for (int i = 1; i <= random; i++) { (first, Second) = (Second, first); }
            Console.WriteLine($"{first}: {Decrypt(answers[(questionumber - 1) * 5 + first - 'A' + 1], Program.key)}" + "\n" + $"{Second}: {Decrypt(answers[(questionumber - 1) * 5 + Second - 'A' + 1], Program.key)}" + "\n");
            fiftyFifty = 1;
        }

        private void ApplyPhoneAFriendTip(Question question)
        {

        }

        private void ApplyAskTheAudienceTip(Question question)
        {

        }
    }
}