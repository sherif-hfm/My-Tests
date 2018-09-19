/* KnockoutSupport.js */

var numobject, percentobject, currencyobject, maskobject;
window.viewModel = {
    //editors
    nvalue: ko.observable(100),
    cvalue: ko.observable(80),
    pvalue: ko.observable(50),
    mvalue: ko.observable("")
}
jQuery(function ($) {
    ko.applyBindings(viewModel);
    numobject = $("#numeric").data("ejNumericTextbox");
    percentobject = $("#percent").data("ejPercentageTextbox");
    currencyobject = $("#currency").data("ejCurrencyTextbox");
    maskobject = $("#maskedit").data("ejMaskEdit");
    maskobject.option("maskFormat", "(999)999-9999");
    maskobject.option("customCharacter", "$");
    $(".text1").blur(function () {
        var val = parseInt(this.value);
        if (!isNaN(val)) {
            numobject.option(this.id, val);
            percentobject.option(this.id, val);
            currencyobject.option(this.id, val);
        }
    });
    $("#minValue").blur(function () {
        var val1 = parseInt(this.value);
        var maxval = parseInt($("#maxValue").val());
        if (!isNaN(val1)) {
            if (!isNaN(maxval) && val1 >= maxval) {
                $("#maxValue").val(val1);
                numobject.option(this.id, val1);
                percentobject.option(this.id, val1);
                currencyobject.option(this.id, val1);
                if (val1 > maxval) {
                    $("#maxValue").trigger("blur");
                }
            }
            else{
                numobject.option(this.id, val1);
                percentobject.option(this.id, val1);
                currencyobject.option(this.id, val1);
            }
            }
    });
    $("#maxValue").blur(function () {
        var minval = parseInt($("#minValue").val());
        var val2 = parseInt(this.value);
        
        if (!isNaN(val2)) {

            if (!isNaN(minval) && val2 <= minval) {
                $("#maxValue").val(minval);
                numobject.option(this.id, minval);
                percentobject.option(this.id, minval);
                currencyobject.option(this.id, minval);
                if (val2 <= minval) {
                    $("#minValue").trigger("blur");
                }
            }
            else {
                numobject.option(this.id, val2);
                percentobject.option(this.id, val2);
                currencyobject.option(this.id, val2);
            }
        }
    });
});

function onMaskChange(args) {
    maskobject.option("maskFormat", args.value);
}