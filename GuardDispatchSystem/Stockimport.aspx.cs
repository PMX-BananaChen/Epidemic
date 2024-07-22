using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuardDispatchSystem
{
    public partial class Stockimport : System.Web.UI.Page
    {
        DataBase da = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)//沒有輸入帳號
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindDate();
                    BindGridview();
                }
            }
            
        }


        protected void BindDate()
        {
            DataTable dsType = da.GetRows("select * from dbo.GoodsType ").Tables[0];
            DataTable dsName = da.GetRows("select * from dbo.GoodsName ").Tables[0];
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


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd hh:mm:ss");
            string username = Session["name"].ToString();
            string plant = Session["Plant"].ToString();
           
            DataTable dsStock = new DataTable();
            //string username = Request.QueryString["name"].ToString();
            ////DataTable dstype = da.GetRows("select * from dbo.GoodsType where TypeID='" + DDL_Type.SelectedItem + "' ").Tables[0];
            ////DataTable dsname = da.GetRows("select * from dbo.GoodsName where NameID='" + DDL_Name.SelectedItem + "' ").Tables[0];
            if(DDL_Name.SelectedIndex==0 || DDL_Type.SelectedIndex==0 || TxtQty.Text=="")
            {
                RegisterStartupScript("", "<script>alert('請確認數據填寫完整！')</script>");
            }
            else
            {
                if (TxtQty.Text == "0")
                {
                    RegisterStartupScript("", "<script>alert('領取數量需要大於0！')</script>");
                }
                else
                {
                    if(plant=="ALL")
                    {
                         dsStock = da.GetRows("select * from dbo.Stock where GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "'    ").Tables[0];

                    }
                    else
                    {
                         dsStock = da.GetRows("select * from dbo.Stock where GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "'  and Plant='" + plant + "'  ").Tables[0];

                    }
                    if (dsStock.Rows.Count > 0) //表中有对应的物资类型和名称，直接修改数量  +库存
                    {
                        int qtr = Convert.ToInt32(dsStock.Rows[0]["Qty"].ToString());
                        int stockid = Convert.ToInt32(dsStock.Rows[0]["StockID"].ToString());
                        int Eqty = qtr + Convert.ToInt32(TxtQty.Text.ToString());

                        int m = da.GetcountsInt(" Update Stock  set Qty='" + Eqty + "',UpdateTime= '" + date + "'  where   GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "' and Plant='" + plant + "'   ");
                        // int n = da.GetcountsInt(" Insert into Goods_Stock values('" + stockid + "','" + DDL_Type.SelectedValue + "','" + DDL_Name.SelectedValue + "')  ");
                        if (m > 0)
                        {
                            RegisterStartupScript("", "<script>alert('增加庫存成功！')</script>");
                            string kucun = "增加庫存";
                            DataTable dsLog = da.GetRows("select * from dbo.ImportLog where GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "' and Plant='" + plant + "'  and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120) ").Tables[0];
                            if (dsLog.Rows.Count > 0)  //已經有增加庫存的記錄，就在此基礎上更改增加的數字即可
                            {
                                int Qtylog = Convert.ToInt32(dsLog.Rows[0]["Qty"].ToString()) + Convert.ToInt32(TxtQty.Text);

                                int log = da.GetcountsInt(" Update ImportLog  set Qty='" + Qtylog + "'  where   GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "' and Plant='" + plant + "'  and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120)   ");

                            }
                            else
                            {
                                int log = da.GetcountsInt("insert into ImportLog (Plant,GoodsType,GoodsName,Qty,OperationType,UserName,UpdateTime)  values('"+plant+"', '" + DDL_Type.SelectedItem + "','" + DDL_Name.SelectedItem + "','" + TxtQty.Text.ToString() + "','" + kucun + "','" + username + "','" + date + "')    ");
                            }
                            BindGridview();
                        }
                        //else if (m > 0)
                        //{
                        //    RegisterStartupScript("", "<script>alert('增加庫存時出現異常！')</script>");
                        //}
                        else
                        {
                            RegisterStartupScript("", "<script>alert('增加庫存失敗！')</script>");
                        }
                    }
                    else //表中没有相应的物资类型和名称
                    {
                        int insert = da.GetcountsInt(" Insert into Stock (Plant,GoodsType,GoodsName,Qty,UpdateTime) values('"+plant+"' ,'" + DDL_Type.SelectedItem + "','" + DDL_Name.SelectedItem + "','" + TxtQty.Text.ToString() + "','" + date + "')  ");
                        if (insert > 0)
                        {
                            DataTable dsStock2 = da.GetRows("select * from dbo.Stock where GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "'   and Plant='"+plant+"' ").Tables[0];
                            int stockid = Convert.ToInt32(dsStock2.Rows[0]["StockID"].ToString());
                            int n = da.GetcountsInt(" Insert into Goods_Stock (Plant,StockID,TypeID,NameID)   values( ''"+plant+" , '" + stockid + "','" + DDL_Type.SelectedValue + "','" + DDL_Name.SelectedValue + "')  ");
                            if (n > 0)
                            {
                                RegisterStartupScript("", "<script>alert('增加庫存成功！')</script>");
                                string kucun = "增加庫存";
                                DataTable dsLog = da.GetRows("select * from dbo.ImportLog where GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "' and Plant='"+plant+"' and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120) ").Tables[0];
                                if (dsLog.Rows.Count > 0)  //已經有增加庫存的記錄，就在此基礎上更改增加的數字即可
                                {
                                    int Qtylog = Convert.ToInt32(dsLog.Rows[0]["Qty"].ToString()) + Convert.ToInt32(TxtQty.Text);

                                    int log = da.GetcountsInt(" Update ImportLog  set Qty='" + Qtylog + "'  where   GoodsType='" + DDL_Type.SelectedItem + "' and GoodsName='" + DDL_Name.SelectedItem + "' and Plant='" + plant + "' and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120)   ");

                                }
                                else
                                {
                                    int log = da.GetcountsInt("insert into ImportLog (Plant,GoodsType,GoodsName,Qty,OperationType,UserName,UpdateTime)   values('"+plant+"', '" + DDL_Type.SelectedItem + "','" + DDL_Name.SelectedItem + "','" + TxtQty.Text.ToString() + "','" + kucun + "','" + username + "','" + date + "')    ");
                                }
                                // int log = da.GetcountsInt("insert into ImportLog   values('" + DDL_Type.SelectedItem + "','" + DDL_Name.SelectedItem + "','" + TxtQty.Text.ToString() + "','" + kucun + "','" + username + "','" + date + "')    ");

                            }
                            else
                            {
                                RegisterStartupScript("", "<script>alert('增加庫存時出現異常！')</script>");
                            }

                        }
                        else
                        {
                            RegisterStartupScript("", "<script>alert('增加庫存失敗！')</script>");
                        }
                    }
                    DDL_Type.SelectedIndex = 0;
                    DDL_Name.SelectedIndex = 0;
                    TxtQty.Text = "";
                    BindGridview();
                    //TxtQty.Text = "";
                }
            }
            
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BindGridview();

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string username = Session["name"].ToString();
            string Plant = Session["Plant"].ToString(); 
            if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
            {
                RegisterStartupScript("", "<script>alert('請選擇Excel文件')</script>");
                return;//当无文件时,返回
            }
            string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls == ".xlsx" || IsXls == ".xls")
            {
                string filename = FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数
                string savePath = Server.MapPath("~/Upload/" + filename);  //Server.MapPath 获得虚拟服务器相对路径
                FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
                DataSet ds = ExcelSqlConnection(savePath, filename, IsXls);           //调用自定义方法
                DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组
                int rowsnum = ds.Tables[0].Rows.Count;
                if (rowsnum == 0)
                {
                    RegisterStartupScript("", "<script>alert('Excel表為空，無數據!')</script>");
                }
                else
                {
                    int mgs = 0;
                    int mgs1 = 0;
                    int mgs2 = 0;
                    for (int i = 0; i < dr.Length; i++)
                    {
                        DataTable dsStock = da.GetRows("select * from dbo.Stock where GoodsType='" + dr[i]["物資類型"].ToString() + "' and GoodsName='" + dr[i]["名稱"].ToString() + "' and Plant='"+Plant+"'   ").Tables[0];
                        if (dsStock.Rows.Count <= 0)//插入时判断表中是否已有该物资类型以及名称   沒有
                        {
                            DataTable dstype = da.GetRows("select * from dbo.GoodsType where GoodsType='" + dr[i]["物資類型"].ToString() + "'    ").Tables[0];
                            DataTable dsname = da.GetRows("select * from dbo.GoodsName where GoodsName='" + dr[i]["名稱"].ToString() + "' ").Tables[0];
                            string typeid = dstype.Rows[0]["TypeID"].ToString();
                            string nameid = dsname.Rows[0]["NameID"].ToString();
                            //if(dr[i]["數量"].ToString()!="0" )
                            //{
                                
                            //}
                            int insert = da.GetcountsInt(" Insert into Stock (Plant,GoodsType,GoodsName,Qty,UpdateTime) values('"+Plant+"' , '" + dr[i]["物資類型"].ToString() + "','" + dr[i]["名稱"].ToString() + "','" + dr[i]["數量"].ToString() + "','" + DateTime.Now + "')  ");
                            if (insert > 0)
                            {
                                DataTable dsStock2 = da.GetRows("select * from dbo.Stock where GoodsType='" + dr[i]["物資類型"].ToString() + "' and GoodsName='" + dr[i]["名稱"].ToString() + "' and Plant='" + Plant + "'  ").Tables[0];
                                int stockid = Convert.ToInt32(dsStock2.Rows[0]["StockID"].ToString());
                                int n = da.GetcountsInt(" Insert into Goods_Stock(Plant,StockID,TypeID,NameID) values('"+Plant+"', '" + stockid + "','" + typeid + "','" + nameid + "')  ");
                                if (n > 0)
                                {
                                    //RegisterStartupScript("", "<script>alert('增加库存成功！')</script>");
                                    mgs++;
                                    string kucun = "增加庫存";
                                    DataTable dsLog = da.GetRows("select * from dbo.ImportLog where GoodsType='" + dr[i]["物資類型"].ToString() + "' and GoodsName='" + dr[i]["名稱"].ToString() + "' and Plant='"+Plant+"' and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120) ").Tables[0];
                                    if (dsLog.Rows.Count > 0)  //已經有增加庫存的記錄，就在此基礎上更改增加的數字即可
                                    {
                                        int Qtylog = Convert.ToInt32(dsLog.Rows[0]["Qty"].ToString()) + Convert.ToInt32(dr[i]["數量"].ToString());

                                        int log = da.GetcountsInt(" Update ImportLog  set Qty='" + Qtylog + "' where   GoodsType='" + dr[i]["物資類型"].ToString() + "' and GoodsName='" + dr[i]["名稱"].ToString() + "' and Plant='" + Plant + "'  and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120)   ");

                                    }
                                    else
                                    {
                                        int log = da.GetcountsInt("insert into ImportLog (Plant,GoodsType,GoodsName,Qty,OperationType,UserName,UpdateTime)  values('"+Plant+"' ,  '" + dr[i]["物資類型"].ToString() + "','" + dr[i]["名稱"].ToString() + "','" + dr[i]["數量"].ToString() + "','" + kucun + "','" + username + "','" + DateTime.Now + "')    ");
                                    }
                                    // int log = da.GetcountsInt("insert into ImportLog   values('" + dr[i]["物資類型"].ToString() + "','" + dr[i]["名稱"].ToString() + "','" + dr[i]["數量"].ToString() + "','" + kucun + "','" + username + "','" + DateTime.Now + "')    ");
                                    BindGridview();
                                }
                                else
                                {
                                    mgs1++;// += "增加库存时出现异常";
                                    //RegisterStartupScript("", "<script>alert('增加库存时出现异常！')</script>");
                                }

                            }
                            else
                            {
                                mgs2++;// += "增加库存失败！";
                                //RegisterStartupScript("", "<script>alert('增加库存失败！')</script>");
                            }
                            
                            
                        }
                        else  //已经有，只需直接更新库存数量即可
                        {
                            string stockid = dsStock.Rows[0]["StockID"].ToString();
                            //if(dr[i]["數量"].ToString()!="0")
                            //{
                                
                            //}
                            int qty = Convert.ToInt32(dsStock.Rows[0]["Qty"].ToString()) + Convert.ToInt32(dr[i]["數量"].ToString());
                            int m = da.GetcountsInt(" Update Stock  set Qty='" + qty + "',UpdateTime= '" + DateTime.Now + "'  where   GoodsType='" + dr[i]["物資類型"].ToString() + "' and GoodsName='" + dr[i]["名稱"].ToString() + "' and Plant='"+Plant+"'   ");
                            //int n = da.GetcountsInt(" Insert into Goods_Stock values('" + stockid + "','" + dr[i]["物資類型"].ToString() + "','" + dr[i]["名稱"].ToString() + "')  ");
                            if (m > 0)
                            {
                                mgs++;// += "更新库存数量成功！";
                                string kucun = "增加庫存";
                                DataTable dsLog = da.GetRows("select * from dbo.ImportLog where GoodsType='" + dr[i]["物資類型"].ToString() + "' and GoodsName='" + dr[i]["名稱"].ToString() + "' and Plant='"+Plant+"' and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120) ").Tables[0];

                                if (dsLog.Rows.Count > 0)  //已經有增加庫存的記錄，就在此基礎上更改增加的數字即可
                                {
                                    int Qtylog = Convert.ToInt32(dsLog.Rows[0]["Qty"].ToString()) + Convert.ToInt32(dr[i]["數量"].ToString());

                                    int log = da.GetcountsInt(" Update ImportLog  set Qty='" + Qtylog + "' where   GoodsType='" + dr[i]["物資類型"].ToString() + "' and GoodsName='" + dr[i]["名稱"].ToString() + "' and Plant='" + Plant + "'  and convert(varchar(10),UpdateTime,120)=convert(varchar(10) ,GETDATE(),120)   ");

                                }
                                else
                                {
                                    int log = da.GetcountsInt("insert into ImportLog (plant,GoodsType,GoodsName,Qty,OperationType,UserName,UpdateTime)  values('"+Plant+"' , '" + dr[i]["物資類型"].ToString() + "','" + dr[i]["名稱"].ToString() + "','" + dr[i]["數量"].ToString() + "','" + kucun + "','" + username + "','" + DateTime.Now + "')    ");
                                }
                                // int log = da.GetcountsInt("insert into ImportLog   values('" + dr[i]["物資類型"].ToString() + "','" + dr[i]["名稱"].ToString() + "','" + dr[i]["數量"].ToString() + "','" + kucun + "','" + username + "','" + DateTime.Now + "')    ");
                                BindGridview();
                            }
                            else
                            {
                                mgs2++;// += "更新库存数量失败！";
                            }
                            


                        }

                    }
                    string message = "";
                    if (mgs != 0)
                    {
                        message = "庫存增加成功";
                    }
                    else if (mgs1 != 0)
                    {
                        message = "操作出現異常";
                    }
                    else if (mgs2 != 0)
                    {
                        message = "庫存增加失敗";
                    }
                    RegisterStartupScript("", "<script>alert('" + message + "')</script>");
                    // BindGridview();


                }
              
                    
             
                

               
            }

            else
            {
                RegisterStartupScript("", "<script>alert('只可以選擇Excel文件')</script>");

                return;//当选择的不是Excel文件时,返回
            }
        }


        #region 连接Excel  读取Excel数据   并返回DataSet数据集合
        /// <summary>
        /// 连接Excel  读取Excel数据   并返回DataSet数据集合
        /// </summary>
        /// <param name="filepath">Excel服务器路径</param>
        /// <param name="tableName">Excel表名称</param>
        /// <returns></returns>
        public static System.Data.DataSet ExcelSqlConnection(string filepath, string tableName, string strEName)
        {
           
            DataBase da = new DataBase();
            string strCon = "";
            if (strEName == ".xls")
            {

                strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
            }
            else if (strEName == ".xlsx")
            {
                strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source= " + filepath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
            }
            else
            {
                return null;
            }
            OleDbConnection ExcelConn = new OleDbConnection(strCon);

            try
            {
                string strCom = string.Format("SELECT * FROM [Sheet1$]");
                ExcelConn.Open();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, ExcelConn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "[" + tableName + "$]");
                ExcelConn.Close();
                return ds;
            }
            catch
            {
                ExcelConn.Close();
                return null;
            }    
            
           
           
        }
        #endregion


        public void BindGridview()
        {
            string type = DDL_Type.SelectedItem.ToString();
            string name = DDL_Name.SelectedItem.ToString();
            string Plant = Session["Plant"].ToString();
            if(Plant=="ALL")
            {
                Plant = "";
            }
            else
            {
                Plant = Session["Plant"].ToString();
            }
         
            string sql = "";
            if (type != "")
            {
                sql += "  and GoodsType='" + type + "'  ";
            }
            if (name != "")
            {
                sql += "  and GoodsName='" + name + "'  ";
            }
            if (Plant != "")
            {
                sql += "  and Plant='" + Plant + "'  ";
            }
            DataTable dsStock = da.GetRows("select * from dbo.Stock where 1=1 " + sql + "    "   ).Tables[0];
            GridView2.DataSource = dsStock;
            GridView2.DataBind();
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

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindGridview();
        }

       
    }
}