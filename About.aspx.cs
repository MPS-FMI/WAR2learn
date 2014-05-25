using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace licenta
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (Request.QueryString["lista"] != "")
                {

                    DataList1.Visible = true;
                    DataList1.DataBind();
                }
                else
                {
                    DataList1.Visible = false;
                }
            }
            


        }
        protected DataView AfiseazaSucursale()
        {
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string select = "select sucursala.nume as nume, oras.nume as oras, judet.nume as judet, adresa.nume_strada as strada";
            string from = "from sucursala, adresa, oras, judet";
            string where = "where sucursala.id_adresa = adresa.id_adresa and adresa.id_oras = oras.id_oras and oras.id_judet = judet.id_judet";

            string query = select + " " + from + " " + where;
            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "table");

            conn.Dispose();
            conn.Close();
            return ds.Tables["table"].DefaultView;
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
