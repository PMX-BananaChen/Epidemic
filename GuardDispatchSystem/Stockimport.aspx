<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Stockimport.aspx.cs" Inherits="GuardDispatchSystem.Stockimport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
         .auto-style111 {
            width: 100%;
            height: 114px;
        }
        .auto-style556 {
        width: 100%;
        height: 459px;
        border-color: #000000;
        border-width: 0;
        background-color: #f0f8ff;
    }
    .auto-style559 {
        height: 162px;
    }
        .border {
            height: 64px;
            width: 256px;
        }
         .auto-style635 {
             height: 39px;
             width: 56px;
         }
         .auto-style637 {
             height: 39px;
             width: 132px;
         }
         .auto-style640 {
             height: 39px;
             width: 65px;
         }
         .auto-style641 {
             width: 56px;
             height: 27px;
         }
         .auto-style643 {
             height: 27px;
             width: 132px;
         }
         .auto-style646 {
             height: 27px;
             width: 65px;
         }
         .auto-style647 {
             height: 38px;
             width: 56px;
         }
         .auto-style649 {
             height: 38px;
             width: 132px;
         }
         .auto-style652 {
             height: 38px;
             width: 65px;
         }
         .auto-style663 {
             height: 39px;
             width: 509px;
         }
         .auto-style664 {
             height: 27px;
             width: 509px;
         }
         .auto-style665 {
             height: 38px;
             width: 509px;
         }
         .auto-style672 {
             height: 39px;
             width: 183px;
         }
         .auto-style673 {
             height: 27px;
             width: 183px;
         }
         .auto-style674 {
             height: 38px;
             width: 183px;
         }
         .auto-style682 {
             height: 39px;
             width: 260px;
         }
         .auto-style683 {
             height: 27px;
             width: 260px;
         }
         .auto-style684 {
             height: 38px;
             width: 260px;
         }
         .auto-style697 {
             height: 39px;
             width: 15px;
         }
         .auto-style698 {
             height: 27px;
             width: 15px;
         }
         .auto-style699 {
             height: 38px;
             width: 15px;
         }
         .auto-style702 {
             height: 39px;
             width: 159px;
         }
         .auto-style703 {
             height: 27px;
             width: 159px;
         }
         .auto-style704 {
             height: 38px;
             width: 159px;
         }
         .auto-style706 {
             width: 100%;
             height: 61px;
         }
         .auto-style707 {
             width: 368px;
         }
         .auto-style710 {
             width: 331px;
         }
         .auto-style713 {
             width: 293px;
         }
         .auto-style714 {
             width: 134px;
             height: 162px;
         }
         .auto-style715 {
             width: 56px;
             height: 5px;
         }
         .auto-style716 {
             height: 5px;
             width: 260px;
         }
         .auto-style717 {
             height: 5px;
             width: 132px;
         }
         .auto-style718 {
             height: 5px;
             width: 159px;
         }
         .auto-style719 {
             height: 5px;
             width: 15px;
         }
         .auto-style720 {
             height: 5px;
             width: 509px;
         }
         .auto-style721 {
             height: 5px;
             width: 183px;
         }
         .auto-style722 {
             height: 5px;
             width: 65px;
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
    <asp:Panel ID="Panel_del" runat="server" BackColor="AliceBlue" Height="731px">
                    <table class="auto-style111" style="background-color: #F0F8FF">
                        <tr>
                            <td class="auto-style715"></td>
                            <td class="auto-style716"></td>
                            <td class="auto-style717" style="text-align: right"></td>
                            <td class="auto-style718" style="text-align: left"></td>
                            <td class="auto-style719"></td>
                            <td class="auto-style720"></td>
                            <td class="auto-style721"></td>
                            <td class="auto-style722"></td>
                        </tr>
                        <tr>
                            <td class="auto-style635"></td>
                            <td class="auto-style682"></td>
                            <td class="auto-style637" style="text-align: right; font-size: small; font-weight: bold;">物資類型：</td>
                            <td class="auto-style702" style="text-align: left">
                                <asp:DropDownList ID="DDL_Type" runat="server"  Height="25px"  Width="183px" AutoPostBack="True" OnSelectedIndexChanged="DDL_Type_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style697"></td>
                            <td class="auto-style663"></td>
                            <td class="auto-style672">&nbsp;</td>
                            <td class="auto-style640"></td>
                        </tr>
                        <tr>
                            <td class="auto-style641"></td>
                            <td class="auto-style683"></td>
                            <td class="auto-style643" style="text-align: right; font-size: small; font-weight: bold;">名稱：</td>
                            <td class="auto-style703" style="text-align: left">
                                <asp:DropDownList ID="DDL_Name" runat="server"  Height="25px"  Width="183px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style698">&nbsp;</td>
                            <td class="auto-style664"></td>
                            <td class="auto-style673">&nbsp;</td>
                            <td class="auto-style646"></td>
                        </tr>
                        <tr>
                            <td class="auto-style647"></td>
                            <td class="auto-style684"></td>
                            <td class="auto-style649" style="text-align: right; font-size: small; font-weight: bold;">數量：</td>
                            <td class="auto-style704" style="text-align: left">
                                <asp:TextBox ID="TxtQty" runat="server" Width="180px"></asp:TextBox>
                            </td>
                            <td class="auto-style699">
                                &nbsp;</td>
                            <td class="auto-style665">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="180px" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnImport" runat="server" Font-Bold="True" OnClick="btnImport_Click" Text="批量新增庫存" />
                            </td>
                            <td class="auto-style674">&nbsp;</td>
                            <td class="auto-style652"></td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" class="auto-style706">
                        <tr>
                            <td class="auto-style713">&nbsp;</td>
                            <td class="auto-style710">
                                <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="加入庫存" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" Font-Bold="True" OnClick="Button2_Click" Text="查詢庫存" />
                            </td>
                            <td class="auto-style707">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" class="auto-style556">
                        <tr>
                            <td class="auto-style714">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td class="auto-style559">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="White" BorderStyle="Solid" BorderWidth="3px" GridLines="Horizontal" Height="425px" Width="1030px" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="Plant" HeaderText="廠區">
                                        <HeaderStyle BackColor="#3399FF" ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GoodsType" HeaderText="物資類型" SortExpression="GoodsType">
                                        <HeaderStyle BackColor="#3399FF" Font-Size="Small" ForeColor="White" Height="30px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GoodsName" HeaderText="名稱" SortExpression="GoodsName">
                                        <HeaderStyle BackColor="#3399FF" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="數量" SortExpression="Qty">
                                        <HeaderStyle BackColor="#3399FF" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UpdateTime" HeaderText="更改時間" HtmlEncodeFormatString="False" SortExpression="UpdateTime">
                                        <HeaderStyle BackColor="#3399FF" Font-Size="Small" ForeColor="White" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <RowStyle Font-Size="Small" />

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
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                </asp:Panel>
</asp:Content>
