#pragma checksum "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81dd63bc36016dc1a90d9789ed9a05999a5a729b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Cancelled), @"mvc.1.0.view", @"/Views/User/Cancelled.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81dd63bc36016dc1a90d9789ed9a05999a5a729b", @"/Views/User/Cancelled.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd383c2eb8b50da9e0497874b12c6e5c8bfa323e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_Cancelled : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("media-object"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
  
    ViewData["Title"] = "Cancelled";
    Layout = "~/Views/Shared/_Layout2.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content"">

    <div class=""row"">
        <div class=""col-md-12"">
            <section class=""panel tasks-widget"">
                <header class=""panel-heading"">
                    Cancelled
                </header>
                <div class=""panel-body table-responsive"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>Product Name</th>
                                <th>Image</th>
                                <th>Quantity</th>
                                <th>Price</th>
                                <th>Total Price</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 28 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
                             foreach (var or in ViewBag.lstCancelled)
                            {
                                foreach (var de in ViewBag.lstOrderDetail)
                                {
                                    if (or.OrderId == de.OrderId)
                                    {
                                        foreach (var item in ViewBag.lstProduct)
                                        {
                                            if (item.ProductId == de.ProductId)
                                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td style=\"padding-top:40px\">");
#nullable restore
#line 40 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
                                                                            Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "81dd63bc36016dc1a90d9789ed9a05999a5a729b6058", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1746, "~/images/product-details/product/", 1746, 33, true);
#nullable restore
#line 41 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
AddHtmlAttributeValue("", 1779, item.ProductImage, 1779, 18, false);

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
            WriteLiteral("</td>\r\n                                                    <td style=\"padding-top:40px\">");
#nullable restore
#line 42 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
                                                                            Write(de.OrderDetailsNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td style=\"padding-top:40px\">");
#nullable restore
#line 43 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
                                                                            Write(item.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                                    <td style=\"padding-top:40px\">");
#nullable restore
#line 44 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
                                                                            Write(or.OrderTotalMoney);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td style=\"padding-top:40px\">\r\n");
            WriteLiteral("                                                        <a");
            BeginWriteAttribute("href", " href=\"", 2338, "\"", 2377, 2);
            WriteAttributeValue("", 2345, "/User/Reorder?Id=", 2345, 17, true);
#nullable restore
#line 47 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
WriteAttributeValue("", 2362, item.ProductId, 2362, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"alert(confirm(\'Bạn có muốn mua lại sản phẩm?\'))\"><button class=\"btn btn-default btn-xs\"><i class=\"fa fa-times\"></i></button></a>\r\n");
            WriteLiteral("                                                        <a");
            BeginWriteAttribute("href", " href=\"", 2921, "\"", 2969, 2);
            WriteAttributeValue("", 2928, "/Product/ProductDetail?Id=", 2928, 26, true);
#nullable restore
#line 51 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
WriteAttributeValue("", 2954, item.ProductId, 2954, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Đánh Gía</a>\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 54 "E:\Visual Studio 2019\Project_PRN221\ProjectPRN221\ProjectPRN221\ProjectPRN221\Views\User\Cancelled.cshtml"
                                            }
                                        }
                                    }
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </section>\r\n        </div>\r\n    </div>\r\n</section>\r\n<div class=\"footer-main\">\r\n    Copyright &copy Director, 2022\r\n</div>\r\n\r\n");
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
