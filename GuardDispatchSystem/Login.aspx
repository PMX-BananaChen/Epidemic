<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GuardDispatchSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>疫情物資管控系統登錄界面</title>
    <style type="text/css">
         body, form {
            margin: 0;
            padding: 0;
            text-align: center;
            background-color: #;
        }
           

        .auto-style1 {
            width:100%;
           
            height: 876px;
        }
        .auto-style25 {
            width: 100%;
            height: 107px;
        }
        .auto-style33 {
            height: 73px;
        }
        .auto-style73 {
            height: 73px;
            width: 376px;
        }
        .auto-style76 {
            height: 232px;
        }
        .auto-style86 {
            width: 99%;
            height: 228px;
        }
        .auto-style93 {
            width: 308px;
            height: 232px;
        }
        .auto-style108 {
            width: 308px;
            height: 165px;
        }
        .auto-style109 {
            height: 165px;
        }
        .auto-style110 {
            width: 72px;
        }
        .auto-style118 {
            width: 147px;
        }
        .auto-style125 {
            width: 147px;
            height: 48px;
        }
        .auto-style127 {
            width: 72px;
            height: 48px;
        }
        .auto-style130 {
            width: 202px;
            height: 48px;
        }
        .auto-style131 {
            width: 202px;
        }
        .auto-style132 {
            width: 387px;
            height: 165px;
        }
        .auto-style133 {
            width: 387px;
            height: 232px;
        }
        .auto-style137 {
            height: 17px;
        }
        .auto-style139 {
            width: 72px;
            height: 17px;
        }
        .auto-style143 {
            width: 147px;
            height: 33px;
        }
        .auto-style144 {
            width: 202px;
            height: 33px;
        }
        .auto-style145 {
            width: 72px;
            height: 33px;
        }
        .auto-style146 {
            width: 147px;
            height: 58px;
        }
        .auto-style147 {
            width: 202px;
            height: 58px;
        }
        .auto-style148 {
            width: 72px;
            height: 58px;
        }
        .auto-style149 {
            height: 164px;
        }
        .auto-style150 {
            width: 389px;
            height: 165px;
        }
        .auto-style151 {
            width: 389px;
            height: 232px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1" style="background-image: url('Images/beijing22.jpg')">
            <tr>
                <td class="auto-style149" colspan="4">
                    <table class="auto-style25">
                        <tr>
                            <td class="auto-style73" style="font-family: 黑体; font-size: 40px; font-weight: bolder; text-align: right; color: #0099FF;">
                                <asp:Image ID="Image1" runat="server" Height="48px" ImageUrl="~/Images/logo.png" Width="115px" />
                            </td>
                            <td class="auto-style33" style="font-family: 黑体; font-size: 40px; font-weight: bolder; text-align: left; color: #0099FF;">
                                &nbsp; 疫 情 物 资 管 控 系 统</td>
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style150"></td>
                <td class="auto-style132">
                    <table class="auto-style86" style="border: medium outset #FFFFFF;">
                        <tr>
                            <td class="auto-style146" style="text-align: right">
                                <asp:Image ID="Image2" runat="server" Height="39px" ImageUrl="~/Images/tubiao.png" Width="44px" />
                            </td>
                            <td class="auto-style147" style="text-align: left; font-family: 黑体; font-weight: bolder; font-size: medium; color: #3399FF;">&nbsp;&nbsp; 用戶登錄</td>
                            <td class="auto-style148"></td>
                        </tr>
                        <tr>
                            <td class="auto-style143" style="text-align: right; font-weight: bold;">用戶名：</td>
                            <td class="auto-style144" style="text-align: left">
                                <asp:TextBox ID="txt_username" runat="server" Width="140px"></asp:TextBox>
                            </td>
                            <td class="auto-style145" style="color: #FF0000; font-size: small; font-weight: bold">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style137" style="text-align: center; font-weight: normal; color: #FF0000; font-size: small;" colspan="2">格式：PCN\Monica.Huang</td>
                            <td class="auto-style139" style="color: #FF0000; font-size: small; font-weight: bold"></td>
                        </tr>
                        <tr>
                            <td class="auto-style125" style="text-align: right; font-weight: bold;">密碼：</td>
                            <td class="auto-style130" style="text-align: left">
                                <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password" Width="138px"></asp:TextBox>
                            </td>
                            <td class="auto-style127"></td>
                        </tr>
                        <tr>
                            <td class="auto-style118">&nbsp;</td>
                            <td class="auto-style131" style="text-align: left">
                                &nbsp;
                                <asp:ImageButton ID="btn_login" runat="server" Height="30px" ImageUrl="~/Images/login.png" OnClick="btn_login_Click1" Width="75px" />
                            </td>
                            <td class="auto-style110">&nbsp;</td>
                        </tr>
                    </table>
                    </td>
                <td class="auto-style108" style="border-style: none; ">
                </td>
                <td class="auto-style109"></td>
            </tr>
            <tr>
                <td class="auto-style151"></td>
                <td class="auto-style133"></td>
                <td class="auto-style93"></td>
                <td class="auto-style76"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
