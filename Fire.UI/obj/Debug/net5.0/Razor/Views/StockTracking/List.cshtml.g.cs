#pragma checksum "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cac09480b286c75e8ce3773eb616fee4aaed6d32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StockTracking_List), @"mvc.1.0.view", @"/Views/StockTracking/List.cshtml")]
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
#nullable restore
#line 1 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
using Fire.Business.Encryption;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cac09480b286c75e8ce3773eb616fee4aaed6d32", @"/Views/StockTracking/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eff37adba0bd44ca44ec7676c8f6f02f797baaaa", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_StockTracking_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AllLayoutViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <header class=\"page-header\">\r\n    </header>\r\n    <table class=\"table table-bordered\">\r\n        <tr>\r\n            <td>Ürün</td>\r\n            <td></td>\r\n        </tr>\r\n");
#nullable restore
#line 17 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
         foreach (var customer in Model.productTypes)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
               Write(customer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-align:right\">\r\n");
#nullable restore
#line 22 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
                     if (Functions.stockTrackings(customer.id).Count > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 636, "\"", 726, 2);
            WriteAttributeValue("", 643, "/StockTracking/StockUpdate/", 643, 27, true);
#nullable restore
#line 24 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
WriteAttributeValue("", 670, CommondMethod.ConvertToEncrypt(@customer.id.ToString()), 670, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"id\" class=\"btn-sm btn-warning\" style=\"margin-right:6px !important;\" title=\"Edit\">Güncelle</a>\r\n");
#nullable restore
#line 25 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
                    }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                          <a");
            BeginWriteAttribute("href", " href=\"", 885, "\"", 975, 2);
            WriteAttributeValue("", 892, "/StockTracking/StockUpdate/", 892, 27, true);
#nullable restore
#line 26 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
WriteAttributeValue("", 919, CommondMethod.ConvertToEncrypt(@customer.id.ToString()), 919, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"id\" class=\"btn-sm btn-danger\" style=\"margin-right:6px !important;\" title=\"Edit\">Stock Girişi</a>\r\n");
#nullable restore
#line 27 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\StockTracking\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
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