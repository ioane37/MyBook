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
    public class UserRegister
    {
        public void RegisterUser(string userName, string password, Page page, SqlDataSource sqlDataSource)
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
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            using (SqlCommand checkUser = new SqlCommand("select count(*) from Users where Username='" + userName + "'", sqlConnection))
            {
                checkUser.Parameters.AddWithValue("@UserName", userName);
                int UserExist = (int)checkUser.ExecuteScalar();

                if (UserExist != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(
                        page, this.GetType(),
                        "alertMessage",
                        "alert('User Name Already Taken!')",
                        true
                    );

                    return;
                }
            }


            sqlDataSource.InsertCommandType = SqlDataSourceCommandType.Text;
            sqlDataSource.InsertCommand = $"insert into Users (UserName,Password) values({userName},{password})";

            string query = "insert into Users (UserName,Password)";
            query += " Values(@UserName,@Password)";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@UserName", userName);
            sqlCommand.Parameters.AddWithValue("@Password", password);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            string script = "window.onload = function() { AddImage(); };";
            page.ClientScript.RegisterStartupScript(this.GetType(), "AddImage()", script, true);

            //ScriptManager.RegisterClientScriptBlock(
            //        page, this.GetType(),
            //        "alertMessage",
            //        "alert('Successfully Registered!')",
            //        true
            //    );
        }
    }
}