<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CK_Payment_edit.aspx.cs"
    Inherits="FineUIDemo.CK_Payment_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <x:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" EnableBackgroundColor="true" Title="SimpleForm">
        <Toolbars>
            <x:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <x:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </x:ToolbarSeparator>
                    <x:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭">
                    </x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:DropDownList runat="server" ID="DropDownListPeople" Label="支付人" AutoPostBack="true">
            </x:DropDownList>
            <x:TextBox ID="tbxCount" runat="server" Label="支付金额" Required="true" ShowRedStar="true">
            </x:TextBox>
            <x:DatePicker runat="server" Required="true" Label="支付日期" EmptyText="请选择支付日期"
                ID="DatePicker1" ShowRedStar="True">
            </x:DatePicker>
            <x:TextBox ID="tbxNote" runat="server" Label="备注" ShowRedStar="true">
            </x:TextBox>
        </Items>
    </x:SimpleForm>
    </form>
</body>
</html>
