#pragma checksum "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b539ddb1bbe5dfd5de303d066cc9065bdf0b4de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Navigation), @"mvc.1.0.view", @"/Views/Shared/_Navigation.cshtml")]
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
#line 1 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
using RumarApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b539ddb1bbe5dfd5de303d066cc9065bdf0b4de", @"/Views/Shared/_Navigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0dc1ec51c54e71b8e29a061db6f6abb49f30ad43", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<style type=""text/css"">
    .circle-logo {
        border-radius: 50%;
        margin-left: 10%;
        background-color: #fff;
        min-height: 100px;
        min-width: 100px;
        width: 70% !important;
        background-color: #fff;
        position: relative;
    }

    .no-a {
        padding: 0 !important;
        display: inline !important;
    }

    #side-menu > li.active > a {
        background-color: #c4813f !important;
    }

    #side-menu > li.active > ul.nav-second-level > li.active > a {
        background-color: #c4813f !important;
    }

    .nav-third-level > li.active > a {
        background-color: #c4813f !important;
    }

    .activeSubmenu {
        background: #3a4459;
        border: solid 1px #6F7FA0;
    }
</style>

<nav class=""navbar-default navbar-static-side"" role=""navigation"">
    <div class=""sidebar-collapse"">
        <ul class=""nav"" id=""side-menu"">
            <li class=""nav-header bg-primary-important"">
                <div");
            WriteLiteral(" class=\"dropdown profile-element\">\r\n                    <a data-toggle=\"dropdown\" class=\"dropdown-toggle text-center\" href=\"#\">\r\n                        <div class=\"circle-logo\" style=\"vertical-align: middle;\">\r\n");
            WriteLiteral("                        </div>\r\n                    </a>\r\n                </div>\r\n            </li>\r\n");
#nullable restore
#line 54 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
             if (SignInManager.IsSignedIn(User))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("class", " class=\"", 1726, "\"", 1734, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1760, "\"", 1796, 1);
#nullable restore
#line 57 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1767, Url.Action("Index", "Loans"), 1767, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fa fa-money\"></i> <span class=\"nav-label\">Prestamos </span>\r\n                    </a>\r\n                </li>\r\n                <li");
            BeginWriteAttribute("class", " class=\"", 1963, "\"", 1971, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1997, "\"", 2034, 1);
#nullable restore
#line 62 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2004, Url.Action("Index", "Client"), 2004, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fa fa-user\"></i> <span class=\"nav-label\">Clientes </span>\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 66 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</nav>");
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
