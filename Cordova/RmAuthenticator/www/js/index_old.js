
$(function () {

    console.log('Start');
    document.addEventListener('deviceready', initApp, false);
    var userSecKey = localStorage.getItem("UserSecKey");
    if (userSecKey != null)
    {
        ShowOtp();
    }
    else
    {
        ShowLogin();
    }
    $('#btnLogin').on('click', function () {
        console.log('click');
        var url = 'http://10.0.2.2:8010/Otp/UserLogin';
        _userInfo.UserName = $('#txtUserName').val();
        _userInfo.Password = $('#txtPassword').val();
        var DataStr = JSON.stringify(_userInfo);
        console.log(DataStr);
        $.post(url, _userInfo,
            function (result) {
                console.log(result);
                if (result.Status == true) {
                    console.log('Done');
                    console.log(result.ResultSet.UserSecKey);
                    _userInfo = result.ResultSet;
                    ShowSms();
                }
                else {
                    console.log('Error');
                }
            }
                , 'json');
    });

    $('#btnCheckSms').on('click', function () {
        if ($('#txtSmsCode').val() == _userInfo.SmsCode)
        {
            localStorage.setItem("UserSecKey", _userInfo.UserSecKey);
            ShowOtp();
        }
    });

});

function ShowLogin()
{
    $('#divLogin').show();
    $('#divCheckSms').hide();
}

function ShowSms() {
    $('#divLogin').hide();
    $('#divCheckSms').show();
    $('#mobileNo').text(_userInfo.UserMobile);
    //$('#txtSmsCode').val(_userInfo.SmsCode);
}

function ShowOtp() {
    $('#divLogin').hide();
    $('#divCheckSms').hide();
    updateOtp();
    setInterval(timer, 1000);

}

function initApp()
{
    console.log('initApp');
    startWatch();
    document.addEventListener('onSMSArrive', function(e){
        console.log('onSMSArrive');
        var data = e.data;
        console.log(e.data);
    });
}

function startWatch() {
    console.log('startWatch');
    if(SMS) SMS.startWatch(function(){        
        console.log('watching started');
    }, function(){        
        console.log('failed to start watching');
    });
}