using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace licenta
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // daca utilizatorul e logat
            if (User.Identity.IsAuthenticated)
            {
                // daca utilizatorul are rolul de administrator
                if (User.IsInRole("admin")) MasterPageFile = "~/Admin.master";
                else
                    if (User.IsInRole("angajat")) MasterPageFile = "~/Angajat.master";
                    else
                    // daca utilizatorul e client
                    {
                        MasterPageFile = "~/Client.master";

                    }
            }
            else MasterPageFile = "~/Site.master";
        }
       
    }
}
