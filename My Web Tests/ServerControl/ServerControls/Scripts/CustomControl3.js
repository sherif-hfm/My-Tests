var allCtrls = new Object();

Type.registerNamespace("ServerControls");

ServerControls.CustomControl3 = function (element) {
    ServerControls.CustomControl3.initializeBase(this, [element]);
    console.log('initializeBase');
    console.log(this);
    // "private" variable to hold the Name properties value
    this._mapWindowWidth = null;
    this.Id = this.get_element().id;
};

ServerControls.CustomControl3.prototype = {
    initialize: function () {
        ServerControls.CustomControl3.callBaseMethod(this, "initialize");
        var id = this.get_element().id;
        allCtrls[id] = this;
        console.log('initialize element Id:' + id);
        console.log(this);
    },
    dispose: function () {
        $clearHandlers(this.get_element());
        ServerControls.CustomControl3.callBaseMethod(this, "dispose");
    },
    // property getter
    get_MapWindowWidth: function () {
        console.log('get_MapWindowWidth');
        return this._mapWindowWidth;
    },
    // property Setter
    set_MapWindowWidth: function (value) {
        console.log('set_MapWindowWidth Value = ' + value);
        this._mapWindowWidth = value;
    },
    add_OnMapWindowClosed: function (handler) {
        console.log("add_OnMapWindowClosed");
        console.log(handler);
        this.get_events().addHandler("OnMapWindowClosed", handler);
    },
    remove_OnMapWindowClosed: function (handler) {
        console.log("remove_OnMapWindowClosedr");
        console.log(handler);
        this.get_events().removeHandler("OnMapWindowClosed", handler);
    },
    _onOnMapWindowClosed: function (source, e) {
        console.log("_onOnMapWindowClosed");
        console.log(source);
        if (!this._events) return;
        var handler = this._events.getHandler("OnMapWindowClosed");
        if (handler)
            handler(source,e);
    },
    get_ElementProperty: function ()
    {
        console.log("ElementProperty Get")
        return 0;
    },
    set_ElementProperty: function (value) {
        console.log("ElementProperty Set" )
        console.log(value)
    },
    get_ScriptProperty: function () {
        console.log("get_ScriptProperty")
        return this._ScriptProperty;
    },
    set_ScriptProperty: function (value) {
        console.log("set_ScriptProperty : " + value)
        console.log(value)
        this._ScriptProperty = value;
    },
}

ServerControls.CustomControl3.registerClass("ServerControls.CustomControl3", Sys.UI.Control);
if (typeof (Sys) !== "undefined") Sys.Application.notifyScriptLoaded();

function ScriptPropertyFunc() {
    console.log("ScriptPropertyFunc");
    //return arguments.callee; // return the function itself
    return "Script";
}


$(document).ready(function () {
    $.each(allCtrls, function (index, value) {
        console.log(index);
        console.log(value.get_ScriptProperty());
        $('#' + index).on('click', function () {
            console.log("click: " + index);
            //$.fancybox({ type: 'inline', content: $("#divMap").html(), 'autoSize': false, 'scrolling': 'no', 'width': 770, 'height': 620 });
            $.fancybox.open({
                'type': 'iframe', 'href': '<%= WebResource("ServerControls.Map.html")%>', 'autoSize': false, 'scrolling': 'no', 'width': value.get_MapWindowWidth(), 'height': 620,
                beforeClose: function () {
                    console.log("fancybox.beforeClose : " + index);
                    value._onOnMapWindowClosed(value, "Args");
                    //var myData = $("#hdnData", $(".fancybox-iframe").contents()).val();
                    var myData = $(".fancybox-iframe").contents().find("#hdnData").val();
                    console.log(myData);
                },
                afterLoad: function () {
                    console.log("fancybox.afterLoad: " + index);
                    $(".fancybox-iframe").contents().find("#txt1").val(index);
                },
            });
        });
    });
});

