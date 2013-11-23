using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace AISVotingApp
{
    public class VotingData
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public VotingData()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["VotingData"].ConnectionString;
        }

        public bool ValidateUser(string ufid, string pwd)
        {
            try
            {
                cmd = new SqlCommand();
                bool validate = false;
                cmd.Connection = con;
                cmd.CommandText = string.Format("SELECT * FROM Login_Details WHERE UFID='{0}' AND password='{1}'", ufid, pwd);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    validate = true;
                }
                dr.Close();
                con.Close();
                return validate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetPassword(string ufid)
        {
            try
            {
                cmd = new SqlCommand();
                string pass = "";
                cmd.Connection = con;
                cmd.CommandText = string.Format("SELECT Password FROM Login_Details WHERE UFID='{0}'", ufid);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    pass = dr[0].ToString();
                }

                dr.Close();
                con.Close();
                return pass;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AISMember GetMemberDetails(string ufid)
        {
            try
            {
                cmd = new SqlCommand();
                AISMember member = new AISMember();
                cmd.Connection = con;
                cmd.CommandText = string.Format("SELECT * FROM AIS_Members WHERE UFID='{0}'", ufid);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    member.UFID = ufid;
                    member.FirstName = dr[1].ToString();
                    member.LastName = dr[2].ToString();
                    member.EMail = dr[3].ToString();
                    member.Phone = dr[4].ToString();
                    member.MemberType = dr[5].ToString();
                    member.PaidMembershipFees = dr[6].ToString().ToLower();
                    member.Voted = dr[7].ToString().ToLower();
                }
                else
                {
                    member = null;
                }

                dr.Close();
                con.Close();
                return member;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VotersInformation GetVotersInformation(string ufid)
        {
            try
            {
                cmd = new SqlCommand();
                VotersInformation voter = new VotersInformation();
                cmd.Connection = con;
                cmd.CommandText = string.Format("SELECT * FROM Voters_Information WHERE UFID='{0}'", ufid);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    voter.UFID = ufid;
                    voter.VotedForPresident = dr[1].ToString().ToLower();
                    voter.VotedForLeadership = dr[2].ToString().ToLower();
                    voter.VotedForMedia = dr[3].ToString().ToLower();
                    voter.VotedForCorporate = dr[4].ToString().ToLower();
                    voter.VotedForTreasury = dr[5].ToString().ToLower();
                }
                else
                {
                    voter = null;
                }

                dr.Close();
                con.Close();
                return voter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetPositionActivationStatus(string position)
        {
            try
            {
                cmd = new SqlCommand();
                bool activated = false;
                cmd.Connection = con;
                cmd.CommandText = string.Format("SELECT Activated FROM Voting_Activation WHERE Position='{0}'", position);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr[5].ToString().ToLower() == "yes")
                        activated = true;
                }

                dr.Close();
                con.Close();
                return activated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetMemberType(string ufid)
        {
            string memberType = null;
            AISMember member = GetMemberDetails(ufid);
            if (member != null)
            {
                memberType = member.MemberType;
            }
            return memberType;
        }

        public bool CheckAlreadyVoted(string ufid, string position)
        {
            try
            {
                cmd = new SqlCommand();
                bool voted = false;
                cmd.Connection = con;
                cmd.CommandText = string.Format("SELECT * FROM Vote_Bank WHERE UFID='{0}' AND Position='{1}'", ufid, position);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    voted = true;
                }
                dr.Close();
                con.Close();
                return voted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}