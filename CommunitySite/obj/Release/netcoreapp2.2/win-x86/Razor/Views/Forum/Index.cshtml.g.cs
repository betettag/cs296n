#pragma checksum "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5707d98762c3720507be827b2dc82c1b0ecc5a26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Forum_Index), @"mvc.1.0.view", @"/Views/Forum/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Forum/Index.cshtml", typeof(AspNetCore.Views_Forum_Index))]
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
#line 1 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\_ViewImports.cshtml"
using CommunitySite;

#line default
#line hidden
#line 2 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\_ViewImports.cshtml"
using CommunitySite.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5707d98762c3720507be827b2dc82c1b0ecc5a26", @"/Views/Forum/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9f8bdd5ace99f8afeb9e5796390339171979fdd", @"/Views/_ViewImports.cshtml")]
    public class Views_Forum_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Topic>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/styles.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Forum", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "NewMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
  
    ViewData["Title"] = "C.O.D.E.C. Forum";

#line default
#line hidden
            BeginContext(195, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(224, 233, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5707d98762c3720507be827b2dc82c1b0ecc5a266323", async() => {
                BeginContext(230, 92, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width =device-width\" />\r\n    <title>Forum</title>\r\n    ");
                EndContext();
                BeginContext(322, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5707d98762c3720507be827b2dc82c1b0ecc5a266803", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(371, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(377, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5707d98762c3720507be827b2dc82c1b0ecc5a268135", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(448, 2, true);
                WriteLiteral("\r\n");
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
            BeginContext(457, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(459, 2026, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5707d98762c3720507be827b2dc82c1b0ecc5a2610264", async() => {
                BeginContext(465, 120, true);
                WriteLiteral("\r\n    <div class=\"container text-center\">\r\n        <p class=\"text-left\">\r\n            <h3>Forum</h3><br />\r\n            ");
                EndContext();
                BeginContext(585, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5707d98762c3720507be827b2dc82c1b0ecc5a2610776", async() => {
                    BeginContext(654, 25, true);
                    WriteLiteral("Click Here To Add a Topic");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(683, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 23 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
             if (Model.Count() != 0)
            {
                

#line default
#line hidden
#line 25 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                 foreach (Topic t in Model)
                {

#line default
#line hidden
                BeginContext(802, 24, true);
                WriteLiteral("                    <h4>");
                EndContext();
                BeginContext(827, 7, false);
#line 27 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                   Write(t.Title);

#line default
#line hidden
                EndContext();
                BeginContext(834, 7, true);
                WriteLiteral("</h4>\r\n");
                EndContext();
                BeginContext(863, 22, false);
#line 28 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                Write("Posted: " + t.PubDate);

#line default
#line hidden
                EndContext();
                BeginContext(886, 9, true);
                WriteLiteral(" <br />\r\n");
                EndContext();
                BeginContext(917, 21, false);
#line 29 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                Write("Author: " + t.Author);

#line default
#line hidden
                EndContext();
                BeginContext(939, 8, true);
                WriteLiteral("<br />\r\n");
                EndContext();
                BeginContext(969, 20, false);
#line 30 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                Write("Message: " + t.Body);

#line default
#line hidden
                EndContext();
                BeginContext(990, 37, true);
                WriteLiteral(" <br />\r\n                    <br />\r\n");
                EndContext();
#line 32 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                     if (t.Comments.Count != 0)
                    {
                        

#line default
#line hidden
                BeginContext(1125, 31, false);
#line 34 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                    Write(t.Comments.Count + " Replies: ");

#line default
#line hidden
                EndContext();
                BeginContext(1157, 8, true);
                WriteLiteral("<br />\r\n");
                EndContext();
#line 35 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                        //extra credit?
                        
                        

#line default
#line hidden
#line 37 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                         foreach (Message m in t.Comments)
                        {
                            

#line default
#line hidden
                BeginContext(1349, 17, false);
#line 39 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                        Write("User: " + m.User);

#line default
#line hidden
                EndContext();
                BeginContext(1367, 8, true);
                WriteLiteral("<br />\r\n");
                EndContext();
                BeginContext(1405, 20, false);
#line 40 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                        Write("Date: " + m.PubDate);

#line default
#line hidden
                EndContext();
                BeginContext(1426, 9, true);
                WriteLiteral(" <br />\r\n");
                EndContext();
                BeginContext(1465, 26, false);
#line 41 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                        Write("Repling to: " + m.ReplyTo);

#line default
#line hidden
                EndContext();
                BeginContext(1492, 8, true);
                WriteLiteral("<br />\r\n");
                EndContext();
                BeginContext(1530, 23, false);
#line 42 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                        Write("Message: " + m.MsgText);

#line default
#line hidden
                EndContext();
                BeginContext(1554, 45, true);
                WriteLiteral(" <br />\r\n                            <hr />\r\n");
                EndContext();
#line 44 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                        }

#line default
#line hidden
#line 44 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                         
                        string url = "NewMessage" + "?title=" + @t.Title;
                        

#line default
#line hidden
                BeginContext(1725, 113, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5707d98762c3720507be827b2dc82c1b0ecc5a2617768", async() => {
                    BeginContext(1826, 8, true);
                    WriteLiteral("Comments");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-title", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 46 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                                                        WriteLiteral(t.Title);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-title", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1838, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 47 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
                BeginContext(1938, 35, false);
#line 50 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                    Write("No replies yet. Be the first One!");

#line default
#line hidden
                EndContext();
                BeginContext(1974, 8, true);
                WriteLiteral("<br />\r\n");
                EndContext();
#line 51 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                        string url = "Forum/NewMessage" + "?title=" + @t.Title;
                        

#line default
#line hidden
                BeginContext(2087, 113, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5707d98762c3720507be827b2dc82c1b0ecc5a2621434", async() => {
                    BeginContext(2188, 8, true);
                    WriteLiteral("Comments");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-title", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 52 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                                                        WriteLiteral(t.Title);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-title", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2200, 63, true);
                WriteLiteral("\r\n                        <!--<a class=\"btn btn-primary\" href=\"");
                EndContext();
                BeginContext(2264, 3, false);
#line 53 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                                                        Write(url);

#line default
#line hidden
                EndContext();
                BeginContext(2267, 19, true);
                WriteLiteral("\">Comments</a>-->\r\n");
                EndContext();
#line 54 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                    }

#line default
#line hidden
#line 54 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                     
                }

#line default
#line hidden
#line 55 "C:\Users\Admin\Desktop\cs295n\ASP.net-CommunitySite\CommunitySite\Views\Forum\Index.cshtml"
                 
            }

#line default
#line hidden
                BeginContext(2343, 135, true);
                WriteLiteral("\r\n            <br>\r\n        </p>\r\n    </div>\r\n    <div class=\"container\">\r\n        <br />\r\n        <br />\r\n        <br />\r\n    </div>\r\n");
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
            BeginContext(2485, 11, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Topic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
