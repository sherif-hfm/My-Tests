/* APIs.js */
var i = 0, treeview;
$(function () {
    $("#sampleProperties").ejPropertiesPanel();
    var treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
});



// Client side APIs 

function onExpandAll(args) {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model) {
        if (args.isChecked)
            treeview.expandAll();
        else
            treeview.collapseAll();
    }
}
function onCheckAll(args) {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model) {
        if (args.isChecked)
            treeview.checkAll();
        else
            treeview.unCheckAll();
    }
}
function onExpand() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model)
        treeview.expandNode(treeview.getSelectedNode());
}
function onCollapse() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model)
        treeview.collapseNode(treeview.getSelectedNode());
}
function onCheck() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model)
        treeview.checkNode(treeview.getSelectedNode());
}
function onUncheck() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model)
        treeview.uncheckNode(treeview.getSelectedNode());
}
function onEnable() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model) {
        var node = $("#LayoutSection_ControlsSection_treeview").find('.e-node-disable');
        treeview.enableNode(node[0]); 
    }
}
function onDisable() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model)
        treeview.disableNode(treeview.getSelectedNode());
}
function onAddNew() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model) {
        treeview.addNode("Item" + i, treeview.getSelectedNode());
        i++;
    }
}
function onRemoveNode() {
    treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    if (treeview.model)
        treeview.removeNode(treeview.getSelectedNode());
}
function onDestoryRestore(args) {
    i = 0;
    if (args.isChecked) {
        $("button[id^='btn']").attr('disabled', 'disabled');
        $("input[id^='btn']").ejToggleButton("disable")
        treeview.destroy();
    }
    else {
        $("#LayoutSection_ControlsSection_treeview").ejTreeView(
                     {
                         showCheckbox: true,
                         allowEditing: true
                     });
        $("button[id^='btn']").removeAttr('disabled');
        $("input[id^='btn']").ejToggleButton("enable")
        treeview = $("#LayoutSection_ControlsSection_treeview").data("ejTreeView");
    }
}