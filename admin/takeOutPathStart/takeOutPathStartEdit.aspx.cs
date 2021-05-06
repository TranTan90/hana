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
	TakeOutPathStart bll = new TakeOutPathStart();
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
			TakeOutPathStartInfo takeOutPathStartInfo = new TakeOutPathStartInfo();
			takeOutPathStartInfo.TakeOutPathStartCode = Convert.ToInt32(Request.QueryString["takeOutPathStartCode"]);
			takeOutPathStartInfo.TakeOutPathStartName = txtCodeName.Text;
            takeOutPathStartInfo.Status = txtStatus.Text;

            // 수정하기
            if (mode.Value.Equals("modify"))
            {
				int result = bll.updateTakeOutPathStart(takeOutPathStartInfo);
				Response.Redirect("takeOutPathStartList.aspx");
            }
            // 등록하기
            else
            {
				int result = bll.insertTakeOutPathStart(takeOutPathStartInfo);
				Response.Redirect("takeOutPathStartList.aspx"); ;
            }
        }
        else
        {   
            if (Request.QueryString["mode"].Equals("modify"))
            {
				TakeOutPathStartInfo takeOutPathStartInfo = new TakeOutPathStartInfo();
				takeOutPathStartInfo = bll.selectTakeOutPathStart(Request.QueryString["takeOutPathStartCode"]);

				txtCodeName.Text = takeOutPathStartInfo.TakeOutPathStartName;
                txtStatus.Text = takeOutPathStartInfo.Status;

				lableCodeName.Text = " Sửa thông tin (정보 수정하기) : " + takeOutPathStartInfo.TakeOutPathStartName ;
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
