using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamento.Models
{
    class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public Medicamento()
        {
            this.lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            this.lotes = new Queue<Lote>();
        }

        public Queue<Lote> Lotes { get { return this.lotes; } }

        public int qtdeDisponivel()
        {
            int qtde = 0;
            this.lotes.ToList().ForEach(i => qtde += i.Qtde);
            return qtde;
        }

        public void comprar(Lote lote)
        {
            this.lotes.Enqueue(lote);
        }

        public bool vender(int qtde)
        {
            int q = qtde;

            if (qtdeDisponivel() < q || q < 0) return false;
            incio:
            foreach(Lote l in lotes) 
            {
                if (l.Qtde <= q)
                {
                    q -= l.Qtde;
                    lotes.Dequeue();
                    goto incio;
                }
                else if (l.Qtde > q)
                {
                    l.Qtde -= q;
                    q = 0;
                    return true;
                }
                else return true;
            }
            return true;
        }

        public override string ToString()
        {
            return id + "-" + nome + "-" + laboratorio + "-" + qtdeDisponivel();
        }

        public override bool Equals(object obj)
        {
            Medicamento medic = (Medicamento)obj;
            return this.id.Equals(medic.id);
        }
    }
}
