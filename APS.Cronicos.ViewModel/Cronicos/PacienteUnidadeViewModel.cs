using System;

namespace APS.Cronicos.ViewModels.Cronicos
{
    public class PacienteUnidadeViewModel
    {
        public int Id { get; set; }
        public int? IdEquipe { get; set; }
        public string NomeEquipe { get; set; }
        public int IdUnidade { get; set; }
        public int IdDiagnostico { get; set; }
        public string CnsPaciente { get; set; }
        public string CpfEnfermeiro { get; set; }
        public string NomeEnfermeiro { get; set; }
        public string CpfMedico { get; set; }
        public string NomeMedico { get; set; }
        public string Prontuario { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlForaDeArea { get; set; }

        public DiagnosticoViewModel Diagnostico { get; set; }
    }
}
