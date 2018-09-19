<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="CallPageWebMethod.WebUserControl1" %>

 <div>
     <input id="btnSave" type="button" value="Send" />
</div>

<script type="text/javascript">
        $(function () {
            $('#btnSave').on('click', function () {
                var data = {};
                data.fName = "Sherif";
                data.sName = "Hamdy";
                $.ajax({
                    type: "POST",
                    url: "index.aspx/Test",
                    data: JSON.stringify(data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        console.log(msg)
                    }
                });
            })
        });
    </script>
