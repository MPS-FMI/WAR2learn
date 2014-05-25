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
    public partial class Adauga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CategoriiDropDown.DataBind();
            }
        }

        protected void ButtonAdaugaProdus_Click(object sender, EventArgs e) {
            string insert_query = "insert into produs(id_produs, id_categorie, denumire, stoc_curent, stoc_impus, pret_unitar) values(produs_seq.nextval, '"+CategoriiDropDown.SelectedValue+"', '"+TextBoxNumeProdus.Text+"', '"+TextBoxStocCurent.Text+"', '"+TextBoxStocImpus.Text+"', '"+TextBoxPretUnitar.Text+"')";
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = insert_query;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            conn.Close();
            LabelProdus.Visible = true;
        }

        protected DataView AfiseazaCategorii()
        {
            string oradb = "<CNlz c.  fnsdlvnc v sdgknfvnfv
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string query = "select categorie.id_categorie as id, categorie.denumire as nume from categorie where categorie.id_parinte is not null";

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "table");

            conn.Dispose();
            conn.Close();

            return ds.Tables["table"].DefaultView;
        } 
    }
}