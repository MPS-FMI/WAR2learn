using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Data.SqlClient;

namespace licenta.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            DataBind();
        }

       
        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
           
            /*string nume = ((TextBox)RegisterUser.FindControl("UserName")).Text;
            string prenume = ((TextBox)RegisterUser.FindControl("Prenume")).Text;
            string email = ((TextBox)RegisterUser.FindControl("Email")).Text;
            string strada = ((TextBox)RegisterUser.FindControl("Strada")).Text;
            string oras= ((DropDownList)RegisterUser.FindControl("OrasDropDown")).SelectedValue;

            System.Diagnostics.Debug.WriteLine("nume=" + nume + ", oras=" + oras);

            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#
            
            //inserez adresa
            string query_adr = "insert into adresa(id_adresa, id_oras, nume_strada) values(adresa_seq.nextval, '"+oras+"', '"+strada+"' )";
            conn.Open();
            OracleCommand com1 = new OracleCommand(query_adr, conn);
            com1.CommandType = CommandType.Text;
            com1.ExecuteNonQuery();
            
            //iau id adresa inserata adineauri

            OracleDataAdapter adapter_last_id = new OracleDataAdapter("select adresa_seq.currval from dual", conn);
            DataSet ds_last = new DataSet();
            adapter_last_id.Fill(ds_last, "last_id");
            conn.Close();
            string lastId = ds_last.Tables["last_id"].Rows[0][0].ToString();
            
            //inserez in client
            conn.Open();
            string query_client = "insert into client(id_client, id_adresa, email, nume, prenume,) values(client_seq.nextval, '"+lastId+"', '"+email+"', '"+nume+"', '"+prenume+"')";
            OracleCommand cmd2 = new OracleCommand(query_client, conn);
            cmd2.CommandType = CommandType.Text;
            cmd2.ExecuteNonQuery();

            //iau id client inserat adineauri

            OracleDataAdapter adapter_last_id_client = new OracleDataAdapter("select client_seq.currval from dual", conn);
            DataSet ds_last_client = new DataSet();
            adapter_last_id_client.Fill(ds_last_client, "last_id");
            conn.Close();
            
            //updatez id-ul din baza lor pt userul curent
            string id_last_client = ds_last_client.Tables["last_id"].Rows[0][0].ToString();
            string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\vali\\Downloads\\mine-licenta\\licenta\\licenta\\App_Data\\ASPNETDB.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string query_id = "update aspnet_Users set ClientId = '"+id_last_client+"' where UserId='" + Membership.GetUser().ProviderUserKey + "' ;";

            SqlConnection con = new SqlConnection(connString);
            con.Open();

            SqlCommand com = new SqlCommand(query_id, con);
            com.CommandType = CommandType.Text;
            var trans = conn.BeginTransaction();
            com.ExecuteNonQuery();
            trans.Commit();
            con.Close();
           */
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        protected DataView AfiseazaOrase()
        {
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string query = "select oras.id_oras as id, oras.nume as nume, oras.id_judet as judet from oras;";
           
            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "table");

            conn.Dispose();
            conn.Close();
            
            return ds.Tables["table"].DefaultView;
        } 

    }
}
