#pragma checksum "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\FactoryReceptAddByFactoryid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e34af2d1435673a00747cc396612ba39258590e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Factory_FactoryReceptAddByFactoryid), @"mvc.1.0.view", @"/Views/Factory/FactoryReceptAddByFactoryid.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e34af2d1435673a00747cc396612ba39258590e", @"/Views/Factory/FactoryReceptAddByFactoryid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eff37adba0bd44ca44ec7676c8f6f02f797baaaa", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Factory_FactoryReceptAddByFactoryid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AllLayoutViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "date", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Factory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FactoryReceptAddByFactoryid", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\FactoryReceptAddByFactoryid.cshtml"
  
    ViewData["Title"] = "FactoryReceptAddByFactoryid";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"row\">\r\n    <header class=\"page-header\">\r\n");
#nullable restore
#line 11 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\FactoryReceptAddByFactoryid.cshtml"
         if (ViewBag.message != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert-danger\">");
#nullable restore
#line 13 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\FactoryReceptAddByFactoryid.cshtml"
                                 Write(ViewBag.message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 14 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\FactoryReceptAddByFactoryid.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </header>\r\n    <div class=\"col-lg-6 col-md-6\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e34af2d1435673a00747cc396612ba39258590e6394", async() => {
                WriteLiteral("\r\n            <span>Fiş Tarihi:</span>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3e34af2d1435673a00747cc396612ba39258590e6688", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 20 "C:\Users\unilogistix\OneDrive\Masaüstü\FireProject\FireApp\Fire.UI\Views\Factory\FactoryReceptAddByFactoryid.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Factory.CreatedDate);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            <table id=""dtBasicExample3"" class=""table table-striped table-bordered""
                   cellspacing=""0"" style=""text-align:center"">
                <thead>
                    <tr class=""odd"" id=""tablodoldurss""></tr>

                </thead>
                <tbody>
                    <tr class=""odd"" id=""tablodoldaltt""></tr>
                </tbody>
            </table>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>


<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/ace/1.4.12/snippets/javascript.min.js""></script>
<script src=""/lib/jquery/dist/jquery.min.js""></script>


<script>
    $(document).ready(function() {
        $('#tablodoldaltt').show();
        $('#tablodoldurss').show();
        $.ajax({
            type: 'POST',
            url: '/ProductType/deneme',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: """",
            success: function(data) {
                var Adth = '<th>#</th>';
                var inputth = '<th>#</th>';
                var value = """";
                var d = """";
                console.log(data);
                for (var i = 0; i < data.length; i++) {
                    Adth += '<th style=""min-width:73px;"">' + data[i] + '</th>';
                    value = data[i].split(',');
                    inputth += '<th >';
                    for (var j = 0; j < 50; j++) {

");
            WriteLiteral(@"                        if (j == 0) 
                        {
                            inputth += '<span>fiyat :</span><input style=""text-align:center"" onkeyup=""keyCapt(this)"" onkeypress=""isNumberKey(this)"" value=""0"" name=""' + data[i] + '_' + i + '"" type=""text"" min=""0"" form-control calcdata"" >';

                            inputth += '<input style=""text-align:center"" onkeyup=""keyCapt(this)"" onkeypress=""isNumberKey(this)"" value="""" disabled=""disabled"" name=""' + data[i] + '_' + i + '"" type=""text"" min=""0"" form-control calcdata"" >';
                        }

                        inputth += '<input style=""text-align:center"" onkeyup=""keyCapt(this)"" onkeypress=""isNumberKey(this)"" value=""0"" name=""' + data[i] + '_' + i + '"" type=""text"" min=""0"" form-control calcdata"" >';

                    }
                    inputth += '</th>';
                }
                inputth += '<th><button type=""submit"" style=""background-color:#96885a; color:white; "" class=""btn width-md waves-effect waves-light form");
            WriteLiteral(@"-control""> Add +</button>    <span>Genel Toplam</span><input style=""text-align:center"" value=""0"" name=""geneltoplam""  id=""geneltoplam"" type=""text"" disabled=""disabled""  form-control calcdata"" >  </th>';
                $(""#tablodoldurss"").html(Adth);
                $(""#tablodoldaltt"").html(inputth);
            },
            error: function() {
                alert('Failed to receive the Data');
                console.log('Failed ');
            }
        })
    });
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
