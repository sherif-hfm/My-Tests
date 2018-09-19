var dialogObj;
$(function () {
    var dialogObj = $("#LayoutSection_ControlsSection_eventDialog").data("ejDialog");
    $(".e-dialog-icon,.e-icon e-close").click(function () {
        $("#LayoutSection_ControlsSection_btnOpen").show();
    });   
});
function onButtonCreate(e) {
    $("#LayoutSection_ControlsSection_btnOpen").hide();
}
function btnclick() {
    var dialogObj = $("#LayoutSection_ControlsSection_eventDialog").data("ejDialog");
    dialogObj.open();
    $("#LayoutSection_ControlsSection_btnOpen").hide();
}