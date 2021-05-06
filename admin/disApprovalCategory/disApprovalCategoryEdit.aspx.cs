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
	DisApprovalCategory bll = new DisApprovalCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
		// 관리자 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ManagerLevel < 2)
		{
			Response.Redirect("~/login.aspx", true);
		}

        if (Page.IsPostBack)
        {
			DisApprovalCategoryInfo disApprovalCategoryInfo = new DisApprovalCategoryInfo();
			disApprovalCategoryInfo.DisApprovalCategoryCode = Convert.ToInt32(Request.QueryString["disApprovalCategoryCode"]);
			disApprovalCategoryInfo.CodeName = txtCodeName.Text;
            disApprovalCategoryInfo.Status = txtStatus.Text;
            // 수정하기 Sửa
            if (mode.Value.Equals("modify"))
            {
				int result = bll.updateDisApprovalCategory(disApprovalCategoryInfo);
				Response.Redirect("disApprovalCategoryList.aspx");
            }
            // 등록하기  Đăng ký
            else
            {
				int result = bll.insertDisApprovalCategory(disApprovalCategoryInfo);
				Response.Redirect("disApprovalCategoryList.aspx"); ;
            }
        }
        else
        {   
            if (Request.QueryString["mode"].Equals("modify"))
            {
				DisApprovalCategoryInfo disApprovalCategoryInfo = new DisApprovalCategoryInfo();
				disApprovalCategoryInfo = bll.selectDisApprovalCategory(Request.QueryString["disApprovalCategoryCode"]);

				txtCodeName.Text = disApprovalCategoryInfo.CodeName;
                txtStatus.Text = disApprovalCategoryInfo.Status;
              
				lableCodeName.Text =  " Sửa thông tin (정보 수정하기) : " +disApprovalCategoryInfo.CodeName ;
                mode.Value = Request.QueryString["mode"];
            }
            else
            {
                lableCodeName.Text = "Đăng ký (등록하기)";
                mode.Value = Request.QueryString["mode"];
            }   
            
        }
        
        
    }
}
