using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyBook
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = Request.Form["username"];
            string password = Request.Form["password"];

            UserRegister userRegister = new UserRegister();
            userRegister.RegisterUser(userName.Trim(), password.Trim(), this, SqlDataSource1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string userName = Request.Form["username"];
            string password = Request.Form["password"];

            UserLogin userLogin = new UserLogin();
            userLogin.LogInUser(userName.Trim(), password.Trim(), this, SqlDataSource1);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string imageUrl = Request.Form["imageInput"];
            string userName = Request.Form["username"];

            string connection = @"Data Source=LAPTOP-LDJUJ350\SQLEXPRESS;Initial Catalog=MyBook;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connection);

            string query = "update Users set ImageLink = @ImageLink where UserName = @UserName";

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@UserName", userName);
                sqlCommand.Parameters.AddWithValue("@ImageLink", imageUrl);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}