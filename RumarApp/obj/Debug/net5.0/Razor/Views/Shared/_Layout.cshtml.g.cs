#pragma checksum "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7120a3b5cb11d3e451da9b6f7e6933ebd6a2b540"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7120a3b5cb11d3e451da9b6f7e6933ebd6a2b540", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e67a4d27cb5d54a66c0f362e379c12155c4d2c9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TopNavBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Navigation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Footer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition sidebar-mini layout-fixed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7120a3b5cb11d3e451da9b6f7e6933ebd6a2b5405172", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <title>");
#nullable restore
#line 6 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" - RumarApp</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback"">
    <!-- Font Awesome -->
    <link rel=""stylesheet"" href=""/plugins/fontawesome-free/css/all.min.css"">
    <!-- overlayScrollbars -->
    <link rel=""stylesheet"" href=""/plugins/overlayScrollbars/css/OverlayScrollbars.min.css"">
    <!-- Theme style -->
    <link rel=""stylesheet"" href=""/css/adminlte.min.css"">
    <!-- JQVMap -->
    <link rel=""stylesheet"" href=""/plugins/jqvmap/jqvmap.min.css"">
    <!-- SweetAlert2 -->
    <link rel=""stylesheet"" href=""/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css"">
    <!-- Toastr -->
    <link rel=""stylesheet"" href=""/plugins/toastr/toastr.min.css"">
    <!-- Ionicons -->
    <link rel=""stylesheet"" href=""https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"">
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel=""stylesheet"" href=""/plugins/tempusdominu");
                WriteLiteral(@"s-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"">
    <!-- icheck bootstrap -->
    <link rel=""stylesheet"" href=""/plugins/icheck-bootstrap/icheck-bootstrap.min.css"">
    <!-- DataTables -->
    <link rel=""stylesheet"" href=""/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"">
    <link rel=""stylesheet"" href=""/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"">
    <link rel=""stylesheet"" href=""/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"">
    <!-- Daterange picker -->
    <link rel=""stylesheet"" href=""/plugins/daterangepicker/daterangepicker.css"">
    <!-- summernote -->
    <link rel=""stylesheet"" href=""/plugins/summernote/summernote-bs4.min.css"">
    <!-- Select2 -->
    <link rel=""stylesheet"" href=""/plugins/select2/css/select2.css"">
    <link rel=""stylesheet"" href=""/plugins/select2-bootstrap4-theme/select2-bootstrap4.min.css"">
    <!-- Bootstrap Color Picker -->
    <link rel=""stylesheet"" href=""/plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.min.c");
                WriteLiteral(@"ss"">
    <!-- Bootstrap4 Duallistbox -->
    <link rel=""stylesheet"" href=""/plugins/bootstrap4-duallistbox/bootstrap-duallistbox.min.css"">
    <!-- BS Stepper -->
    <link rel=""stylesheet"" href=""/plugins/bs-stepper/css/bs-stepper.min.css"">
    <!-- dropzonejs -->
    <link rel=""stylesheet"" href=""/plugins/dropzone/min/dropzone.min.css"">
    <link rel=""stylesheet"" href=""/css/site.css"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7120a3b5cb11d3e451da9b6f7e6933ebd6a2b5409085", async() => {
                WriteLiteral(@"
    <div class=""wrapper"">
        <!-- Preloader -->
        <div class=""preloader flex-column justify-content-center align-items-center"">
            <img class=""animation__wobble"" src=""/img/AdminLTELogo.png"" alt=""AdminLTELogo"" height=""60"" width=""60"">
        </div>

        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7120a3b5cb11d3e451da9b6f7e6933ebd6a2b5409639", async() => {
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
                WriteLiteral("\r\n\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7120a3b5cb11d3e451da9b6f7e6933ebd6a2b54010827", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <!-- Content Wrapper. Contains page content -->\r\n        <div class=\"content-wrapper\">\r\n            <main role=\"main\" class=\"pb-3\">\r\n                ");
#nullable restore
#line 62 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </main>\r\n        </div>\r\n        <!-- /.content-wrapper -->\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7120a3b5cb11d3e451da9b6f7e6933ebd6a2b54012485", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
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
    <!-- ./wrapper -->
    <!-- jQuery -->
    <script src=""/plugins/jquery/jquery.min.js""></script>
    <!-- jQuery UI 1.11.4 -->
    <script src=""/plugins/jquery-ui/jquery-ui.min.js""></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button)
    </script>
    <!-- Bootstrap 4 -->
    <script src=""/plugins/bootstrap/js/bootstrap.bundle.min.js""></script>
    <!-- ChartJS -->
    <script src=""/plugins/chart.js/Chart.min.js""></script>
    <!-- Sparkline -->
    <script src=""/plugins/sparklines/sparkline.js""></script>
    <!-- JQVMap -->
    <script src=""/plugins/jqvmap/jquery.vmap.min.js""></script>
    <script src=""/plugins/jqvmap/maps/jquery.vmap.usa.js""></script>
    <!-- jQuery Knob Chart -->
    <script src=""/plugins/jquery-knob/jquery.knob.min.js""></script>
    <!-- daterangepicker -->
    <script src=""/plugins/moment/moment.min.js""></script>
    <script src=""/plugins/daterangepicker/d");
                WriteLiteral(@"aterangepicker.js""></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src=""/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js""></script>
    <!-- Summernote -->
    <script src=""/plugins/summernote/summernote-bs4.min.js""></script>
    <!-- overlayScrollbars -->
    <script src=""/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js""></script>
    <!-- AdminLTE App -->
    <script src=""/js/adminlte.js""></script>
    <!-- DataTables  & Plugins -->
    <script src=""/plugins/datatables/jquery.dataTables.min.js""></script>
    <script src=""/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
    <script src=""/plugins/datatables-responsive/js/dataTables.responsive.min.js""></script>
    <script src=""/plugins/datatables-responsive/js/responsive.bootstrap4.min.js""></script>
    <script src=""/plugins/datatables-buttons/js/dataTables.buttons.min.js""></script>
    <script src=""/plugins/datatables-buttons/js/buttons.bootstrap4.min.js""></script>
    <script ");
                WriteLiteral(@"src=""/plugins/jszip/jszip.min.js""></script>
    <script src=""/plugins/pdfmake/pdfmake.min.js""></script>
    <script src=""/plugins/pdfmake/vfs_fonts.js""></script>
    <script src=""/plugins/datatables-buttons/js/buttons.html5.min.js""></script>
    <script src=""/plugins/datatables-buttons/js/buttons.print.min.js""></script>
    <script src=""/plugins/datatables-buttons/js/buttons.colVis.min.js""></script>
    <!-- Select2 -->
    <script src=""/plugins/select2/js/select2.full.min.js""></script>
    <!-- Bootstrap4 Duallistbox -->
    <script src=""/plugins/bootstrap4-duallistbox/jquery.bootstrap-duallistbox.min.js""></script>
    <!-- Toastr -->
    <script src=""/plugins/toastr/toastr.min.js""></script>
    <!-- Page specific script -->
    <script src=""/js/demo.js""></script>
    ");
#nullable restore
#line 120 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <script>\r\n    $(\'.select2\').select2();\r\n\r\n    //Initialize Select2 Elements\r\n    $(\'.select2bs4\').select2({\r\n        theme: \'bootstrap4\'\r\n    });\r\n\r\n    var url = \'");
#nullable restore
#line 129 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_Layout.cshtml"
          Write(Url.Action("Create"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
    $(function () {
        $(""#dataTableIndexList"").DataTable({
            ""responsive"": true,
            ""lengthChange"": false,
            //lengthMenu: [25, 50, 100, 200],
            ""autoWidth"": false,
            ""buttons"": {
                buttons: [
                    {
                        text: '<i class=""fas fa-plus fa-fw""></i>Agregar',
                        className: 'btn-outline-primary',
                        action: function navigateTo() {
                            window.location = url;
                        }
                    }
                ],
                dom: {
                    button: {
                        className: 'btn'
                    },
                    buttonLiner: {
                        tag: null
                    }
                }
            },
            ""oLanguage"": {
                ""sSearch"": ""Filtrar en la Lista""
            },
            ""language"": {
                emptyTable: ""No hay datos p");
                WriteLiteral(@"ara mostrar"",
                paginate: {
                    ""first"": ""Primera"",
                    ""last"": ""Ultima"",
                    ""next"": ""Proxima"",
                    ""previous"": ""Anterior""
                },
                info: ""Mostrando _PAGE_ de _PAGES_"",
                ""infoEmpty"": ""No hay registros disponibles"",
                ""infoFiltered"": ""(filtrados de _MAX_ registros totales)"",
            }
        }).buttons().container().appendTo('#dataTableIndexList_wrapper .col-md-6:eq(0)');
    });

    var msg = ");
#nullable restore
#line 173 "C:\Users\User\Desktop\App\RumarApp\RumarApp\Views\Shared\_Layout.cshtml"
          Write(TempData["Message"]!=null? Html.Raw(TempData["Message"]) : Html.Raw("undefined"));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n\r\n    if (msg != null) {\r\n        toastr[msg.type](msg.message, msg.title);\r\n    }\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
