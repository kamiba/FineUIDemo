<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index3.aspx.cs" Inherits="FineUIDemo.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .top-header .title
        {
            font-size: 28px;
            line-height: 50px;
            margin: 0 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></x:PageManager>
    <x:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <x:Region runat="server" Position="Top" ShowBorder="false" ShowHeader="false" Height="50px"
                Layout="Fit">
                <Items>
                    <x:ContentPanel runat="server" CssClass="top-header" ShowBorder="false" ShowHeader="false"
                        EnableBackgroundColor="true">
                        <div class="title">
                            取送货管理系统
                        </div>
                    </x:ContentPanel>
                </Items>
            </x:Region>
            <x:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="false" Title="示例菜单" EnableLargeHeader="false" Icon="Outline"
                EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Items>
                    <x:Tree runat="server" ID="leftTree" Title="菜单" ShowBorder="false" EnableArrows="true">
                    </x:Tree>
                </Items>
            </x:Region>
            <x:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <x:TabStrip ID="mainTabStrip" ShowBorder="false" runat="server">
                        <Tabs>
                            <x:Tab runat="server" Title="首页" EnableIFrame="true" IFrameUrl="~/CK_ProductType.aspx"
                                IFrameName="mainframe">
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/menu.xml">
    </asp:XmlDataSource>
    </form>

    <script>

        var leftTreeID = '<%= leftTree.ClientID %>';
        var mainTabStripID = '<%= mainTabStrip.ClientID %>';
        
        
        function onReady() {

            X.util.initTreeTabStrip(X(leftTreeID), X(mainTabStripID), null, false, true, true);

        }


    
    </script>

</body>
</html>
