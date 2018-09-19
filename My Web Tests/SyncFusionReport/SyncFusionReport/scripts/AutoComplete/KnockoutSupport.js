var autocomplete;
$(function () {
    var countryList = ["United States", "Australia", "Austria", "India"];
    $('#country').ejAutocomplete({
        watermarkText: "Select country",
        showPopupButton: true,
        dataSource: countryList
    });
    $('#state').ejAutocomplete({
        showPopupButton: true     
    });
    $("#GetValue").click(function () {
        alert("Current value is : " + autocomplete.getValue());
    });
    var stateObj = $('#state').data("ejAutocomplete");
    stateObj.disable();
    // declaration             
    var ViewModel = function () {
        var usaStates = ["California", "New York", "South Carolina", "Washington"];
        var australiaStates = ["West Island", "Sydney", "Kingston", "Melbourne"];
        var austriaStates = ["Burgenland", "Carinthia", "Styria", "Vienna"];
        var indiaStates = ["Tamil Nadu", "Rajasthan", "West Bengal", "Maharashtra"];

        this.countryName = ko.observable();
        this.stateName = ko.computed(function () {
            var source = null;
            switch (this.countryName()) {
                case "United States": source = usaStates; break;
                case "Australia": source = australiaStates; break;
                case "Austria": source = austriaStates; break;
                case "India": source = indiaStates; break;
            }
            if (source) {
                stateObj.enable();
                stateObj.setModel({ dataSource: source });
                return source[0];
            }
            else stateObj.setModel({ dataSource: null });

            return "";
        }, this);
    };
    ko.applyBindings(new ViewModel());
    $("#sampleProperties").ejPropertiesPanel();
    autocomplete = $('#country').data("ejAutocomplete");
    autocomplete1 = $('#state').data("ejAutocomplete");
});


function changeState(args) {
    if (args.isChecked) {
        autocomplete.disable();
        autocomplete1.disable();
    }

    else {
        autocomplete.enable();
        autocomplete1.enable();
    }
}