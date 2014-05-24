using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace licenta
{
    public partial class RaportVanzariPeCategorii : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataListRaport2.DataSource = RaportCategorie();
                DataListRaport2.DataBind();
            }
        }
        DataView RaportCategorie()
        {
            string query;
            string select;
            string from;
            string where;

            select = "select sum(v.venit_incasat) || ' RON' as valoare, cc.denumire as categorie, dt.an as an";
            from = "from vanzari v, dim_timp dt, produs p, categorie cc";
            where = "where v.id_timp = dt.id_timp and v.id_produs = p.id_produs and p.id_categorie = cc.id_categorie";
            string group_by = "group by rollup( (dt.an, cc.denumire)) order by cc.denumire, dt.an";
            query = select + " " + from + " " + where + " " + group_by;


            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "rezultate");

            conn.Close();



            return ds.Tables["rezultate"].DefaultView;
        }
    }
}