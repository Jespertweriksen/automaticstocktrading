#pragma checksum "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e6be76ea076b7b66544b183c061b484e9321403"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Apitest), @"mvc.1.0.view", @"/Views/Home/Apitest.cshtml")]
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
#line 1 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
using AutomaticStockTrading.Services;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e6be76ea076b7b66544b183c061b484e9321403", @"/Views/Home/Apitest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0db18666010fd7e449f4d1a8f19c5cee4fe725c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Apitest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
  
    ViewData["Title"] = "Profile Page";

#line default
#line hidden
            WriteLiteral("\n\n\n<p>TEST</p>\n\n");
#line 10 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
  
    
    var apilist = Tools.GetStocks("GME");
    var currStock = Tools.GetStock("GME");


#line default
#line hidden
            WriteLiteral("    <p>");
#line 15 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
  Write(currStock.First().close);

#line default
#line hidden
            WriteLiteral("</p>\n");
            WriteLiteral("    <table style=\"width:100%\">\n        <tr>\n            <th>Datetime</th>\n            <th>Open</th>\n            <th>High</th>\n            <th>Low</th>\n            <th>Close</th>\n            <th>Volume</th>\n        </tr>\n");
#line 26 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
          foreach (var item in apilist)
            {

#line default
#line hidden
            WriteLiteral("                <tr>\n                    <td>");
#line 29 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
                   Write(item.dateTime);

#line default
#line hidden
            WriteLiteral("</td>\n                    <td>");
#line 30 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
                   Write(item.open);

#line default
#line hidden
            WriteLiteral("</td>\n                    <td>");
#line 31 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
                   Write(item.high);

#line default
#line hidden
            WriteLiteral("</td>\n                    <td>");
#line 32 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
                   Write(item.low);

#line default
#line hidden
            WriteLiteral("</td>\n                    <td>");
#line 33 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
                   Write(item.close);

#line default
#line hidden
            WriteLiteral("</td>\n                    <td>");
#line 34 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
                   Write(item.volume);

#line default
#line hidden
            WriteLiteral("</td>\n                </tr>\n");
#line 36 "/Users/jesper/Documents/Projekter/AutoStock/AutomaticStockTrading/AutomaticStockTrading/Views/Home/Apitest.cshtml"
            }
        

#line default
#line hidden
            WriteLiteral("    </table>\n");
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
