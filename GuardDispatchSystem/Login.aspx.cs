using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuardDispatchSystem
{

    public partial class Login : System.Web.UI.Page
    {
        DataBase da = new DataBase();
        public string Acount = "";
        public static string name="";
        protected void btn_login_Click(object sender, EventArgs e)
        {
            
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //name = "" ;
               
            }
            StockReport.reportname = "";
            name = "";
            Acount = this.txt_username.Text;
            txt_username.Focus();
           
            
            
        }

        protected void btn_login_Click1(object sender, ImageClickEventArgs e)
        {
            if (txt_username.Text == "")
            {
                RegisterStartupScript("", "<script>alert('用戶名不能為空')</script>");
            }
            if (txt_pwd.Text == "")
            {
                RegisterStartupScript("", "<script>alert('密碼不能為空')</script>");
            }
            else
            {
                string empacount = Acount;
                string emppw = txt_pwd.Text.Trim();
                DataTable DTuser = da.GetRows(" select * from dbo.Sys_UserInfo where UserAcount ='" + empacount + "' and UserPwd='" + emppw + "' ").Tables[0];
                // DataTable DTroles = da.GetRows("select * from dbo.Users a inner join dbo.UserRole b on a .UserId =b .UserId where a.UserAcount ='" + empacount + "' ").Tables[0];
                if (DTuser.Rows.Count > 0)
                {
                    name = empacount;
                    Session["name"] = empacount;
                    Session["Plant"] = DTuser.Rows[0]["Plant"].ToString();
                    Response.Redirect("HomePage.aspx?name=" + empacount + " ");
                    
                    //Session["name"] = empacount;
                }
                else
                {
                    RegisterStartupScript("", "<script>alert('用戶名或密碼不正確，請重新填寫！')</script>");
                    txt_username.Text = "";
                    txt_pwd.Text = "";
                    

                }

            }

        }
    }
}