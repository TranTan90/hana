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

public partial class main_visit_visitorEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
        // 관리자 체크 
        EmployeeInfo loginEmployee = new EmployeeInfo();
        loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (loginEmployee.ManagerLevel == -1 || loginEmployee.ManagerLevel > 0)
        {
            PanelFreepass.Visible = true;
        }

		Visitor bll = new Visitor();

		if (Page.IsPostBack)
		{
			VisitorInfo visitor = new VisitorInfo();
            if (!String.IsNullOrEmpty(visitorCode.Value))
            {
                visitor.VisitorCode = Convert.ToInt32(visitorCode.Value);
            }
            
            //visitor.VisitorCode = Convert.ToInt32(Request.QueryString["visitorCode"]);
            visitor.VisitorName = visitorName.Text;
			visitor.VisitorPhone1 = phone1.Text;
			visitor.VisitorPhone2 = phone2.Text;
			visitor.VisitorPhone3 = phone3.Text;
			visitor.VisitorRegNumber1 = visitorRegNumber1.Text;
            visitor.VisitorRegNumber2 = null;
            visitor.VisitorPassportNumber = visitorPassportNumber.Text;
			if (!String.IsNullOrEmpty(companyCode.Value)) visitor.CompanyCode = Convert.ToInt32(companyCode.Value);

            // 기존에 reject 여부확인하여 업데이트
            if (!String.IsNullOrEmpty(reject.Value))
            {
                visitor.Reject = Convert.ToInt32(reject.Value);
            }
            else
            {
                visitor.Reject = 0;
            }

            // 기존에 rejectContent 여부확인하여 업데이트
            if (!String.IsNullOrEmpty(rejectContent.Value))
            {
                visitor.RejectContent = rejectContent.Value;
            }
            else
            {
                visitor.RejectContent = "";
            }

			// 수정하기   sửa
            if (mode.Value.Equals("modify"))
            {
                int result = bll.updatetVisitor(visitor);
                Page.RegisterStartupScript("alertMove", JavaScriptBuilder.alert(visitorName.Text + " Đã được đăng ký (님의 정보가 등록되었습니다).", "searchVisitor.aspx?index=" + Request.QueryString["index"]));
                //Response.Redirect("searchVisitor.aspx?index=" + Request.QueryString["index"], true);
            }
            // 등록하기 đăng ký
            else
            {
                // 내국인 Việt nam
                if (!String.IsNullOrEmpty(visitorRegNumber1.Text))
                {
                    //김민우
                    if (StringUtil.CheckBirthDay(visitorRegNumber1.Text))
                    {
                        // 등록 여부 검사
                        bool exists = bll.existsVisitor(visitorRegNumber1.Text, visitorName.Text);

                        if (exists == true)
                        {
                            Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(visitorName.Text + " Là khách thăm đã được đăng ký trước\\n. Hãy tìm kiếm nhé.  (는(은) 이미 등록된 내방객 입니다.\\n검색해 보시기 바랍니다)."));
                        }
                        else
                        {
                            visitor.VisitorFlag = 0;
                            int result = bll.insertVisitor(visitor);
                        }
                    }
                    else
                    {
                        Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Nhấm ngày, tháng, năm sinh.\\n\\n Hãy kiểm tra lại. (생년월일이 잘못 되었습니다.\\n\\n생년월일을 확인하여 주십시오)"));
                    }
                }
                //외국인 또는 free pass 인원  // người nước ngoài hoặc free pass
                else
                {
                    // 외국인 Người ngoại quốc
                    if (!String.IsNullOrEmpty(visitorPassportNumber.Text))
                    {
                        visitor.VisitorFlag = 1;
                        int result = bll.insertVisitor(visitor);
                        //Response.Redirect("searchVisitor.aspx?index=" + Request.QueryString["index"], true);
                    }
                    // free pass 인원  Số lượng free pass
                    else
                    {
                        //등록 여부 검사
                        bool existsFree = bll.existsFreepassVisitor(visitor.VisitorName, visitor.CompanyCode);

                        if (existsFree == true)
                        {
                            Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(visitor.VisitorName + " là khách thăm đã được đăng ký.\\n Hãy tìm kiếm nhé. (는(은) 이미 등록된 내방객 입니다.\\n검색해 보시기 바랍니다)."));
                        }
                        else
                        {
                            visitor.VisitorFlag = 2;
                            int result = bll.insertVisitor(visitor);
                        }
                    }
                }

                Page.RegisterStartupScript("alertMove", JavaScriptBuilder.alert(visitorName.Text + " thông tin đã được đăng ký (님의 정보가 등록되었습니다).", "searchVisitor.aspx?index=" + Request.QueryString["index"]));
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
                visitorPassportNumber.Text = visitor.VisitorPassportNumber;
				phone1.Text = visitor.VisitorPhone1;
				phone2.Text = visitor.VisitorPhone2;
				phone3.Text = visitor.VisitorPhone3;
				companyName.Text = visitor.CompanyName;

				companyCode.Value = visitor.CompanyCode.ToString();

				lableCodeName.Text = visitor.VisitorName + " Sửa thông tin khách thăm (내방객 정보 수정하기)";
				mode.Value = Request.QueryString["mode"];
			}
			else
			{
				lableCodeName.Text = "Đăng ký khách thăm (내방객 등록하기)";
				mode.Value = Request.QueryString["mode"];
			}

            visitorRegNumber1.Attributes.Add("onkeyPress", "if ((event.keyCode<48) || (event.keyCode>57)) event.returnValue=false;");
            visitorRegNumber2.Attributes.Add("onkeyPress", "if ((event.keyCode<48) || (event.keyCode>57)) event.returnValue=false;");

            phone1.Attributes.Add("onkeyPress", "if ((event.keyCode<48) || (event.keyCode>57)) event.returnValue=false;");
            phone2.Attributes.Add("onkeyPress", "if ((event.keyCode<48) || (event.keyCode>57)) event.returnValue=false;");
            phone3.Attributes.Add("onkeyPress", "if ((event.keyCode<48) || (event.keyCode>57)) event.returnValue=false;");

		}

        #region 주민번호 검색 AJAX BLOCK
        visitorRegNumber2.Attributes.Add("onblur", "getRegNumberInfo();");

        ClientScriptManager cm = Page.ClientScript;

        StringBuilder script = new StringBuilder();
        script.Append(@"
				function getRegNumberInfo(){
					var url='regCheckVisitor.aspx?regNumber1='+document.getElementById('" + visitorRegNumber1.ClientID + @"').value + '&regNumber2='+document.getElementById('" + visitorRegNumber2.ClientID + @"').value;
					// alert(url);
					request.open('GET',url,false);
					request.onreadystatechange = showMessage; // call back method
					request.send(null);
				}
				// call back method
				function showMessage(){
					if(request.readyState == 4){
						if(request.status== 200){
							var response = request.responseText;
                            var arryStr = response.split(':|:');

                            // alert(response);
                            var message = 'Thông tin nhập là thông tin khách thăm 입력하신 주민등록번호는 이미 ' + arryStr[1] + ' đã đăng ký. Có muốn sửa không? 님으로 등록되어 있습니다. 수정하시겠습니까?';
                            if(arryStr[0] != '0'){
                                if(confirm(message)!=0){
                                    document.getElementById('" + mode.ClientID + @"').value='modify';
                                    document.getElementById('" + visitorCode.ClientID + @"').value= arryStr[0];
                                    document.getElementById('" + reject.ClientID + @"').value= arryStr[2];
                                    document.getElementById('" + rejectContent.ClientID + @"').value= arryStr[3];
                                    document.getElementById('" + phone1.ClientID + @"').focus();
                                }else{
                                    document.getElementById('" + visitorRegNumber1.ClientID + @"').value='';
                                    document.getElementById('" + visitorRegNumber2.ClientID + @"').value='';
                                    document.getElementById('" + visitorRegNumber1.ClientID + @"').focus(); 
                                }
                            }
						}else if(request.status == 404){
							alert('request url does not exist!');
						}else{
							alert('status code is = ' + request.status);
						}
					}
				}
			");
        cm.RegisterClientScriptBlock(this.GetType(), "callback", script.ToString(), true);
        #endregion
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{

	}
}
