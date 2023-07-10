using APS.Cronicos.Dominio.EntidadeBase;

using System;

namespace APS.Cronicos.Dominio.Cronicos.Entidades
{
    public class PacienteUnidadeEntity : Entidade
    {
        public int? IdEquipe { get; set; }

        private string nomeEquipe;
        public string NomeEquipe
        {
            get
            {
                return nomeEquipe;
            }
            set
            {
                nomeEquipe = IdEquipe != null || IdEquipe != 0 ? value : null;
            }
        }
        public int IdUnidade { get; set; }
        public int IdDiagnostico { get; set; }
        public string CnsPaciente { get; set; }
        public string CpfEnfermeiro { get; set; }

        private string nomeEnfermeiro;
        public string NomeEnfermeiro
        {
            get
            {
                return nomeEnfermeiro;
            }
            set
            {
                nomeEnfermeiro = string.IsNullOrWhiteSpace(CpfEnfermeiro) ? null : value;
            }
        }

        public string CpfMedico { get; set; }

        private string nomeMedico;
        public string NomeMedico
        {
            get
            {
                return nomeMedico;
            }
            set
            {
                nomeMedico = string.IsNullOrWhiteSpace(CpfMedico) ? null : value;
            }
        }
        public string Prontuario { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlForaDeArea { get; set; }

        public bool ValidarUnidade
        {
            get { return IdUnidade != 0; }
        }

        public DiagnosticoEntity Diagnostico { get; set; }

    }  
}
