#pragma checksum "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9d0a8c64af698c5997a39d4907ae597fcc0561d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cars_Details), @"mvc.1.0.view", @"/Views/Cars/Details.cshtml")]
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
#line 1 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\_ViewImports.cshtml"
using assignment2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\_ViewImports.cshtml"
using assignment2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9d0a8c64af698c5997a39d4907ae597fcc0561d", @"/Views/Cars/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7d14921b6e9a473ffe36cf77cfbdf8a2e29f453", @"/Views/_ViewImports.cshtml")]
    public class Views_Cars_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<assignment2.Models.Car>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
  
  ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
Write(Html.DisplayFor(model => model.Make));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 7 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
                                     Write(Html.DisplayFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n  <hr />\r\n  <dl class=\"row\">\r\n    <dt class=\"col-sm-2\">\r\n      ");
#nullable restore
#line 13 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayNameFor(model => model.Make));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n      ");
#nullable restore
#line 16 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayFor(model => model.Make));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n      ");
#nullable restore
#line 19 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayNameFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n      ");
#nullable restore
#line 22 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n      ");
#nullable restore
#line 25 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayNameFor(model => model.Colour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n      ");
#nullable restore
#line 28 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayFor(model => model.Colour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n      ");
#nullable restore
#line 31 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n      ");
#nullable restore
#line 34 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayFor(model => model.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n      ");
#nullable restore
#line 37 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayNameFor(model => model.PurchaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n      ");
#nullable restore
#line 40 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayFor(model => model.PurchaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n      ");
#nullable restore
#line 43 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayNameFor(model => model.Kilometres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n      ");
#nullable restore
#line 46 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
 Write(Html.DisplayFor(model => model.Kilometres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n  </dl>\r\n</div>\r\n<div>\r\n  ");
#nullable restore
#line 51 "C:\Users\User\Documents\MOHAWK_FALL2020_SEM4\COMPCO884_WebApplicationsWithASPNET\assignment2\assignment2\Views\Cars\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9d0a8c64af698c5997a39d4907ae597fcc0561d9041", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<assignment2.Models.Car> Html { get; private set; }
    }
}
#pragma warning restore 1591
