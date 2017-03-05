<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SaleManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hoàng Phúc - Đăng nhập</title>
    <link href="Styles/Login.css" rel="stylesheet" />
    <link rel="icon" type="image/gif" href="Images/logo.png" />
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#form").css('height', $(document).height() - 68);
            $("#txtUserName").focus();
        });
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div id="header">
            <img id="logo" src="../Images/logo.png" alt="Logo" />
            <p class="nameCom">Công ty TNHH Hoàng Phúc</p>
        </div>
        <div id="content">
            <div class="left">
            </div>
            <div class="right">
                <table id="inputForm">
                    <tr>
                        <td id="divTitle">Đăng nhập
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="divUser">
                                <asp:TextBox ID="txtUserName" MaxLength="20" placeholder='Tên đăng nhập' runat="server"
                                    autofocus=""></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="divPass">
                                <asp:TextBox ID="txtPass" MaxLength="30" placeholder='Mật khẩu' runat="server"
                                    TextMode="Password"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr class="submit">
                        <td>
                            <div class="floatleft">
                                <asp:CheckBox ID="chkRememberPass" runat="server" Text="<span>Duy trì đăng nhập</span>" />
                            </div>
                            <div class="floatright">
                                <asp:HiddenField ID="hdmd5pass" runat="server" />
                                <asp:HiddenField ID="hdrememberpass" runat="server" />
                                <asp:Button ID="btnLogin" Text="Đăng nhập" OnClick="btnLogin_Click" runat="server" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="error">
                    <asp:Literal ID="lblWarning" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <div id="footer">
            <p>Thông tin liên hệ: © 2009 - 2016 HoangPhuc Corporation</p>
            <div class="contact">
                <p>Địa chỉ: Lục Nam - Bắc Giang</p>
                <p>Email: hoangphucbacgiang@gmail.com</p>
                <p>SĐT: 0912106586</p>
            </div>
        </div>
    </form>
</body>
</html>
