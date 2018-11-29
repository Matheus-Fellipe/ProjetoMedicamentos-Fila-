using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamento.Models
{
    class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public Lote() {

        }

        public Lote(int id, int qtde, DateTime venc) {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }

        public int Qtde { get { return this.qtde; } set { this.qtde = value; } }

        public override string ToString()
        {
            return id + "-" + qtde + "-" + venc;
        }
    }
}
