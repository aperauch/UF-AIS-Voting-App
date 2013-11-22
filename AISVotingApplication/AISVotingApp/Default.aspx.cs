using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AISVotingApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                string ufid = username.Text;
                string pwd = password.Text;
                VotingData votingData = new VotingData();

                if (votingData.ValidateUser(ufid, pwd))
                {
                    string memberType = votingData.GetMemberType(ufid);
                    if (memberType == "president" || memberType == "admin")
                    {
                        Response.Redirect("AdminHome.aspx");
                    }
                    else
                        Response.Redirect("VotingHome.aspx");
                }
                else
                    Error.Text = "Invalid UFID or Password";
            }
            catch (Exception ex)
            {
                Error.Text = "Invalid UFID or Password";
            }
        }

    }
}