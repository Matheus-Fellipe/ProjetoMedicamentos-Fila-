using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMedicamento.Controllers;
using ProjetoMedicamento.Models;
using System.Globalization;

namespace ProjetoMedicamento
{
    class Program
    {
        public static Medicamentos medicamentos = new Medicamentos();
        static void Main(string[] args)
        {
            string op = " ";
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("0. Finalizar processo\n" +
                                "1. Cadastrar medicamento\n" +
                                "2. Consultar medicamento (sintético: informar dados)\n" +
                                "3. Consultar medicamento (analítico: informar dados + lotes)\n" +
                                "4. Comprar medicamento (cadastrar lote)\n" +
                                "5. Vender medicamento (abater do lote mais antigo)\n" +
                                "6. Listar medicamentos (informando dados sintéticos)\n");
                Console.Write("Digite uma opção: ");
                op = Console.ReadLine();
                try
                {
                    switch (op)
                    {
                        case "1": cadMedic(); break;
                        case "2": consMedic(); break;
                        case "3": consMedicAnalitico(); break;
                        case "4": compMedic(); break;
                        case "5": vendMedic(); break;
                        case "6": listMedic(); break;
                    }
                }
                catch (Exception e) {
                    Console.Write("Ocorreu um erro: " + e.Message);
                    Console.ReadKey();
                }
            }
        }

        static void cadMedic() {
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o laboratório: ");
            string lab = Console.ReadLine();
            medicamentos.adicionar(new Medicamento(id, nome, lab));
        }

        static void consMedic()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Medicamento medic = medicamentos.pesquisar(new Medicamento(id, "", ""));
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(medic.ToString());
            Console.ReadKey();
        }

        static void consMedicAnalitico()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Medicamento medic = medicamentos.pesquisar(new Medicamento(id, "", ""));
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(medic.ToString());
            Console.WriteLine("\nLOTES:");
            foreach(Lote l in medic.Lotes.ToList()){
                Console.WriteLine(l.ToString());
            }
            Console.ReadKey();
        }

        static void compMedic()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Medicamento medic = medicamentos.pesquisar(new Medicamento(id, "", ""));
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Digite o ID do lote: ");
            int idlote = Int32.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade: ");
            int qtde = Int32.Parse(Console.ReadLine());
            Console.Write("Digite a data de vencimento(yyyy-MM-dd): ");
            DateTime venc = DateTime.Parse(Console.ReadLine());
            medic.comprar(new Lote(idlote, qtde, venc));
            Console.WriteLine("Cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void vendMedic()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Medicamento medic = medicamentos.pesquisar(new Medicamento(id, "", ""));
            Console.Write("Digite o a quantidade: ");
            int qtde = Int32.Parse(Console.ReadLine());
            if(medic.vender(qtde)) Console.WriteLine("vendido com sucesso!");
            else Console.WriteLine("Não foi possível vender.");
            Console.ReadKey();
        }

        static void listMedic() {
            foreach (Medicamento m in medicamentos.ListaMedicamentos)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(m.ToString());
            }
            Console.ReadKey();
        }
    }
}
