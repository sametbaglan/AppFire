#pragma checksum "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae020bd8f25f068f29446181aa2023ae162dc944"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expenses_MounthExpenses), @"mvc.1.0.view", @"/Views/Expenses/MounthExpenses.cshtml")]
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
#line 1 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\_ViewImports.cshtml"
using Fire.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\_ViewImports.cshtml"
using Fire.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\_ViewImports.cshtml"
using Fire.UI.Models.AllViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\_ViewImports.cshtml"
using Fire.UI.Models.CustomerViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\_ViewImports.cshtml"
using Fire.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae020bd8f25f068f29446181aa2023ae162dc944", @"/Views/Expenses/MounthExpenses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eff37adba0bd44ca44ec7676c8f6f02f797baaaa", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Expenses_MounthExpenses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AllLayoutViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Expenses/Delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
  
    ViewData["Title"] = "MounthExpenses";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <header class=\"page-header\">\r\n    </header>\r\n    <table class=\"table table-bordered\">\r\n        <tr>\r\n            <td>Açıklama</td>\r\n            <td>Gider</td>\r\n            <td></td>\r\n        </tr>\r\n");
#nullable restore
#line 17 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
         foreach (var employees in Model.ListExpenses)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
               Write(employees.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
               Write(employees.ExpensesPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-align:right\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 603, "\"", 640, 2);
            WriteAttributeValue("", 610, "/Expenses/Update/", 610, 17, true);
#nullable restore
#line 23 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
WriteAttributeValue("", 627, employees.id, 627, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"id\" class=\"btn btn-warning\" style=\"margin-right:6px !important;\" title=\"Edit\">Güncelle<i class=\"fa fa-edit\"></i></a>\r\n");
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae020bd8f25f068f29446181aa2023ae162dc9447128", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1147, "\"", 1168, 1);
#nullable restore
#line 26 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
WriteAttributeValue("", 1155, employees.id, 1155, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <button type=\"submit\" class=\"btn btn-danger js-sweetalert\" style=\"margin-right:6px !important;\" data-type=\"confirm\" title=\"Delete\">Sil<i class=\"fa fa-trash-o\"></i></button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <div class=\"col-md-10\">\r\n        <span>Toplam Gider</span> <input type=\"text\" name=\"id\" disabled=\"disabled\"");
            BeginWriteAttribute("value", " value=\"", 1579, "\"", 1604, 1);
#nullable restore
#line 34 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Expenses\MounthExpenses.cshtml"
WriteAttributeValue("", 1587, ViewBag.sumtotal, 1587, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AllLayoutViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
