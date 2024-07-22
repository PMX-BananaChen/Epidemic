<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StockReport.aspx.cs" Inherits="GuardDispatchSystem.StockReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style10 {
            width: 100%;
            height: 152px;
            background-color: #E3ECF3;
        }
        .auto-style12 {
            width: 153px;
        }
        .auto-style14 {
            width: 85px;
        }
        .auto-style16 {
            width: 153px;
            height: 50px;
        }
        .auto-style18 {
            width: 85px;
            height: 50px;
        }
        .auto-style19 {
            height: 50px;
        }
        .auto-style20 {
            width: 100%;
        height: 547px;
    }
        .auto-style21 {
            width: 1115px;
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




    .auto-style22 {
        height: 395px;
    }
    .auto-style23 {
        width: 1115px;
        height: 395px;
    }




        .auto-style25 {
            width: 153px;
            height: 57px;
        }
        .auto-style27 {
            width: 85px;
            height: 57px;
        }
        .auto-style28 {
            height: 57px;
        }
        .auto-style29 {
            width: 327px;
        }
        .auto-style30 {
            width: 327px;
            height: 57px;
        }
        .auto-style31 {
            width: 327px;
            height: 50px;
        }
        .auto-style32 {
            width: 266px;
        }
        .auto-style33 {
            width: 266px;
            height: 57px;
        }
        .auto-style34 {
            width: 266px;
            height: 50px;
        }




    .auto-style35 {
        width: 100%;
        height: 170px;
    }
    .auto-style36 {
        height: 55px;
    }




        .auto-style37 {
            width: 154px;
        }
        .auto-style38 {
            height: 57px;
            width: 154px;
        }
        .auto-style39 {
            height: 50px;
            width: 154px;
        }




        .auto-style40 {
            width: 327px;
            height: 48px;
        }
        .auto-style41 {
            width: 153px;
            height: 48px;
        }
        .auto-style42 {
            width: 266px;
            height: 48px;
        }
        .auto-style43 {
            width: 85px;
            height: 48px;
        }
        .auto-style44 {
            height: 48px;
            width: 154px;
        }
        .auto-style45 {
            height: 48px;
        }
        .auto-style46 {
            height: 395px;
            width: 332px;
        }
        .auto-style47 {
            width: 265px;
        }
        .auto-style48 {
            width: 332px;
        }




    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table cellpadding="0" cellspacing="0" class="auto-style10">
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style32">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style37">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style40"></td>
            <td class="auto-style41" style="text-align: right">廠區：</td>
            <td class="auto-style42" style="text-align: left">
                <asp:DropDownList ID="DDL_Plant" runat="server" Width="210px">
                </asp:DropDownList>
            </td>
            <td class="auto-style43"></td>
            <td class="auto-style44"></td>
            <td class="auto-style45"></td>
        </tr>
        <tr>
            <td class="auto-style30"></td>
            <td class="auto-style25" style="text-align: right">物資類型：</td>
            <td class="auto-style33" style="text-align: left">
                                <asp:DropDownList ID="DDL_Type" runat="server"  Height="25px"  Width="210px" AutoPostBack="True" OnSelectedIndexChanged="DDL_Type_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
            <td class="auto-style27"></td>
            <td class="auto-style38"></td>
            <td class="auto-style28"></td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style12" style="text-align: right">名稱：</td>
            <td class="auto-style32" style="text-align: left">
                                <asp:DropDownList ID="DDL_Name" runat="server"  Height="25px"  Width="210px">
                                </asp:DropDownList>
                            </td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style37">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style31"></td>
            <td class="auto-style16" style="text-align: right">日期：</td>
            <td class="auto-style34" style="text-align: left">
                <input id="txt_startDate" runat="server" aria-checked="undefined" aria-disabled="False" class="Wdate" contenteditable="false" name="Text2" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" style="width: 96px; height: 19px;" type="text" visible="True" /> - <input id="txt_endDate" runat="server" class="Wdate" onclick="    WdatePicker({ dateFmt: 'yyyy-MM-dd' });" size="20" style="height: 19px; width: 94px;" type="text" /></td>
            <td class="auto-style18">
                <asp:ImageButton ID="ImgSearch" runat="server" Height="32px" ImageUrl="~/Images/Search.PNG" Width="75px" OnClick="ImgSearch_Click" />
            </td>
            <td class="auto-style39">
                <asp:ImageButton ID="imgExport" runat="server" Height="39px" ImageUrl="~/Images/export.gif" OnClick="imgExport_Click" Width="77px" />
            </td>
            <td class="auto-style19"></td>
        </tr>
    </table>
    <asp:Panel ID="Panel_Date" runat="server">
        <table cellpadding="0" cellspacing="0" class="auto-style20">
            <tr>
                <td class="auto-style46"></td>
                <td class="auto-style23">
                    <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  ForeColor="Black" GridLines="Horizontal" RowStyle-HorizontalAlign="Center" Width="732px" PageSize="15" OnPageIndexChanging="gridView_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Plant" HeaderText="廠區" />
                            <asp:BoundField DataField="UserName" HeaderText="系統操作員" >
                            <HeaderStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GoodsType" HeaderText="物資類型" ItemStyle-HorizontalAlign="Center" readonly="true" SortExpression="Id">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GoodsName" HeaderStyle-Width="90px" HeaderText="名稱" ItemStyle-HorizontalAlign="Center" readonly="true">
                            <HeaderStyle Width="90px" />
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Qty" HeaderStyle-Width="150px" HeaderText="入庫數量" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundField>
                            <%--  <asp:BoundField DataField="CertificateProject" HeaderStyle-Width="130px" HeaderText="總領取數量" ItemStyle-HorizontalAlign="Center" readonly="true" SortExpression="CertificateProject">
                        <HeaderStyle HorizontalAlign="Center" Width="130px" />
                        <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundField>--%>
                            <asp:BoundField DataField="UpdateTime" HeaderText="時間" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#003366" ForeColor="Black" />
                        <HeaderStyle BackColor="#438EB9" Font-Bold="True" Font-Names="Book Antiqua"  ForeColor="White" Height="29px" />
                        <PagerStyle BackColor="White" CssClass="bubufxPagerCss" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style48">&nbsp;</td>
                <td class="auto-style21" style="text-align: right">
                    <br />
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="總庫存數量："></asp:Label>
                    <asp:Label ID="LabCount" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Panel>
<asp:Panel ID="Panel_Errorimage" runat="server" Height="216px" Visible="False">
    <table cellpadding="0" cellspacing="0" class="auto-style35">
        <tr>
            <td class="auto-style36"></td>
            <td class="auto-style36"></td>
            <td class="auto-style36"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red" Text="當日暫時沒有新入庫的物資資料！"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<br />
<br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
