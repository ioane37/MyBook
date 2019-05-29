<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyBook.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>myBook</title>
    <link rel="stylesheet" href="./CssCleaner.css" />
    <link rel="stylesheet" href="./RegisterPage.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous" />
    </head>

<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1 class="title">myBook</h1>
            <div class="register--container">
                <div>
                    <label for="username" class="register--text">
                        <span>User Name</span>
                        <br />
                        <input type="text" id="username" name="username" runat="server" />
                    </label>
                </div>

                <div style="margin-left: 30px;">
                    <label for="password" class="register--text">
                        <span>Password</span>
                        <br />
                        <input type="password" id="password" name="password" runat="server" />
                    </label>
                </div>

                <div class="registerBtn">
                    <asp:Button ID="Button2" class="loginBtn" runat="server" Text="LogIn" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:MyBookConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    

    <div class="image--container">
        <div class="image"><i class="fas fa-question-circle question--mark"></i></div>
        Let The World Know How Sexy You Are
        <p class="img--url">Image URL <input class="image--input" type="text" name="imageInput" runat="server"/></p>
        <asp:Button ID="Button3" class="okBtn" runat="server" Text="OK!" OnClick="Button3_Click" />
    </div>
    </form>
    <script src="RegisterScript.js"></script>
</body>

</html>