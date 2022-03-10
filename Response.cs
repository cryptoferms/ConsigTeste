using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsigTeste
{

    public class Request
    {
        public string usuarioWebservice { get; set; } = "INTEGRACAO@SOMAFINANCEIRA";
        public string senhaWebservice { get; set; } = "INTEGRACAO";
        public string cnpjOrgao { get; set; } = "94436474000124";
        public string cpfColaborador { get; set; } = "72090219220";
    }

    public class Response
    {
        public List<Margen> margens { get; set; }
    }

    public class Margen
    {
        public string identificadorUnicoMargem { get; set; }
        public string cnpjOrgao { get; set; }
        public string matriculaColaborador { get; set; }
        public double margemDisponivel { get; set; }
        public int diaCorte { get; set; }
        public int folhaVigente { get; set; }
        public bool bloqueado { get; set; }
        public string motivoBloqueio { get; set; }
        public string vinculo { get; set; }
        public string tipoMargem { get; set; }
        public string dataAdmissao { get; set; }
        public object dataFinalVinculo { get; set; }
        public double margemTotal { get; set; }
        public string dataNascimento { get; set; }
        public string nomeColaborador { get; set; }
        public string situacaoFuncional { get; set; }
        public int codigoIntegracaoFolha { get; set; }
    }
}
