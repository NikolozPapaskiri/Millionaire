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

        private void ApplyFiftyFiftyTip(Question question)
        {

        }

        private void ApplyPhoneAFriendTip(Question question)
        {

        }

        private void ApplyAskTheAudienceTip(Question question)
        {

        }
    }
}
