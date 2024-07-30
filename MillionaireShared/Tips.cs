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

        private int ApplyFiftyFiftyTip(Question question)
        {
            Random rand = new Random();
            int randInt = rand.Next(0, 4);

            while (randInt == question.CorrectAnswer switch
                                            {
                                                AnswerChoice.A => 0,
                                                AnswerChoice.B => 1,
                                                AnswerChoice.C => 2,
                                                AnswerChoice.D => 3
                                            })
            {
                randInt = rand.Next(0, 4);
            }

            return randInt;
            
        }

        private void ApplyPhoneAFriendTip(Question question)
        {

        }

        private void ApplyAskTheAudienceTip(Question question)
        {

        }
    }
}
