
//alert("First");

function ShowAlert()
{
    //alert("ShowAlert");
}


//$(document).ready(function () {
//    alert("Jquery My.js");
//});
//var f= function(){
//    alert("My.js");
//}

function Startup()
{
    NumberOnly();
}

//Sys.Application.remove_load(Startup);
//Sys.Application.add_load(Startup);


function NumberOnly() {
    //alert("NumberOnly");
    $('form').find('[number]').each(function (index) {
        $(this).on("keypress", function (event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        });

        $(this).on("focusout", function () {
            if (isNaN($(this).val())) {
                $(this).val("");
            }
        });
    });
}