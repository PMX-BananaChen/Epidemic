using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuardDispatchSystem
{
    public partial class StockReport : System.Web.UI.Page
    {
        DataBase da = new DataBase();
        public static string reportname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["ID"].ToString();
            if (ID == "999")
            {
                reportname = "A";
            }
            else
            {
                reportname = "";
            }
            if (!IsPostBack)
            {
                BindDate();
                BindGridview();
            }
         
          
        }
        protected void BindDate()
        {

            txt_startDate.Focus();
            DateTime time = DateTime.Now;
            string nowtime = time.ToString("yyyy-MM-dd");
            txt_startDate.Value = nowtime;
            txt_endDate.Value = nowtime;

            string plant = "";
           // string sql = "";
            if(reportname == "A")
            {
                plant = "";
            }
            else
            {
                plant = Session["Plant"].ToString();
            }
             
            DataTable dsType = da.GetRows("select * from dbo.GoodsType ").Tables[0];
            DataTable dsName = da.GetRows("select * from dbo.GoodsName ").Tables[0];
            DataTable dsPlant = new DataTable();
            if(plant!="")
            {
                 dsPlant = da.GetRows("select * from dbo.Plant where Plant='" + plant + "'  ").Tables[0];
            }
            else
            {
                 //dsPlant = da.GetRows("select * from dbo.Plant where Plant='ALL'  ").Tables[0];
                dsPlant = da.GetRows("select * from dbo.Plant  ").Tables[0];
            }
            
            if (dsType.Rows.Count > 0 && dsName.Rows.Count > 0)
            {


                DDL_Type.Items.Clear();
                DDL_Type.DataSource = dsType;
                DDL_Type.DataTextField = "GoodsType";
                DDL_Type.DataValueField = "TypeID";
                DDL_Type.DataBind();
                DDL_Type.Items.Insert(0, new ListItem("", ""));



                DDL_Name.Items.Clear();
                DDL_Name.DataSource = dsName;
                DDL_Name.DataTextField = "GoodsName";
                DDL_Name.DataValueField = "NameID";
                DDL_Name.DataBind();
                DDL_Name.Items.Insert(0, new ListItem("", ""));


                DDL_Plant.Items.Clear();
                DDL_Plant.DataSource = dsPlant;
                DDL_Plant.DataTextField = "Plant";
                DDL_Plant.DataValueField = "PlantID";
                DDL_Plant.DataBind();
                //DDL_Plant.Items.Insert(0, new ListItem("", ""));
                if (reportname == "A")
                {
                    DDL_Plant.Enabled = true;
                }
                else
                {
                    DDL_Plant.Enabled = false;
                }
                


            }
        }
        protected void ImgSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGridview();
        }

        public void BindGridview()
        {
            int qty = 0;
            string type = DDL_Type.SelectedItem.ToString();
            string name = DDL_Name.SelectedItem.ToString();//
            string starttime = txt_startDate.Value;//發證日期CertificateDate
            string endtime = txt_endDate.Value;//發證日期
            string plant = "";
            if (DDL_Plant.SelectedItem.ToString() =="ALL")
            {
                plant = "";
            }
            else
            {
                plant = DDL_Plant.SelectedItem.ToString();
            }
          
            string sql = "";
            if (type != "")
            {
                sql += " and GoodsType='" + type + "'";
            }
            if (name != "")
            {
                sql += " and GoodsName='" + name + "'";
            }
            if (plant != "")
            {
                sql += " and Plant='" + plant + "'";
            }
            if (starttime != "" && endtime != "")
            {

                sql += "  and CONVERT (varchar(10),UpdateTime,120)>='" + starttime + "' and CONVERT (varchar(10),UpdateTime,120)<='" + endtime + "'";
            }
            DataSet ds = da.GetRows(" select Plant, GoodsType,GoodsName,Qty,UserName,UpdateTime From ImportLog where 1=1  " + sql + " ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Qty"].ToString()) + qty;
                }
                LabCount.Text = Convert.ToString(qty);
                Panel_Date.Visible = true;
                Panel_Errorimage.Visible = false;
            }
            else
            {
                //RegisterStartupScript("", "<script>alert('所查結果為空，請確認查詢條件！')</script>");
                gridView.DataSource = ds;
                gridView.DataBind();
                Panel_Date.Visible = false;
                Panel_Errorimage.Visible = true;
            }




        }

       

       

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindGridview();
        }

        protected void DDL_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_Name.Items.Clear();
            DataTable ds = da.GetRows("select distinct c.* From GoodsType a ,Goods_Stock b , GoodsName c where a.TypeID=b.TypeID and b.NameID=c.NameID  and a.GoodsType='" + DDL_Type.SelectedItem + "'").Tables[0];
            DDL_Name.DataSource = ds;
            DDL_Name.DataTextField = "GoodsName";
            DDL_Name.DataValueField = "NameID";
            DDL_Name.DataBind();
            DDL_Name.Items.Insert(0, new ListItem("", ""));
        }

        protected void imgExport_Click(object sender, ImageClickEventArgs e)
        {
           
            string type = DDL_Type.SelectedItem.ToString();
            string name = DDL_Name.SelectedItem.ToString();//
            string starttime = txt_startDate.Value;//發證日期CertificateDate
            string endtime = txt_endDate.Value;//發證日期
            string plant = DDL_Plant.SelectedItem.ToString(); 
            string sql = "";
            if (plant == "ALL")
                plant = "";
            if (type != "")
            {
                sql += " and GoodsType='" + type + "'";
            }
            if (name != "")
            {
                sql += " and GoodsName='" + name + "'";
            }
            if (plant != "")
            {
                sql += " and Plant='" + plant + "'";
            }
            if (starttime != "" && endtime != "")
            {

                sql += "  and CONVERT (varchar(10),UpdateTime,120)>='" + starttime + "' and CONVERT (varchar(10),UpdateTime,120)<='" + endtime + "'";
            }
            DataSet ds = da.GetRows(" select Plant, GoodsType,GoodsName,Qty,UserName,UpdateTime From ImportLog where 1=1  " + sql + " ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                CreateExcelByXml(dt, plant+" 疫情物資庫存詳情報表", "ExceptionSystem (" + DateTime.Now.ToShortDateString() + ").xls");

               
            }
          

           

        }


        /// <summary>
        /// xml格式生成excel文件并存盘;
        /// </summary>
        /// <param name="page">生成报表的页面，没有传null</param>
        /// <param name="dt">数据表</param>
        /// <param name="TableTitle">报表标题，sheet1名</param>
        /// <param name="fileName">存盘文件名，全路径</param>
        /// <param name="IsDown">生成文件后是否提示下载,只有web下才有效</param>
        public void CreateExcelByXml(DataTable dt, String TableTitle, string fileName)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            strb.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            strb.Append("<head> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>");
            strb.Append("<style>");
            strb.Append("body");
            strb.Append("{mso-style-parent:style0;");
            strb.Append("font-family:\"Times New Roman\", serif;");
            strb.Append("mso-font-charset:0;");
            strb.Append("mso-number-format:\"@\";}");
            strb.Append("table");
            //strb.Append(" {border-collapse:collapse;margin:1em 0;line-height:20px;font-size:12px;color:#222; margin:0px;}");
            strb.Append(" {border-collapse:collapse;margin:1em 0;line-height:20px;color:#222; margin:0px;}");
            strb.Append("thead tr td");
            strb.Append(" {background-color:#e3e6ea;color:#6e6e6e;text-align:center;font-size:14px;}");
            strb.Append("tbody tr td");
            strb.Append(" {font-size:12px;color:#000;}");
            strb.Append(" </style>");
            strb.Append("<!--[if gte mso 9]>");
            strb.Append(" <xml>");
            strb.Append(" <x:ExcelWorkbook>");

            strb.Append("  <x:ExcelWorksheets>");

            strb.Append("   <x:ExcelWorksheet>");

            strb.Append("    <x:Name>" + TableTitle + "</x:Name>");

            strb.Append("    <x:WorksheetOptions>");

            strb.Append("      <x:Print>");

            strb.Append("       <x:ValidPrinterInfo />");

            strb.Append("      </x:Print>");

            strb.Append("    </x:WorksheetOptions>");

            strb.Append("   </x:ExcelWorksheet>");

            strb.Append("  </x:ExcelWorksheets>");

            strb.Append("</x:ExcelWorkbook>");
            strb.Append(" </xml>");
            strb.Append("<![endif]-->");
            strb.Append(" </head> <body> ");
            strb.Append(" <table style=\"border-right: 1px solid #CCC;border-bottom: 1px solid #CCC;text-align:center;\"> <thead><tr>");
            //合格所有列并显示标题
            strb.Append(" <td style=\"text-align:center;font-size:18px;height:40px;\" colspan=\"" + (dt.Columns.Count ) + "\" ><b>");
            strb.Append(TableTitle);
            strb.Append(" </b></td> ");
            strb.Append(" </tr>");
            strb.Append(" </thead><tbody><tr style=\"height:20px;\">");

            if (dt != null)
            {
                //写列标题 
                int columncount = dt.Columns.Count;
                strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;background:#CCC;\"> <b>" + "廠區" + " </b> </td>");
                strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;background:#CCC;\"> <b>" + "物資類型" + " </b> </td>");
                strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;background:#CCC;\"> <b>" + "名稱" + " </b> </td>");
                strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;background:#CCC;\"> <b>" + "入庫數量" + " </b> </td>");
                strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;background:#CCC;\"> <b>" + "系統操作員" + " </b> </td>");
                strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;background:#CCC;\"> <b>" + "時間" + " </b> </td>");
               
                strb.Append(" </tr>");
                //写数据 
                int qty = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strb.Append(" <tr style=\"height:20px;\">");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //if (j != 1)
                        //{
                            //if (j != 18)
                            //{
                            strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;\">" + dt.Rows[i][j].ToString() + " </td>");
                            
                            //}
                        //}
                    }
                    qty = Convert.ToInt32(dt.Rows[i]["Qty"].ToString()) + qty;
                    //strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;\"> <b> </b> <b> </b><b>" + "物資庫存數量總和：" + " </b>" + qty + " </td>");
                    strb.Append(" </tr>");
                }
                strb.Append(" <td style=\"vnd.ms-excel.numberformat:@;text-align:center;\"> <b> </b> <b> </b><b>" + "物資庫存數量總和：" + " </b>" + qty + " </td>");
                strb.Append(" </tr>");

            }
            strb.Append(" </tbody> </table>");
            strb.Append(" </body> </html>");

            HttpResponse resp;
            resp = Page.Response;
            resp.Clear();
            resp.Buffer = true;
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            resp.ContentType = "application/ms-excel";
            Page.EnableViewState = false;
            resp.Write(strb);
            resp.Flush();
            resp.End();



        }

       


    }
}