#pragma checksum "F:\CTS\MailOrderPharmaProject-main\Portal\Portal\Views\Member\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2dcb2295499fda9de4bb9fc8a83e2c370a8e1a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_Index), @"mvc.1.0.view", @"/Views/Member/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\CTS\MailOrderPharmaProject-main\Portal\Portal\Views\_ViewImports.cshtml"
using Portal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\CTS\MailOrderPharmaProject-main\Portal\Portal\Views\_ViewImports.cshtml"
using Portal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2dcb2295499fda9de4bb9fc8a83e2c370a8e1a6", @"/Views/Member/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea73c18953461b2da0883cbece56eb399a5ce162", @"/Views/_ViewImports.cshtml")]
    public class Views_Member_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "F:\CTS\MailOrderPharmaProject-main\Portal\Portal\Views\Member\Index.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    h1 {
        font-family: 'Times New Roman', Times, serif
    }
</style>

<h1 align=""center"">Welcome To Mail Order Pharmacy!</h1>

<hr />

<div class=""container col-12"" style=""align-content:center;padding-right:30px;padding-left:120px;"">

    <div class=""row"" style=""padding-right:10px; margin-bottom:10px;"">
        <div class=""col"">
            <div class=""card"" style=""width: 18rem; height:12rem;"">
                <img class=""card-img-top"" src=""https://wallpaperaccess.com/full/1621424.jpg"" alt=""Card image cap"" width=""50"" height=""100"">
                <div class=""card-body"">
                    <a href=""/Drug/DrugDetailsall"" class=""col btn btn-success m-2"">View Drug Availabilities</a>
                </div>
            </div>
        </div>
        <div class=""col"">
            <div class=""card"" style=""width: 18rem;height:12rem;"">
                <img class=""card-img-top"" src=""https://wallpaperaccess.com/full/4204887.jpg"" alt=""Card image cap"" height=""100"">
                <div class=""card-body"">
 ");
            WriteLiteral(@"                   <a href=""/Refill/getIdforRefilldetails"" class=""col btn btn-primary m-2"">Drug Refill Details</a>
                </div>
            </div>
        </div>
        <div class=""col"">
            <div class=""card"" style=""width: 18rem;height:12rem;"">
                <img class=""card-img-top"" src=""https://wallpaperbat.com/img/418737-medical-wallpaperdownload-free-cool-hd-background.jpg"" alt=""Card image cap"" height=""100"">
                <div class=""card-body"">
                    <a href=""/Subscription/subscriber"" class=""col btn btn-success m-2"">Subscribe to Mail Order</a>
                </div>
            </div>
        </div>
    </div>

    <div class=""row"">
        <div class=""col"">
            <div class=""card"" style=""width: 18rem;height:12rem;"">
                <img class=""card-img-top"" src=""https://swall.teahub.io/photos/small/359-3595145_pharmacy-medicine-images-hd.jpg"" alt=""Card image cap"" height=""100"">
                <div class=""card-body"">
                    <a href=""/Subscription/un");
            WriteLiteral(@"subscriber"" class=""col btn btn-primary m-2"">Unsubscribe to Mail Order</a>
                </div>
            </div>
        </div>
        <div class=""col"">
            <div class=""card"" style=""width: 18rem; height:12rem;"">
                <img class=""card-img-top"" src=""https://thumbs.dreamstime.com/b/customer-pharmacy-holding-medicine-bottle-woman-reading-label-text-medical-information-side-effects-drug-store-144083908.jpg"" alt=""Card image cap"" height=""100"">
                <div class=""card-body"">
                    <a href=""/Refill/ViewRefillDues"" class=""col btn btn-success m-2"">Check Dues for Refill</a>
                </div>
            </div>
        </div>
        <div class=""col"">
            <div class=""card"" style=""width: 18rem; height:12rem;"">
                <img class=""card-img-top"" src=""https://images.livemint.com/img/2020/04/23/1600x900/Para_1587664874862_1587664875068.jpg"" alt=""Card image cap"" height=""100"">
                <div class=""card-body"">
                    <a href=""/Refill/AdhokRefil");
            WriteLiteral(@"lOrder"" class=""col btn btn-primary m-2"">Request Adhoc Refill Details</a>
                </div>
            </div>
        </div>


    </div>

    <div class=""row"" style=""padding-left:100px; padding-right:100px; margin:auto;"">
        <a href=""/Drug/GetDrugId"" class=""col btn btn-primary m-2"">View drug details by Name or ID</a>
    </div>





</div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591