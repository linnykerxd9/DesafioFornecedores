#pragma checksum "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9783dfd6ae42559ade83b7e7290de513d0fe96ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supplier_Details), @"mvc.1.0.view", @"/Views/Supplier/Details.cshtml")]
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
#line 1 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\_ViewImports.cshtml"
using DesafioFornecedores.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\_ViewImports.cshtml"
using DesafioFornecedores.WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9783dfd6ae42559ade83b7e7290de513d0fe96ff", @"/Views/Supplier/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"002d45cd6c7d14881892029cc53bf292373077cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Supplier_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SupplierListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
  
    ViewData["Title"] = "Details Supplier";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>\r\n    Supplier Details\r\n</h2>\r\n<br/>\r\n<br/>\r\n<br/>\r\n\r\n<dl class=\"row\">\r\n  <dt class=\"col-sm-3\">Status Supplier</dt>\r\n  <dd class=\"col-sm-9\">\r\n");
#nullable restore
#line 17 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
         if(Model.Active){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>Active</p>\r\n");
#nullable restore
#line 19 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>deactivated</p>\r\n");
#nullable restore
#line 21 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </dd>\r\n\r\n  <dt class=\"col-sm-3\">Full Name/Company Name</dt>\r\n  <dd class=\"col-sm-9\">\r\n");
#nullable restore
#line 26 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
      if(Model.FullName != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>");
#nullable restore
#line 27 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
          Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 28 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
        }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>");
#nullable restore
#line 29 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
          Write(Model.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 30 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </dd>\r\n\r\n  <dt class=\"col-sm-3\">Fantasy Name</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 34 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.FantasyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n  <dt class=\"col-sm-3 text-truncate\">Email address</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 37 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Email.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n  \r\n  <dt class=\"col-sm-3 text-truncate\">Cnpj/CPF</dt>\r\n  <dd class=\"col-sm-9\">\r\n");
#nullable restore
#line 41 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
          if(Model.Cnpj != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 42 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Cnpj);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 43 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 44 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 45 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dd>\r\n<dt class=\"col-sm-3 text-truncate\">Phones</dt>\r\n  <dd class=\"col-sm-9\">\r\n");
#nullable restore
#line 49 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
          foreach (var item in Model.Phone)
         {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>(");
#nullable restore
#line 51 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
           Write(item.Ddd);

#line default
#line hidden
#nullable disable
            WriteLiteral(") - ");
#nullable restore
#line 51 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                        Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 52 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
         }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dd>\r\n\r\n  <h4>Address</h4>\r\n  <div class=\"row\">\r\n\r\n    <dt class=\"col-sm-3 text-truncate\">Street</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 59 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n   <dt class=\"col-sm-3 text-truncate\">Number</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 62 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n   <dt class=\"col-sm-3 text-truncate\">Neighborhood</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 65 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.Neighborhood);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n  <dt class=\"col-sm-3 text-truncate\">ZipCode</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 68 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n   <dt class=\"col-sm-3 text-truncate\">City</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 71 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n   <dt class=\"col-sm-3 text-truncate\">State</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 74 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n   <dt class=\"col-sm-3 text-truncate\">Complement</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 77 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.Complement);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n  \r\n  <dt class=\"col-sm-3 text-truncate\">Reference</dt>\r\n  <dd class=\"col-sm-9\">");
#nullable restore
#line 80 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
                  Write(Model.Address.Reference);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n  </div>\r\n    ");
#nullable restore
#line 82 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Details.cshtml"
Write(Html.ActionLink("Go To List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SupplierListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
