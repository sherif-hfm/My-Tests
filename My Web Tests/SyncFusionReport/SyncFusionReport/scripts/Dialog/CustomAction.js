﻿
function onDialogClose(args) {
    $("#LayoutSection_ControlsSection_btnOpen").show();
}
function btnclick() {
    var dialogObj = $("#LayoutSection_ControlsSection_dialogIcon").data("ejDialog");
    dialogObj.open();
    $("#LayoutSection_ControlsSection_btnOpen").hide();
}
function onButtonCreate(e) {
  
    $("#LayoutSection_ControlsSection_btnOpen").hide();
}