
var eDialog;
$(function () {
    eDialog = $("#LayoutSection_ControlsSection_dialogAPI").data("ejDialog");
    $("#sampleProperties").ejPropertiesPanel();
       
});
function onButtonCreate(e) {
    $("#LayoutSection_ControlsSection_btnOpen").hide();
}
function onDialogClose(args) {
    $("#LayoutSection_ControlsSection_btnOpen").show();
}
function onOpen() {
    eDialog = $("#LayoutSection_ControlsSection_dialogAPI").data("ejDialog");
    if (eDialog.model) {
        eDialog.open();
        $("#LayoutSection_ControlsSection_btnOpen").hide();
    }
}
function onClose() {
    eDialog = $("#LayoutSection_ControlsSection_dialogAPI").data("ejDialog");
    eDialog.close();
}
function onIsOpen() {
    eDialog = $("#LayoutSection_ControlsSection_dialogAPI").data("ejDialog");
    if (eDialog.model) {
        var _isopen = eDialog.isOpen();
        if (_isopen)
            alert("Dialog Open");
        else
            alert("Dialog Closed");
    }
    else
        alert("Dialog is in Destoryed state");
}
function onDestoryRestore(args) {
    if (args.isChecked) {
        $("#LayoutSection_ControlsSection_dialogAPI").ejDialog("destroy");
        $("#LayoutSection_ControlsSection_btnOpen").hide();
    }
    else {
        $("#LayoutSection_ControlsSection_dialogAPI").ejDialog({
            content: ".cols-sample-area",
            close: "onDialogClose",
            title: "Essential Grid"
        });
        eDialog = $("#LayoutSection_ControlsSection_dialogAPI").data("ejDialog");
    }
}
function btnclick() {
    eDialog = $("#LayoutSection_ControlsSection_dialogAPI").data("ejDialog");
    if (eDialog.model)  {   
        eDialog.open();
        $("#LayoutSection_ControlsSection_btnOpen").hide();
    }
}