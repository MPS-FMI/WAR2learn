using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace licenta
{
    public partial class AfiseazaCategorie : System.Web.UI.Page
    {
        public string numeCateg { get; set; } 

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // daca utilizatorul e logat
            if (User.Identity.IsAuthenticated)
            {
                // daca utilizatorul are rolul de administrator
                if (User.IsInRole("admin")) MasterPageFile = "~/Admin.master";
                else
                    if (User.IsInRole("angajat")) MasterPageFile = "~/Angajat.master";
                    else
                    // daca utilizatorul e client
                    {
                        MasterPageFile = "~/Client.master";
                        string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
                        OracleConnection conn = new OracleConnection(oradb); // C#

                        conn.Open();

                        string query = "select categorie.denumire from categorie where categorie.id_categorie = " + Request.QueryString["id_categ"] + " ";

                        OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "table");

                        conn.Dispose();
                        conn.Close();


                        numeCateg = ds.Tables["table"].Rows[0][0].ToString();
                    }
            }
            else MasterPageFile = "~/Site.master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack){
               LabelNumeCategorie.Text = numeCateg;

               RepeaterProduseInCategorie.DataSource = AfiseazaProduseInCategorie();
               RepeaterProduseInCategorie.DataBind();

               if (LabelNumeCategorie.Text.Length == 0)
               {
                   LabelNumeCategorie.Text = "Eroare";
               }
           }
        }

        DataView AfiseazaProduseInCategorie(){

            string idCateg = Request.QueryString["id_categ"];

            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            string query = "select produs.denumire as nume, produs.id_produs as id_prod from produs where produs.id_categorie =" + idCateg + " ";

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "table");

            conn.Dispose();
            conn.Close();

            return ds.Tables["table"].DefaultView;
        }
    }
}