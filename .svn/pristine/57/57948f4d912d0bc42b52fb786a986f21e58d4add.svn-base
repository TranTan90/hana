<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="admin_Registration_Registration"
    MasterPageFile="~/admin/admin.master" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="registration" runat="server">
    <div style="width: 100%; top: 1px; " class="col-md-8 offset-md-2 container-fluid">
        <div style="width: 100%; height: 50px; background-color: #205AA7">
        </div>
        <div class=" mb-5">
            <h1 style="text-align: center; color: Blue; font-family: Times New Roman; font-size: 45px">
                Registration</h1>
                
        </div>
        <form class="col-11 ">
        <fieldset>
            <legend>Account Information</legend>
            <div class="form-row">
                <div class="col-sm-2">
                    <label>  ID </label>
                    <asp:RequiredFieldValidator runat="server" ID="ckeckid" ControlToValidate="txtid" ErrorMessage="Vui long dien thong tin" CssClass="text-danger">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtid" runat="server" CssClass="form-control"> </asp:TextBox>
                    
                </div>
                <div class="col-sm-2 mb-4">
                    <label>
                        SN</label>
                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtsn" ErrorMessage="Vui long dien thong tin" CssClass="text-danger">*</asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txtsn" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <label>
                        GIVENNAME</label>
                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtgvname" ErrorMessage="Vui long dien thong tin" CssClass="text-danger">*</asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txtgvname" CssClass="form-control"></asp:TextBox>
                </div>
                <%--<div class="col-sm-2">
                    <label>
                        DISPLAYNAME</label>
                    <asp:TextBox runat="server" ID="txtdisname" CssClass="form-control"></asp:TextBox>
                </div>--%>
                
                <div class=" col-sm-2">
                    <label>
                        ENGNAME</label>
                    <asp:TextBox runat="server" ID="txtelname" CssClass="form-control"></asp:TextBox>
                </div>
            
                
                <div class="col-sm-2 mb-4">
                    <asp:Label runat="server" ID="labeltile"></asp:Label> 
                    <label>TITLE</label>
                      <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="idtitle" ErrorMessage="Vui long dien thong tin" CssClass="text-danger">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:DropDownList runat="server" ID="idtitle" CssClass="dropdown form-control" Width="100%" Height="35px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>G3</asp:ListItem>                 <%--Staff/사원--%>
                        <asp:ListItem>GS</asp:ListItem>                 <%--Senior staff/주임--%>
                        <asp:ListItem>G4</asp:ListItem>                 <%--Assistant Manage/대리--%>
                        <asp:ListItem>G5</asp:ListItem>                 <%--Manager/과장--%>
                        <asp:ListItem>G6</asp:ListItem>                 <%--Deputy Senior Manager/차장--%>
                        <asp:ListItem>G7</asp:ListItem>                 <%--Senior Manager/부장--%>
                        <asp:ListItem>M3</asp:ListItem>                 <%--Research Engineer/선임--%>
                        <asp:ListItem>M4</asp:ListItem>                 <%--Senior Research Engineer/책임--%>
                        <asp:ListItem>M5</asp:ListItem>                 <%--Principal Research Engineer/수석--%>
                        <asp:ListItem>M6</asp:ListItem>                 <%--Chief Senior Manager/담당--%>
                        <asp:ListItem>D1</asp:ListItem>                 <%--Director/이사--%>
                        <asp:ListItem>CO</asp:ListItem>                 <%--General Director/법인장--%>
                    </asp:DropDownList>

                </div>
                <div class="col-sm-2">
                    <label>
                        DEPARTMENT</label>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="iddpm" ErrorMessage="Vui long dien thong tin" CssClass="text-danger">*</asp:RequiredFieldValidator> 
                    <asp:DropDownList runat="server" ID="iddpm" CssClass=" dropdown form-control">
                    <asp:ListItem></asp:ListItem>
                        <asp:ListItem>V22000</asp:ListItem>
                        <asp:ListItem>V23110</asp:ListItem>
                        <asp:ListItem>V23120</asp:ListItem>
                        <asp:ListItem>V22000</asp:ListItem>
                        <asp:ListItem>V24000</asp:ListItem>
                        <asp:ListItem>V24100</asp:ListItem>
                        <asp:ListItem>V24200</asp:ListItem>
                        <asp:ListItem>V25000</asp:ListItem>
                        <asp:ListItem>V25100</asp:ListItem>
                        <asp:ListItem>V25200</asp:ListItem>
                        <asp:ListItem>V26000</asp:ListItem>
                        <asp:ListItem>V26100</asp:ListItem>
                        <asp:ListItem>V26200</asp:ListItem>
                        <asp:ListItem>V26300</asp:ListItem>
                        <asp:ListItem>V26400</asp:ListItem>
                        <asp:ListItem>V27000</asp:ListItem>
                        <asp:ListItem>V28000</asp:ListItem>
                        <asp:ListItem>etc</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2">
                    <label>
                        COMPANY</label>
                    <asp:TextBox ID="txtcompany" runat="server" CssClass="form-control" > </asp:TextBox>
                   
                </div>
                <div class="col-sm-2 mb-4">
                    <label>
                        OFFICE NAME</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <label>
                        OFF PHONENUMBER</label>
                    <asp:TextBox ID="txtoffphone" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                
                <div class="col-sm-2">
                    <label>
                        MOBILEPHONENUMBR</label>
                    <asp:TextBox ID="txtmobiphone" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                
                
                <div class="col-sm-2 mb-4">
                    <label>
                        COUNTRY</label>
                    <asp:TextBox ID="txtcountry" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <label>
                        PassWord</label>
                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtpass" ErrorMessage="Vui long dien thong tin" CssClass="text-danger">*</asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txtpass" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-sm-3">
                    <label>
                        EMAL ADDRESS</label>
                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
               
                </div>
             
            </div>
                <div class="col-sm-4" style =" float:right" >
            
              <asp:Button runat="server" ID="regis" CssClass=" btn btn-primary" Text="Registration" 
                        onclick="regis_Click" />
              <input type="reset" class=" btn btn-primary" value="Cancel" />
            
               </div>
        </fieldset>
    
     
        </form>
        
    </div>
    </div>
</asp:Content>
