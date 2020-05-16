<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Assets/css/login.css" rel="stylesheet" />
    <link href="Assets/css/animate.min.css" rel="stylesheet" />
    <link href="Assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Assets/css/grids-responsive-min.css" rel="stylesheet" />
    <link href="Assets/css/input.css" rel="stylesheet" />
    <link href="Assets/css/main.css" rel="stylesheet" />
    <link href="Assets/css/pure-min.css" rel="stylesheet" />
    <link href="Assets/css/shop.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="login-container pure-g">
            <div class="pure-u-md-3-4">
            </div>
            <div class="pure-u-md-1-4">
                <h4>在线音乐商店</h4>
                <asp:Panel ID="login" runat="server">
                    <div class="pure-u-1 pure-u-md-2-3">
                        登录账号  
                    <br />
                        <asp:TextBox ID="login_id" runat="server"></asp:TextBox> 
                    </div>
                    <div class="pure-u-1 pure-u-md-2-3">
                        登录密码
                     
                    <br />
                        <asp:TextBox ID="login_pwd" TextMode="Password" runat="server"></asp:TextBox> 
                    </div>

                    <div class="pure-u-1 pure-u-md-2-3">
                        验证码
                    
                     
                    <br />
                               <asp:TextBox ID="login_Code"   runat="server"></asp:TextBox> 
                 
                    </div>

                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Handler1.ashx"  onclick="this.src=this.src+1" Width="100" Height="40"/>
                   
                </asp:Panel>
                <%--注册--%>
                <asp:Panel ID="rex" runat="server" CssClass="">
                    <div class="pure-u-1 pure-u-md-2-3">
                        登录账号  
                    <br />
                        
                        <asp:TextBox ID="reg_id" runat="server"></asp:TextBox> 
                    </div>
                    <div class="pure-u-1 pure-u-md-2-3">
                        登录密码
                     
                    <br /><asp:TextBox ID="reg_pwd" runat="server" TextMode="Password"></asp:TextBox> 
                    </div>
                    <div class="pure-u-1 pure-u-md-2-3">
                        确认密码
                     
                    <br />
                        <asp:TextBox ID="reg_pwd2" runat="server" TextMode="Password"></asp:TextBox> 
                    </div>
                    <div class="pure-u-1 pure-u-md-2-3">
                        用户姓名  
                    <br />
                       <asp:TextBox ID="reg_Name" runat="server"></asp:TextBox> 
                    </div>
                    <div class="pure-u-1 pure-u-md-2-3">
                        联系电话  
                    <br />
                       <asp:TextBox ID="reg_Phone" runat="server" TextMode="Phone"></asp:TextBox> 
                    </div>
                </asp:Panel>
                 <div>
                        <asp:Button ID="btnLogin" CssClass="pure-button  button-default pure-button-primary" runat="server" Text="登录" OnClick="btnLogin_Click" />


                        <asp:Button ID="btnReg" CssClass="pure-button  button-default " runat="server" Text="注册" OnClick="btnReg_Click" />
                    </div>
            </div>

        </div>


    </form>
</body>
</html>
