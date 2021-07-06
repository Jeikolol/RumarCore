#pragma checksum "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "018d93c589cc7c239a0c10b754c72d263351089f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Loans_Details), @"mvc.1.0.view", @"/Views/Loans/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"018d93c589cc7c239a0c10b754c72d263351089f", @"/Views/Loans/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e52e96b49aa4bc465c65816048d8cba2a143c531", @"/Views/_ViewImports.cshtml")]
    public class Views_Loans_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RumarApp.Models.Loan>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
  
    ViewData["Title"] = "Detalle";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalle</h1>\r\n\r\n<div>\r\n    <h4>Prestamo</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            Capital\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Capital));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Interes(%)\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Interest));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Cuotas\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Quote));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Cliente\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Clients.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
</div>
<div class=""card bg-primary"">
    <div class=""card-header"">
        <h1>Tabla Amortización</h1>
    </div>
    <div class=""card-body"">
        <table class=""table table-bordered table-striped table-responsive"">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Fechas de Pago</th>
                    <th class=""text-right"">Cuota</th>
                    <th class=""text-right"">Interés Mensual</th>
                    <th class=""text-right"">Amortización Principal</th>
                    <th class=""text-right"">Amortización Total</th>
                    <th class=""text-right"">Capital Pendiente</th>
                </tr>
            </thead>
");
#nullable restore
#line 56 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
              
                double capital = Model.Capital;
                double interest = Convert.ToDouble(Model.Interest) / 1200;
                double plazo = Convert.ToDouble(Model.Quote);
                DateTime paymentDate = Model.CreationTime;
                DateTime nextDate = DateTime.UtcNow;

                //Generate QuoteNumber

                double quote = capital * (interest / (double)(1 - Math.Pow(1 + (double)interest, -plazo)));

                double interest_monthly = 0;
                double amortization = 0;
                double amortization_total = 0;
                int i = 1;

                for (i = 1; i <= plazo; i++)
                {
                    interest_monthly = (interest * capital);
                    capital = (capital - quote + interest_monthly);

                    //Amortizacion totales y principales

                    amortization_total += (quote - interest_monthly);
                    amortization = quote - interest_monthly;
                    paymentDate = nextDate.AddMonths(i);


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tbody>\r\n                        <tr>\r\n                            <td>");
#nullable restore
#line 85 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 86 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                           Write(paymentDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-right\">");
#nullable restore
#line 87 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                                              Write(quote.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-right\">");
#nullable restore
#line 88 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                                              Write(interest_monthly.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-right\">");
#nullable restore
#line 89 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                                              Write(amortization.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-right\">");
#nullable restore
#line 90 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                                              Write(amortization_total.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-right\">");
#nullable restore
#line 91 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                                              Write(capital.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                    </tbody>\r\n");
#nullable restore
#line 94 "C:\Users\DEVELOPER04\Desktop\App\RumarApp\RumarApp\Views\Loans\Details.cshtml"
                }

            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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