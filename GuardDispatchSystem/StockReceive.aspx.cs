using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuardDispatchSystem
{
    public partial class StockReceive : System.Web.UI.Page
    {
        DataBase da = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"]==null)//沒有輸入帳號
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    BindDate();
                }
            }
            
        }

        protected void BindDate()
        {
            string plant = Session["Plant"].ToString();
            DataTable dsType = da.GetRows("select * from dbo.GoodsType ").Tables[0];
            DataTable dsName = da.GetRows("select * from dbo.GoodsName ").Tables[0];
            DataTable dsBU = da.GetRows("select * from dbo.Sys_BU ").Tables[0];
            DataTable dsPlant = da.GetRows("select * from dbo.Plant where Plant='" + plant + "'  ").Tables[0];
            if (dsType.Rows.Count > 0 && dsName.Rows.Count > 0 && dsBU.Rows.Count > 0)
            {

                ddl_BU.Items.Clear();
                ddl_BU.DataSource = dsBU;
                ddl_BU.DataTextField = "BU";
                ddl_BU.DataValueField = "BUID";
                ddl_BU.DataBind();
                ddl_BU.Items.Insert(0, new ListItem("", ""));

                ddl_type.Items.Clear();
                ddl_type.DataSource = dsType;
                ddl_type.DataTextField = "GoodsType";
                ddl_type.DataValueField = "TypeID";
                ddl_type.DataBind();
                ddl_type.Items.Insert(0, new ListItem("", ""));



                ddl_name.Items.Clear();
                ddl_name.DataSource = dsName;
                ddl_name.DataTextField = "GoodsName";
                ddl_name.DataValueField = "NameID";
                ddl_name.DataBind();
                ddl_name.Items.Insert(0, new ListItem("", ""));

                ddl_Plant.Items.Clear();
                ddl_Plant.DataSource = dsPlant;
                ddl_Plant.DataTextField = "Plant";
                ddl_Plant.DataValueField = "PlantID";
                ddl_Plant.DataBind();
                //ddl_Plant.Items.Insert(0, new ListItem("", ""));

                ddl_Plant.Enabled = false;

            }
        }




        protected void BtnOK_Click(object sender, EventArgs e)
        {
            if( ddl_BU.SelectedIndex==0 || ddl_name.SelectedIndex==0 || ddl_type.SelectedIndex==0 ||txt_empid.Text=="" || txt_name.Text=="" || txtQty.Text=="")
            {
                RegisterStartupScript("", "<script>alert('請確認數據填寫完整！')</script>");
            }
            else
            {
                if (txtQty.Text == "0")
                {
                    RegisterStartupScript("", "<script>alert('請確認領取數量大於0！')</script>");
                }
                else
                {
                    DataTable dsStock = da.GetRows("select a.* from dbo.Stock a inner join Goods_Stock b on  a.StockID=b.StockID    and b.TypeID='" + ddl_type.SelectedValue + "' and b.NameID='" + ddl_name.SelectedValue + "'   and a.Plant='"+ddl_Plant.SelectedItem+"' ").Tables[0];

                    if (dsStock.Rows.Count > 0) //表中有对应的物资类型和名称，直接修改数量  -库存
                    {
                        int qtr = Convert.ToInt32(dsStock.Rows[0]["Qty"].ToString());
                        if (qtr >= Convert.ToInt32(txtQty.Text.ToString()))//庫存數大於領取數，可以領取
                        {
                            int Eqty = qtr - Convert.ToInt32(txtQty.Text.ToString());
                            DateTime now = DateTime.Now;
                            string date = now.ToString("yyyy-MM-dd hh:mm:ss");
                            string username = Session["name"].ToString();
                            //更新领取完物资之后的数量
                            int m = da.GetcountsInt("Update a  set Qty='" + Eqty + "', UpdateTime= '" + date + "' from Stock a inner join  Goods_Stock b  on   a.StockID=b.StockID and    b.TypeID='" + ddl_type.SelectedValue + "' and b.NameID='" + ddl_name.SelectedValue + "' and  a.Plant='" + ddl_Plant.SelectedItem + "'  ");
                            if (m > 0)
                            {
                                RegisterStartupScript("", "<script>alert('領取物資成功！')</script>");
                                string kucun = "領取物資";
                                int log = da.GetcountsInt("insert into ReceiveLog (Plant,BU,UserName,ReceiveName,ReceiveEmpID,GoodsType,GoodsName,OperationType,Qty,Remark,UpdateTime)  values('" + ddl_Plant.SelectedItem + "','" + ddl_BU.SelectedItem + "','" + username + "','" + txt_name.Text + "','" + txt_empid.Text + "','" + ddl_type.SelectedItem + "','" + ddl_name.SelectedItem + "','" + kucun + "' ,'" + txtQty.Text.ToString() + "'  ,'" + txtRemark.Text + "'  ,'" + date + "'    )    ");
                                ddl_BU.SelectedIndex = 0;
                                ddl_name.SelectedIndex = 0;
                                ddl_type.SelectedIndex = 0;
                                txt_empid.Text = "";
                                txt_name.Text = "";
                                txtQty.Text = "";
                            }
                            else
                            {
                                RegisterStartupScript("", "<script>alert('領取物資失败！')</script>");
                                ddl_BU.SelectedIndex = 0;
                                ddl_name.SelectedIndex = 0;
                                ddl_type.SelectedIndex = 0;
                                txt_empid.Text = "";
                                txt_name.Text = "";
                                txtQty.Text = "";
                            }
                        }
                        else
                        {
                            RegisterStartupScript("", "<script>alert('庫存不足！')</script>");
                        }


                    }
                    else
                    {
                        RegisterStartupScript("", "<script>alert('請確認該物資是否還有庫存！')</script>");
                    }
                }
            }
           
            
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_name.Items.Clear();
            DataTable ds = da.GetRows("select distinct c.* From GoodsType a ,Goods_Stock b , GoodsName c where a.TypeID=b.TypeID and b.NameID=c.NameID  and a.GoodsType='" + ddl_type.SelectedItem + "'").Tables[0];
            ddl_name.DataSource = ds;
            ddl_name.DataTextField = "GoodsName";
            ddl_name.DataValueField = "NameID";
            ddl_name.DataBind();
            ddl_name.Items.Insert(0, new ListItem("", ""));
        }

        protected void txt_empid_TextChanged(object sender, EventArgs e)
        {

            DataTable ds = da.GetRows(" SELECT  Emp_No,Emp_Name,Emp_OutDate   FROM HRDataSync.dbo.v_hr_emp_app  where Emp_No= '" + txt_empid.Text + "'   ").Tables[0];
            if (ds.Rows.Count > 0)
            {
                string outdate = ds.Rows[0]["Emp_OutDate"].ToString();
                if (outdate != "9999-12-31")//離職
                {
                    RegisterStartupScript("", "<script>alert('此人已離職！')</script>");
                    txt_name.Text = "";
                    txt_empid.Text = "";
                }
                else  //此人在職
                {
                    string name = ds.Rows[0]["Emp_Name"].ToString();
                    txt_name.Text = name;
                }

            }
            else
            {
                RegisterStartupScript("", "<script>alert('未找到此員工，請確認工號是否正確！')</script>");
                txt_name.Text = "";
            }

        }



    }
}