using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuardDispatchSystem
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public string show1 = "", show2 = "",show3="",show4="";
        DataBase da = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (StockReport.reportname == "A")
                //{
                //    lab_Acount.Text = "";
                //    BindGetUserAcountData(lab_Acount.Text);
                //}
                //else
                //{
                //    lab_Acount.Text = Login.name;
                //    BindGetUserAcountData(lab_Acount.Text);
                //}
            
            }
            if (StockReport.reportname == "A")
            {
                lab_Acount.Text = "";
                BindGetUserAcountData(lab_Acount.Text);
            }
            else
            {
                lab_Acount.Text = Login.name;
                BindGetUserAcountData(lab_Acount.Text);
            }
           
        }

        private void BindGetUserAcountData(string UserAcount)
        {
            if(UserAcount=="")
            {
                lab_Acount.Visible = false;
                Labuser.Visible = false;

            }
           
            
            DataTable ds2 = da.GetRows(" select * from dbo.Sys_UserInfo where UserAcount ='" + lab_Acount.Text + "'").Tables[0];
            if (ds2 != null && ds2.Rows.Count > 0)
            {
               // DataTable  ds3 = da.GetRows(" select * from dbo.Users a inner join dbo.UserRole b  on a .UserId =b .UserId  where UserAcount ='" + lab_Acount.Text + "'").Tables[0];
                string RoID = ds2.Rows[0]["UserID"].ToString();

                switch (RoID)
                {
                    case "0"://管理員
                        break;

                    case "1"://拥有物资导入的权限
                        this.show2 = " style=\"display:none\"";//隐藏
                        this.show3 = " style=\"display:true\"";//領取報表  
                        this.show4 = " style=\"display:true\"";//庫存報表 
                        break;

                    case "2"://拥有物资领用的权限
                        this.show1 = " style=\"display:none\"";//隐藏 
                        this.show3 = " style=\"display:true\"";//領取報表  
                        this.show4 = " style=\"display:true\"";//庫存報表
                        break;
                   
                }

            }
            else
            {
                this.show2 = " style=\"display:none\"";//隐藏  
                this.show1 = " style=\"display:none\"";//隐藏  
                this.show3 = " style=\"display:none\"";//隐藏  
                this.show4 = " style=\"display:none\"";//隐藏
            

            }
        }

        protected void btnout_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("Login.aspx");
        }
    }
}