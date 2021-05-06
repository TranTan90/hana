using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.Utility;

public partial class _Default : System.Web.UI.Page
{
	Car bll = new Car();
    protected void Page_Load(object sender, EventArgs e)
    {
		// 관리자 체크 check người quản lý
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ISAdmin == false)
		{
			Response.Redirect("~/login.aspx", true);
		}

        if (Page.IsPostBack)
        {
            // 수정하기 Sửa
            if (mode.Value.Equals("modify"))
            {
                int result = bll.updateCarCategory(Request.QueryString["carCategoryCode"], codeName.Text, txtStatus.Text);
                Response.Redirect("carCategoryList.aspx");
            }
            // 등록하기  đăng ký
            else
            {

                int result = bll.insertCarCategory(codeName.Text, txtStatus.Text);
                Response.Redirect("carCategoryList.aspx");
            }
        }
        else
        {   
            if (Request.QueryString["mode"].Equals("modify"))
            {
				CarCategoryInfo carCategory = bll.getCarCategory(Request.QueryString["carCategoryCode"]);

                codeName.Text = carCategory.CodeName;
                txtStatus.Text = carCategory.Status;

                lableCodeName.Text =" Sửa thông tin (정보 수정하기) : "  +carCategory.CodeName ;
                mode.Value = Request.QueryString["mode"];
            }
            else
            {
                lableCodeName.Text = "Đăng ký loại xe (차종 등록하기)";
                mode.Value = Request.QueryString["mode"];
            }   
            
        }
        
        
    }
}
