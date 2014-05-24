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
    public partial class RaportVanzariPeAn : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RepeaterRaport3.DataSource = RaportAn();
                RepeaterRaport3.DataBind();
            }
        }
        DataView RaportAn()
        {
            string query;
            string select;
            string from;
            string where;

            select = "select sum(v.venit_incasat) || ' RON' as valoare, dt.an as an";
            from = "from vanzari v, dim_timp dt";
            where = "where v.id_timp = dt.id_timp";
            string group_by = "group by rollup(dt.an) order by dt.an";
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