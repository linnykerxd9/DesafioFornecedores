#pragma checksum "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "954a7ed2d43f1c6dd0a1ecd4627c0866a7edbabd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supplier_Index), @"mvc.1.0.view", @"/Views/Supplier/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"954a7ed2d43f1c6dd0a1ecd4627c0866a7edbabd", @"/Views/Supplier/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"002d45cd6c7d14881892029cc53bf292373077cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Supplier_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SupplierListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreatePhysical", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Supplier", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateJuridical", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
  
    ViewData["Title"] = "Supplier";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"text\">\n    <h1 class=\"display-4\">Supplier</h1>\n</div>\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "954a7ed2d43f1c6dd0a1ecd4627c0866a7edbabd4853", async() => {
                WriteLiteral("New Supplier Physical");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "954a7ed2d43f1c6dd0a1ecd4627c0866a7edbabd6314", async() => {
                WriteLiteral("New Supplier Juridical");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<br/>
<br/>
<table class=""table"">
  <thead>
    <tr>
      <th scope=""col"">Status</th>
      <th scope=""col"">Fantasy Name</th>
      <th scope=""col"">Full Name/Company Name</th>
      <th scope=""col"">Email</th>
      <th scope=""col"">Phones</th>
      <th scope=""col"">CPF/CNPJ</th>
    </tr>
  </thead>
  <tbody>
");
#nullable restore
#line 28 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
     if(Model != null)
     

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
      foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n");
#nullable restore
#line 33 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                 if(item.Active){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>Active</p>\n");
#nullable restore
#line 35 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>deactivated</p>\n");
#nullable restore
#line 37 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\n            <td>\n                ");
#nullable restore
#line 40 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FantasyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n");
#nullable restore
#line 43 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                 if(item.FullName != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 44 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                  Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 45 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 46 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                  Write(item.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 47 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\n            <td>\n                ");
#nullable restore
#line 50 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n");
#nullable restore
#line 53 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                 foreach (var phones in item.Phone)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>(");
#nullable restore
#line 55 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                   Write(phones.Ddd);

#line default
#line hidden
#nullable disable
            WriteLiteral(") - ");
#nullable restore
#line 55 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                                  Write(phones.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 56 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\n            <td>\n");
#nullable restore
#line 59 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                 if(item.Cnpj != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 60 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                  Write(item.Cnpj);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 61 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 62 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                  Write(item.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 63 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\n            <td>\n                ");
#nullable restore
#line 66 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { identification =item.Cpf != null ? item.Cpf : item.Cnpj}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 69 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { identification =item.Cpf != null ? item.Cpf : item.Cnpj}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 72 "C:\Users\jramosli\WorkSpace\Trilhas\DesafioFornecedores\DesafioFornecedores.WebApp\Views\Supplier\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SupplierListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
