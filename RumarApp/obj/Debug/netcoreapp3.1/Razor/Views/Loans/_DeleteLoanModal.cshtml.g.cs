#pragma checksum "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\_DeleteLoanModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2051e011e53107ced486cbe0f7f5e7212930c196"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Loans__DeleteLoanModal), @"mvc.1.0.view", @"/Views/Loans/_DeleteLoanModal.cshtml")]
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
#line 1 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using RumarApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using RumarApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using RumarApp.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2051e011e53107ced486cbe0f7f5e7212930c196", @"/Views/Loans/_DeleteLoanModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e67a4d27cb5d54a66c0f362e379c12155c4d2c9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Loans__DeleteLoanModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RumarApp.Models.Loan>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\_DeleteLoanModal.cshtml"
  
    ViewData["Title"] = "Borrar";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\_DeleteLoanModal.cshtml"
 using (Html.BeginForm("Delete", "Loans", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-header bg-danger"">
        <h5 class=""modal-title"">
            <i class=""fa fa-remove fa-fw fa-3x pull-left""></i>
            <span class=""h2"">Cancelar Prestamo de Cliente</span>
            <button type=""button"" class=""close mt-10"" data-dismiss=""modal"" aria-label=""Close"">
                <span aria-hidden=""true"">&times;</span>
            </button>
        </h5>
    </div>
    <div class=""modal-body"">
        <div class=""form-group text-center row"">
            <div class=""col-md-12"">
                <span class=""h3"">
                    Seguro que desea cancelar el Prestamo del Cliente
                </span>
            </div>
            <div class=""col-md-12"">
                <span class=""h3 font-bold"">
                    ");
#nullable restore
#line 28 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\_DeleteLoanModal.cshtml"
               Write(Html.DisplayFor(model => model.Clients.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("?\r\n                </span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2051e011e53107ced486cbe0f7f5e7212930c1966267", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2051e011e53107ced486cbe0f7f5e7212930c1966537", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 35 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\_DeleteLoanModal.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

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
                WriteLiteral("\r\n            <input type=\"submit\" value=\"Aceptar\" class=\"btn btn-danger\" />\r\n            <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Salir</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 40 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\_DeleteLoanModal.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RumarApp.Models.Loan> Html { get; private set; }
    }
}
#pragma warning restore 1591
