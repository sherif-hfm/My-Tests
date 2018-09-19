//Function triggers while check the checkbox in tree view and it adds the checked item text to dropdownlist value
function checkScroll(args) {
    dropdownobj = $("#LayoutSection_ControlsSection_selectFolder").data("ejDropDownList");
    var scrolpos = dropdownobj.scrollerObj.model.scrollTop;
    dropdownobj._refreshScroller();    
    dropdownobj.popupList.css("display", "block");
    dropdownobj.scrollerObj.setModel({ "scrollTop": scrolpos });
}

function onNodeCheck(args) {
    var browser = ej.browserInfo();
    dropdownobj = $("#LayoutSection_ControlsSection_selectFolder").data("ejDropDownList");
    if ($(args.currentElement.children("ul")).text() == "")
        dropdownobj._addText((args.value));
    else {
        var data = dropdownobj.getValue().split(",");
        if (args.currentCheckedNodes != "") {
            var checkeditems = args.currentCheckedNodes;
            for (i = 0; i < checkeditems.length; i++) {
                if ((checkeditems[i + 1] != undefined) && (data[i] != checkeditems[i + 1]))
                    dropdownobj._addText(checkeditems[i + 1].text);
            }
        }
        else {
            var checkeditems = this.getCheckedNodes();
            for (i = 0; i < checkeditems.length; i++) {
                if (browser.name == "msie" && parseInt(browser.version) == 8) {
                    if (((checkeditems[i] != undefined) && (data[i] != checkeditems[i].innerText)) && ($(checkeditems[i]).children("ul.e-treeview-ul")[0] == undefined)) {
                        dropdownobj._addText(checkeditems[i].innerText);
                    }
                }
                else {
                    if (((checkeditems[i] != undefined) && (data[i] != checkeditems[i].textContent)) && ($(checkeditems[i]).children("ul.e-treeview-ul")[0] == undefined)) {
                        dropdownobj._addText(checkeditems[i].textContent);
                    }
                }
            }
        }
    }
}
//Function triggers while uncheck the checkbox in tree view and it removes the unchecked item text from dropdownlist value
function onNodeUnCheck(args) {
    var browser = ej.browserInfo();
    dropdownobj = $("#LayoutSection_ControlsSection_selectFolder").data("ejDropDownList");
    if ($(args.currentElement.children("ul")).text() == "")
        dropdownobj._removeText((args.value));
    else {
        var data = dropdownobj.getValue().split(",");
        if (args.currentCheckedNodes != undefined) {
            var uncheckeditems = args.currentUncheckedNodes;
            for (i = 0; i < uncheckeditems.length; i++) {
                if ((uncheckeditems[i + 1] != undefined))
                    dropdownobj._removeText(uncheckeditems[i + 1].nodeText);
            }
        }
        else {
            var checkeditems = this.getCheckedNodes();
            dropdownobj.clearText();
            for (i = 0; i < checkeditems.length; i++) {
                if (browser.name == "msie" && parseInt(browser.version) == 8) {
                    if (((checkeditems[i] != undefined) && (data[i] != checkeditems[i].innerText)) && ($(checkeditems[i]).children("ul.e-treeview-ul")[0] == undefined)) {
                        dropdownobj._addText(checkeditems[i].innerText);
                    }
                }
                else {
                    if (((checkeditems[i] != undefined) && (data[i] != checkeditems[i].textContent)) && ($(checkeditems[i]).children("ul.e-treeview-ul")[0] == undefined)) {
                        dropdownobj._addText(checkeditems[i].textContent);
                    }
                }
            }

        }
    }
}
// check & uncheck the checkbox when click on text
function onNodeSelect(args) {
    var treeobj = $(args).parents("#LayoutSection_ControlsSection_selectFolder_ctl00_Treeview").data("ejTreeView");
    if (args.currentElement != undefined) {
        if (!$(args.currentElement.children().find("input.nodecheckbox")).hasClass("checked"))
            this.checkNode(args.currentElement);
        else
            this.uncheckNode(args.currentElement);
    }
}