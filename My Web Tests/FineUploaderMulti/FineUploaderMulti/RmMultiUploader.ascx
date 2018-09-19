<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RmMultiUploader.ascx.cs" Inherits="FineUploaderMulti.RmMultiUploader" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="FineUploader/jquery.fine-uploader.js"></script>
<%--<link href="FineUploader/fine-uploader.css" rel="stylesheet" />--%>
<link href="Controls.css" rel="stylesheet" />
<style type="text/css">
    .qq-uploader DIALOG {
    display: none;
}
</style>

<asp:Repeater ID="rptDocs" runat="server" OnItemDataBound="rptDocs_ItemDataBound">
    <ItemTemplate>
        <script type="text/template" id='<%# Container.ItemIndex + "_qq-template" %>' >
            <div class="qq-uploader-selector qq-uploader" qq-drop-area-text="Drop files here">
                <div class="qq-total-progress-bar-container-selector qq-total-progress-bar-container">
                    <div role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" class="qq-total-progress-bar-selector qq-progress-bar qq-total-progress-bar"></div>
                </div>
                <div class="qq-upload-drop-area-selector qq-upload-drop-area" qq-hide-dropzone>
                    <span class="qq-upload-drop-area-text-selector"></span>
                </div>
                <div>
                    <div class="qq-upload-button-selector qq-upload-button">
                        Upload a file
                    </div>
                </div>
                <span class="qq-drop-processing-selector qq-drop-processing">
                    <span>Processing dropped files...</span>
                    <span class="qq-drop-processing-spinner-selector qq-drop-processing-spinner"></span>
                </span>
                <ul class="qq-upload-list-selector qq-upload-list" aria-live="polite" aria-relevant="additions removals">
                    <li>
                        <div class="qq-progress-bar-container-selector">
                            <div role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" class="qq-progress-bar-selector qq-progress-bar"></div>
                        </div>
                        <span class="qq-upload-spinner-selector qq-upload-spinner"></span>
                        <span class="qq-upload-file-selector qq-upload-file"></span>
                        <span class="qq-edit-filename-icon-selector qq-edit-filename-icon" aria-label="Edit filename"></span>
                        <input class="qq-edit-filename-selector qq-edit-filename" tabindex="0" type="text">
                        <span class="qq-upload-size-selector qq-upload-size"></span>
                        <button type="button" class="qq-btn qq-upload-cancel-selector qq-upload-cancel">Cancel</button>
                        <button type="button" class="qq-btn qq-upload-retry-selector qq-upload-retry">Retry</button>
                        <button type="button" class="qq-btn qq-upload-delete-selector qq-upload-delete">Delete</button>
                        <span role="status" class="qq-upload-status-text-selector qq-upload-status-text"></span>
                    </li>
                </ul>

                <dialog class="qq-alert-dialog-selector">
                    <div class="qq-dialog-message-selector"></div>
                    <div class="qq-dialog-buttons">
                        <button type="button" class="qq-cancel-button-selector">Close</button>
                    </div>
                </dialog>

                <dialog class="qq-confirm-dialog-selector">
                    <div class="qq-dialog-message-selector"></div>
                    <div class="qq-dialog-buttons">
                        <button type="button" class="qq-cancel-button-selector">No</button>
                        <button type="button" class="qq-ok-button-selector">Yes</button>
                    </div>
                </dialog>

                <dialog class="qq-prompt-dialog-selector">
                    <div class="qq-dialog-message-selector"></div>
                    <input type="text">
                    <div class="qq-dialog-buttons">
                        <button type="button" class="qq-cancel-button-selector">Cancel</button>
                        <button type="button" class="qq-ok-button-selector">Ok</button>
                    </div>
                </dialog>
            </div>
        </script>
        <div id="fineuploadergallery1" data-uploder templatename='<%# Container.ItemIndex + "_qq-template" %>' data-DocId='<%# Eval("DocId") %>'></div>
        <asp:Repeater ID="rptFile" runat="server">
            <ItemTemplate>
                <ul class="qq-upload-list-selector qq-upload-list" aria-live="polite" aria-relevant="additions removals">
                    <li class="qq-file-id-1 qq-upload-success" data-UploadedFileContainer='<%# Eval("FileId") %>'>
                        <div class="qq-progress-bar-container-selector qq-hide">
                            <div role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" class="qq-progress-bar-selector qq-progress-bar" style="width: 100%;"></div>
                        </div>
                        <span class="qq-upload-spinner-selector qq-upload-spinner qq-hide"></span>
                        <span class="qq-upload-file-selector qq-upload-file" title="image_big.jpg"><%# Eval("FileName") %></span>
                        <span class="qq-edit-filename-icon-selector qq-edit-filename-icon" aria-label="Edit filename"></span>
                        <input class="qq-edit-filename-selector qq-edit-filename" tabindex="0" type="text">
                        <span class="qq-upload-size-selector qq-upload-size"><%# string.Format(new FileSizeFormatProvider(), "File size: {0:fs}", Eval("FileSize")) %></span>
                        <button data-uploadedfile data-DocId='<%# Eval("DocId")%>' data-qquuid='<%# Eval("FileId") %>' type="button" class="qq-btn qq-upload-delete-selector qq-upload-delete">Delete</button>
                        <span role="status" class="qq-upload-status-text-selector qq-upload-status-text"></span>
                    </li>
                </ul>
                <asp:Label ID="lblFile" runat="server" Text=''></asp:Label>
            </ItemTemplate>
        </asp:Repeater>
    </ItemTemplate>
</asp:Repeater>

<script type="text/javascript">
    $("form").find("[data-uploder]").each(function (e) {
        //alert(this);
        //return;
        $(this).fineUploader({
            template: $(this).attr('templateName'),
            request: {
                endpoint: '/Uploader.ashx',
                params: { Operation: "Add", DocId: $(this).attr('data-DocId') }
            },
            thumbnails: {
                placeholders:
                    {
                        waitingPath: '/FineUploader/placeholders/waiting-generic.png',
                        notAvailablePath: '/FineUploader/placeholders/not_available-generic.png'
                    }
            },
            validation: {
                allowedExtensions: ['pdf', 'jpeg', 'jpg', 'gif', 'png']
            },
            deleteFile: {
                enabled: true,
                endpoint: '/Uploader.ashx', params: { Operation: "Del", DocId: $(this).attr('data-DocId') },
                method: "POST"
            }
        });
    })

    $("form").find("[data-uploadedfile]").each(function () {
        $(this).on('click', function () { DeleteFile($(this)); })
    });

    function DeleteFile(delBtn) {
        $.ajax({
            url: "/Uploader.ashx",
            contentType: "application/json; charset=utf-8",
            responseType: "json",
            dataType: "json",
            data: { "Operation": "Del", "DocId": delBtn.attr("data-DocId"), "qquuid": delBtn.attr("data-qquuid") },
            success: OnComplete,
            error: OnFail
        });
        return false;
    }

    function OnComplete(result) {
        if (result.success = true)
        {
            var fineContainer = "li[data-UploadedFileContainer='" + result.qquuid + "']";
            $("form").find(fineContainer).remove();
            console.log(result.qquuid);
        }
    }

    function OnFail(result) {
        //alert('Request Failed');
    }
</script>
