using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classe_e_validacao
{
    class Classe_e_ValidacaoBLL
    {
        public static void validaprop(Classe_e_Validacao classe_e_validacao)
        {
            Erro.setErro(false);

            if (classe_e_validacao.getProp().Length == 0)
            {
                Erro.setErro("Favor preencher o campo de Propriedades.");
                return;
            }

        }

        public static void validalist_p(Classe_e_Validacao classe_e_validacao)
        {
            Erro.setErro(false);

            if (float.Parse(classe_e_validacao.getList_p())<=0)
            {
                Erro.setErro("Favor adicionar alguma propriedade.");
                return;
            }
        }

        public static void validaclas(Classe_e_Validacao classe_e_validacao)
        {
            Erro.setErro(false);

            if (classe_e_validacao.getClas().Length == 0)
            {
                Erro.setErro("Favor preencher o campo de Classe.");
                return;
            }

        }
    }
}
