#pragma checksum "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b426b569d8fdf6f2ac3cf129ff60a9e9a0375584"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b426b569d8fdf6f2ac3cf129ff60a9e9a0375584", @"/Views/Shared/_Navigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e67a4d27cb5d54a66c0f362e379c12155c4d2c9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_LoginPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
 if (SignInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!-- Main Sidebar Container -->\r\n<aside class=\"main-sidebar main-sidebar-custom sidebar-dark-primary elevation-4\">\r\n    <!-- Brand Logo -->\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 342, "\"", 377, 1);
#nullable restore
#line 13 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 349, Url.Action("Index", "Home"), 349, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""brand-link"">
        <img src=""/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">RumarApp</span>
    </a>

    <!-- Sidebar -->
    <div class=""sidebar"">
        <!-- Sidebar user (optional) -->
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b426b569d8fdf6f2ac3cf129ff60a9e9a03755845303", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <!-- SidebarSearch Form -->
        <div class=""form-inline"">
            <div class=""input-group"" data-widget=""sidebar-search"">
                <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Buscar en el Menu"" aria-label=""Search"">
                <div class=""input-group-append"">
                    <button class=""btn btn-sidebar"">
                        <i class=""fas fa-search fa-fw""></i>
                    </button>
                </div>
            </div>
        </div>

        <!-- Sidebar Menu -->
        <nav class=""mt-2"">
            <ul class=""nav nav-pills nav-sidebar flex-column"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
                <li class=""nav-item"">
                    <a");
            BeginWriteAttribute("href", " href=\"", 1512, "\"", 1549, 1);
#nullable restore
#line 38 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1519, Url.Action("Index", "Client"), 1519, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link\">\r\n                        <i class=\"fas fa-users nav-icon\"></i>\r\n                        <p>Clientes</p>\r\n                    </a>\r\n                </li>\r\n                <li class=\"nav-item\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1784, "\"", 1820, 1);
#nullable restore
#line 44 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 1791, Url.Action("Index", "Loans"), 1791, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""nav-link"">
                        <i class=""fas fa-money-bill-alt nav-icon""></i>
                        <p>Prestamos</p>
                    </a>
                </li>
                <li class=""nav-item"">
                    <a href=""#"" class=""nav-link"">
                        <i class=""nav-icon fas fa-cog""></i>
                        <p>
                            Seguridad
                            <i class=""right fas fa-angle-left""></i>
                        </p>
                    </a>
                    <ul class=""nav nav-treeview"">
                        <li class=""nav-item"">
                            <a");
            BeginWriteAttribute("href", " href=\"", 2476, "\"", 2512, 1);
#nullable restore
#line 59 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
WriteAttributeValue("", 2483, Url.Action("Index", "Roles"), 2483, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""nav-link"">
                                <i class=""far fa-circle nav-icon""></i>
                                <p>Roles</p>
                            </a>
                        </li>
                    </ul>
                </li>
            </ul>
        </nav>
        <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
    <div class=""sidebar-custom"">
");
#nullable restore
#line 72 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
         using (Html.BeginForm("LogOut", "Security", FormMethod.Post, new { id = "logoutForm", name = "logoutForm" }))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
                                    
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a class=\"btn btn-secondary hide-on-collapse pos-right\" href=\"javascript:document.getElementById(\'logoutForm\').submit()\">\r\n            <i class=\"fas fa-sign-out-alt\"></i> Cerrar Sesion\r\n        </a>\r\n    </div>\r\n</aside>\r\n");
#nullable restore
#line 81 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Shared\_Navigation.cshtml"
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
