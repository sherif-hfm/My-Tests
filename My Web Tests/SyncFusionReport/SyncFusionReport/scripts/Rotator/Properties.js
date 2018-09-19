
            var slideObj,dropObj;
            $(function () {
                // declaration
     
                slideObj = $("#LayoutSection_ControlsSection_sliderContent").data("ejRotator");
                slideObj.option("change", "onChange");
                dropObj = $('#LayoutSection_PropertySection_itemMove').data('ejDropDownList');
                $("#LayoutSection_ControlsSection_SlideCount").html(slideObj.getIndex() + 1 + "/" + (slideObj.element.find('li').length - (slideObj.model.displayItemsCount * 2)));
                //$("#chkAutoplay").ejCheckBox({ "change": "onAutoplay" });
                $("#sampleProperties").ejPropertiesPanel();
            });
            first = [{ text: "1"}];
            second = [{ text: "1" }, { text: "2"}];
            third = [{ text: "1" }, { text: "2" }, { text: "3"}];
            function onPagerChange(args) {
                slideObj.option({ pagerPosition:args.text });
            }
            function onAnimationChange(args) {
                if (args.text == "SlowSlide") slideObj.option({ animationType: "slowSlide" });
                else if (args.text == "FastSlide") slideObj.option({ animationType: "fastSlide" });
                else if (args.text == "Slide") slideObj.option({ animationType: "slide" });
                else if (args.text == "SlideShow") slideObj.option({ animationType: "slideshow" });
            }
            function onDisplayChange(args) {
                slideObj.option({ displayItemsCount: args.text });
                if (args.text == 1) {
                    dropObj.setModel({ dataSource: first, value: args.text });
                    slideObj.option({ navigateSteps: args.text })
                }
                else if (args.text == 2) {
                    dropObj.setModel({ dataSource: second, value: args.text });
                    slideObj.option({ navigateSteps: args.text })
                }
                else {
                    dropObj.setModel({ dataSource: third, value: args.text });
                    slideObj.option({ navigateSteps: args.text })
                }
            }
            function onMoveChange(args)
            {
                slideObj.option({ navigateSteps: args.text });
            }
            function onOrientationChange(args) {
                slideObj.option({ orientation: args.text }); 
            }
            function onAutoplay(args) {
                slideObj.option({ showPlayButton: args.isChecked });
            };
            function onPager(args) {
                slideObj.option({ showPager: args.isChecked });
            };
            function EnableDisable(args) {
                if(args.isChecked )
				slideObj.enable();
				else
				slideObj.disable();
            };
           
            function previous() {
                slideObj.slidePrevious();
               
            }
            function next() {
                slideObj.slideNext();
               
            }
            function getValue() {
                alert("Current Slide Index : " + slideObj.getIndex());
            }
            function onChange(args) {
                $("#LayoutSection_ControlsSection_SlideCount").html(++args.activeItemIndex +"/"+ (slideObj.element.find('li').length - (slideObj.model.displayItemsCount * 2)));
            }
          