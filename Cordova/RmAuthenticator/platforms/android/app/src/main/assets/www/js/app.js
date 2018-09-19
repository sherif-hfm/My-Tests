function initApp()
{
    ///
    console.log('Start');
   
    AddPermission();
    var info = localStorage.getItem("UsersInfo");
    if (info != null && info.length > 2)
    {
        ShowAccountsList();
    }
    else
    {
        ShowLogin();
    }


    $('#btnLogin').on('click', function () {
        console.log('click');

        var userExist=FindAccountByUserLogin($('#txtUserLogin').val())
        if(userExist != null)
        {
            alert('الحساب مضاف من قبل');
            return;
        }
        var url1 = 'http://10.0.2.2:8010/Otp/UserLogin';
        var url2 = 'http://10.110.1.143:5030/Otp/UserLogin';
        var url =  'http://eservices.alriyadh.gov.sa:6080/Otp/UserLogin';
        
        var appId = localStorage.getItem("AppId");
        if (info != null)
            _userInfo.AppId=appId;
        _userInfo.UserLogin = $('#txtUserLogin').val();
        _userInfo.Password = $('#txtPassword').val();
        var DataStr = JSON.stringify(_userInfo);
        console.log(DataStr);
        $.mobile.loading( 'show', {theme: 'b',textVisible:false});
        $.ajax
        ({
            type: "POST",
            url: url,
            dataType: 'json',
            async: true,
            data: _userInfo,
            headers: {
                "Authorization": "Basic " + GtBaseAuth()
              },
            success: function (result){
                console.log(result);
                _userInfo=result.ResultSet;
                localStorage.setItem("AppId", result.ResultSet.AppId);
                if (result.Status == true) {                    
                    console.log('Done');
                    console.log(_userInfo);
                    ShowSms();
                }
                else {
                    alert(result.Message);
                    console.log('Error');
                }
            },
            error:function(){
                alert('حدث خطأ في الاتصال');
            }
        });
        $.mobile.loading( 'hide');
    });

    $('#btnCheckSms').on('click', function () {
        SaveUserTwoFactorAuthInfo();
        StopSmsWatch();
    });

    $('#btnAddAccount').on('click', function ()
    {
        $("#accordion").remove();
        ShowLogin();
    
    });   

    
}

function AddRemoveButtonsEvent()
    {
        $('#btnRemoveAccount').on('click', function ()
        {
            console.log('btnRemoveAccount');
            var userId=$(this).attr('userId');
            console.log('userId' + userId);
            var newAccounts = usersInfo.filter(function( obj ) {
                return obj.UserId !== userId;
            });
            
            console.log('newAccounts');
            console.log(newAccounts);
            usersInfo = newAccounts;
            localStorage.setItem("UsersInfo", JSON.stringify(usersInfo));
            LoadAccountsList();
        }
        );
    }


function GtBaseAuth() {
    var now = new Date();
    return btoa('RmOtp:' + 'dc7f3b22-42fe-4261-b09c-f581fbed1d3f' );
  }

function FindAccountByUserLogin(_userLogin)
{
    for (var i=0; i < usersInfo.length; i++) {
        if (usersInfo[i].UserLogin === _userLogin) {
            return usersInfo[i];
        }
    }
}

function ShowLogin()
{
    $('#divLogin').show();
    $('#divCheckSms').hide();
    $('#divAccountsList').hide();
}

function ShowSms() {
    $('#divLogin').hide();
    $('#divAccountsList').hide();
    $('#divCheckSms').show();
    $('#mobileNo').text(_userInfo.UserMobile);
    //$('#txtSmsCode').val(_userInfo.SmsCode);
    startSmsWatch();
}

function ShowAccountsList() {
    $('#divLogin').hide();
    $('#divCheckSms').hide();
    $('#divAccountsList').show();
    LoadAccountsList();
}

function LoadAccountsList()
{
    var usersInfoStr = localStorage.getItem("UsersInfo");
    if (usersInfoStr != null)
    {
        clearInterval(otpTimer);
        $("#otpContainer").empty();
        $("#accordion").remove();
        usersInfo = JSON.parse(usersInfoStr);
        $.each(usersInfo, function (key, value) {
            var panle = $("#accountTemp" ).html()
            var accordion = '<div id="accordion" class="w3-center"></div>';
            panle = panle.replace("#UserLogin#", value.UserLogin);
            panle = panle.replace("#UserName#", value.UserName);
            panle = panle.replace("#UserId#", value.UserId);
            panle = panle.replace("#Index#", key);
            $("#otpContainer").append(accordion);
            $("#accordion").append(panle);
        });
        
        $("#accordion").accordion();

        AddRemoveButtonsEvent();

        crUserInfo = usersInfo[0];
        ShowOtp();

        $("[name='tfaPanle']").on('click', function () {
            var index = $(this).attr("data-Index");
            crUserInfo = usersInfo[index];
            
            ShowOtp();
        });
    }
    else
    {
        ShowLogin();
    }
}

function SaveUserTwoFactorAuthInfo()
{
    var url1 = 'http://10.0.2.2:8010/Otp/SaveUserTwoFactorAuthInfo';
    var url2 = 'http://10.110.1.143:5030/Otp/SaveUserTwoFactorAuthInfo';
    var url = 'http://eservices.alriyadh.gov.sa:6080/Otp/SaveUserTwoFactorAuthInfo';
    
    var userVerificationInfo={};
    userVerificationInfo.UserId=_userInfo.UserId;
    userVerificationInfo.SmsCode=$('#txtSmsCode').val()
    $.mobile.loading( 'show', {theme: 'b',textVisible:false});
    $.ajax
    ({
        type: "POST",
        url: url,
        dataType: 'json',
        async: true,
        data: userVerificationInfo,
        headers: {
            "Authorization": "Basic " + GtBaseAuth()
          },
        success: function (result){
            console.log(result);
            if (result.Status == true) {
                console.log('Done');
                _userInfo = result.ResultSet;
                console.log(_userInfo);
                usersInfo.push(_userInfo);
                localStorage.setItem("UsersInfo", JSON.stringify(usersInfo));
                ShowAccountsList();
            }
            else {
                alert(result.Message);
                console.log('Error');
            }
        },
        error:function(){
            alert('حدث خطأ في الاتصال');
        }
    });
    $.mobile.loading( 'hide');
}

function startSmsWatch() {
    console.log('start Watch SMS');
    if(SMS) SMS.startWatch(function(){        
        console.log('watching SMS started');
        document.addEventListener('onSMSArrive', function(e){
            console.log('onSMSArrive');
            var data = e.data;
            console.log(e.data);
            $('#txtSmsCode').val(e.data.body);
            $('#btnCheckSms').click();
            StopSmsWatch();
    }, function(){        
        console.log('failed to start SMS watching');
    });
});
}


function StopSmsWatch()
{
    if(SMS) SMS.stopWatch(function(){
        console.log("Stop Sms Watching OK");
    }, function(){
        updateStatus('error Stop Sms Watching');
    });
}

function AddPermission()
{
    var platform = device.platform
    console.log(platform);
    if(platform=='Android')
    {
        var permissions = cordova.plugins.permissions;
        permissions.hasPermission(permissions.RECEIVE_SMS, function( status ){
            if ( status.hasPermission ) {
              console.log("Yes :D ");
            }
            else {
              console.warn("No :( ");
              permissions.requestPermission(permissions.RECEIVE_SMS, function(){
                console.log("Yes2 :D ");
              }, function(){
                console.warn("No2 :( ");
              });
            }
          });
    
    }   
}