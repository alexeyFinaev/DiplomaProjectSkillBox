#pragma checksum "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Services.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0dac3b2bc7610a6e37a760ff92be41de395e0f8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Services), @"mvc.1.0.view", @"/Views/Home/Services.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Services.cshtml", typeof(AspNetCore.Views_Home_Services))]
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
#line 1 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\_ViewImports.cshtml"
using DiplomaProjectAsp;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\_ViewImports.cshtml"
using DiplomaProjectAsp.Models;

#line default
#line hidden
#line 3 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\_ViewImports.cshtml"
using DiplomaProjectAsp.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0dac3b2bc7610a6e37a760ff92be41de395e0f8d", @"/Views/Home/Services.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5086516a0f8fe178a692e04712daf771c90fc1e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Services : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Service>>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Services.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(63, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(92, 103, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61f8e6606f164cb8a4162937b9c0e96b", async() => {
                BeginContext(98, 90, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Services</title>\r\n");
                EndContext();
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
            EndContext();
            BeginContext(195, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(197, 458, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88f6d53136cb4eff83ec710587d0b9fb", async() => {
                BeginContext(203, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                DefineSection("footer", async() => {
                }
                );
                BeginContext(228, 117, true);
                WriteLiteral("    <div class=\"serviceList\">\r\n        <b>Что мы можем сделать</b>\r\n        <div class=\"line\"></div>\r\n        <div>\r\n");
                EndContext();
#line 20 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Services.cshtml"
              
                foreach (var e in Model)
                {

#line default
#line hidden
                BeginContext(422, 64, true);
                WriteLiteral("                    <details>\r\n                        <summary>");
                EndContext();
                BeginContext(487, 13, false);
#line 24 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Services.cshtml"
                            Write(e.NameService);

#line default
#line hidden
                EndContext();
                BeginContext(500, 39, true);
                WriteLiteral("</summary>\r\n                        <p>");
                EndContext();
                BeginContext(540, 6, false);
#line 25 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Services.cshtml"
                      Write(e.Text);

#line default
#line hidden
                EndContext();
                BeginContext(546, 38, true);
                WriteLiteral("</p>\r\n                    </details>\r\n");
                EndContext();
#line 27 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Services.cshtml"

                }
            

#line default
#line hidden
                BeginContext(620, 28, true);
                WriteLiteral("        </div>\r\n    </div>\r\n");
                EndContext();
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
            EndContext();
            BeginContext(655, 21, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Service>> Html { get; private set; }
    }
}
#pragma warning restore 1591