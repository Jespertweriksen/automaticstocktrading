#pragma checksum "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3f59db14f9b55d3187bb771d59261b8d04d98b5"
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
#line 1 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/_ViewImports.cshtml"
using AutomaticStockTrading;

#line default
#line hidden
#line 2 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/_ViewImports.cshtml"
using AutomaticStockTrading.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3f59db14f9b55d3187bb771d59261b8d04d98b5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0db18666010fd7e449f4d1a8f19c5cee4fe725c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Apitest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "StockAPIController", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PostStocks(\'AAPL\')", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3f59db14f9b55d3187bb771d59261b8d04d98b55102", async() => {
                WriteLiteral(@"

        <!-- NOTICE: You can use the _analytics.html partial to include production code specific code & trackers -->

        <nav class=""navbar navbar-dark navbar-theme-primary px-4 col-12 d-md-none"">
    <a class=""navbar-brand me-lg-5"" href=""../../index.html"">
        <img class=""navbar-brand-dark"" src=""../../assets/img/brand/light.svg"" alt=""Volt logo"" /> <img class=""navbar-brand-light"" src=""../../assets/img/brand/dark.svg"" alt=""Volt logo"" />
    </a>
    <div class=""d-flex align-items-center"">
        <button class=""navbar-toggler d-md-none collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#sidebarMenu"" aria-controls=""sidebarMenu"" aria-expanded=""false"" aria-label=""Toggle navigation"">
          <span class=""navbar-toggler-icon""></span>
        </button>
    </div>
</nav>

        <nav id=""sidebarMenu"" class=""sidebar d-md-block bg-dark text-white collapse"" data-simplebar>
  <div class=""sidebar-inner px-4 pt-3"">

    <ul class=""nav flex-column pt-3 pt-md-0"">
      <li class=""nav-item "">
   ");
                WriteLiteral("     ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3f59db14f9b55d3187bb771d59261b8d04d98b56464", async() => {
                    WriteLiteral("\n          <span class=\"sidebar-icon\"><span class=\"fas fa-hand-holding-usd\"></span></span>\n          <span class=\"sidebar-text\">Aktiedata</span>\n        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
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
      </li>
      <li class=""nav-item"">
        <a href=""../../pages/upgrade-to-pro.html""
          class=""btn btn-secondary d-flex align-items-center justify-content-center btn-upgrade-pro"">
          <span class=""sidebar-icon""><span class=""fas fa-rocket me-2""></span></span> <span>Kontakt</span>
        </a>
      </li>
    </ul>
  </div>
</nav>
    
        <main class=""content"">

");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3f59db14f9b55d3187bb771d59261b8d04d98b58517", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            <div class=""theme-settings card pt-2 collapse"" id=""theme-settings"">
    <div class=""card-body pt-4"">
        <button type=""button"" class=""btn-close theme-settings-close"" aria-label=""Close"" data-bs-toggle=""collapse""
            href=""#theme-settings"" role=""button"" aria-expanded=""false"" aria-controls=""theme-settings""></button>
        <div class=""d-flex justify-content-between align-items-center mb-3"">
            <p class=""m-0 mb-1 me-4 fs-7"">Open source <span role=""img"" aria-label=""gratitude"">💛</span></p>
            <a class=""github-button"" href=""https://github.com/themesberg/volt-bootstrap-5-dashboard""
                data-color-scheme=""no-preference: dark; light: light; dark: light;"" data-icon=""octicon-star""
                data-size=""large"" data-show-count=""true""
                aria-label=""Star themesberg/volt-bootstrap-5-dashboard on GitHub"">Star</a>
        </div>
        <a href=""https://themesberg.com/product/admin-dashboard/volt-bootstrap-5-dashboard"" target=""_blank""
            class=");
                WriteLiteral(@"""btn btn-primary mb-3 w-100"">Download <i class=""fas fa-download ms-2""></i></a>
        <p class=""fs-7 text-gray-700 text-center"">Available in the following technologies:</p>
        <div class=""d-flex justify-content-center"">
            <a class=""me-3"" href=""https://themesberg.com/product/admin-dashboard/volt-bootstrap-5-dashboard""
                target=""_blank"">
                <img src=""../../assets/img/technologies/bootstrap-5-logo.svg"" class=""image image-xs"">
            </a>
            <a href=""https://demo.themesberg.com/volt-react-dashboard/#/"" target=""_blank"">
                <img src=""../../assets/img/technologies/react-logo.svg"" class=""image image-xs"">
            </a>
        </div>
    </div>
</div>

<div class=""card theme-settings theme-settings-expand"" id=""theme-settings-expand"">
    <div class=""card-body p-3 py-2"">
        <span class=""fw-bold h6"">
            <i class=""fas fa-cogs me-1 fs-7""></i> Settings
        </span>
    </div>
</div></main>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
