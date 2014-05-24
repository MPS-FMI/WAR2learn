using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace licenta.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count > 0)
                if (Request.QueryString["mesaj"].Length > 0)
                {
                    LabelMesaj.Visible = true;
                    LabelMesaj.Text = "Trebuie sa va autentificati pentru a putea cauta produse!";
                
                }
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
    }
}
