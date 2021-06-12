using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AdminPanel
{
    public partial class auth_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {

            string pass = Request.Form["password"];
            string name = Request.Form["username"];


            string Sqlds = "SELECT TOP(1) [Kod],[Sifre],[Tip],[AdSoyad],[Id] FROM Kullanici WHERE Kod='" + name + "'";
            DataSet ds = new DataSet();

            ds = dbFunction.GetDataSet(Sqlds);
            if (ds.Tables[0].Rows.Count > 0)
            {


                if (name.ToUpper() == ds.Tables[0].Rows[0]["Kod"].ToString().ToUpper())
                {

                    if (pass == ds.Tables[0].Rows[0]["Sifre"].ToString())
                    {
                        Session["KULLANICIKODU"] = name.ToUpper();
                        Session["KULLANICIID"] = ds.Tables[0].Rows[0]["Id"].ToString();
                        Session["KULLANICITIP"] = ds.Tables[0].Rows[0]["Tip"].ToString();
                        Session["AdSoyad"] = ds.Tables[0].Rows[0]["AdSoyad"].ToString().ToUpper();

                        Response.Redirect("~/Default.aspx", true);
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Kullanıcı Kodu ve/veya Parola Hatalı Girdiniz.');", true);
                        return;

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Kullanıcı Kodu ve/veya Parola Hatalı Girdiniz.');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Kullanıcı Kodu ve/veya Parola Hatalı Girdiniz.');", true);
                return;
            }


        }
    }
}