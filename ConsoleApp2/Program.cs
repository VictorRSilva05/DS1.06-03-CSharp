using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar um leitor");
            Console.WriteLine("2. Incluir livros para um leitor");
            Console.WriteLine("3. Remover um livro perdido de um leitor");
            Console.WriteLine("4. Doar um livro para outro leitor");
            Console.WriteLine("5. Listar todos os leitores e seus livros");
            Console.WriteLine("6. Listar um leitor específico e seus livros");
            Console.WriteLine("7. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        biblioteca.CadastrarLeitor();
                        break;
                    case 2:
                        biblioteca.IncluirLivrosParaLeitor();
                        break;
                    case 3:
                        biblioteca.RemoverLivroPerdidoDeLeitor();
                        break;
                    case 4:
                        biblioteca.DoarLivroParaLeitor();
                        break;
                    case 5:
                        biblioteca.ListarTodosOsLeitoresELivros();
                        break;
                    case 6:
                        biblioteca.ListarLeitorEspecificoELivros();
                        break;
                    case 7:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
            }
        }
    }
}

class Leitor
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public List<string> Livros { get; set; }

    public Leitor(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
        Livros = new List<string>();
    }
}

class Biblioteca
{
    private List<Leitor> leitores = new List<Leitor>();

    public void CadastrarLeitor()
    {
        Console.Write("Digite o nome do leitor: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o CPF do leitor: ");
        string cpf = Console.ReadLine();

        if (leitores.Exists(l => l.Cpf == cpf))
        {
            Console.WriteLine("CPF já cadastrado. Não é possível cadastrar o mesmo CPF novamente.");
            return;
        }

        Leitor novoLeitor = new Leitor(nome, cpf);
        leitores.Add(novoLeitor);
        Console.WriteLine("Leitor cadastrado com sucesso!");
    }

    public void IncluirLivrosParaLeitor()
    {
        Console.Write("Digite o CPF do leitor: ");
        string cpf = Console.ReadLine();

        Leitor leitor = leitores.Find(l => l.Cpf == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado.");
            return;
        }

        Console.Write("Digite o título do livro a ser incluído: ");
        string livro = Console.ReadLine();
        leitor.Livros.Add(livro);
        Console.WriteLine("Livro incluído com sucesso para o leitor.");
    }

    public void RemoverLivroPerdidoDeLeitor()
    {
        Console.Write("Digite o CPF do leitor: ");
        string cpf = Console.ReadLine();

        Leitor leitor = leitores.Find(l => l.Cpf == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado.");
            return;
        }

        Console.Write("Digite o título do livro perdido: ");
        string livroPerdido = Console.ReadLine();
        if (leitor.Livros.Remove(livroPerdido))
        {
            Console.WriteLine("Livro removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Livro não encontrado na lista do leitor.");
        }
    }

    public void DoarLivroParaLeitor()
    {
        Console.Write("Digite o CPF do leitor que receberá o livro: ");
        string cpf = Console.ReadLine();

        Leitor leitor = leitores.Find(l => l.Cpf == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado.");
            return;
        }

        Console.Write("Digite o título do livro a ser doado: ");
        string livroDoado = Console.ReadLine();
        leitor.Livros.Add(livroDoado);
        Console.WriteLine("Livro doado com sucesso para o leitor.");
    }

    public void ListarTodosOsLeitoresELivros()
    {
        Console.WriteLine("Lista de todos os leitores e seus respectivos livros:");
        foreach (var leitor in leitores)
        {
            Console.WriteLine($"Nome: {leitor.Nome}, CPF: {leitor.Cpf}");
            Console.WriteLine("Livros:");
            foreach (var livro in leitor.Livros)
            {
                Console.WriteLine($"- {livro}");
            }
            Console.WriteLine();
        }
    }

    public void ListarLeitorEspecificoELivros()
    {
        Console.Write("Digite o CPF do leitor: ");
        string cpf = Console.ReadLine();

        Leitor leitor = leitores.Find(l => l.Cpf == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado.");
            return;
        }

        Console.WriteLine($"Nome: {leitor.Nome}, CPF: {leitor.Cpf}");
        Console.WriteLine("Livros:");
        foreach (var livro in leitor.Livros)
        {
            Console.WriteLine($"- {livro}");
        }
    }
}
