#pragma checksum "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8f3a70f96854e5587176a893e87a796e1ae4838"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8f3a70f96854e5587176a893e87a796e1ae4838", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e67a4d27cb5d54a66c0f362e379c12155c4d2c9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-sm-12 col-md-12 col-lg-12"">
                <h1 class=""text-center font-bold"">Dashboard</h1>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-lg-3 col-6"">
                <!-- small card -->
                <div class=""small-box bg-info"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 23 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Home\Index.cshtml"
                       Write(Model.LoansCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                        <h4>Prestamos</h4>\r\n                    </div>\r\n                    <div class=\"icon\">\r\n                        <i class=\"fas fa-money-bill-alt\"></i>\r\n                    </div>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 906, "\"", 942, 1);
#nullable restore
#line 30 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 913, Url.Action("Index", "Loans"), 913, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""small-box-footer"">
                        Consulta <i class=""fas fa-arrow-circle-right""></i>
                    </a>
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-6"">
                <!-- small card -->
                <div class=""small-box bg-success"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 40 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Home\Index.cshtml"
                       Write(Model.ClientsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                        <h4>Clientes</h4>\r\n                    </div>\r\n                    <div class=\"icon\">\r\n                        <i class=\"fas fa-users\"></i>\r\n                    </div>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1588, "\"", 1625, 1);
#nullable restore
#line 47 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 1595, Url.Action("Index", "Client"), 1595, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"small-box-footer\">\r\n                        Consulta <i class=\"fas fa-arrow-circle-right\"></i>\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
