#pragma checksum "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70ec7d09771ed504e4e7194b7e48459eb5912f19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TopNavBar), @"mvc.1.0.view", @"/Views/Shared/_TopNavBar.cshtml")]
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
#line 1 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using RumarApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using RumarApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using RumarApp.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
using Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70ec7d09771ed504e4e7194b7e48459eb5912f19", @"/Views/Shared/_TopNavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e67a4d27cb5d54a66c0f362e379c12155c4d2c9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TopNavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
 if (User.Identity.IsAuthenticated)
 {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <nav class=""main-header navbar navbar-expand navbar-dark"">
        <!-- Left navbar links -->
        <ul class=""navbar-nav"">
            <li class=""nav-item"">
                <a class=""nav-link"" data-widget=""pushmenu"" href=""#"" role=""button""><i class=""fas fa-bars""></i></a>
            </li>
            <li class=""nav-item d-none d-sm-inline-block"">
                <a");
            BeginWriteAttribute("href", " href=\"", 483, "\"", 518, 1);
#nullable restore
#line 13 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
WriteAttributeValue("", 490, Url.Action("Index", "Home"), 490, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" class=\"nav-link\">Inicio</a>\r\n            </li>\r\n        </ul>\r\n\r\n        <!-- Right navbar links -->\r\n        <ul class=\"navbar-nav ml-auto\">\r\n            <!-- Navbar Search -->\r\n");
            WriteLiteral("            <li class=\"nav-item\">\r\n");
#nullable restore
#line 41 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
                 using (Html.BeginForm("LogOut", "Security", FormMethod.Post, new { id = "logoutForm", name = "logoutForm" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
                                            
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <a class=""nav-link"" href=""javascript:document.getElementById('logoutForm').submit()"" role=""button"">
                    <i class=""fas fa-power-off text-danger""></i> Cerrar Sesion
                </a>
            </li>
        </ul>
    </nav>
");
#nullable restore
#line 51 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
