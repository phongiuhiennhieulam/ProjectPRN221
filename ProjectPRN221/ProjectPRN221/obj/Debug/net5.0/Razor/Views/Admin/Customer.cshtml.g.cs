#pragma checksum "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c69c8cc95e2d78ea93c083d02605cfb56a108bb2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Customer), @"mvc.1.0.view", @"/Views/Admin/Customer.cshtml")]
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
#line 1 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\_ViewImports.cshtml"
using ProjectPRN221;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\_ViewImports.cshtml"
using ProjectPRN221.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
using X.PagedList.Mvc.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c69c8cc95e2d78ea93c083d02605cfb56a108bb2", @"/Views/Admin/Customer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd383c2eb8b50da9e0497874b12c6e5c8bfa323e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Customer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
  
    ViewData["Title"] = "Customer";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<!-- Main content -->
<section class=""content"">

    <!-- Main row -->
    <div class=""row"">

        <div class=""col-md-12"">
            <section class=""panel"">
                <header class=""panel-heading"">
                    List Customer
                </header>
");
#nullable restore
#line 23 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                 if (ViewBag.messC != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""alert alert-success"">
                        <button data-dismiss=""alert"" class=""close close-sm"" type=""button"">
                            <i class=""fa fa-times""></i>
                        </button>
                        <strong>Well done!</strong> ");
#nullable restore
#line 29 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                               Write(ViewBag.messC);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 31 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                 using (Html.BeginForm("Customer", "Admin", FormMethod.Get))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"input-group\">\r\n                        <input type=\"text\" name=\"search\"");
            BeginWriteAttribute("value", " value=\"", 1100, "\"", 1123, 1);
#nullable restore
#line 35 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
WriteAttributeValue("", 1108, ViewBag.search, 1108, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control rounded\" placeholder=\"Search\" aria-label=\"Search\" aria-describedby=\"search-addon\" />\r\n                        <input type=\"submit\" class=\"btn btn-primary\" value=\"Search\" />\r\n                    </div>\r\n");
#nullable restore
#line 38 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""panel-body table-responsive"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>FullName</th>
                                <th>Gender</th>
                                <th>Address</th>
                                <th>Email</th>
                                <th>Phone</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 53 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                             foreach (var item in ViewBag.lstCustomer)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 56 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                   Write(item.AccountId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 57 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                   Write(item.AccountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 58 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                     if (item.AccountGender == true)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>Male</td>\r\n");
#nullable restore
#line 61 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                     if (item.AccountGender == false)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>Female</td>\r\n");
#nullable restore
#line 65 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 66 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                   Write(item.AccountAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 67 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                   Write(item.AccountEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 68 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                   Write(item.AccountPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 69 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                                   Write(item.AccountStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    \r\n                                        <td>\r\n                                            <div class=\"pull-right hidden-phone\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c69c8cc95e2d78ea93c083d02605cfb56a108bb211584", async() => {
                WriteLiteral("<button class=\"btn btn-default btn-xs\"><i class=\"fa fa-pencil\"></i></button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3147, "~/Admin/ViewOrderMember?Id=", 3147, 27, true);
#nullable restore
#line 73 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
AddHtmlAttributeValue("", 3174, item.AccountId, 3174, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3319, "\"", 3365, 2);
            WriteAttributeValue("", 3326, "/Admin/UnLockAccount?Id=", 3326, 24, true);
#nullable restore
#line 74 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
WriteAttributeValue("", 3350, item.AccountId, 3350, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"alert(confirm(\'Bạn có muốn mở khóa người dùng?\'))\"><button class=\"btn btn-default btn-xs\"><i class=\"fa fa-check\"></i></button></a>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3561, "\"", 3605, 2);
            WriteAttributeValue("", 3568, "/Admin/LockAccount?Id=", 3568, 22, true);
#nullable restore
#line 75 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
WriteAttributeValue("", 3590, item.AccountId, 3590, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" onclick=""alert(confirm('Bạn có muốn khóa người dùng?'))""><button class=""btn btn-default btn-xs""><i class=""fa fa-times""></i></button></a>
                                            </div>
                                        </td>
                                    
                                </tr>
");
#nullable restore
#line 80 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                    ");
#nullable restore
#line 83 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\Admin\Customer.cshtml"
               Write(Html.PagedListPager((IPagedList)ViewBag.lstCustomer, page => Url.Action("Customer", new { page })));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </section>
            <div class="" add-task-row"">
                <a class=""btn btn-success btn-sm pull-left"" href=""/Admin/AddCustomer"">Add New Customer</a>
            </div>
        </div><!--end col-6 -->
    </div>
    <!-- row end -->
</section><!-- /.content -->
<div class=""footer-main"">
    Copyright &copy Director, 2022
</div>

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
