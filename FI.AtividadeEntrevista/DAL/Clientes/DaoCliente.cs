using FI.AtividadeEntrevista.DML;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FI.AtividadeEntrevista.DAL
{
    /// <summary>
    /// Classe de acesso a dados de Cliente
    /// </summary>
    internal class DaoCliente : AcessoDados
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        internal long Incluir(Cliente cliente)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("Nome", cliente.Nome),
                new SqlParameter("Sobrenome", cliente.Sobrenome),
                new SqlParameter("Nacionalidade", cliente.Nacionalidade),
                new SqlParameter("CEP", cliente.CEP),
                new SqlParameter("Estado", cliente.Estado),
                new SqlParameter("Cidade", cliente.Cidade),
                new SqlParameter("Logradouro", cliente.Logradouro),
                new SqlParameter("Email", cliente.Email),
                new SqlParameter("Telefone", cliente.Telefone),
                new SqlParameter("CPF", cliente.CPF)
            };

            var ds = base.Consultar("FI_SP_IncClienteV2", parametros);
            long ret = 0;
            
            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);

            return ret;
        }

        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        internal Cliente Consultar(long Id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("Id", Id)
            };

            var ds = base.Consultar("FI_SP_ConsCliente", parametros);
            var cli = Converter(ds);

            return cli.FirstOrDefault();
        }

        internal bool VerificarExistencia(string CPF)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("CPF", CPF)
            };

            var ds = base.Consultar("FI_SP_VerificaCliente", parametros);

            return ds.Tables[0].Rows.Count > 0;
        }

        internal List<Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("iniciarEm", iniciarEm),
                new SqlParameter("quantidade", quantidade),
                new SqlParameter("campoOrdenacao", campoOrdenacao),
                new SqlParameter("crescente", crescente)
            };

            var ds = base.Consultar("FI_SP_PesqCliente", parametros);
            var cli = Converter(ds);

            var iQtd = 0;

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                int.TryParse(ds.Tables[1].Rows[0][0].ToString(), out iQtd);

            qtd = iQtd;

            return cli;
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        internal List<Cliente> Listar()
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("Id", 0)
            };

            var ds = base.Consultar("FI_SP_ConsCliente", parametros);
            var cli = Converter(ds);

            return cli;
        }

        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        internal void Alterar(Cliente cliente)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("Nome", cliente.Nome),
                new SqlParameter("Sobrenome", cliente.Sobrenome),
                new SqlParameter("Nacionalidade", cliente.Nacionalidade),
                new SqlParameter("CEP", cliente.CEP),
                new SqlParameter("Estado", cliente.Estado),
                new SqlParameter("Cidade", cliente.Cidade),
                new SqlParameter("Logradouro", cliente.Logradouro),
                new SqlParameter("Email", cliente.Email),
                new SqlParameter("Telefone", cliente.Telefone),
                new SqlParameter("CPF", cliente.CPF),
                new SqlParameter("ID", cliente.Id)
            };

            base.Executar("FI_SP_AltCliente", parametros);
        }

        /// <summary>
        /// Excluir Cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        internal void Excluir(long Id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("Id", Id)
            };

            base.Executar("FI_SP_DelCliente", parametros);
        }

        private List<Cliente> Converter(DataSet ds)
        {
            var lista = new List<Cliente>();

            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var cli = new Cliente
                    {
                        Id = row.Field<long>("Id"),
                        CEP = row.Field<string>("CEP"),
                        Cidade = row.Field<string>("Cidade"),
                        CPF = row.Field<string>("CPF"),
                        Email = row.Field<string>("Email"),
                        Estado = row.Field<string>("Estado"),
                        Logradouro = row.Field<string>("Logradouro"),
                        Nacionalidade = row.Field<string>("Nacionalidade"),
                        Nome = row.Field<string>("Nome"),
                        Sobrenome = row.Field<string>("Sobrenome"),
                        Telefone = row.Field<string>("Telefone")
                    };

                    lista.Add(cli);
                }
            }

            return lista;
        }
    }
}
