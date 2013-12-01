<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FineUIDemo._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统登陆</title>
    <script type="text/javascript">

        // 本页面一定是顶层窗口，不会嵌在IFrame中
        if (top.window != window) {
            top.window.location.href = "./default.aspx";
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server"></x:PageManager>
    <x:Window ID="Window1" runat="server" IsModal="true" Popup="true" EnableClose="false"
        EnableMaximize="false" WindowPosition="GoldenSection" Icon="Key" Title="系统登陆"
        Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" Width="450px" Plain="false"
        Height="220px">
        <Items>
            <x:Image ID="imageLogin" ImageUrl="~/res/images/login/login_1.png" runat="server"
                ImageWidth="150px" Width="160px">
            </x:Image>
            <x:SimpleForm ID="SimpleForm1" LabelAlign="Top" BoxFlex="1" runat="server" LabelWidth="45px"
                BodyPadding="20px 10px" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:TextBox ID="tbxUserName" FocusOnPageLoad="true" runat="server" Label="帐号" Required="true"
                        ShowRedStar="true" Text="">
                    </x:TextBox>
                    <x:TextBox ID="tbxPassword" TextMode="Password" runat="server" Required="true" ShowRedStar="true"
                        Label="密码" Text="">
                    </x:TextBox>
                </Items>
            </x:SimpleForm>
        </Items>
        <Toolbars>
            <x:Toolbar runat="server" Position="Footer">
                <Items>
                    <x:Button ID="btnSubmit" Icon="LockOpen" Type="Submit" runat="server" ValidateForms="SimpleForm1"
                        OnClick="btnSubmit_Click" Text="登陆">
                    </x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Window>
    </form>
</body>
</html>
