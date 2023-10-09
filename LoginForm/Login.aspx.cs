using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Web;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // You should perform the authentication logic here
            // Check the username and password against your database or other authentication source

            // For this example, we'll check if the username is "admin" and the password is "password"
            if (username == "admin" && password == "password")
            {
                // Redirect to the welcome page upon successful login
                Response.Redirect("Welcome.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}
