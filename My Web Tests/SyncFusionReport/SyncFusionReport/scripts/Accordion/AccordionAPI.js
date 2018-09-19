 function onEnaleDisableAll(args) {
            if (acrdnObj) {
                if (args.isChecked)
                    acrdnObj.disable();
                else
                    acrdnObj.enable();
            }
        }
        function onDestoryRestore(args) {
            if (args.isChecked) {
                acrdnObj.destroy();
                acrdnObj = null;
            }
            else {
                $("#LayoutSection_ControlsSection_APIAccordion").ejAccordion();
                acrdnObj = $("#LayoutSection_ControlsSection_APIAccordion").data("ejAccordion");
            }
        }
        function onActiveChange(args) {
            if (acrdnObj) {
                acrdnObj.option({ selectedItemIndex: args.itemId });
                $("#optDisableChange").ejDropDownList("clearText");
                $("#optEnableChange").ejDropDownList("clearText");
            }
        }
        function onDisableChange(args) {
            if (acrdnObj) {
                acrdnObj.option({ disabledItems: [args.itemId] });
                $("#optActiveChange").ejDropDownList("clearText");
                $("#optEnableChange").ejDropDownList("clearText");
            }
        }
        function onEnableChange(args) {
            if (acrdnObj) {
                acrdnObj.option({ enabledItems: [args.itemId] });
                $("#optActiveChange").ejDropDownList("clearText");
                $("#optDisableChange").ejDropDownList("clearText");
            }
        }
        function onShowHide(args) {
            if (acrdnObj) {
                if (args.isChecked)
                    acrdnObj.show();
                else
                    acrdnObj.hide();
            }
        }
		function onHeightAdjust(args) {
            if (acrdnObj) {
				acrdnObj.element.find(">.e-content").css("height","");
				acrdnObj.option("heightAdjustMode", args.value);
			}
        }