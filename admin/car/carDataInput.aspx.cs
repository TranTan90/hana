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
using System.Text;
using System.Collections.Generic;
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.Utility;

public partial class carDataInput : System.Web.UI.Page
{
    public String displayCellCount = "0";
    public String arryCarHandlerList;
    public int carCode;
    public String reqHandlerName;
    public String[] arrHandlerName;
    public String reqPhone;
    public String[] arrPhone;

	Car bll = new Car();
    protected void Page_Load(object sender, EventArgs e)
    {
        #region control Add Attribute
        // 2019-03-26-임종우 : .net 에서 client단에 readonly 설정 시 값을 안 가져오는 문제 발생.. 서버에 Attributes 추가로 해결 함.
        companyName.Attributes.Add("readonly", "readonly");
        #endregion

        // 관리자 체크 check người quản lý
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

        #region control Add Attribute

        number.Attributes.Add("onblur", "numCheck();");
        
        #endregion

        if (Page.IsPostBack)
        {
            // 객체 생성 creat object
			CarDataInfo carData = new CarDataInfo();
            carData.CarCategoryCode = Convert.ToInt32(carCategoryCode.SelectedValue);
            carData.Header = header.Text;
            carData.Number = number.Text;
            carData.CarType = carType.SelectedValue;

            if (reject.Checked == true)
            {
                carData.Reject = 1;
            }
            else
            {
                carData.Reject = 0;
            }

            carData.RejectContent = rejectContent.Text;
            carData.CompanyName = companyName.Text;

            if (!String.IsNullOrEmpty(companyCode.Value)) carData.CompanyCode = Convert.ToInt32(companyCode.Value);

            //int carCode; // 차량코드  car code

            // 수정하기 sửa 
            if (mode.Value.Equals("modify"))
            {
                carData.CarCode = Convert.ToInt32(Request.QueryString["code"]);

				int result = bll.updateCarData(carData);
                
                carCode = Convert.ToInt32(Request.QueryString["code"]);
                
                // 이전에 등록된 운전자 정보 삭제 xóa thông tin lái xe được đăng ký trước đó
                List<CarHandlerInfo> list = bll.selectCarHandlerList(carCode.ToString());
                for (int i = 0; i<list.Count; i++)
                {
                    //int resultDel = bll.deleteCarHandler((CarHandlerInfo)list[i]);
                }

                reqHandlerName = Request["handlerName"];
                arrHandlerName = reqHandlerName.Split(',');

                reqPhone = Request["phone"];
                arrPhone = reqPhone.Split(',');

                for (int i = 0; i < arrHandlerName.Length; i++)
                {
                    CarHandlerInfo carHandler = new CarHandlerInfo();

                    if (!String.IsNullOrEmpty(arrHandlerName[i]))
                    {
                        carHandler.CarCode = carCode;
                        carHandler.Handler = arrHandlerName[i];
                        carHandler.Phone = arrPhone[i];
                    }

                    bll.insertCarHandler(carHandler);
                }

                Response.Redirect("carDataList.aspx");
            }

            // 등록하기 đăng ký 
            else
            {
                //if (bll.existsCarData(carData.Number))
                //{
                //    Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(number.Text + " 는 이미 등록된 차량 번호 입니다."));
                //}

                if (bll.existsCarData(carData.Header, carData.Number, carData.CompanyCode))
                {
                    Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(header.Text + number.Text + "là số xe đã được đăng ký (는 이미 등록된 차량 번호 입니다)."));
                }
                else
                {
                    if (!String.IsNullOrEmpty(carData.Header) && !String.IsNullOrEmpty(carData.Number))
                    {
                        if (!String.IsNullOrEmpty(carData.CompanyName))
                        {
                            int result = bll.insertCarData(carData);

                            carCode = bll.selectMaxCarCode();

                            reqHandlerName = Request["handlerName"];
                            arrHandlerName = reqHandlerName.Split(',');

                            reqPhone = Request["phone"];
                            arrPhone = reqPhone.Split(',');

                            for (int i = 0; i < arrHandlerName.Length; i++)
                            {
                                CarHandlerInfo carHandler = new CarHandlerInfo();

                                if (!String.IsNullOrEmpty(arrHandlerName[i]))
                                {
                                    carHandler.CarCode = carCode;
                                    carHandler.Handler = arrHandlerName[i];
                                    carHandler.Phone = arrPhone[i];
                                }

                                bll.insertCarHandler(carHandler);
                            }

                            Response.Redirect("carDataList.aspx");
                        }
                        else Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Hãy nhập tên công ty (회사명을 입력하여 주세요)."));
                    }
                    else Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Hãy nhập số xe (차량번호를 입력하여 주세요)."));
                }
            }

        }
        else
        {

            if (Request.QueryString["mode"].Equals("modify"))
            {
				CarDataInfo carData = bll.getCarData(Request.QueryString["type"],Convert.ToInt32(Request.QueryString["code"]));

                carCategoryCode.SelectedValue = carData.CarCategoryCode.ToString();
                header.Text = carData.Header;
                number.Text = carData.Number;
                carType.SelectedValue = carData.CarType;
                companyName.Text = carData.CompanyName;
                companyCode.Value = carData.CompanyCode.ToString();

                if (carData.Reject == 1)
                {
                    reject.Checked = true;
                }
                else
                {
                    reject.Checked = false;
                }
                rejectContent.Text = carData.RejectContent;

                lableCodeName.Text = carData.Header + "" + carData.Number + "sửa thông tin  (정보 수정하기)";
                mode.Value = Request.QueryString["mode"];

                List<CarHandlerInfo> carhandlerList = bll.selectCarHandlerList(carData.CarCode.ToString());

                for (int i = 0; i < carhandlerList.Count; i++)
                {
                    CarHandlerInfo subhandler = (CarHandlerInfo)carhandlerList[i];

                    arryCarHandlerList += "carHandlerCode[" + i + "]='" + subhandler.CarHandlerCode + "';\n";
                    arryCarHandlerList += "handler[" + i + "]='" + subhandler.Handler + "';\n";
                    arryCarHandlerList += "handlerPhone[" + i + "]='" + subhandler.Phone + "';\n";
                }

                displayCellCount = carhandlerList.Count.ToString();
            }
            else
            {
                lableCodeName.Text = "Đăng Ký Xe (차량 등록하기)";
                mode.Value = Request.QueryString["mode"];
            }   
            
        }       
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}
