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
    public partial class VeziComanda : System.Web.UI.Page
    {
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {

                    DataViewInfoClient.DataSource = InformatiiClient();
                    DataViewInfoClient.DataBind();

                    RepeaterInfoComanda.DataSource = InformatiiComanda();
                    RepeaterInfoComanda.DataBind();

                }
            }
        }

        DataView InformatiiClient() {

            string select;
            string from;
            string where;
            string group_by;
            string id_client;
            string my_query;

            id_client = Request.QueryString["id_client"];
            select = "select count(p.id_produs) as numar_produse, sum(p.pret_unitar) as valoare_comanda, cl.id_client as id_client, cl.nume ||' '|| cl.prenume as nume_client, a.nume_strada as nume_strada, o.nume as nume_oras";
            from = "from produs p, client cl, client_comanda_produs ccp, adresa a, oras o";
            where = "where cl.id_client= '" + id_client + "' and p.id_produs = ccp.id_produs and ccp.status like 'trimis' and ccp.id_client = cl.id_client and cl.id_adresa = a.id_adresa and a.id_oras = o.id_oras";
            group_by = "group by cl.id_client, cl.nume, cl.prenume, a.nume_strada, o.nume";

            my_query = select + " " + from + " " + where + " " + group_by;

            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleDataAdapter adapter = new OracleDataAdapter(my_query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "infoc");

            conn.Close();

            return ds.Tables["infoc"].DefaultView;
        }

        DataView InformatiiComanda()
        {
            string id_client = Request.QueryString["id_client"];
            string select;
            string from;
            string where;

            select = "select c.id_categorie as id_categ, c.denumire as nume_categorie, p.id_produs as id_produs, p.denumire as nume_produs, p.stoc_curent as stoc, p.pret_unitar as pret, cl.id_client as id_client, cl.nume ||' '|| cl.prenume as nume_client, a.nume_strada as nume_strada, o.nume as nume_oras";
            from = "from categorie c, produs p, client cl, client_comanda_produs ccp, adresa a, oras o";
            where = "where cl.id_client= '" + id_client + "' and c.id_categorie = p.id_categorie and p.id_produs = ccp.id_produs and ccp.status like 'trimis' and ccp.id_client = cl.id_client and cl.id_adresa = a.id_adresa and a.id_oras = o.id_oras";

            query = select + " " + from + " " + where;


            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "rezultate");

            conn.Close();

            if (ds.Tables["rezultate"].Rows.Count > 0)
            {
                RepeaterInfoComanda.Visible = true;
            }
            else
            {
                RepeaterInfoComanda.Visible = false;
            }

            return ds.Tables["rezultate"].DefaultView;
        }


        protected void Page_PreInit(object sender, EventArgs e)
        {
            // daca utilizatorul e logat
            if (User.Identity.IsAuthenticated)
            {
                // daca utilizatorul are rolul de administrator
                if (User.IsInRole("angajat")) MasterPageFile = "~/Angajat.master";

            }
            else MasterPageFile = "~/Site.master";
        }

        protected void ButtonFinalizeOrder_Click(object sender, EventArgs e) {

            string id_angajat;
            
            string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\vali\\Downloads\\mine-licenta\\licenta\\licenta\\App_Data\\ASPNETDB.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string query_id = "select AngajatId from aspnet_Users where UserId='" + Membership.GetUser().ProviderUserKey + "' ;";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlDataAdapter my_adapter = new SqlDataAdapter(query_id, con);
            DataSet dss = new DataSet();
            my_adapter.Fill(dss, "user");

            id_angajat = dss.Tables["user"].Rows[0][0].ToString();
            con.Close();

            string id_client = Request.QueryString["id_client"];
            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            //conn.Open();
            //mai intai generez factura si retin id-ul ei
            string generate_bill_query = "insert into factura(id_factura, id_angajat, id_client, id_tip_plata, data_eliberare) values(factura_seq.nextval, '"+id_angajat+"', '"+id_client+"', 1, SYSDATE)";
            //string id_factura;
           
            

            conn.Open();
            OracleCommand cmd = new OracleCommand(generate_bill_query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            
            OracleDataAdapter adapter_last_id = new OracleDataAdapter("select factura_seq.currval from dual", conn);
            DataSet ds_last = new DataSet();
            adapter_last_id.Fill(ds_last, "last_id");
            conn.Close();

            string lastId = ds_last.Tables["last_id"].Rows[0][0].ToString();

            string update_timp = "insert into dim_timp(id_timp, data, an,trimestru,luna) values(dim_timp_seq.nextval, SYSDATE,to_char(SYSDATE, 'YYYY'),to_char(SYSDATE, 'Q'), to_char(SYSDATE, 'MONTH'))";
            conn.Open();
            OracleCommand cmd11 = new OracleCommand(update_timp, conn);
            cmd11.CommandType = CommandType.Text;
            cmd11.ExecuteNonQuery();
            //apoi introduc liniile coresp in factura_produs
            string query_products = "select p.id_produs, p.pret_unitar, aa.id_oras  from produs p, client_comanda_produs ccp, client c, adresa aa where ccp.id_client='" + id_client + "' and ccp.status = 'trimis' and ccp.id_produs=p.id_produs and ccp.id_client = c.id_client and c.id_adresa = aa.id_adresa";
            
            OracleDataAdapter adapter = new OracleDataAdapter(query_products, conn);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "infoprod");
            
            for (int i = 0; i < ds1.Tables["infoprod"].Rows.Count; i++)
            {
                string insert_assoc_query = "insert into factura_produs(id_factura, id_produs, pret_facturare, cantitate, id_detalii_factura) values('" + lastId + "','" + ds1.Tables["infoprod"].Rows[i][0] + "', '"+ds1.Tables["infoprod"].Rows[i][1]+"', 1, detalii_factura_seq.nextval)";
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = insert_assoc_query;
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();

                string insert_vanzari = "insert into vanzari(id_vanzare, id_produs, id_oras, id_client, id_timp, venit_incasat) values(vanzari_seq.nextval,'" + ds1.Tables["infoprod"].Rows[i][0] + "', '"+ds1.Tables["infoprod"].Rows[i][2]+"', dim_timp_seq.currval ,'"+ds1.Tables["infoprod"].Rows[i][1]+"' )";
  

                string update_stoc = "update produs set stoc_curent = stoc_curent - 1 where id_produs ='"+ds1.Tables["infoprod"].Rows[i][0].ToString()+"'";
                OracleCommand cmd22 = new OracleCommand();
                cmd22.Connection = conn;
                cmd22.CommandText = update_stoc;
                cmd22.CommandType = CommandType.Text;
                var trans1 = conn.BeginTransaction();
                cmd22.ExecuteNonQuery();
                trans1.Commit();

            }
            conn.Close();

            //apoi schimb statusul comenzii
            string my_update_query = "update client_comanda_produs set status = 'finalizat' where id_client = '"+id_client+"' and status like 'trimis'";

            conn.Open();
            OracleCommand cmd3 = new OracleCommand();
            cmd3.Connection = conn;
            cmd3.CommandText = my_update_query;
            cmd3.CommandType = CommandType.Text;
            //cmd3.ExecuteNonQuery();

            var trans = conn.BeginTransaction();
            cmd3.ExecuteNonQuery();
            trans.Commit();
            conn.Close();
            //apoi

            RepeaterInfoComanda.Visible = false;
            LabelFinalizare.Text = "Comanda s-a finalizat cu succes!";
            LabelFinalizare.Visible = true;
            

        }
    }
}