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
	HanaMicron.COMS.BLL.Unit bll = new HanaMicron.COMS.BLL.Unit();
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
			UnitInfo unitInfo = new UnitInfo();
			unitInfo.UnitCode = Convert.ToInt32(Request.QueryString["unitCode"]);
			unitInfo.CodeName = txtCodeName.Text;
            unitInfo.Status = txtStatus.Text;

            // 수정하기
            if (mode.Value.Equals("modify"))
            {
				int result = bll.updateUnit(unitInfo);
				Response.Redirect("unitList.aspx");
            }
            // 등록하기
            else
            {
				int result = bll.insertUnit(unitInfo);
				Response.Redirect("unitList.aspx"); ;
            }
        }
        else
        {   
            if (Request.QueryString["mode"].Equals("modify"))
            {
				UnitInfo unitInfo = new UnitInfo();
				unitInfo = bll.selectUnit(Request.QueryString["unitCode"]);

				txtCodeName.Text = unitInfo.CodeName;
                txtStatus.Text = unitInfo.Status;

				lableCodeName.Text =  " Sửa thông tin (정보 수정하기) : " +unitInfo.CodeName ;
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
