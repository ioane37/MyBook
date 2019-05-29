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
    public class UserLogin
    {
        public void LogInUser(string userName, string password, Page page, SqlDataSource sqlDataSource)
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                ScriptManager.RegisterClientScriptBlock(
                    page, this.GetType(),
                    "alertMessage",
                    "alert('Please Enter User Name and Password')",
                    true
                );

                return;
            }

            string connection = @"Data Source=LAPTOP-LDJUJ350\SQLEXPRESS;Initial Catalog=MyBook;Integrated Security=True";
            string query = "select Count(*) from Users where UserName='" + userName + "' and Password ='"+password+"'";

            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            using (SqlCommand CheckUser = new SqlCommand(query, sqlConnection))
            {
                CheckUser.Parameters.AddWithValue("@UserName", userName);

                int userExits = (int)CheckUser.ExecuteScalar();

                if (userExits != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(
                    page, this.GetType(),
                    "alertMessage",
                    "alert('Successfully Logged!')",
                    true
                    );
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(
                                        page, this.GetType(),
                                        "alertMessage",
                                        "alert('UserName Or Password Incorrect!')",
                                        true
                                    );
                }
            }

            sqlConnection.Close();
        }
    }
}