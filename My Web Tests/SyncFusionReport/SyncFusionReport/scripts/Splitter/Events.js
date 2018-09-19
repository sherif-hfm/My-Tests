
     var splitterOutter, splitterInner;
$(function () {
          
    splitterOutter = $("#LayoutSection_ControlsSection_outersplitter").data("ejSplitter");
    splitterInner = $("#LayoutSection_ControlsSection_outersplitter_ctl00_innersplitter").data("ejSplitter");
});

function evtpropscheckedevent(args) {
    if (args.isChecked) {
        switch (args.data.itemValue) {
            case "expandCollapse":
                splitterOutter.option(args.data.itemValue, "oncollapse");
                splitterInner.option(args.data.itemValue, "oncollapse");
                break;
            case "resize":
                splitterOutter.option(args.data.itemValue, "onresize");
                splitterInner.option(args.data.itemValue, "onresize");
                break;
        }
    }
    else {
        splitterOutter.option(args.data.itemValue, null);
        splitterInner.option(args.data.itemValue, null);
    }
}

function oncreate(args) {
    splitterid=("LayoutSection_ControlsSection_outersplitter" == this.element[0].id)?"outersplitter":"innersplitter";
    jQuery.addEventLog(splitterid + " has been <span class='eventTitle'>created</span>.");
}
function oncollapse(args) {
    collapsedid = ("LayoutSection_ControlsSection_outersplitter_ctl00_innersplitter" == args.collapsed.item[0].id) ? "innersplitter" : args.collapsed.item[0].id;
    expandedid = ("LayoutSection_ControlsSection_outersplitter_ctl00_innersplitter" == args.expanded.item[0].id) ? "innersplitter" : args.expanded.item[0].id;
    jQuery.addEventLog(collapsedid + " has been <span class='eventTitle'>collapsed</span> and " +
        expandedid + " has been <span class='eventTitle'>expanded</span>.");
}
function onresize(args) {
    jQuery.addEventLog("Splitter has been <span class='eventTitle'>resized</span>.");
}
function onClear() {
    $("#EventLog").html("");
}
