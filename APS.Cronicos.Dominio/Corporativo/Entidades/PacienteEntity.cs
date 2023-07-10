using System;

namespace APS.Cronicos.Dominio.Corporativo.Entidades
{
    public class PacienteEntity
    {
        public int Id { get; set; }
        public int IdSexo { get; set; }
        public string Nome { get; set; }
        public string Cns { get; set; }
        public string NmMae { get; set; }
        public string NmPai { get; set; }
        public DateTime DtNascimento { get; set; }
        public string NrCelular { get; set; }
        public string NrTelResidencial { get; set; }
        public string NrTelContato { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
        public string Logradouro { get; set; }
        public string NrLogradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string UF { get; set; }
        public bool FlObito { get; set; }
        public DateTime? DtProvavelObito { get; set; }


        public SexoEntity Sexo { get; set; }
    }

}
