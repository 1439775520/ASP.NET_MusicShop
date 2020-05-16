<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Edit_MusicManager.aspx.cs" Inherits="WebApplication1.Admin.Edit_MusicManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="pure-form">
        <fieldset>
            <legend>后台管理<i class="fa fa-angle-double-right"></i>音乐管理
                <asp:Button ID="Button1" CssClass=" pure-button pure-button-primary tools-button" runat="server" Text="保存" OnClick="Button1_Click" />
                <asp:Button ID="Button2" CssClass="   pure-button  tools-button" runat="server" Text="返回" OnClick="Button2_Click" />
            </legend>
        </fieldset>
    </div>
    <asp:Label ID="Label1" runat="server" Text="音乐名称"></asp:Label>
    <asp:TextBox ID="MusicName" runat="server"></asp:TextBox>

     <asp:Label ID="Label2" runat="server" Text="类型名称"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>

    <asp:Label ID="Label3" runat="server" Text="歌手名称"></asp:Label>
    <asp:TextBox ID="MusicCreate" runat="server"></asp:TextBox>

      <asp:Label ID="Label4" runat="server" Text="音乐价格"></asp:Label>
    <asp:TextBox ID="MusicPrice" runat="server"></asp:TextBox>

    <asp:FileUpload ID="FileUpload1" runat="server" />
        
    <asp:Image ID="Image1" runat="server"     />

</asp:Content>
