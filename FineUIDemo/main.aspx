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

        /*
            X(leftTreeID).on('click', function (node, e) {

                if (node.isLeaf()) {

                    var url = node.attributes.href;
                    var text = node.attributes.text;

                    X(mainTabStripID).addTab({
                        id: "dynamic_tab_" + node.attributes.id,
                        url: url,
                        title: text,
                        closable: true
                    });

                    e.stopEvent();

                }

            });

            */


            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            X.util.initTreeTabStrip(X(leftTreeID), X(mainTabStripID), null, false, true, true);

        }


    
    </script>

</body>
</html>
