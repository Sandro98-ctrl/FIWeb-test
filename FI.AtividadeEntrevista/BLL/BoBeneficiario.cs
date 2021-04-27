using FI.AtividadeEntrevista.DAL.Beneficiarios;
using FI.AtividadeEntrevista.DML;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiário
        /// </summary>
        /// <param name="beneficiario">Obejto de beneficiário</param>
        /// <returns></returns>
        public long Incluir(Beneficiario beneficiario)
        {
            var cli = new DaoBeneficiario();
            return cli.Incluir(beneficiario);
        }

        /// <summary>
        /// Verifica existência de um beneficiário
        /// </summary>
        /// <param name="CPF">CPF</param>
        /// <param name="idCliente">Id do cliente</param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF, long idCliente)
        {
            var cli = new DaoBeneficiario();
            return cli.VerificarExistencia(CPF, idCliente);
        }
    }
}
