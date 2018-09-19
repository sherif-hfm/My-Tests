<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WcfAjaxCall.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-3.1.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input id="btnGetData" type="button" value="Get Data" onclick="GetData()" /> 
    <input id="txtdata" type="text" />
        <img  id="img" src="" />
    </div>
    </form>
    <script type="text/javascript">
        var UserData = {};
        var UserAddress = {};
        UserAddress.Town = 'Alriaydh';
        UserAddress.Street = 'Batha';
        UserAddress.PoBox = '500600';
        var addressArray=[];
        addressArray[0]=UserAddress;
        UserData.UserName = 'Sherif';
        UserData.UserAge = 40;
        UserData.UserAddress = addressArray;

        var DataStr = JSON.stringify({ userData: UserData });
        function GetData() {

            $.ajax({
                type: 'POST', //GET or POST or PUT or DELETE verb
                url: 'http://localhost:65461/Service1.svc/web/GetUserData',
                data: DataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    console.log(msg.GetUserDataResult);
                    //$('#img').attr('src', msg.GetUserDataResult.UserImage);
                },
                error: function (msg) {
                    console.log(msg);
                }
            });
        }

    </script>
    
</body>
</html>
