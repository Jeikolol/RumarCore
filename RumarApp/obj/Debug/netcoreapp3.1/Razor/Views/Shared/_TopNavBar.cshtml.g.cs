#pragma checksum "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2d8768d89fa714150c1a1dcfd58c9df2bd25844"
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
#line 1 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\_ViewImports.cshtml"
using RumarApp;

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
#nullable restore
#line 1 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
using RumarApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2d8768d89fa714150c1a1dcfd58c9df2bd25844", @"/Views/Shared/_TopNavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e67a4d27cb5d54a66c0f362e379c12155c4d2c9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TopNavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
 if (SignInManager.IsSignedIn(User))
 {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <nav class=""main-header navbar navbar-expand navbar-primary navbar-dark"">
        <!-- Left navbar links -->
        <ul class=""navbar-nav"">
            <li class=""nav-item"">
                <a class=""nav-link"" data-widget=""pushmenu"" href=""#"" role=""button""><i class=""fas fa-bars""></i></a>
            </li>
            <li class=""nav-item d-none d-sm-inline-block"">
                <a");
            BeginWriteAttribute("href", " href=\"", 585, "\"", 620, 1);
#nullable restore
#line 16 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
WriteAttributeValue("", 592, Url.Action("Index", "Home"), 592, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" role=""button"" class=""nav-link"">Inicio</a>
            </li>
        </ul>

        <!-- Right navbar links -->
        <!--<ul class=""navbar-nav ml-auto"">-->
            <!-- Navbar Search -->
            <!--<li class=""nav-item"">
                <a class=""nav-link"" data-widget=""navbar-search"" href=""#"" role=""button"">
                    <i class=""fas fa-search""></i>
                </a>
                <div class=""navbar-search-block"">
                    <form class=""form-inline"">
                        <div class=""input-group input-group-sm"">
                            <input class=""form-control form-control-navbar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
                            <div class=""input-group-append"">
                                <button class=""btn btn-navbar"" type=""submit"">
                                    <i class=""fas fa-search""></i>
                                </button>
                                <button class=""btn btn-navbar"" type=""butt");
            WriteLiteral(@"on"" data-widget=""navbar-search"">
                                    <i class=""fas fa-times""></i>
                                </button>
                            </div>
                        </div>
                    </form>
                </div>
            </li>
        </ul>-->
    </nav>
");
#nullable restore
#line 45 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_TopNavBar.cshtml"
 }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<User> SignInManager { get; private set; }
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
