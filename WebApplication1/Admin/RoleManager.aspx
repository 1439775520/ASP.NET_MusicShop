<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="RoleManager.aspx.cs" Inherits="WebApplication1.Admin.RoleManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Assets/css/input.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pure-form">
        <fieldset>
            <legend>后台管理<i class="fa fa-angle-double-right"></i>角色管理
            
            </legend>
        </fieldset>
    </div>
    <div>
        
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">编号</th>
                    <th scope="col">角色名称</th>
                    
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server" >
                    <ItemTemplate>

                        <tr>
                            <th scope="row"><%# Eval("RoleId") %></th>
                            <td><%# Eval("Name") %></td>
                            
                        </tr>

                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

</asp:Content>
