using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace licenta
{
    public partial class Angajat : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cred ca ar trebui sa faca mereu data bind...la fiecare refresh...in fine
            if (!Page.IsPostBack)
            {
                RepeaterMeniuCategorii.DataBind();
            }
        }

        protected DataView AfiseazaCategorii()
        {
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string query = "select categorie.id_categorie as id, categorie.denumire as nume from categorie where categorie.id_parinte is not null";

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "categorii");

            conn.Dispose();
            conn.Close();

            return ds.Tables["categorii"].DefaultView;
        } 
    }
}