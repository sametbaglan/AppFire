#pragma checksum "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a86ebe5badfa88ac375b6994d414d198d061ccc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Factory_List), @"mvc.1.0.view", @"/Views/Factory/List.cshtml")]
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
#line 1 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
using Fire.Business.Encryption;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a86ebe5badfa88ac375b6994d414d198d061ccc", @"/Views/Factory/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eff37adba0bd44ca44ec7676c8f6f02f797baaaa", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Factory_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AllLayoutViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">

    <center>
        <header class=""page-header"">
            <input type=""text"" id=""txtsearch"" placeholder=""Fabrika Giriniz"" />
        </header>

        <hr />


        <table class=""table table-bordered"">
            <tr>
                <td>İsim</td>
                <td>Telefon</td>
                <td></td>
            </tr>
");
#nullable restore
#line 24 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
             foreach (var customer in Model.Factories)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"Search\">\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
                   Write(customer.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
                   Write(customer.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"text-align:right\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 794, "\"", 894, 2);
            WriteAttributeValue("", 801, "/Factory/GetBeforeReceiptByFactoryid/", 801, 37, true);
#nullable restore
#line 30 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
WriteAttributeValue("", 838, CommondMethod.ConvertToEncrypt(@customer.id.ToString()), 838, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"id\" class=\"btn-sm btn-success\" style=\"margin-right:6px !important;\" title=\"Edit\">Fişler</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1021, "\"", 1121, 2);
            WriteAttributeValue("", 1028, "/Factory/FactoryReceptAddByFactoryid/", 1028, 37, true);
#nullable restore
#line 31 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
WriteAttributeValue("", 1065, CommondMethod.ConvertToEncrypt(@customer.id.ToString()), 1065, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"factoryid\" class=\"btn-sm btn-info\" style=\"margin-right:6px !important;\" title=\"Edit\">Yeni Fiş</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1254, "\"", 1333, 2);
            WriteAttributeValue("", 1261, "/Factory/Update/", 1261, 16, true);
#nullable restore
#line 32 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
WriteAttributeValue("", 1277, CommondMethod.ConvertToEncrypt(@customer.id.ToString()), 1277, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"id\" class=\"btn-sm btn-warning\" style=\"margin-right:6px !important;\" title=\"Edit\">Güncelle</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1462, "\"", 1536, 2);
            WriteAttributeValue("", 1469, "/Check/Add/", 1469, 11, true);
#nullable restore
#line 33 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
WriteAttributeValue("", 1480, CommondMethod.ConvertToEncrypt(@customer.id.ToString()), 1480, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"id\" class=\"btn-success btn-sm\" style=\"margin-right:6px !important;\" title=\"Çek\">Yeni Çek</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 36 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\List.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </table>
    </center>
</div>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>


<script>
    $(document).ready(function() {
        function Contains(text_one, text_two) {
            if (text_one.indexOf(text_two) != -1)
                return true;
        }
        $(""#txtsearch"").keyup(function() {
            var searchtext = $(""#txtsearch"").val().toLowerCase();
            $("".Search"").each(function() {
                if (!Contains($(this).text().toLowerCase(), searchtext)) {
                    $(this).hide();
                }
                else {
                    $(this).show();
                }
            })
        })
    })

</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AllLayoutViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591