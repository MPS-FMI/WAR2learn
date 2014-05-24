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
    public partial class MyCart : System.Web.UI.Page
    {
        protected string idClient;
        protected void Page_Load(object sender, EventArgs e)
        {//trebuie sa aflu id-ul clientului ca sa stiu al cui cos e 
            if (!Page.IsPostBack)
            {
                string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\vali\\Downloads\\mine-licenta\\licenta\\licenta\\App_Data\\ASPNETDB.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True";
                string query_id = "select ClientId from aspnet_Users where UserId='" + Membership.GetUser().ProviderUserKey + "' ;";

                SqlConnection con = new SqlConnection(connString);
                SqlDataAdapter my_adapter = new SqlDataAdapter(query_id, con);
                DataSet dss = new DataSet();
                my_adapter.Fill(dss, "user");
                con.Close();

                idClient = dss.Tables["user"].Rows[0][0].ToString();

                RepeaterCart.DataSource = ShowCart();
                RepeaterCart.DataBind();

                Client master = (Client)Page.Master;
                if (master != null)
                {
                    master.UpdateCart(idClient);
                }
            }
        }

        DataView ShowCart()
        {

            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string query = "select p.id_produs as id, p.denumire as nume_prod, p.pret_unitar as pret,sum(p.pret_unitar) as total from client_comanda_produs ccp, produs p where ccp.id_client ='" + idClient + "' and ccp.id_produs = p.id_produs and ccp.status like 'cart' group by p.id_produs, p.denumire, p.pret_unitar";
            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "cart");
            conn.Close();

            if (ds.Tables["cart"].Rows.Count > 0)
            {
                RepeaterCart.Visible = true;
                LabelProduseInCos.Visible = true;
                LabelCosGol.Visible = false;
                LabelComandaTrimisa.Visible = false;
            }
            else
            {
                LabelCosGol.Visible = true;
                LabelProduseInCos.Visible = false;
                LabelComandaTrimisa.Visible = false;
                RepeaterCart.Visible = false;
            }

            
            return ds.Tables["cart"].DefaultView;
        }

        protected void ButtonSendOrder_Click(object sender, EventArgs e) {

            string client;
            string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\vali\\Downloads\\mine-licenta\\licenta\\licenta\\App_Data\\ASPNETDB.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string query_id = "select ClientId from aspnet_Users where UserId='" + Membership.GetUser().ProviderUserKey + "' ;";

            SqlConnection con = new SqlConnection(connString);
            SqlDataAdapter my_adapter = new SqlDataAdapter(query_id, con);
            DataSet dss = new DataSet();
            my_adapter.Fill(dss, "user");
            con.Close();

            client = dss.Tables["user"].Rows[0][0].ToString();


            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string query_update = "update client_comanda_produs set status = 'trimis' where id_client = '" + client + "' and status='cart'";

            OracleCommand cmd2 = new OracleCommand(query_update,conn);
            cmd2.CommandType = CommandType.Text;
            
            var trans = conn.BeginTransaction();
            cmd2.ExecuteNonQuery();
            trans.Commit();
            /*
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    cmd2.Transaction = transaction;
                    cmd2.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    
                }
            }
            */
            conn.Close();

            LabelProduseInCos.Visible = false;
            LabelComandaTrimisa.Visible = true;
            RepeaterCart.Visible = false;
        }
    }
}