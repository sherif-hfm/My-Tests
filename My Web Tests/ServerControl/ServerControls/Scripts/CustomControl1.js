alert("OK");
var allCtrls = new Object();

Type.registerNamespace("ServerControls");

ServerControls.CustomControl1 = function (element) {
    ServerControls.CustomControl1.initializeBase(this, [element]);
    
    // "private" variable to hold the Name properties value
    this._text = null;
    this._onClientClick = null;
};

ServerControls.CustomControl1.prototype = {
    initialize: function () {
        ServerControls.CustomControl1.callBaseMethod(this, "initialize");
        //console.log("Add Ctrl " + this.get_element().id);
        allCtrls[this.get_element().id] = this;
        var btnName = this.get_element().id + '_Button';
        var txtName = this.get_element().id + '_Text';
        var btn = $('#' + btnName)
        var txt = $('#' + txtName)
        this.Button = btn;
        this.Text = txt;
        //console.log(this.get_Text());
        btn.on("click", { Sender: this, funcName: this.get_OnClientClick() }, this.btn_onclick);
    },
    dispose: function () {
        $clearHandlers(this.get_element());
        ServerControls.CustomControl1.callBaseMethod(this, "dispose");
    },

    // Name Property Accessors
    get_Text: function () {
        return this._text;
    },
    set_Text: function (value) {
        console.log(value);
        this._text = value;
        if (typeof (this.Text) !== "undefined") {
            this.Text.attr("value", value);
        }
    },
    get_OnClientClick: function () {
        return this._onClientClick;
    },
    set_OnClientClick: function (value) {
        this._onClientClick = value;
    },

    // Custom Client Function
    GetId: function () {
        return this.get_element().id;
    },
    btn_onclick: function (e)
    {
        var func = window[e.data.funcName](e.data.Sender, e);
        //console.log($(e.data.Sender.get_element()).attr('Onclick'));
        if (func != false)
            eval($(e.data.Sender.get_element()).attr('Onclick'));
    }

};

function FindCtrl(ctrlId)
{
    //console.log(ctrlId);
    //console.log(allCtrls);
    return allCtrls[ctrlId];
}

ServerControls.CustomControl1.registerClass("ServerControls.CustomControl1", Sys.UI.Control);
if (typeof (Sys) !== "undefined") Sys.Application.notifyScriptLoaded();