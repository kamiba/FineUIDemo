<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayDetailStat.aspx.cs" Inherits="FineUIDemo.PayDetailStat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="5px" EnableLargeHeader="false"
        EnableBackgroundColor="true" ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" ShowHeader="false" Title="支付统计管理">
        <Items>
            <x:Form ID="Form2" runat="server" Height="36px" BodyPadding="5px" ShowHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Rows>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在货品名称中搜索"
                                Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false" OnTrigger2Click="ttbSearchMessage_Trigger2Click"
                                OnTrigger1Click="ttbSearchMessage_Trigger1Click">
                            </x:TwinTriggerBox>
                            <x:Label runat="server">
                            </x:Label>
                            <x:Label ID="Label1" runat="server">
                            </x:Label>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                EnableCheckBoxSelect="true" EnableRowNumber="true" DataKeyNames="CK_PayDetailStatID" AllowSorting="true"
                OnSort="Grid1_Sort" SortColumnIndex="0" SortDirection="DESC" AllowPaging="true"
                IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound" OnRowCommand="Grid1_RowCommand"
                OnPageIndexChange="Grid1_PageIndexChange">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <%--<x:Button ID="btnDeleteSelected" Icon="Delete" runat="server" Text="删除选中记录" OnClick="btnDeleteSelected_Click">
                            </x:Button>--%>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="Button1" EnableAjax="false" DisableControlBeforePostBack="false"
                                runat="server" Text="将Grid导出为Excel文件" OnClick="Button1_Click">
                            </x:Button>
                     
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Columns>
                    <x:BoundField DataField="ck_PeopleName" SortField="ck_PeopleName" Width="100px" HeaderText="加工人员" />
                    <x:BoundField DataField="needPayMoney" SortField="needPayMoney" Width="100px" HeaderText="应付费用" />
                    <x:BoundField DataField="PayedMoney" SortField="PayedMoney" Width="100px" HeaderText="实付费用" />
                    <x:BoundField DataField="unPayedMoney" SortField="unPayedMoney" Width="100px" HeaderText="未付费用" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true" Target="Top"
        EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="650px" Height="450px" OnClose="Window1_Close">
    </x:Window>
    </form>
</body>
</html>
