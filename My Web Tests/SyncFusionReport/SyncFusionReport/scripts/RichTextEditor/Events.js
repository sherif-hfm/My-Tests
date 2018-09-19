var rteObj;
$(function () {
    // declaration
    rteObj = $("#LayoutSection_ControlsSection_RTEEvents").data("ejRTE")
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
            case "create": rteObj.option(args.value, "oncreate"); break;
            case "prerender": rteObj.option(args.value, "OnPreRender"); break;
            case "keydown": rteObj.option(args.value, "onKeydown"); break;
            case "keyup": rteObj.option(args.value, "onKeyup"); break;
            case "change": rteObj.option(args.value, "onchange"); break;
            case "execute": rteObj.option(args.value, "onExecute"); break;
            
        }
    }
    else rteObj.option(args.value, null);
}


function onCreate(args) {
            jQuery.addEventLog("RTE has been <span class='eventTitle'>created</span>.");
}
        function OnPreRender() {
            jQuery.addEventLog("RTE <span class='eventTitle'>preRender</span> event has been triggered.");
        }
        function onChange(args) {
            jQuery.addEventLog("RTE value has been <span class='eventTitle'>changed</span>.");
        }

        function onKeydown(args) {
            jQuery.addEventLog("<span class='eventTitle'>Keydown</span> event is fired.");
        }

        function onKeyup(args) {
            jQuery.addEventLog("<span class='eventTitle'>Keyup</span> event is fired.");
        }

        function onExecute(args) {
            jQuery.addEventLog(args.commandName + " command has been <span class='eventTitle'>Executed</span>");
        }

        function onClear() {
            jQuery.clearEventLog();
        }