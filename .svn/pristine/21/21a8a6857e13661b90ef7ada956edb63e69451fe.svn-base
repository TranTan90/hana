using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HanaMicron.COMS.SQLServerDAL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Registration_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
       
       
    }

    protected void regis_Click(object sender, EventArgs e)
    {

        if (Page.IsPostBack)
        {
            String disname = txtsn.Text + txtgvname.Text;
            string fomatday = "yyyy-MM-dd";
            DateTime reg =  DateTime.Now;
            string s = reg.ToString(fomatday);
            String a = txtsn.Text.ToString();
            String cn = ConfigurationManager.ConnectionStrings["SQLConnString2"].ConnectionString;
            SqlConnection con = new SqlConnection(cn);
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "userinfo";
            cm.Parameters.AddWithValue("@Upnid", txtid.Text.ToString());
            cm.Parameters.Add("@sn", System.Data.SqlDbType.NVarChar, 100).Value = txtsn.Text;   
            cm.Parameters.AddWithValue("@Givenname", txtgvname.Text.ToString());
            cm.Parameters.AddWithValue("@displayname", disname.ToString());
            cm.Parameters.AddWithValue("@Englishname", txtelname.Text.ToString());
            cm.Parameters.AddWithValue("@Title", idtitle.SelectedValue.ToString());
            cm.Parameters.AddWithValue("@Regdate", s);
            cm.Parameters.AddWithValue("@Department", iddpm.SelectedValue.ToString());
            cm.Parameters.AddWithValue("@Company", txtcompany.Text.ToString());
            cm.Parameters.AddWithValue("@Officename", TextBox1.Text.ToString());
            cm.Parameters.AddWithValue("@Officephone", txtoffphone.Text.ToString());
            cm.Parameters.AddWithValue("@Mobiphone", txtmobiphone.Text.ToString());
            cm.Parameters.AddWithValue("@Country", txtcountry.Text.ToString());
            cm.Parameters.AddWithValue("@Email", txtemail.Text.ToString());
            cm.Parameters.AddWithValue("@Upnpwd", txtpass.Text.ToString());
            cm.Connection = con;
            con.Open();
            cm.ExecuteNonQuery();
            cm.Dispose();
            con.Close();
            ShowAlert("Success", "Saved Successfully");
            ClearFeilds();
            return ;


        }
        else
        {
            ShowAlert("Error","Error Registration ");
        }
        
        
    }

    public void ShowAlert(String header, String message)
    {
        //ScriptManager.RegisterStartupScript(this, GetType(), header, "alert('" + message + "');", true);
    }

    public void ClearFeilds()
    {
        txtid.Text = "";
        txtsn.Text = "";
        txtgvname.Text = "";
       txtelname.Text = "";

        idtitle.SelectedValue = "";
        //txtreg.Text = "";
        iddpm.SelectedValue = "";
        txtcompany.Text = "";
        TextBox1.Text = "";
        txtoffphone.Text = "";
        txtmobiphone.Text = "";
        txtcountry.Text = "";
        txtemail.Text = "";
        //txtpage.Text = "";
        txtpass.Text = "";
    
    }
}