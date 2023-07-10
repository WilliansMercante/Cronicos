using APS.Cronicos.Dominio.ContratoGestao.Entidades;
using System;
using System.Collections.Generic;

namespace APS.Cronicos.Dominio.ContratoGestao.Repositories.Interfaces
{
    public interface IServicoRepository
    {
        IEnumerable<ServicoEntity> Listar(DateTime competencia, int idUnidade);
        ServicoEntity Obter(DateTime competencia, int idUnidade, int idServico);
    }
}