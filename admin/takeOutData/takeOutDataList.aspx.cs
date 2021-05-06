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
using System.Collections.Generic;

public partial class main_visit_listVisit : System.Web.UI.Page
{
    TakeOutData bll = new TakeOutData();
    TakeOutObject bllVisit = new TakeOutObject();

    protected void Page_Load(object sender, EventArgs e)
    {
        // 로그인 체크
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
        //2011-04-20-김민우: 반출목적 조회 조건에 추가  //thêm điều kiện tra cứu mục đích mang ra
        #region Data Binding
        if (cboPurpose.Items.Count == 0)
        {
            cboPurpose.Items.Clear();
            List<TakeOutObjectInfo> list = bllVisit.selectTakeOutObjectList(null);

            TakeOutObjectInfo m = new TakeOutObjectInfo();
            for (int i = 0; i < list.Count; i++)
            {
                m = (TakeOutObjectInfo)list[i];

                string a = Convert.ToString(m.TakeOutObjectCode);
                string b = m.CodeName;

                if (!String.IsNullOrEmpty(a)) cboPurpose.Items.Add(new ListItem(b, a));


            }
        }

        #endregion

    }
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TakeOutDataInfo obj = (TakeOutDataInfo)e.Row.DataItem;

            e.Row.Cells[1].Text = bll.timeKor(obj.TakeOutItemDataList[0].TakeOutTime); //반출일 ngày mang ra
            e.Row.Cells[2].Text = obj.RequestUserDisplayName; //신청자 người đăng ký
            e.Row.Cells[3].Text = StringUtil.GetShortString(obj.CompanyName, 12, "..."); //반출처 nơi mang đến/ nơi nhận
            e.Row.Cells[4].Text = StringUtil.GetShortString(obj.RecieveName, 7, ""); //수령자 người nhận 
            e.Row.Cells[5].Text = bll.requireKor(obj.RequireIN); //반입여부 có mang vào hay không
            e.Row.Cells[6].Text = StringUtil.GetShortString(obj.TakeOutItemDataList[0].TakeOutItemName, 18, "..."); //반출항목 hạng mục mang ra

            //반입일 표시  hiển thị ngày mang vào
            if (obj.RequireIN == 2)
            {
                e.Row.Cells[10].Text = "Không thể mang vào 반입불가";
            }
            else
            {
                e.Row.Cells[10].Text = bll.timeKor(obj.TakeOutItemDataList[0].TakeINTime); //반입일 ngày mang vào
            }

            e.Row.Cells[11].Text = bll.getApproveStringKOR(obj); //결재상태 tình trạng phê duyệt

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("onclick", "window.location='takeOutDataView.aspx?takeOutDataCode=" + obj.TakeOutDataCode + "';");
                e.Row.Cells[i].Attributes.Add("style", "cursor:hand;");
            }

            //반입예정일이 지난 것들 색상 표시 hiển thị màu nếu qua ngày dự định mang vào
            if (obj.RequireIN == 1 && obj.TakeOutItemDataList[0].TakeINTime == "-" && obj.TakeOutItemDataList[0].TakeOutTime != "-")
            {
                if (Convert.ToDateTime(obj.ScheduleInDate) < DateTime.Now)
                {
                    e.Row.Attributes.Add("style", "background-color:#FFF7A2;");
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFF7A2'");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
                }
            }
            else
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C0C0C0'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            }
        }
    }

    protected void GridViewExcel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TakeOutDataInfo takeOutDataInfo = (TakeOutDataInfo)e.Row.DataItem;

            e.Row.Cells[1].Text = bll.timeKor(takeOutDataInfo.TakeOutItemDataList[0].TakeOutTime); //반출일  ngày mang vào
            e.Row.Cells[2].Text = takeOutDataInfo.RequestUserDisplayName; //신청자        người đăng ký 
            e.Row.Cells[6].Text = takeOutDataInfo.TakeOutItemDataList[0].ParentCodeName; //대분류 tài sản lớn
            e.Row.Cells[7].Text = takeOutDataInfo.TakeOutItemDataList[0].SubCodeName; // 중분류 tài sản vừa
            e.Row.Cells[8].Text = takeOutDataInfo.TakeOutItemDataList[0].TakeOutItemName; //반출항목 hạng mục mang ra
            e.Row.Cells[9].Text = takeOutDataInfo.TakeOutItemDataList[0].TakeOutItemType; //규격 quy cách
            e.Row.Cells[10].Text = takeOutDataInfo.TakeOutItemDataList[0].Account.ToString(); //수량 số lượng 
            e.Row.Cells[11].Text = takeOutDataInfo.TakeOutItemDataList[0].UnitName; //단위 đơn vị
            e.Row.Cells[16].Text = bll.requireKor(takeOutDataInfo.RequireIN); //반입여부 có mang vào hay không
            e.Row.Cells[21].Text = takeOutDataInfo.TakeOutItemDataList[0].OutSecurityUserName; //반출처리자 người xử lý mang ra

            //반입일 표시  hiển thị ngày mang vào
            if (takeOutDataInfo.RequireIN == 2)
            {
                e.Row.Cells[27].Text = "Không thể mang vào (반입불가)";
            }
            else
            {
                e.Row.Cells[27].Text = bll.timeKor(takeOutDataInfo.TakeOutItemDataList[0].TakeINTime); //반입일  ngày mang vào
            }

            e.Row.Cells[28].Text = bll.getApproveStringKOR(takeOutDataInfo); //상태 tình trạng
            e.Row.Cells[29].Text = takeOutDataInfo.TakeOutItemDataList[0].INSecurityUserName; //반입처리자  người xử lý mang vào
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        String fileName = "TakeOut_List.xls";
        GridViewExportUtil.Export(fileName, this.GridViewExcel);
    }

}
