#pragma checksum "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0f3ac4fb8d81e22d4b0487c26aa67eb3ed745a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Nav), @"mvc.1.0.view", @"/Views/Shared/_Nav.cshtml")]
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
#line 1 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\_VIewImports.cshtml"
using APS.Cronicos.UI.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
using APS.Cronicos.ViewModels.Seguranca;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0f3ac4fb8d81e22d4b0487c26aa67eb3ed745a2", @"/Views/Shared/_Nav.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c89af2b26c738d4319b31a00daf7c24bfddce6f", @"/Views/_VIewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Nav : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
  
    var menu = HttpContextAccessor.HttpContext.User.Claims.Where(p => p.Type.Equals("ItensMenuPrincipal")).FirstOrDefault().Value;
    var lstItensMenuPrincipal = JsonConvert.DeserializeObject<IEnumerable<MenuViewModel>>(menu);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ul class=\"nav nav-list\">\r\n    <li class=\"active\">\r\n        <a>\r\n            <i class=\"menu-icon fa fa-tachometer\"></i>\r\n            <span class=\"menu-text\"> Menu </span>\r\n        </a>\r\n        <b class=\"arrow\"></b>\r\n    </li>\r\n");
#nullable restore
#line 18 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
     foreach (var item in lstItensMenuPrincipal)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li");
            BeginWriteAttribute("class", " class=\"", 679, "\"", 687, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <a href=\"#\" class=\"dropdown-toggle\">\r\n                <i");
            BeginWriteAttribute("class", " class=\"", 759, "\"", 792, 2);
            WriteAttributeValue("", 767, "menu-icon", 767, 9, true);
#nullable restore
#line 22 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
WriteAttributeValue(" ", 776, item.ClassIcon, 777, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                <span class=\"menu-text\">\r\n                    ");
#nullable restore
#line 24 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
               Write(item.NmItem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </span>\r\n                <b class=\"arrow fa fa-angle-down\"></b>\r\n            </a>\r\n            <b class=\"arrow\"></b>\r\n");
#nullable restore
#line 29 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
             if (item.SubItens.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ul class=\"submenu\">\r\n");
#nullable restore
#line 32 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
                     foreach (var subItem in item.SubItens)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 1217, "\"", 1225, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 35 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
                             if (subItem.FlRedirecionamentoExterno)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("href", " href=\"", 1363, "\"", 1398, 1);
#nullable restore
#line 37 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
WriteAttributeValue("", 1370, subItem.LnkRedirecionamento, 1370, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n                                    <i class=\"menu-icon fa fa-caret-right\"></i>\r\n                                    ");
#nullable restore
#line 39 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
                               Write(subItem.NmItem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </a>\r\n");
#nullable restore
#line 41 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("href", " href=\"", 1720, "\"", 1813, 1);
#nullable restore
#line 44 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
WriteAttributeValue("", 1727, Url.ActionLink(subItem.NmAction, subItem.NmController, new { Area = subItem.NmArea }), 1727, 86, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"menu-icon fa fa-caret-right\"></i>\r\n                                    ");
#nullable restore
#line 46 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
                               Write(subItem.NmItem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </a>\r\n");
#nullable restore
#line 48 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <b class=\"arrow\"></b>\r\n                        </li>\r\n");
#nullable restore
#line 51 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n");
#nullable restore
#line 53 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </li>\r\n");
#nullable restore
#line 55 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Views\Shared\_Nav.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul><!-- /.nav-list -->");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
