using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classe_e_validacao
{
    class Classe_e_Validacao
    {
        // prop é de propriedade
        // list_p é de lista de propriedades
        // clas é de classe

        private String prop, list_p, clas;

        public void setProp(String _prop) { prop = _prop; }
        public void setClas(String _clas) { clas = _clas; }
        public void setList_p(String _list_p) { list_p = _list_p; }

        public String getProp() { return prop; }
        public String getClas() { return clas; }
        public String getList_p() { return list_p; }


    }
}
