using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Web.Security;

namespace licenta
{
    public partial class AfiseazaProdus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idProd = Request.QueryString["id_prod"];

                string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
                OracleConnection conn = new OracleConnection(oradb); // C#

                conn.Open();

                string query = "select p.denumire as nume, p.stoc_curent as stoc, p.pret_unitar as pret from produs p where p.id_produs = " + idProd + " ";

                OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "produs");

                conn.Dispose();
                conn.Close();

                LabelNumeProdus.Text = ds.Tables["produs"].Rows[0][0].ToString();
                LabelStoc.Text = ds.Tables["produs"].Rows[0][1].ToString();
                LabelPret.Text = ds.Tables["produs"].Rows[0][2].ToString();
                DataListInfoCaracteristiciProdus.DataSource = CaracteristiciProdus();
                DataListInfoCaracteristiciProdus.DataBind();
            }
        }

        protected void ButtonAddToCart_Click(object sender, EventArgs e)
        { 
             string idProd = Request.QueryString["id_prod"];
             
             string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\vali\\Downloads\\mine-licenta\\licenta\\licenta\\App_Data\\ASPNETDB.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True";
             string query_id = "select ClientId from aspnet_Users where UserId='"+Membership.GetUser().ProviderUserKey+"' ;";
                
             SqlConnection con = new SqlConnection(connString);
             SqlDataAdapter my_adapter = new SqlDataAdapter(query_id, con);
             DataSet dss = new DataSet();
             my_adapter.Fill(dss, "user");
             con.Close();

             string idClient = dss.Tables["user"].Rows[0][0].ToString();

             string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
                OracleConnection conn = new OracleConnection(oradb); // C#

                conn.Open();

                    
                string query_ins = "insert into client_comanda_produs(id_client, id_produs, status, id_comanda) values('"+ idClient+"', '"+idProd+"', 'cart', comanda_seq.nextval) ";
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = query_ins;
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
          
                
                conn.Dispose();
                conn.Close();

                Client master = (Client) Page.Master;
                if (master != null)
                {
                    master.UpdateCart(idClient);
                }
        }

        DataView CaracteristiciProdus()
        {

            string idProd = Request.QueryString["id_prod"];

            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string query = "select pc.valoare as valoare, c.denumire as nume from produs_caracteristica pc, caracteristica c where pc.id_produs = " + idProd +" and pc.id_caracteristica = c.id_caracteristica order by c.denumire";

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "table");

            conn.Dispose();
            conn.Close();

            return ds.Tables["table"].DefaultView;
        }
    }
}