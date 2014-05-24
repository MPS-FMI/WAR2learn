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
    public partial class Actualizeaza : System.Web.UI.Page
    {
        protected string id_produs;
        protected string query_search="";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack){
                
                DataInfoProduse.Visible = true;
                DataInfoProduse.DataSource = InformatiiProduse();
                DataInfoProduse.DataBind();
            }


        }

        DataView InformatiiProduse() {
            
             string query="";
             string produs;
             string categorie;
             string pretmin;
             string pretmax;
            
             if (Request.QueryString.Count != 0)
             {
                 produs = Request.QueryString["cuv"];
                 categorie = Request.QueryString["categ"];
                 pretmin = Request.QueryString["pmin"];
                 pretmax = Request.QueryString["pmax"];

                 if (produs.Length == 0)
                 {
                     //afisez toate produsele din categorie si pret
                     query = "select p.id_produs as id_produs, p.denumire as nume_produs, c.id_categorie as id_categ, c.denumire as nume_categorie from produs p, categorie c where p.id_categorie = c.id_categorie and p.pret_unitar between '" + pretmin + "' and '" + pretmax + "' order by c.denumire";
                 }
                 else if (categorie.Length == 0)
                 {
                     query = "select p.id_produs as id_produs, p.denumire as nume_produs, c.id_categorie as id_categ, c.denumire as nume_categorie from produs p, categorie c where p.id_categorie = c.id_categorie and p.pret_unitar between '" + pretmin + "' and '" + pretmax + "' and lower(p.denumire) like '%" + produs.ToLower() + "%' order by c.denumire";
                 }
                 else
                 {
                     query = "select p.id_produs as id_produs, p.denumire as nume_produs, c.id_categorie as id_categ, c.denumire as nume_categorie from produs p, categorie c where p.id_categorie = c.id_categorie and c.id_categorie = '" + categorie + "' and (p.pret_unitar between '" + pretmin + "' and '" + pretmax + "') and lower(p.denumire) like '%" + produs.ToLower() + "%' ";
                 }
             }
             if (query.Length == 0)
             {
                 query = "select p.id_produs as id_produs, p.denumire as nume_produs, c.denumire as nume_categorie from produs p, categorie c where p.id_categorie = c.id_categorie";
             }


            string oradb = "user id=badeavalentina;password=valentina;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 193.226.51.37)(PORT = 1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=o11g)));";
            OracleConnection conn = new OracleConnection(oradb); // C#

            conn.Open();

            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "produse");

            conn.Close();

            if (ds.Tables["produse"].Rows.Count == 0) {
                DataInfoProduse.Visible = false;
                LabelFaraProduse.Visible = true;
            }

            return ds.Tables["produse"].DefaultView;
        }

       
    }
}