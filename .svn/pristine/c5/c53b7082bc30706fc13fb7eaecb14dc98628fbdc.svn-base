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

public partial class main_visit_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		index.Value = Request.QueryString["index"];
        if (!Page.IsPostBack)
        {
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
			pnNotice.Visible = false;
            Visitor bll = new Visitor();
            Int32 totalCount = bll.totalVisitor(keyWord.Text, key.Text, false);
            Label1.Text = totalCount.ToString();
        }
    }

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[2].ColumnSpan = 3;
			e.Row.Cells[3].Visible = false;
			e.Row.Cells[4].Visible = false;

			e.Row.Cells[5].ColumnSpan = 2;
			e.Row.Cells[6].Visible = false;
		}

		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			VisitorInfo obj = (VisitorInfo)e.Row.DataItem;
			e.Row.Cells[2].Text = obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3;

			e.Row.Cells[2].ColumnSpan = 3;
			e.Row.Cells[3].Visible = false;
			e.Row.Cells[4].Visible = false;

            if (obj.VisitorFlag != 1)
            {
                //e.Row.Cells[5].Text = obj.VisitorRegNumber1 + "-" + obj.VisitorRegNumber2.Substring(0, 4) + "***";
                e.Row.Cells[5].Text = obj.VisitorRegNumber1;
            }
            else
            {
                e.Row.Cells[5].Text = obj.VisitorPassportNumber;
            }
			e.Row.Cells[5].ColumnSpan = 2;
			e.Row.Cells[6].Visible = false;

            if (obj.Reject == 0)
            {
                e.Row.Attributes.Add("style", "cursor:hand");
                if (!String.IsNullOrEmpty(obj.VisitorRegNumber1))
                {
                    //e.Row.Attributes.Add("onclick", "selectEnd('" + obj.VisitorCode + "','" + obj.VisitorRegNumber1 + "-" + obj.VisitorRegNumber2.Substring(0, 4) + "***" + "','" + obj.VisitorPassportNumber + "','" + obj.VisitorName + "','" + obj.CompanyName + "','" + obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3 + "','" + index.Value + "');");
                    e.Row.Attributes.Add("onclick", "selectEnd('" + obj.VisitorCode + "','" + obj.VisitorRegNumber1 +  "','" + obj.VisitorPassportNumber + "','" + obj.VisitorName + "','" + obj.CompanyName + "','" + obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3 + "','" + index.Value + "');");
                }
                else
                {
                    //e.Row.Attributes.Add("onclick", "selectEnd('" + obj.VisitorCode + "','" + obj.VisitorRegNumber1 + obj.VisitorRegNumber2 + "','" + obj.VisitorPassportNumber + "','" + obj.VisitorName + "','" + obj.CompanyName + "','" + obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3 + "','" + index.Value + "');");
                    e.Row.Attributes.Add("onclick", "selectEnd('" + obj.VisitorCode + "','" + obj.VisitorRegNumber1 + "','" + obj.VisitorPassportNumber + "','" + obj.VisitorName + "','" + obj.CompanyName + "','" + obj.VisitorPhone1 + "-" + obj.VisitorPhone2 + "-" + obj.VisitorPhone3 + "','" + index.Value + "');");
                }
            }
		}
	}
	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{

	}
}
