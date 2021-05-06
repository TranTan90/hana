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
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    public String check ="0";
    protected void Page_Load(object sender, EventArgs e)
    {
        
		// 관리자 체크
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

        Visitor bll = new Visitor();

        if (Page.IsPostBack)
        {
			VisitorInfo visitor = new VisitorInfo();
            visitor.VisitorCode = Convert.ToInt32(Request.QueryString["visitorCode"]);
            visitor.VisitorName = visitorName.Text;
            visitor.VisitorPhone1 = phone1.Text;
            visitor.VisitorPhone2 = phone2.Text;
            visitor.VisitorPhone3 = phone3.Text;
            visitor.VisitorRegNumber1 = visitorRegNumber1.Text;
            //visitor.VisitorRegNumber2 = visitorRegNumber2.Text;
            visitor.VisitorRegNumber2 = null;
            visitor.VisitorPassportNumber = visitorPassportNumber.Text;

            if(!String.IsNullOrEmpty(companyCode.Value)) visitor.CompanyCode = Convert.ToInt32(companyCode.Value);

            if (reject.Checked == true) visitor.Reject = 1;
            else visitor.Reject = 0;

            visitor.RejectContent = rejectContent.Text;

            // 수정하기
            if (mode.Value.Equals("modify"))
            {
                int result = bll.updatetVisitor(visitor);

                if (visitor.Reject == 1) Response.Redirect("visitorRejectList.aspx");
                else Response.Redirect("visitorList.aspx");
            }
            // 등록하기(내국인)
            else if (!String.IsNullOrEmpty(visitorRegNumber1.Text))
            {
                // 등록 여부 검사
                
                //bool exists = bll.existsVisitor(visitorRegNumber1.Text, visitorRegNumber2.Text);
                bool exists = bll.existsVisitor(visitorRegNumber1.Text, visitorName.Text);
                if (exists == true)
                {
                    Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(visitorName.Text + " Là khách đã được đăng ký trước. \\n Hãy tra cứu tại thông tin khách thăm (는 이미 등록된 내방객 입니다.\\n검색해 보시기 바랍니다.)"));
                }
                else
                {
                    int result = bll.insertVisitor(visitor);
                    Response.Redirect("visitorList.aspx");
                }
              
            }
            // 등록하기(외국인)
            else
            {
                int result = bll.insertVisitor(visitor);
                Response.Redirect("visitorList.aspx");
            }
            
        }
        else
        {
            StringBuilder jsFunc = new StringBuilder();
            jsFunc.Append("<script language='javascript' type='text/javascript'>\n");
            jsFunc.Append("function addNameID(codeName,companyCode){\n");
            jsFunc.Append(Form.UniqueID + "." + companyName.UniqueID + ".value=codeName\n");
            jsFunc.Append(Form.UniqueID + "." + companyCode.UniqueID + ".value=companyCode\n");
            jsFunc.Append("}\n");
            jsFunc.Append("</script>\n");

            Page.RegisterStartupScript("alertMsg", jsFunc.ToString());

            if (Request.QueryString["mode"].Equals("modify"))
            {
                VisitorInfo visitor = bll.getVisitor(Request.QueryString["visitorCode"]);

                visitorName.Text = visitor.VisitorName;
                visitorRegNumber1.Text = visitor.VisitorRegNumber1;
                visitorRegNumber2.Text = visitor.VisitorRegNumber2;

                // 외국인
                if (visitor.VisitorFlag == 1)
                {
                    check = "1";
                    visitorPassportNumber.Text = visitor.VisitorPassportNumber;
                }
                else
                {
                    // Free pass인원
                    if (visitor.VisitorFlag == 0) check = "0";
                    if (visitor.VisitorFlag == 2) check = "2";
                    visitorPassportNumber.Text = null;
                }

                phone1.Text = visitor.VisitorPhone1;
                phone2.Text = visitor.VisitorPhone2;
                phone3.Text = visitor.VisitorPhone3;
                companyName.Text = visitor.CompanyName;
                rejectContent.Text = visitor.RejectContent ;

                if (visitor.Reject == 1) reject.Checked = true;
                else reject.Checked = false;

                companyCode.Value = visitor.CompanyCode.ToString();

                lableCodeName.Text =  "Sửa thông tin khách thăm (내방객 정보 수정하기) : " +visitor.VisitorName ;
                mode.Value = Request.QueryString["mode"];
            }
            else
            {
                lableCodeName.Text = "Đăng ký khách thăm (내방객 등록하기)";
                mode.Value = Request.QueryString["mode"];
            }

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}
