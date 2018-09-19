var rteObj;
$(function () {
    // declaration
    rteObj = $("#LayoutSection_ControlsSection_fileExplorer").data("ejFileExplorer")
    $("#LayoutSection_EventSection_selectControls").ejDropDownList({
        popupShown: "adjustpopupposition",
        showCheckbox: true,
        checkAll: true,
        change: "evtpropscheckedevent"
    });
});

function evtpropscheckedevent(args) {
    if (args.isChecked) {
        switch (args.value) {
            case "layoutChange": rteObj.option(args.value, "onLayoutChange"); break;
            case "select": rteObj.option(args.value, "onSelect"); break;
            case "createFolder": rteObj.option(args.value, "onCreateFolder"); break;
            case "remove": rteObj.option(args.value, "onRemove"); break;
            case "cut": rteObj.option(args.value, "onCut"); break;
            case "copy": rteObj.option(args.value, "onCopy"); break;
            case "paste": rteObj.option(args.value, "onPaste"); break;
            case "open": rteObj.option(args.value, "onOpen"); break;
        }
    }
    else rteObj.option(args.value, null);
}


function onLayoutChange(args) {
    jQuery.addEventLog("current view: " + args.layoutType);
}
function onSelect(args) {
    jQuery.addEventLog("item has been selected");
}
function onCreateFolder(args) {
    jQuery.addEventLog("new folder created");
}
function onRemove(args) {
    jQuery.addEventLog("item removed");
}

function onCut(args) {
    jQuery.addEventLog("cut operation performed");
}
function onCopy(args) {
    jQuery.addEventLog("copy operation performed");
}
function onPaste(args) {
    jQuery.addEventLog("paste operation performed");
}
function onOpen() {
    jQuery.addEventLog("file opened");
}

function onClear() {
    jQuery.clearEventLog();
}