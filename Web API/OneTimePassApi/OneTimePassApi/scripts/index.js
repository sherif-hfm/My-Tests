var progressBarOptions = {
    thickness: 10,
    startAngle: 0,
    size: 25,
    value: 0.0,
    fill: {
        color: '#ffa500'
    }
}

$(function () {

    console.log('Start');
    
    var info = localStorage.getItem("UsersInfo");
    if (info != null)
    {
        ShowAccountsList();
    }
    else
    {
        ShowLogin();
    }
    $('#btnLogin').on('click', function () {
        console.log('click');
        var url1 = 'http://localhost:43336/Otp/UserLogin';
        var url = 'http://localhost:8010/Otp/UserLogin';
        var url2 = 'http://10.0.2.2:8010/Otp/UserLogin';
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
            usersInfo.push(_userInfo);
            localStorage.setItem("UsersInfo", JSON.stringify(usersInfo));
            ShowAccountsList();
        }
    });

    $('#btnAddAccount').on('click', function ()
    {
        ShowLogin();
    }
    );

});

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
    $('#txtSmsCode').val(_userInfo.SmsCode);
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
        $("#accordion").remove();
        usersInfo = JSON.parse(usersInfoStr);
        $.each(usersInfo, function (key, value) {
            var panle = `<div class="w3-panel w3-blue"  name="tfaPanle" data-Index=#Index#>
                <span class ="w3-right">#UserName#</span>
                <span class ="w3-right">&nbsp; - &nbsp; </span>
                <span class ="w3-right">#UserLogin#</span>
                </div>
            <div>
                <div class="circle w3-center w3-row" name="circle-a">
                    <strong>
                        <label name="updatingIn">00</label>
                    </strong>
                </div>
                <div class="w3-row">
                    <label class="w3-text-teal"><b>كود التحقق</b></label>
                    <div class="w3-container">
                        <label class="w3-text-red w3-wide w3-xxlarge" name="otpCode"><b>123</b></label>
                    </div>
                </div>
            </div>`
            var accordion = `<div id="accordion" class="w3-center"></div>`;
            panle = panle.replace("#UserName#", value.UserName);
            panle = panle.replace("#UserLogin#", value.UserCode);
            panle = panle.replace("#Index#", key);
            $("#divAccountsList").append(accordion);
            $("#accordion").append(panle);
        });
        
        $("#accordion").accordion();

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