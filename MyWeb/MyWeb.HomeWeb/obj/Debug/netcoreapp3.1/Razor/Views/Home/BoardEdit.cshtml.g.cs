#pragma checksum "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\Home\BoardEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "443cb0bfc630f2f46add149e4840c41fa0026c15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BoardEdit), @"mvc.1.0.view", @"/Views/Home/BoardEdit.cshtml")]
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
#line 1 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\_ViewImports.cshtml"
using MyWeb.HomeWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\_ViewImports.cshtml"
using MyWeb.HomeWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\Home\BoardEdit.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"443cb0bfc630f2f46add149e4840c41fa0026c15", @"/Views/Home/BoardEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d515280afbb24f34010e28d208872f4ac0784a77", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_BoardEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BoardModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/home/BoardEdit_Input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <link href=""https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css"" rel=""stylesheet"">
    <script src=""https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js""></script>

    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""table-responsive"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "443cb0bfc630f2f46add149e4840c41fa0026c154797", async() => {
                WriteLiteral("\r\n                            ");
#nullable restore
#line 13 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\Home\BoardEdit.cshtml"
                       Write(Html.Hidden("idx", Model.Idx));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            <table class=""table table-bordered no-wrap"">
                                <colgroup>
                                    <col style=""width:100px"" />
                                    <col style=""width:auto"" />
                                </colgroup>
                                <tbody>
                                    <tr>
                                        <th>제목</th>
                                        <td>

                                            ");
#nullable restore
#line 24 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\Home\BoardEdit.cshtml"
                                       Write(Html.TextBox("title", Model.Title, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
                WriteLiteral("                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <th>내용</th>\r\n                                        <td>");
#nullable restore
#line 32 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\Home\BoardEdit.cshtml"
                                       Write(Html.TextArea("contents", Model.Contents));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <th>작성자</th>\r\n                                        <td>");
#nullable restore
#line 36 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\Home\BoardEdit.cshtml"
                                       Write(Model.Reg_Username);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (");
#nullable restore
#line 36 "E:\www\WebMVCCore3\MyWeb\MyWeb.HomeWeb\Views\Home\BoardEdit.cshtml"
                                                            Write(Model.Reg_Date.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
                WriteLiteral(")</td>\r\n                                    </tr>\r\n                                </tbody>\r\n                            </table>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
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
                    <div class=""text-right"">
                        <button id=""btn1"" class=""btn btn-sm btn-primary"">저장</button>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(""#form1 textarea[name=contents]"").summernote();
        });

        $(""#btn1"").click(function () {

            //var markupStr = $('#summernote').summernote('code');
            var code = $(""#form1 textarea[name=contents]"").summernote(""code"");
            $(""#form1 textarea[name=contents]"").val(code);
            $(""#form1"").submit();
        });

    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BoardModel> Html { get; private set; }
    }
}
#pragma warning restore 1591