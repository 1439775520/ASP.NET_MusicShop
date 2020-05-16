<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="WebApplication1.Admin.UserManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Assets/css/input.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pure-form">
        <fieldset>
            <legend>后台管理<i class="fa fa-angle-double-right"></i>用户管理
                <asp:Button ID="Button1" CssClass=" pure-button pure-button-primary tools-button" runat="server" Text="保存" OnClick="Button1_Click" />
                <asp:Button ID="Button2" CssClass="   pure-button  tools-button" runat="server" Text="返回" OnClick="Button2_Click" />
            </legend>
        </fieldset>
    </div>

     <table class="pure-table">
        <thead>
            <tr>
                <th>编号</th>
                <th>账号</th>
                <th>姓名</th>
                <th>电话</th>
                <th>状态</th>
                <th>图片</th>
                <th>编辑</th>
            </tr>
        </thead>
        <tbody>
        
           
        </tbody>



    </table>
    
    <script src="../Assets/js/jquery-3.4.1.min.js"></script>
    <script src="js/usermanager.js"></script>
</asp:Content>
