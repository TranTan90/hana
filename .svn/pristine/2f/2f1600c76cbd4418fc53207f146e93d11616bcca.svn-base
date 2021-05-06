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
using HanaMicron.COMS.Model;
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Utility;

public partial class main_security_carVisitDataList : System.Web.UI.Page
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    /// 

    Car bll = new Car();
    CarDataInfo carData = new CarDataInfo();
    CarHandlerInfo carHandler = new CarHandlerInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
		// 로그인 체크  check login
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}
		
		// 보안 요원 체크
		if (loginEmployee.ManagerLevel < 0)
		{
			Response.Redirect("~/login.aspx", true);
		}

		//VisitData bll = new VisitData();
		//GridView1.DataSource = bll.selectVisitDataList(ddlKeyWord.Text, txtKey.Text, txtStartDate.Text, txtEndDate.Text, "", "");
		//GridView1.DataBind();

		if (!Page.IsPostBack)
		{
			if (!String.IsNullOrEmpty(Request.QueryString["page"])) GridView1.PageIndex = Convert.ToInt32(Request.QueryString["page"]);
			if (!String.IsNullOrEmpty(Request.QueryString["keyWord"])) ddlKeyWord.SelectedValue = Request.QueryString["keyWord"];
			if (!String.IsNullOrEmpty(Request.QueryString["key"])) txtKey.Text = Request.QueryString["key"];
		}

        #region control Add Attribute

        //txtCarNo.Attributes.Add("onblur", "closeDiv();");
        txtCarNo.Attributes.Add("onkeyup", "getCarDataInfo();");

        #endregion
    }
    
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
	{

		if (e.Row.RowType == DataControlRowType.DataRow)
		{
            CarVisitDataInfo obj = (CarVisitDataInfo)e.Row.DataItem;

            e.Row.Cells[0].ColumnSpan = 2;
            e.Row.Cells[1].Visible = false;

            e.Row.Cells[0].Text = obj.CarDataInfo.Header + " " + obj.CarDataInfo.Number;
            //e.Row.Cells[1].Text = obj.CarDataInfo.Number;
            e.Row.Cells[2].Text = bll.getCarTypeKor(obj.CarDataInfo.CarType);
            e.Row.Cells[3].Text = obj.CarDataInfo.CompanyName;
            e.Row.Cells[4].Text = obj.RegDate;

            if (!obj.InTime.Equals("-"))
            {
                e.Row.Cells[5].Text = obj.InTime.Substring(11, 8);
            }
            else e.Row.Cells[5].Text = obj.InTime;

            if (obj.OutTime.Equals("-"))
            {
                if (!obj.CarDataInfo.CarType.Equals("3"))
                {
                    e.Row.Cells[6].Text = "<a href='#;' onClick=\"javascript:confirmMove(' Bạn có muốn xử lý ra cổng không (출문 처리 하시겠습니까)?','../car/carVisitTimeUpdate.aspx?carVisitDataCode=" + obj.CarVistDataCode + "&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "')\">";
                    e.Row.Cells[6].Text += "<span style=\"color:blue\">Xử lý ra cổng (출문 처리)</span></a>";
                }
                else e.Row.Cells[6].Text = "-";
            }
            else e.Row.Cells[6].Text = obj.OutTime.Substring(11,8);
            
            e.Row.Cells[7].Text = obj.CarHandlerInfo.Handler;
            e.Row.Cells[8].Text = obj.CarHandlerInfo.Phone;
            e.Row.Cells[9].Text = obj.EmployeeName;
            e.Row.Cells[10].Text = obj.Etc;

		}

        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].ColumnSpan = 2;
            e.Row.Cells[1].Visible = false;
        }
	}

    protected void GridView2_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CarVisitDataInfo obj = (CarVisitDataInfo)e.Row.DataItem;

            e.Row.Cells[0].Text = obj.CarDataInfo.Number;
            e.Row.Cells[1].Text = bll.getCarTypeKor(obj.CarDataInfo.CarType);
            e.Row.Cells[2].Text = obj.CarDataInfo.CompanyName;
            e.Row.Cells[3].Text = obj.RegDate;
            e.Row.Cells[4].Text = obj.InTime;
            e.Row.Cells[5].Text = obj.OutTime;

            //if (obj.OutTime.Equals("-"))
            //{
            //    if (!obj.CarDataInfo.CarType.Equals("3"))
            //    {
            //        e.Row.Cells[5].Text = "<a href='#;' onClick=\"javascript:confirmMove('Bạn có muốn xử lý ra cổng không (출문 처리 하시겠습니까)?','../car/carVisitTimeUpdate.aspx?carVisitDataCode=" + obj.CarVistDataCode + "&keyWord=" + ddlKeyWord.SelectedValue + "&key=" + HttpUtility.UrlEncode(txtKey.Text) + "&page=" + GridView1.PageIndex + "')\">";
            //        e.Row.Cells[5].Text += "<span style=\"color:blue\">출문 처리</span></a>";
            //    }
            //    else e.Row.Cells[5].Text = "-";
            //}
            //else e.Row.Cells[5].Text = obj.OutTime.Substring(11, 8);

            e.Row.Cells[6].Text = obj.CarHandlerInfo.Handler;
            e.Row.Cells[7].Text = obj.CarHandlerInfo.Phone;
            e.Row.Cells[8].Text = obj.EmployeeName;
            e.Row.Cells[9].Text = obj.Etc;

        }
    }

	/// <summary>
	/// 엑셀 다운 Tải xuống excel
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Button1_Click(object sender, EventArgs e)
	{
		String fileName = "Car_visit_Data_List_Security.xls";
		GridViewExportUtil.Export(fileName, this.GridView2);
	}
	protected void GridView1_PageIndexChanged(object sender, EventArgs e)
	{

	}
    protected void btnInput_Click(object sender, EventArgs e)
    {
        CarVisitDataInfo carVisitDataInfo = new CarVisitDataInfo();
        carVisitDataInfo.CarDataInfo = new CarDataInfo();
        carVisitDataInfo.CarHandlerInfo = new CarHandlerInfo();
        int carCode = 0;
        int carHandlerCode = 0;

        // 미등록 차량일 경우 신규 등록 Trường hợp xe chưa đăng ký thì đăng ký mới
        if (String.IsNullOrEmpty(Request.Form["txtCarCode"]))
        {
            carData.Header = txtHeader.Text;
            carData.Number = txtCarNumer.Text;
            carData.CarType = Request.Form["slCarType"];
            carData.CompanyName = Request.Form["companyName"];
            carData.Reject = 0;
            carData.RejectContent = "";
            carData.CompanyCode = Convert.ToInt32(Request.Form["companyCode"]);

            if (!bll.existsCarData(carData.Header, carData.Number, carData.CompanyCode))
            {
                // 임직원차(2), 내방객차(4) 일 경우 승용차로 고정(code 2)   / trường hợp xe nhân viên (2), xe khách thăm (4) thì cố định bằng xe chở khách
                if (carData.CarType.Equals("2") || carData.CarType.Equals("4"))
                {
                    carData.CarCategoryCode = 2;
                }
                else carData.CarCategoryCode = 17; //그외 입출문 관리에서 등록할 경우 납품차로 고정(트럭:code 17)  / Ngoài ra Trong quản lý xe ra vào cổng, trường hợp chưa đăng ký thì cố định bằng xe giao hàng

                if (!String.IsNullOrEmpty(carData.Header) && !String.IsNullOrEmpty(carData.Number))
                {
                    if (!String.IsNullOrEmpty(carData.CompanyName))
                    {
                        if (!String.IsNullOrEmpty(Request.Form["txthandler"]))
                        {
                            // 차량 정보 등록 Đăng ký thông tin xe
                            int result = bll.insertCarData(carData);
                            carCode = bll.selectMaxCarCode();

                            carHandler.CarCode = carCode;
                            carHandler.Handler = Request.Form["txthandler"];
                            carHandler.Phone = txtPhone.Text;

                            // 운전자 등록  Đăng ký lái xe
                            bll.insertCarHandler(carHandler);
                            carHandlerCode = bll.selectMaxCarHandlerCode();

                            carVisitDataInfo.CarDataInfo.CarCode = carCode;
                            carVisitDataInfo.EmployeeName = txtEmployee.Text;
                            carVisitDataInfo.Etc = txtEtc.Text;
                            carVisitDataInfo.CarHandlerInfo.CarHandlerCode = carHandlerCode;

                            // 차량 입문 처리  Xử lý xe vào cổng
                            bll.insertCarVisitData("input", carVisitDataInfo);

                            Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "carVisitDataList.aspx"));
                        }
                        else Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Hãy nhập tên lái xe (운전자 이름을 입력하여 주세요)."));
                    }
                    else Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Hãy nhập tên công ty (회사명을 입력하여 주세요)."));
                }
                else Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Hãy nhập số xe (차량번호를 입력하여 주세요)."));
            }
            else Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Xe đã được đăng ký trước. Hãy kiểm tra lại (이미등록된 차량입니다. 확인하여 주세요)."));
            // 차량 정보 등록  Đăng ký thông tin xe 
            //int result = bll.insertCarData(carData);
            //carCode = bll.selectMaxCarCode();

            //carHandler.CarCode = carCode;
            //carHandler.Handler = Request.Form["txthandler"];
            //carHandler.Phone = txtPhone.Text;

            // 운전자 등록 Đăng ký lái xe
            //bll.insertCarHandler(carHandler);
            //carHandlerCode = bll.selectMaxCarHandlerCode();

            //carVisitDataInfo.CarDataInfo.CarCode = carCode;
            //carVisitDataInfo.EmployeeName = txtEmployee.Text;
            //carVisitDataInfo.Etc = txtEtc.Text;
            //carVisitDataInfo.CarHandlerInfo.CarHandlerCode = carHandlerCode;
        }
        else // 기존 등록된 차량일 경우   trường hợp xe đã được đăng ký trước
        {
            carCode = Convert.ToInt32(Request.Form["txtCarCode"]);            

            // 2010-05-19-임종우 : 헤더 없는 차량은 수정 가능하도록 변경.     Thay đổi để có thể sửa xe không có header
            carData.Header = txtHeader.Text;
            carData.CarCode = carCode;

            //운전자 추가  Thêm lái xe
            if (Request.Form["slHandler"].Equals("ADD"))
            {
                carHandler.CarCode = carCode;
                carHandler.Handler = Request.Form["txthandler"];
                carHandler.Phone = txtPhone.Text;

                // 2010-05-18-임종우 : 해당 차량에 운전자 등록 되어 있는지 체크   check xem xe đó đã được đăng ký lái xe chưa
                if (!bll.existsCarHandlerData(carHandler.CarCode, carHandler.Handler))
                {
                    // 2010-05-29-임종우 : 차량 헤더 없는것은 수정 가능하도록 추가   Thêm khả năng sửa đổi xe không có deader
                    if (Request.Form["txtUpdate"] == "yes")
                    {
                        bll.updateCarData_header(carData);
                    }

                    // 운전자 등록 đăng ký lái xe 
                    bll.insertCarHandler(carHandler);
                    carHandlerCode = bll.selectMaxCarHandlerCode();

                    carVisitDataInfo.CarDataInfo.CarCode = carCode;
                    carVisitDataInfo.EmployeeName = txtEmployee.Text;
                    carVisitDataInfo.Etc = txtEtc.Text;
                    carVisitDataInfo.CarHandlerInfo.CarHandlerCode = carHandlerCode;

                    // 차량 입문 처리 hoàn thành xe vào cổng
                    bll.insertCarVisitData("input", carVisitDataInfo);
                    
                    Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "carVisitDataList.aspx"));
                }
                else
                {
                    Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert(carHandler.Handler + "là lái xe đã được đăng ký. Hãy kiểm tra lại. (님은 이미 등록 된 운전자 입니다.\\n다시 확인 하시기 바랍니다).", "carVisitDataList.aspx"));
                    //Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(carHandler.Handler + "님은 이미 등록 된 운전자 입니다."));
                }                
            }
            else
            {
                // 2010-05-29-임종우 : 차량 헤더 없는것은 수정 가능하도록 추가    Thêm khả năng sửa đổi xe không có deader
                if (Request.Form["txtUpdate"] == "yes")
                {
                    bll.updateCarData_header(carData);
                }

                carHandlerCode = Convert.ToInt32(Request.Form["txtHandlerCode"]);

                carVisitDataInfo.CarDataInfo.CarCode = carCode;
                carVisitDataInfo.EmployeeName = txtEmployee.Text;
                carVisitDataInfo.Etc = txtEtc.Text;
                carVisitDataInfo.CarHandlerInfo.CarHandlerCode = carHandlerCode;
                
                //차량 입문 처리 시 전화번호 업데이트     Xử lý xe vào cổng thì update số điện thoại
                carHandler.CarHandlerCode = Convert.ToInt32(Request.Form["txtHandlerCode"]);
                //carHandler.CarCode = carCode;
                //carHandler.Handler = Request.Form["txtHandler"];
                carHandler.Phone = txtPhone.Text;                
                bll.updateCarHandlerPhone(carHandler);
                
                // 차량 입문 처리  xử lý xe vào cổng
                bll.insertCarVisitData("input", carVisitDataInfo);
                Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "carVisitDataList.aspx"));
            }                        
        }

        // 차량 입문 처리 
        //bll.insertCarVisitData("input",carVisitDataInfo);

        //Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("처리 하였습니다.", "carVisitDataList.aspx"));
    }

    protected void btnOutput_Click(object sender, EventArgs e)
    {
        CarVisitDataInfo carVisitDataInfo = new CarVisitDataInfo();
        carVisitDataInfo.CarDataInfo = new CarDataInfo();
        carVisitDataInfo.CarHandlerInfo = new CarHandlerInfo();

        if (Request.Form["slHandler"].Equals("ADD"))
        {
            carHandler.CarCode = Convert.ToInt32(Request.Form["txtCarCode"]);
            carHandler.Handler = Request.Form["txthandler"];
            carHandler.Phone = txtPhone.Text;

            bll.insertCarHandler(carHandler);
            carVisitDataInfo.CarHandlerInfo.CarHandlerCode = bll.selectMaxCarHandlerCode();
        }
        else
        {
            carVisitDataInfo.CarHandlerInfo.CarHandlerCode = Convert.ToInt32(Request.Form["txtHandlerCode"]);
        }

        carVisitDataInfo.CarDataInfo.CarCode = Convert.ToInt32(Request.Form["txtCarCode"]);
        carVisitDataInfo.EmployeeName = txtEmployee.Text;
        carVisitDataInfo.Etc = txtEtc.Text;


        // 차량 출문 처리 (업무차)  xử lý xe ra cổng (xe công vụ )
        bll.insertCarVisitData("output", carVisitDataInfo);

        Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành 처리 하였습니다.", "carVisitDataList.aspx"));
    }
}

