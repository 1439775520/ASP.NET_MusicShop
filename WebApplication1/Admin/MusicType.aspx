<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="MusicType.aspx.cs" Inherits="WebApplication1.Admin.MusicManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Assets/css/input.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pure-form">
        <fieldset>
            <%--genres表--%>
            <legend>后台管理<i class="fa fa-angle-double-right"></i>类型管理
                <asp:Button ID="Button1" runat="server" CssClass="button-default pure-button-primary tools-button" Text="添加音乐类型" OnClick="Button1_Click" />
            </legend>
        </fieldset>
    </div>
    <table class="pure-table">
        <thead>
            <tr>
                <th>#</th>
                <th>Make</th>
                <th>Model</th>
                <th>Year</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate> 
                   <tr>
                            <th scope="col"><%# Eval("GenreId") %></th>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Description").ToString().Length>30?Eval("Description").ToString().Substring(0,30)+"...":Eval("Description") %>...</td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" CssClass="button-default pure-button-primary" runat="server"  CommandArgument='<%#Eval("GenreId") %>'  CommandName="Edit">编辑</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" CssClass="button-default  button-error" runat="server"     CommandArgument='<%#Eval("GenreId") %>'  CommandName="Delete">删除</asp:LinkButton></td>
                         
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
