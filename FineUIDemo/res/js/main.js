function onReady() {

    var treeMenu = Ext.getCmp(DATA.treeMenu),
        regionPanel = Ext.getCmp(DATA.regionPanel),
        regionTop = Ext.getCmp(DATA.regionTop),
        btnShowHideHeader = Ext.getCmp(DATA.btnShowHideHeader),
        mainTabStrip = Ext.getCmp(DATA.mainTabStrip),
        txtUser = Ext.getCmp(DATA.txtUser),
        txtOnlineUserCount = Ext.getCmp(DATA.txtOnlineUserCount),
        txtCurrentTime = Ext.getCmp(DATA.txtCurrentTime),
        btnRefresh = Ext.getCmp(DATA.btnRefresh);


    // 欢迎信息和在线用户数
    txtUser.setText('欢迎您：<span class="highlight">' + DATA.userName + '</span>&nbsp;&nbsp;[' + DATA.userIP + ']');
    txtOnlineUserCount.setText('在线用户：' + DATA.onlineUserCount);

    // 点击刷新按钮
    btnRefresh.on('click', function () {
        var iframe = Ext.DomQuery.selectNode('iframe', mainTabStrip.getActiveTab().body.dom);
        iframe.src = iframe.src;
    });

    // 显示 / 隐藏标题
    btnShowHideHeader.on('click', function () {
        if (regionTop.getInnerHeight() > 0) {
            regionTop.setHeight(0);
            btnShowHideHeader.setTooltip('显示标题栏');
            btnShowHideHeader.setIcon('res.axd?icon=SectionCollapsed');
        } else {
            regionTop.setHeight(60);
            btnShowHideHeader.setTooltip('隐藏标题栏');
            btnShowHideHeader.setIcon('res.axd?icon=SectionExpanded');
        }
        regionPanel.doLayout();
    });


    // 设置当前时间
    function setCurrentTime() {
        var today = new Date();
        year = today.getFullYear().toString();
        month = String.leftPad(today.getMonth() + 1, '2', '0');
        date = String.leftPad(today.getDate(), '2', '0');
        hour = String.leftPad(today.getHours(), '2', '0');
        minute = String.leftPad(today.getMinutes(), '2', '0');
        //second = String.leftPad(today.getSeconds(), '2', '0');
        txtCurrentTime.setText('当前时间：' + year + '-' + month + '-' + date + ' ' + hour + ':' + minute);
    }
    // 当前时间并定时更新
    setCurrentTime();
    window.setInterval(setCurrentTime, 30 * 1000);


    // 初始化主框架中的树和选项卡互动，以及地址栏的更新
    X.util.initTreeTabStrip(treeMenu, mainTabStrip);


//    // 公开 addExampleTab 方法
//    window.mainTabStrip = mainTabStrip;
//    window.addExampleTab = X.util.addMainTab;
    // 公开添加示例标签页的方法
    window.addExampleTab = function (id, url, text, icon) {
        X.util.addMainTab(mainTabStrip, id, url, text, icon);
    };

}