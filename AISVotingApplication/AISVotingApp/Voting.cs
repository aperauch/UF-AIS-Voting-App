using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AISVotingApp
{
    public class AISMember
    {
        public string UFID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string MemberType { get; set; }
        public string PaidMembershipFees { get; set; }
        public string Voted { get; set; }
    }

    public class VotingCandidate
    {
        public string UFID { get; set; }
        public string Position { get; set; }
        public string ProfilePicName { get; set; }
        public int NoOfVotes { get; set; }
    }

    public class VotersInformation
    {
        public string UFID { get; set; }
        public string VotedForPresident { get; set; }
        public string VotedForLeadership { get; set; }
        public string VotedForMedia { get; set; }
        public string VotedForCorporate { get; set; }
        public string VotedForTreasury { get; set; }
    }

    public class Vote
    {
        public string VoterUFID { get; set; }
        public string CandidateUFID { get; set; }
        public string Position { get; set; }
    }
}