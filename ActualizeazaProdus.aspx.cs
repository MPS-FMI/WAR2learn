using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace licenta
{
    public partial class ActualizeazaProdus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                DataListProdus.DataSource = InfoProdus();
                DataListProdus.DataBind();
            }
        }

        DataView InfoProdus()
        {
            string id_produs = Request.QueryString["id_prod"];
            string query;
            query = "select denumire as nume_produs, stoc_curent as stoc, stoc_impus as stoc_impus, pret_unitar as pret from produs where id_produs = '" + id_produs + "'";
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";

            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "produs");

            string nume = ds.Tables["produs"].Rows[0][0].ToString();

            conn.Close();

            LabelInfo.Text = "Informatii despre: " + nume;
            return ds.Tables["produs"].DefaultView;
        }

        string stoc, stoc_impus, pret;
        protected void TextBoxStoc_Changed(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            stoc = tb.Text.ToString();
        }

        protected void TextBoxImpus_Changed(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            stoc_impus = tb.Text.ToString();
        }

        protected void TextBoxPret_Changed(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            pret = tb.Text.ToString();
        }

        protected void ButtonUpdateProdus_Click(object sender, EventArgs e)
        {
            string id_produs = Request.QueryString["id_prod"];
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();
            string query_update = "update produs set stoc_curent = '" + stoc + "', stoc_impus = '" + stoc_impus + "', pret_unitar = '" + pret + "' where id_produs = '" + id_produs + "'";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = query_update;
            cmd.CommandType = CommandType.Text;
            var trans = conn.BeginTransaction();
            cmd.ExecuteNonQuery();
            trans.Commit();
            conn.Close();

            LabelProdus.Visible = true;
            DataListProdus.DataSource = InfoProdus();
            DataListProdus.DataBind();
            DataListProdus.Visible = true;
        }
    }
}