#pragma checksum "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8378da70119975133dffcd79411ed2e9052795af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Projects), @"mvc.1.0.view", @"/Views/Home/Projects.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Projects.cshtml", typeof(AspNetCore.Views_Home_Projects))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8378da70119975133dffcd79411ed2e9052795af", @"/Views/Home/Projects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5086516a0f8fe178a692e04712daf771c90fc1e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Projects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project>>
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
#line 2 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(63, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(92, 103, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8976ccfcaa584660b06a5380450bcbc2", async() => {
                BeginContext(98, 90, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Projects</title>\r\n");
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
            BeginContext(197, 683, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa4e946fd6674b669d67f07e3ee55867", async() => {
                BeginContext(203, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                DefineSection("footer", async() => {
                }
                );
                BeginContext(228, 39, true);
                WriteLiteral("    <div class=\"projects\">\r\n        <b>");
                EndContext();
                BeginContext(268, 18, false);
#line 17 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml"
      Write(ViewBag.Buttons[1]);

#line default
#line hidden
                EndContext();
                BeginContext(286, 73, true);
                WriteLiteral("</b>\r\n        <div class=\"line\"></div>\r\n        <div>\r\n            <ul>\r\n");
                EndContext();
#line 21 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml"
                  
                    foreach (var e in Model)
                    {


#line default
#line hidden
                BeginContext(450, 81, true);
                WriteLiteral("                        <li class=\"projectsList\">\r\n                            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 531, "\"", 557, 2);
                WriteAttributeValue("", 538, "/Home/Project/", 538, 14, true);
#line 26 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml"
WriteAttributeValue("", 552, e.Id, 552, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(558, 40, true);
                WriteLiteral(">\r\n                                 <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 598, "\"", 656, 2);
                WriteAttributeValue("", 604, "data:image;base64,", 604, 18, true);
#line 27 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml"
WriteAttributeValue("", 622, Convert.ToBase64String(e.Picture), 622, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(657, 41, true);
                WriteLiteral(" />\r\n                                 <p>");
                EndContext();
                BeginContext(699, 8, false);
#line 28 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml"
                               Write(e.Header);

#line default
#line hidden
                EndContext();
                BeginContext(707, 73, true);
                WriteLiteral("</p>\r\n                            </a>\r\n\r\n                        </li>\r\n");
                EndContext();
#line 32 "C:\Users\user\Desktop\Диплом\DiplomaProjectAsp\DiplomaProjectAsp\DiplomaProjectAsp\Views\Home\Projects.cshtml"

                    }

                

#line default
#line hidden
                BeginContext(826, 47, true);
                WriteLiteral("            </ul>\r\n        </div>\r\n    </div>\r\n");
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
            BeginContext(880, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
