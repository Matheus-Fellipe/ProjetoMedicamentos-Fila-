using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMedicamento.Models;

namespace ProjetoMedicamento.Controllers
{
    class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos() {
            this.listaMedicamentos = new List<Medicamento>();
        }

        public List<Medicamento> ListaMedicamentos { get { return this.listaMedicamentos; } }

        public void adicionar(Medicamento medicamento) {
            this.listaMedicamentos.Add(medicamento);
        }

        public bool deletar(Medicamento medicamento)
        {
            return this.listaMedicamentos.Remove(medicamento);
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(item => item.Equals(medicamento));
        }
    }
}
