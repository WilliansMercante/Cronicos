#pragma checksum "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03d8c3cf0b6d607c484a10bbf42376c093ec0cea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Paciente_Views_Paciente__cadastro), @"mvc.1.0.view", @"/Areas/Paciente/Views/Paciente/_cadastro.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03d8c3cf0b6d607c484a10bbf42376c093ec0cea", @"/Areas/Paciente/Views/Paciente/_cadastro.cshtml")]
    #nullable restore
    public class Areas_Paciente_Views_Paciente__cadastro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<APS.Cronicos.UI.Web.Areas.Paciente.ViewModels.Paciente.DadosPacienteViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"tabPaciente\" class=\"tab-pane in active\">\r\n");
#nullable restore
#line 4 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
     using (Html.BeginForm("Cadastro", "Paciente", new { area = "Paciente" }, FormMethod.Post, true, new { @class = "form-horizontal", id = "frm-paciente" }))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
   Write(Html.HiddenFor(p => p.Paciente.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
   Write(Html.HiddenFor(p => p.PacienteUnidade.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
   Write(Html.HiddenFor(p => p.PacienteUnidade.IdUnidade));

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
   Write(Html.HiddenFor(p => p.PacienteUnidade.NomeEnfermeiro));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
   Write(Html.HiddenFor(p => p.PacienteUnidade.NomeMedico));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
   Write(Html.HiddenFor(p => p.PacienteUnidade.NomeEquipe));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <fieldset class=""scheduler-border"">
            <legend class=""scheduler-border"">Paciente</legend>
            <div class=""row clearfix"">
                <div class=""col-sm-12 col-md-12 col-lg-12"">
                    <div class=""col-sm-4"">
                        <label>CNS:</label><span class=""text-danger"">*</span>
                        ");
#nullable restore
#line 19 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                   Write(Html.TextBoxFor(p => p.Paciente.Cns, new { @class = "form-control", required = "required", maxlength = "15" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <div class=""col-sm-6"" id=""divPequisar"">
                        <a class=""btn btn-sm btn-success"" id=""btnPesquisar""><i class=""ace-icon fa fa-search""></i></a>
                    </div>                    
                </div>
            </div>
            <div id=""divDadosPaciente"">
                ");
#nullable restore
#line 27 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
           Write(Html.HiddenFor(p => p.Paciente.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px;"">
                        <div class=""col-sm-9"">
                            <label>Nome:</label><span class=""text-danger"">*</span>
                            ");
#nullable restore
#line 32 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Nome, new { @class = "form-control", required = "required", autocapitalize="word" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-3\">\r\n                            <label>CPF:</label>\r\n                            ");
#nullable restore
#line 36 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Cpf, new { @class = "form-control cpf" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px;"">
                        <div class=""col-sm-4"">
                            <label>RG:</label>
                            ");
#nullable restore
#line 44 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Rg, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-3\">\r\n                            <label>Sexo:<span class=\"text-danger\">*</span></label>\r\n                            ");
#nullable restore
#line 48 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.DropDownListFor(p => p.Paciente.IdSexo, Model.ListarSexo, "--Selecione--", new { @class = "form-control",required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-5\">\r\n                            <label>E-mail:</label>\r\n                            ");
#nullable restore
#line 52 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px;"">
                        <div class=""col-sm-3"">
                            <label>Dt. Nascimento: <span class=""text-danger"">*</span></label>
                            ");
#nullable restore
#line 60 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.DtNascimento, new { @class = "form-control data", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-3\">\r\n                            <label>Celular:</label>\r\n                            ");
#nullable restore
#line 64 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.NrCelular, new { @class = "form-control telefone" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-3\">\r\n                            <label>Tel. Residencial:</label>\r\n                            ");
#nullable restore
#line 68 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.NrTelResidencial, new { @class = "form-control telefone" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-3\">\r\n                            <label>Tel. Contato:</label>\r\n                            ");
#nullable restore
#line 72 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.NrTelContato, new { @class = "form-control telefone" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px;"">
                        <div class=""col-sm-6"">
                            <label>Pai:</label>
                            ");
#nullable restore
#line 80 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.NmPai, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-6\">\r\n                            <label>Mãe:</label>\r\n                            ");
#nullable restore
#line 84 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.NmMae, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px;"">
                        <div class=""col-sm-3"">
                            <label>CEP:<span class=""text-danger"">*</span></label>
                            ");
#nullable restore
#line 92 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Cep, new { @class = "form-control cep", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-6\">\r\n                            <label>Logradouro:<span class=\"text-danger\">*</span></label>\r\n                            ");
#nullable restore
#line 96 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Logradouro, new { @class = "form-control", @readonly = "readonly", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-3\">\r\n                            <label>Número:<span class=\"text-danger\">*</span></label>\r\n                            ");
#nullable restore
#line 100 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.NrLogradouro, new { @class = "form-control", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px; "">
                        <div class=""col-sm-3"">
                            <label>Bairro:<span class=""text-danger"">*</span></label>
                            ");
#nullable restore
#line 108 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Bairro, new { @class = "form-control", required = "required", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <label>Complemento:</label>\r\n                            ");
#nullable restore
#line 112 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Complemento, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <label>Municipio:<span class=\"text-danger\">*</span></label>\r\n                            ");
#nullable restore
#line 116 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.Municipio, new { @class = "form-control", required = "required", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <label>UF:<span class=\"text-danger\">*</span></label>\r\n                            ");
#nullable restore
#line 120 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.UF, new { @class = "form-control", required = "required", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-1\">\r\n                            <label>Óbito?</label>\r\n                            ");
#nullable restore
#line 124 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.CheckBoxFor(p => p.Paciente.FlObito, new { @class = "form-control check"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\" style=\"display:none\" id=\"divDtObito\">\r\n                            <label>Data Provavél do Óbito:<span class=\"text-danger\">*</span></label>\r\n                            ");
#nullable restore
#line 128 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.TextBoxFor(p => p.Paciente.DtProvavelObito,"{0:yyyy-MM-dd}", new {  @class = "form-control data"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
        <div id=""divDadosUnidade"">
            <fieldset class=""scheduler-border"">
                <legend class=""scheduler-border"">Dados da Unidade</legend>
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px; "">
                        <div class=""col-sm-1"">
                            <label>Fora de Área?</label>
                            ");
#nullable restore
#line 141 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.CheckBoxFor(p => p.PacienteUnidade.FlForaDeArea, new { @class = "form-control check"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div id=""divEquipe"">
                            <div class=""col-sm-2"">
                                <label>Prontuario:<span class=""text-danger"">*</span></label>
                                ");
#nullable restore
#line 146 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                           Write(Html.TextBoxFor(p => p.PacienteUnidade.Prontuario, new { @class = "form-control", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-sm-3\">\r\n                                <label>Equipe:</label>\r\n                                ");
#nullable restore
#line 150 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                           Write(Html.DropDownListFor(p => p.PacienteUnidade.IdEquipe, Model.Equipes, "--Selecione--", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-sm-3\">\r\n                                <label>Enfermeiro:</label>\r\n                                ");
#nullable restore
#line 154 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                           Write(Html.DropDownListFor(p => p.PacienteUnidade.CpfEnfermeiro, Model.Enfermeiros, "--Selecione--", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-sm-3\">\r\n                                <label>Medico:</label>\r\n                                ");
#nullable restore
#line 158 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                           Write(Html.DropDownListFor(p => p.PacienteUnidade.CpfMedico, Model.Medicos, "--Selecione--", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
        <div id=""divDiagnostico"">
            <fieldset class=""scheduler-border"">
                <legend class=""scheduler-border"">Diagnóstico</legend>
                <div class=""row clearfix"">
                    <div class=""col-sm-12 col-md-12 col-lg-12"" style=""margin-top: 8px; "">
                        <div class=""col-sm-3"">
                            <label>Equipe:</label>
                            ");
#nullable restore
#line 172 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
                       Write(Html.DropDownListFor(p => p.PacienteUnidade.IdDiagnostico, Model.Diagnosticos, "--Selecione--", new { @class = "form-control", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
        <div class=""divBotoesEdicao"">
            <input class=""btn btn-danger"" type=""button"" value=""Cancelar"" id=""btnCancelar"">
            <input class=""btn btn-success"" type=""submit"" value=""Gravar"" id=""btnSalvar"">
        </div>
        <input class=""btn btn-warning"" type=""button"" value=""Editar"" id=""btnEditar"" />
");
#nullable restore
#line 183 "C:\NovosProjetos\APS.Cronicos\APS.Cronicos.UI.Web\Areas\Paciente\Views\Paciente\_cadastro.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<APS.Cronicos.UI.Web.Areas.Paciente.ViewModels.Paciente.DadosPacienteViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591