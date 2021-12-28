using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Settings
{
    public static class Options
    {
        public static SetCarriages SetCarriages { get;set;}
        public static SerializableGuid ChallengeGuid { get; private set; }

        public static Challenge Challenge
        {
            get { return GetChallange(); }
            set { ChallengeGuid = value.Id; }
        }

        private static Challenge GetChallange()
        {
            if (ChallengeGuid.Value == null) return null;
            
            var data = UnityEngine.Object.FindObjectOfType<SaveSystem>().PlayerData;//.Campany.Locations;
            var locs = data.Campany.Locations;
            var  challenges = locs.Select(location => location.Challenges).Aggregate((a, b) => a.Concat(b).ToList());
            var found = challenges.First(challenge => challenge.Id == (Guid) ChallengeGuid);
            return found;
        }

        public static void SelectChallenge(Challenge challenge)
        {
            ChallengeGuid = challenge.Id;
        }
        public static TicketData Ticket { get; set; }
    }
}
