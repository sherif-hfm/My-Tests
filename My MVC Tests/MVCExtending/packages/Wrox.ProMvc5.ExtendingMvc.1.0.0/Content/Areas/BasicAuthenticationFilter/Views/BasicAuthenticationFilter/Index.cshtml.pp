@model $rootnamespace$.Areas.BasicAuthenticationFilter.Models.User
@{ ViewBag.Title = "Authentication Filter Sample"; }
<p>This URL allows anonymous access.</p>
<p>The @Html.ActionLink("Authenticated URL", "Authenticated") requires you to authenticate.<br/>
    Use the password "secret" with any username.</p>
