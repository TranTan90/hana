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
using System.Collections.Generic;
using HanaMicron.COMS.BLL;

public partial class admin_approve_approveList : System.Web.UI.Page
{

	private Department bll = new Department();
	private Employee bllEmployee = new Employee();

    protected void Page_Load(object sender, EventArgs e)
	{
		// 관리자 체크 kiểm tra người quản lý
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

		imgError.Visible = false;
		lblError.Visible = false;

		# region tree binding
		TreeView1.Nodes.Clear();
		TreeNode rootNode = new TreeNode();
		TreeNode parentNode;
		TreeNode currentNode;
		TreeNode previousNode = rootNode;
		int previousDepth = 0;
		int currentDepth = 0;


		List<DepartmentInfo> list = bll.listDepartment();

		for (int i = 0; i < list.Count; i++)
		{
			DepartmentInfo departmentInfo = (DepartmentInfo)list[i];

			currentDepth = departmentInfo.Level_no;
			currentNode = new TreeNode(); //현재 노드 생성

			if (currentDepth < 1) currentNode.Expanded = true; //노드를 확장(펼쳐보여지게 한다.)
			else currentNode.Expanded = false;

			//currentNode.Expanded = true; //노드를 확장(펼쳐보여지게 한다.)

			currentNode.Text = departmentInfo.Dep_name;
			//currentNode.NavigateUrl = "javascript:selected()";

			currentNode.Value = departmentInfo.Dep_code.ToString();

			

			if (currentDepth > 0)
			{
				if (previousDepth < currentDepth)//이전 depth보다 현재 depth가 크면...
					previousNode.ChildNodes.Add(currentNode); //이전 노드가 부모 노드가 된다.
				else if (previousDepth == currentDepth)
					previousNode.Parent.ChildNodes.Add(currentNode); //같은 depth상의 노드라면 이전 노드의 부모 노드가 현재 노드의 부모 노드이다.
				else if (previousDepth > currentDepth)
					findParentNode(previousNode, previousDepth - currentDepth).ChildNodes.Add(currentNode);

				//현재 depth가 이전 depth보다 작다면 현재 노드의 부모 노드를 찾는다.
				previousDepth = currentDepth; //이전 depth를 할당
				previousNode = currentNode; //이전 노드 할당
			}
			else //루트 노드 생성
			{
				rootNode = currentNode;
				parentNode = rootNode;
				previousNode = parentNode;
				previousDepth = currentDepth;
			}
		}
		TreeView1.Nodes.Add(rootNode);
		

		
		//if (TreeView1.SelectedValue != null)
		//{
		//    Response.Write(TreeView1.SelectedNode.ValuePath);
		//}
		
		#endregion
	}

	private TreeNode findParentNode(TreeNode node, int gap)
	{

		TreeNode tmpNode = node;

		for (int i = 0; i <= gap; i++)
		{

			tmpNode = tmpNode.Parent;

		}

		return tmpNode;

	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
	{
		employeeList.DataSource = bllEmployee.listEmployee(TreeView1.SelectedValue);
		employeeList.DataValueField = "upnid";
		employeeList.DataTextField = "displayName";
		employeeList.DataBind();

		TreeView1.SelectedNode.Expanded = true;

		String[] path = TreeView1.SelectedNode.ValuePath.Split('/');

		String valuePath = "";
		for (int i = 0; i < path.Length; i++)
		{
			valuePath += path[i];

			TreeView1.FindNode(valuePath).Expanded = true;
			valuePath+= "/";
			
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="message"></param>
	protected void showError(String message)
	{
		imgError.Visible = true;
		lblError.Visible = true;
		lblError.Text = message;
	}
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		if (String.IsNullOrEmpty(employeeList.SelectedValue))
		{
			showError("☞ Chọn nhân viên sau đó (Click 임직원을 선택하신 후에 클릭하여 주시기 바랍니다).");
		}
		else
		{
			if (bllEmployee.existsApprovor(employeeList.SelectedValue, "1", "0"))
			{
				showError("☞ Là nhân viên được đăng ký làm người phê duyệt (이미 결재자로 등록된 임직원 입니다).");
			}
			else
			{
				EmployeeInfo employee=new EmployeeInfo();
				employee.Upnid=employeeList.SelectedValue;

				int result = bllEmployee.insertApprovor(employee, "1", "0");

				Response.Redirect("approveList.aspx",true);
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
	{
		if (String.IsNullOrEmpty(visit.SelectedValue))
		{
            showError("☞ Chọn nhân viên sau đó Click (임직원을 선택하신 후에 클릭하여 주시기 바랍니다).");
		}
		else
		{	
			EmployeeInfo employee = new EmployeeInfo();
			employee.Upnid = visit.SelectedValue;

			int result = bllEmployee.deleteApprovor(employee, "1", "0");

			Response.Redirect("approveList.aspx", true);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
	{
		if (String.IsNullOrEmpty(employeeList.SelectedValue))
		{
            showError("☞ Chọn nhân viên sau đó Click (임직원을 선택하신 후에 클릭하여 주시기 바랍니다).");
		}
		else
		{
			if (bllEmployee.existsApprovor(employeeList.SelectedValue, "0", "1"))
			{
                showError("☞ Là nhân viên được đăng ký làm người phê duyệt (이미 결재자로 등록된 임직원 입니다).");
			}
			else
			{
				EmployeeInfo employee = new EmployeeInfo();
				employee.Upnid = employeeList.SelectedValue;

				int result = bllEmployee.insertApprovor(employee, "0", "1");

				Response.Redirect("approveList.aspx", true);
			}
		}
	}
	protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
	{
		if (String.IsNullOrEmpty(takeOut.SelectedValue))
		{
            showError("☞ Chọn nhân viên sau đó Click (임직원을 선택하신 후에 클릭하여 주시기 바랍니다).");
		}
		else
		{
			EmployeeInfo employee = new EmployeeInfo();
			employee.Upnid = takeOut.SelectedValue;

			int result = bllEmployee.deleteApprovor(employee, "0", "1");

			Response.Redirect("approveList.aspx", true);
		}
	}
}
