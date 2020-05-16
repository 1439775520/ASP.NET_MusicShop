<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="MusicManager.aspx.cs" Inherits="WebApplication1.Admin.MusicManager1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Assets/css/input.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pure-form">
        <fieldset>
            <%--genres表--%>
            <legend>后台管理<i class="fa fa-angle-double-right"></i>音乐管理
                <asp:Button ID="Button1" runat="server" CssClass="button-default pure-button-primary tools-button" Text="添加音乐" OnClick="Button1_Click" />
            </legend>
        </fieldset>
    </div>
    <table class="pure-table">
        <thead>
            <tr>
                <th>#</th>
                <th>音乐名称</th>
                <th>歌手名称</th>
                <th>标题</th>
                <th>单价</th>
                <th>图片</th>
                <th>编辑</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("AlbumId") %></td>
                        <td><%# Eval("Genres.Name") %></td>
                        <td><%# Eval("Artists.Name") %></td>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><%#  Eval("AlbumArtUrl") %><asp:Image ID="Image1" ImageUrl='<%# "~"+Eval("AlbumArtUrl") %>' runat="server" Width="40px" Height="40px" /></td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" CssClass="button-default pure-button-primary" runat="server" CommandArgument='<%#Eval("AlbumId") %>' CommandName="Edit">编辑</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" CssClass="button-default  button-error" runat="server" CommandArgument='<%#Eval("AlbumId") %>' CommandName="Delete">删除</asp:LinkButton></td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="6">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
                    <asp:Button ID="btnPrev" runat="server" Text="上页" OnClick="btnPrev_Click" />
                    <asp:Button ID="btnNext" runat="server" Text="下页" OnClick="btnNext_Click" />
                    <asp:Button ID="btnLast" runat="server" Text="尾页" OnClick="btnLast_Click" />


                </td>
            </tr>
        </tbody>



    </table>
</asp:Content>
