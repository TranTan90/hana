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
	TakeOutPathEnd bll = new TakeOutPathEnd();
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
			TakeOutPathEndInfo takeOutPathEndInfo = new TakeOutPathEndInfo();
			takeOutPathEndInfo.TakeOutPathEndCode = Convert.ToInt32(Request.QueryString["takeOutEndEndCode"]);
			takeOutPathEndInfo.TakeOutPathEndName = txtCodeName.Text;
            takeOutPathEndInfo.Status = txtStatus.Text;

            // 수정하기 Sửa
            if (mode.Value.Equals("modify"))
            {
				int result = bll.updateTakeOutPathEnd(takeOutPathEndInfo);
				Response.Redirect("takeOutPathEndList.aspx");
            }
            // 등록하기  đăng ký
            else
            {
				int result = bll.insertTakeOutPathEnd(takeOutPathEndInfo);
				Response.Redirect("takeOutPathEndList.aspx"); ;
            }
        }
        else
        {   
            if (Request.QueryString["mode"].Equals("modify"))
            {
				TakeOutPathEndInfo takeOutPathEndInfo = new TakeOutPathEndInfo();
				takeOutPathEndInfo = bll.selectTakeOutPathEnd(Request.QueryString["takeOutEndEndCode"]);

				txtCodeName.Text = takeOutPathEndInfo.TakeOutPathEndName;
                txtStatus.Text = takeOutPathEndInfo.Status;

				lableCodeName.Text =  " Sửa thông tin (정보 수정하기) : " +takeOutPathEndInfo.TakeOutPathEndName ;
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
