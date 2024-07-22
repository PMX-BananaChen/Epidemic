<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StockReceive.aspx.cs" Inherits="GuardDispatchSystem.StockReceive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style123 {
            width: 100%;
            height: 270px;
            border-color: #000000;
            border-width: 0;
            background-color: #f0f8ff;
        }
        .auto-style164 {
        height: 68px;
    }
        .auto-style221 {
            width: 273px;
            height: 68px;
        }
        .auto-style306 {
            width: 342px;
            height: 46px;
        }
        .auto-style307 {
            width: 154px;
            height: 46px;
        }
        .auto-style309 {
            width: 273px;
            height: 46px;
        }
        .auto-style310 {
            height: 46px;
        }
        .auto-style316 {
            width: 342px;
            height: 68px;
        }
        .auto-style330 {
            width: 296px;
            height: 46px;
        }
        .auto-style332 {
            width: 296px;
            height: 50px;
        }
        .auto-style334 {
            width: 154px;
            height: 42px;
        }
        .auto-style335 {
            width: 296px;
            height: 42px;
        }
        .auto-style336 {
            width: 273px;
            height: 42px;
        }
        .auto-style337 {
            height: 42px;
        }
        .auto-style338 {
            width: 342px;
            height: 39px;
        }
        .auto-style339 {
            width: 154px;
            height: 39px;
        }
        .auto-style340 {
            width: 296px;
            height: 39px;
        }
        .auto-style341 {
            width: 273px;
            height: 39px;
        }
        .auto-style342 {
            height: 39px;
        }
        .auto-style343 {
            width: 342px;
            height: 41px;
        }
        .auto-style344 {
            width: 154px;
            height: 41px;
        }
        .auto-style345 {
            width: 296px;
            height: 41px;
        }
        .auto-style346 {
            width: 273px;
            height: 41px;
        }
        .auto-style347 {
            height: 41px;
        }
        .auto-style348 {
            width: 342px;
            height: 37px;
        }
        .auto-style349 {
            width: 154px;
            height: 37px;
        }
        .auto-style350 {
            width: 296px;
            height: 37px;
        }
        .auto-style351 {
            width: 273px;
            height: 37px;
        }
        .auto-style352 {
            height: 37px;
        }
        .auto-style353 {
            width: 342px;
            height: 50px;
        }
        .auto-style354 {
            width: 273px;
            height: 50px;
        }
        .auto-style355 {
            height: 50px;
        }
        .auto-style356 {
            width: 342px;
            height: 33px;
        }
        .auto-style357 {
            width: 154px;
            height: 33px;
        }
        .auto-style358 {
            width: 296px;
            height: 33px;
        }
        .auto-style359 {
            width: 273px;
            height: 33px;
        }
        .auto-style360 {
            height: 33px;
        }
        .auto-style361 {
            width: 342px;
            height: 42px;
        }
        


td { font-size: 11pt}
a { color: #000000; text-decoration: none}
a:hover { color:#E78a29; text-decoration: none}

th {

    background: #33CCFF;   /*url('/Images/th.jpg') repeat;*/
    height:20px;

}


.bubufxPagerCss table
{
    text-align:center;
    margin:auto;
}
.bubufxPagerCss table td
{
    border:0px;
    padding:5px;
}
.bubufxPagerCss td
{
    border-left: #ffffff 3px solid;
    border-right: #ffffff 3px solid;
    border-bottom: #ffffff 3px solid;
}
.bubufxPagerCss a
{
    color:#231815;text-decoration:none;padding:3px 6px 3px 6px; margin: 0 0 0 4px; text-align:center; border:1px solid #CCC;
}
.bubufxPagerCss span
{
     color:#fefefe;background-color:#289D2A; padding:3px 6px 3px 6px; margin: 0 0 0 4px; text-align:center; font-weight:bold; border:1px solid #CCC;
}





    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="PanelAll" runat="server" BackColor="AliceBlue" Height="818px">
        <asp:Panel ID="Panel_add" runat="server" Height="813px">
            <table cellpadding="0" cellspacing="0" class="auto-style123">
                <tr>
                    <td class="auto-style356">&nbsp;</td>
                    <td class="auto-style357" style="text-align: right; font-size: small;">&nbsp;</td>
                    <td class="auto-style358" style="text-align: left">
                        &nbsp;</td>
                    <td class="auto-style359" style="text-align: left">
                        &nbsp;</td>
                    <td class="auto-style360">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style356"></td>
                    <td class="auto-style357" style="text-align: right; font-size: small; font-weight: bold;">廠區：</td>
                    <td class="auto-style358" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_Plant" runat="server" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style359" style="text-align: left"></td>
                    <td class="auto-style360"></td>
                </tr>
                <tr>
                    <td class="auto-style361"></td>
                    <td class="auto-style334" style="text-align: right; font-size: small; font-weight: bold;">BU：</td>
                    <td class="auto-style335" style="text-align: left">
                        &nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_BU" runat="server" Height="23px" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style336" style="text-align: left"></td>
                    <td class="auto-style337"></td>
                </tr>
                <tr>
                    <td class="auto-style338"></td>
                    <td class="auto-style339" style="text-align: right; font-size: small; font-weight: bold;">领用人工号：</td>
                    <td class="auto-style340" style="text-align: left">&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txt_empid" runat="server" Width="157px" OnTextChanged="txt_empid_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="auto-style341" style="text-align: left">
                        </td>
                    <td class="auto-style342"></td>
                </tr>
                <tr>
                    <td class="auto-style343"></td>
                    <td class="auto-style344" style="text-align: right; font-size: small; font-weight: bold;">领用人姓名：</td>
                    <td class="auto-style345" style="text-align: left">&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txt_name" runat="server" Width="157px"></asp:TextBox>
                    </td>
                    <td class="auto-style346" style="text-align: left"></td>
                    <td class="auto-style347"></td>
                </tr>
                <tr>
                    <td class="auto-style306"></td>
                    <td class="auto-style307" style="text-align: right; font-size: small; font-weight: bold;">物資類型：</td>
                    <td class="auto-style330" style="text-align: left">&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_type" runat="server" Height="24px" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style309" style="text-align: left"></td>
                    <td class="auto-style310"></td>
                </tr>
                <tr>
                    <td class="auto-style343"></td>
                    <td class="auto-style344" style="text-align: right; font-size: small; font-weight: bold;">
                        物資名稱：</td>
                    <td class="auto-style345" style="text-align: left">&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_name" runat="server" Height="21px" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style346" style="text-align: left"></td>
                    <td class="auto-style347"></td>
                </tr>
                <tr>
                    <td class="auto-style348"></td>
                    <td class="auto-style349" style="text-align: right; font-size: small; font-weight: bold;">數量：</td>
                    <td class="auto-style350" style="text-align: left">&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtQty" runat="server" Width="157px"></asp:TextBox>
                    </td>
                    <td class="auto-style351" style="text-align: left"></td>
                    <td class="auto-style352"></td>
                </tr>
                <tr>
                    <td class="auto-style353"></td>
                    <td class="auto-style355" style="text-align: right; font-size: small; font-weight: bold;">備註：</td>
                    <td class="auto-style332" style="text-align: left">&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtRemark" runat="server" Width="157px"></asp:TextBox>
                    </td>
                    <td class="auto-style354" style="text-align: left">
                    </td>
                    <td class="auto-style355"></td>
                </tr>
                <tr>
                    <td class="auto-style316">&nbsp;</td>
                    <td class="auto-style2" colspan="2" style="text-align: center; font-size: small; font-weight: bold;">
                        <asp:Button ID="BtnOK" runat="server" Font-Bold="True" OnClick="BtnOK_Click" Text="確定領用" />
                    </td>
                    <td class="auto-style221" style="text-align: left">&nbsp;</td>
                    <td class="auto-style164">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
