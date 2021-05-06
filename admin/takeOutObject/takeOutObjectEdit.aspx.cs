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
	TakeOutObject bll = new TakeOutObject();
    protected void Page_Load(object sender, EventArgs e)
    {
		// 관리자 체크 check  người quản lý
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
			TakeOutObjectInfo takeOutObjectInfo = new TakeOutObjectInfo();
			takeOutObjectInfo.TakeOutObjectCode = Convert.ToInt32(Request.QueryString["takeOutObjectCode"]);
			takeOutObjectInfo.CodeName = txtCodeName.Text;
            takeOutObjectInfo.Status = txtStatus.Text;

            // 수정하기 Sửa
            if (mode.Value.Equals("modify"))
            {
				int result = bll.updateTakeOutObject(takeOutObjectInfo);
                Response.Redirect("takeOutObjectList.aspx");
            }
            // 등록하기 Đăng ký
            else
            {
				int result = bll.insertTakeOutObject(takeOutObjectInfo);
				Response.Redirect("takeOutObjectList.aspx"); ;
            }
        }
        else
        {   
            if (Request.QueryString["mode"].Equals("modify"))
            {
				TakeOutObjectInfo takeOutObjectInfo = new TakeOutObjectInfo();
				takeOutObjectInfo = bll.selectTakeOutObject(Request.QueryString["takeOutObjectCode"]);

				txtCodeName.Text = takeOutObjectInfo.CodeName;
                txtStatus.Text = takeOutObjectInfo.Status;

				lableCodeName.Text =  "  Sửa thông tin (정보 수정하기) : " +takeOutObjectInfo.CodeName ;
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
