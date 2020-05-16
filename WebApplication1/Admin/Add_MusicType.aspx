<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Add_MusicType.aspx.cs" Inherits="WebApplication1.Admin.Add_MusicType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="pure-form">
        <fieldset>
            <legend>类型管理&nbsp;&nbsp;<i class="fa fa-angle-double-right"></i>&nbsp;&nbsp;类型信息
                <asp:Button ID="Button2" runat="server" Text="返回" CssClass="pure-button tools-button" OnClick="Button2_Click" />
                <asp:Button ID="Button1" runat="server" Text="保存" CssClass="pure-button pure-button-primary tools-button" OnClick="Button1_Click" />
            </legend>
        </fieldset>
        <div class="pure-g">
            <div class="pure-u-2-3">
                <asp:Label ID="Label1" runat="server" Text="音乐名称"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div class="pure-u-2-3">
                   <asp:Label ID="Label2" runat="server" Text="音乐描述"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
     </div>
</asp:Content>
