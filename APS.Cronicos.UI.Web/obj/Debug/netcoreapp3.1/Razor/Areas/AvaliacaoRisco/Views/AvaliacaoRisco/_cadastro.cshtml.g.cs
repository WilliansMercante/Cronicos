#pragma checksum "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c52496f5e39a036ef1325a5fd04988d304f7b88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AvaliacaoRisco_Views_AvaliacaoRisco__cadastro), @"mvc.1.0.view", @"/Areas/AvaliacaoRisco/Views/AvaliacaoRisco/_cadastro.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c52496f5e39a036ef1325a5fd04988d304f7b88", @"/Areas/AvaliacaoRisco/Views/AvaliacaoRisco/_cadastro.cshtml")]
    #nullable restore
    public class Areas_AvaliacaoRisco_Views_AvaliacaoRisco__cadastro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<APS.Cronicos.UI.Web.Areas.AvaliacaoRisco.ViewModels.CadastroViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row clearfix\" style=\"padding:10px\">\r\n    <div class=\"col-lg-12\">\r\n        <div class=\"card\">\r\n            <div class=\"body\">\r\n");
#nullable restore
#line 7 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                 using (Html.BeginForm("Cadastro", "AvaliacaoRisco", new { area = "AvaliacaoRisco" }, FormMethod.Post, true, new { id = "frm-Avaliacao", @class = "form-horizontal" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
               Write(Html.HiddenFor(p => p.AvaliacaoRisco.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
               Write(Html.HiddenFor(p => p.AvaliacaoRisco.CnsPaciente));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
               Write(Html.HiddenFor(p => p.flDiabetes));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""row clearfix"">
                        <div class=""col-lg-12"">
                            <div class=""float-right"">
                                <span class=""text-danger pull-left"">(*) Campos obrigatórios</span>
                            </div>
                        </div>
                    </div>
");
            WriteLiteral(@"                    <fieldset class=""scheduler-border"">
                        <legend class=""scheduler-border"">Estratificação</legend>
                        <div class=""row clearfix"">
                            <div class=""col-md-3"">
                                <label class=""control-label font-bold"">
                                    Data de Estratificação:
                                </label> <span class=""text-danger"">*</span>
                                ");
#nullable restore
#line 28 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                           Write(Html.TextBoxFor(p => p.AvaliacaoRisco.DtEstratificacao, "{0:yyyy-MM-dd}", new { @class = "form-control",@type = "date", @required = "required", max = DateTime.Now.ToString("yyyy-MM-dd")}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""col-md-5"">
                                <label class=""control-label"">Estratificação de Risco</label>
                                <span class=""text-danger"">*</span>
                                ");
#nullable restore
#line 33 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                           Write(Html.DropDownListFor(p => p.AvaliacaoRisco.IdEstratificacaoRisco, Model.EstratificacoesRisco, "----- Selecione -----", new { @class = "form-control", @required="required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                    </fieldset>
                    <div id=""divImc"">
                        <fieldset class=""scheduler-border"">
                            <legend class=""scheduler-border"">IMC</legend>
                            <div class=""col-md-2"">
                                <label class=""control-label font-bold"">
                                    Peso:
                                </label> <span class=""text-danger"">*</span>
                                ");
#nullable restore
#line 44 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                           Write(Html.TextBoxFor(p => p.AvaliacaoRisco.Peso, new { @class = "form-control", @required = "required", @maxlength ="3", @type = "number", @oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""col-md-2"">
                                <label class=""control-label font-bold"">
                                    Altura:
                                </label> <span class=""text-danger"">*</span>
                                ");
#nullable restore
#line 50 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                           Write(Html.TextBoxFor(p => p.AvaliacaoRisco.Altura, new { @class = "form-control", @required = "required"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""col-md-1"" id=""divGerarImc"">
                                <a class=""btn btn-sm btn-success"" id=""gerarImc""><i class=""ace-icon fa fa-search""></i></a>
                            </div>
                            <div class=""col-md-7"">
                                <div id=""divResultadoIMC"">
                                    <h4 class=""margin-0"" id=""mensagemImc""></h4>
                                    <br />
                                    <strong id=""resultadoImc""></strong>
                                    <br />
                                    <br />
                                    <span id=""classificacaoImc""></span>
                                    <br />
                                </div>
                            </div>
                        </fieldset>
                    </div>
");
#nullable restore
#line 68 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                     if (Model.flDiabetes)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <fieldset class=""scheduler-border"">
                            <legend class=""scheduler-border"">Diabetes</legend>
                            <div class=""row clearfix"" id=""divDiabetes"">
                                <div class=""col-md-3"">
                                    <label class=""control-label font-bold"">
                                        Insulino Dependente?
                                    </label> <span class=""text-danger"">*</span>
                                    ");
#nullable restore
#line 77 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                               Write(Html.CheckBoxFor(p => p.AvaliacaoRisco.FlInsulinoDependente));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                                <div class=""col-md-5"">
                                    <label class=""control-label"">Tipo de Diabetes:</label>
                                    <span class=""text-danger"">*</span>
                                    ");
#nullable restore
#line 82 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                               Write(Html.DropDownListFor(p => p.AvaliacaoRisco.IdTipoDiabetes, Model.TiposDiabetes, "----- Selecione -----", new { @class = "form-control", @required="required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                                <div class=""col-md-3"">
                                    <label class=""control-label font-bold"">
                                        Data da Avaliação dos Pés:
                                    </label> <span class=""text-danger"">*</span>
                                    ");
#nullable restore
#line 88 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                               Write(Html.TextBoxFor(p => p.AvaliacaoRisco.DtAvaliacaoPes, "{0:yyyy-MM-dd}", new { @class = "form-control",@type = "date", @required = "required", max = DateTime.Now.ToString("yyyy-MM-dd")}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>

                            </div>
                            <br />
                            <div class=""row clearfix"" id=""divAmg"">
                                <div class=""col-md-3"">
                                    <label class=""control-label font-bold"">
                                        AMG?
                                    </label> <span class=""text-danger"">*</span>
                                    ");
#nullable restore
#line 98 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                               Write(Html.CheckBoxFor(p => p.AvaliacaoRisco.FlAmg));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                                <div class=""col-md-3"" id=""divLaudo"" style=""display:none"">
                                    <label class=""control-label font-bold"">
                                        Data do Laudo:
                                    </label> <span class=""text-danger"">*</span>
                                    ");
#nullable restore
#line 104 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                               Write(Html.TextBoxFor(p => p.AvaliacaoRisco.DtUltimolaudo, "{0:yyyy-MM-dd}", new { @class = "form-control",@type = "date", max = DateTime.Now.ToString("yyyy-MM-dd")}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </fieldset>\r\n");
#nullable restore
#line 108 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""row clearfix"">
                        <div class=""col-md-12"">
                            <label class=""control-label font-bold"">
                                Observação:
                            </label> <span class=""text-danger"">*</span>
                            ");
#nullable restore
#line 115 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                       Write(Html.TextAreaFor(p => p.AvaliacaoRisco.Observacao, new { @class = "form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
            WriteLiteral(@"                    <div class=""row clearfix pull-right"">
                        <div class=""col-md-2"">
                            <button class=""btn btn-sm btn-primary"" id=""btnIncluir"">
                                Incluir
                                <i class=""ace-icon fa fa-arrow-right icon-on-right""></i>
                            </button>
                        </div>
                    </div>
");
#nullable restore
#line 127 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\AvaliacaoRisco\Views\AvaliacaoRisco\_cadastro.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<APS.Cronicos.UI.Web.Areas.AvaliacaoRisco.ViewModels.CadastroViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
