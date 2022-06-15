using Revisao.Classes;
using Revisao.Enums;
using static System.Console;


namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        AdicionarNota(alunos, ref indiceAluno);
                        break;
                    case "2":
                        MostrarAlunos(alunos);
                        break;
                    case "3":
                        CalcularConceito(alunos);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void CalcularConceito(Aluno[] alunos)
        {
            decimal notaTotal = 0;
            decimal nrAlunos = 0;
            Conceito conceitoGeral;

            for (int i = 0; i < alunos.Length; i++)
            {
                if (!string.IsNullOrEmpty(alunos[i].Nome))
                {
                    notaTotal += alunos[i].Nota;
                    nrAlunos++;
                }
            }

            decimal mediaGeral = notaTotal / nrAlunos;

            switch (mediaGeral)
            {
                case < 2:
                    conceitoGeral = Conceito.E;
                    break;
                case < 4:
                    conceitoGeral = Conceito.D;
                    break;
                case < 6:
                    conceitoGeral = Conceito.C;
                    break;
                case < 8:
                    conceitoGeral = Conceito.B;
                    break;
                default:
                    conceitoGeral = Conceito.A;
                    break;
            }

            Console.WriteLine($"Media Geral: {mediaGeral} - CONCEITO:{conceitoGeral}");
        }

        private static void MostrarAlunos(Aluno[] alunos)
        {
            foreach (Aluno a in alunos)
            {
                if (!string.IsNullOrEmpty(a.Nome))
                    Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");
            }
        }

        private static void AdicionarNota(Aluno[] alunos, ref int indiceAluno)
        {
            Console.WriteLine("Informe o nome do aluno:");

            var aluno = new Aluno
            {
                Nome = Console.ReadLine()
            };

            Console.WriteLine("Informe a nota do aluno:");

            if (!decimal.TryParse(Console.ReadLine(), out decimal nota))
                throw new ArgumentException(" Valor da nota deve ser decimal");

            aluno.Nota = nota;

            alunos[indiceAluno] = aluno;
            indiceAluno++;
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar Alunos");
            Console.WriteLine("3- Calcular Média Geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}