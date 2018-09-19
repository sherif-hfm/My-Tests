
var splitterObj, i = 0;
$(function () {
    splitterObj = $("#LayoutSection_ControlsSection_outterSplitter").data("ejSplitter");
    $("#sampleProperties").ejPropertiesPanel();
});
function expandpane() {
    splitterObj.expand(parseInt($('#paneindex').val()));
}
function collapsepane() {
    splitterObj.collapse(parseInt($('#paneindex').val()));
}
function add(){
    var property = {};
    property["paneSize"] = parseInt($('#size').val()) || 0;
    property["minSize"] = parseInt($('#min').val()) || 0;
    property["maxSize"] = parseInt($('#max').val()) || null;
    splitterObj.addItem("New Pane " + i++, property, parseInt($('#paneindex').val()));
}
function removepane() {
	if($("#"+splitterObj._id+">.e-pane").length>1)
    splitterObj.removeItem(parseInt($('#paneindex').val()));
}
