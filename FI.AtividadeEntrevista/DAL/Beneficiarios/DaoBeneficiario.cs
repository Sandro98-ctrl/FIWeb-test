using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FI.AtividadeEntrevista.DAL.Beneficiarios
{
    internal class DaoBeneficiario : AcessoDados
    {
        /// <summary>
        /// Inclui um novo beneficiário
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiário</param>
        /// <returns></returns>
        internal long Incluir(Beneficiario beneficiario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("Nome", beneficiario.Nome),
                new SqlParameter("CPF", beneficiario.CPF),
                new SqlParameter("IdCliente", beneficiario.IdCliente)
            };

            var ds = base.Consultar("FI_SP_IncBenef", parametros);
            long ret = 0;

            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);

            return ret;
        }

        internal bool VerificarExistencia(string CPF, long idCliente)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("CPF", CPF),
                new SqlParameter("IdCliente", idCliente)
            };

            var ds = base.Consultar("FI_SP_VerificaBeneficiario", parametros);

            return ds.Tables[0].Rows.Count > 0;
        }
    }
}
