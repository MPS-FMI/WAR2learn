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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriiDropDown.DataSource = AfiseazaCategorii();
            CategoriiDropDown.DataBind();
        }

        protected void ButtonSearchProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account/Login.aspx?mesaj=da");
            //Response.Redirect("/CautareProduse.aspx?cuv=" + TextBoxSearchCuv.Text + "&categ=" + CategoriiDropDown.SelectedValue.ToString() + "&pmin=" + DropDownListPret1.SelectedValue.ToString() + "&pmax=" + DropDownListPret2.SelectedValue.ToString());
        }

        protected DataView AfiseazaCategorii()
        {
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
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
