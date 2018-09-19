/* APIs.js */

var numobject, percentobject, currencyobject, maskobject;
jQuery(function ($) {

    numobject = $("#LayoutSection_ControlsSection_numeric").data("ejNumericTextbox");
    percentobject = $("#LayoutSection_ControlsSection_percent").data("ejPercentageTextbox");
    currencyobject = $("#LayoutSection_ControlsSection_currency").data("ejCurrencyTextbox");
    maskobject = $("#LayoutSection_ControlsSection_maskedit").data("ejMaskEdit");

        $(".input").blur(function () {
            var val = parseInt(this.value);
            var minVal = parseInt($("[id$=minValue]").val());
            var maxVal = parseInt($("[id$=maxValue]").val());
            if (!isNaN(maxVal) && !isNaN(minVal)) {
                if (maxVal < minVal) {
                    $("[id$=error]").html("Min value exceeds Max value");
                }
                else {
                    if (!isNaN(val)) {
                        numobject.option(this.id, val);
                        percentobject.option(this.id, val);
                        currencyobject.option(this.id, val);
                        $("[id$=error]").html("");
                    }
                }
            }
            else {
                if (!isNaN(val)) {
                    numobject.option(this.id, val);
                    percentobject.option(this.id, val);
                    currencyobject.option(this.id, val);
                    $("[id$=error]").html("");
                }
            }
        });
            
    });
    function onMaskChange(args) {
        maskobject.option("maskFormat", args.value);
    }
    function changeState(args) {
        if (args.isChecked) {
            numobject.disable();
            percentobject.disable();
            currencyobject.disable();
            maskobject.disable();
        }
        else {
            numobject.enable();
            percentobject.enable();
            currencyobject.enable();
            maskobject.enable();
        }
    }