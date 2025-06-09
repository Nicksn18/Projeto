using System;
using System.Collections.Generic;
using System.Linq;

public class Biblioteca
{
    // Listas para armazenar usuários e livros
    private List<Usuario> usuarios = new();
    private List<Livro> livros = new();

    public Biblioteca()
    {
        // Inicializa a biblioteca com livros padrão
        AdicionarLivrosPadrao();
    }

    private void AdicionarLivrosPadrao()
    {
        livros.AddRange(new List<Livro>
        {
            new Livro("1984", "George Orwell", "101"),
            new Livro("A Revolução dos Bichos", "George Orwell", "102"),
            new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "103"),
            new Livro("Harry Potter e a Pedra Filosofal", "J.K. Rowling", "104"),
            new Livro("O Código Da Vinci", "Dan Brown", "105"),
            new Livro("A Menina que Roubava Livros", "Markus Zusak", "106"),
            new Livro("O Pequeno Príncipe", "Antoine de Saint‑Exupéry", "107"),
            new Livro("O Alquimista", "Paulo Coelho", "108"),
            new Livro("Jogos Vorazes", "Suzanne Collins", "109"),
            new Livro("A Culpa é das Estrelas", "John Green", "110"),
            new Livro("O Nome do Vento", "Patrick Rothfuss", "111")
        });
    }

    // Cadastra um usuário se o ID não existir
    public void CadastrarUsuario(int id, string nome)
    {
        if (!usuarios.Any(u => u.Id == id))
        {
            usuarios.Add(new Usuario { Id = id, Nome = nome });
            Console.WriteLine("Usuário cadastrado com sucesso.");
        }
        else
        {
            Console.WriteLine("Usuário já existe.");
        }
    }

    // Cadastra um novo livro se o ISBN não estiver duplicado
    public void CadastrarLivro(string titulo, string autor, string isbn)
    {
        if (!livros.Any(l => l.Isbn == isbn))
        {
            livros.Add(new Livro(titulo, autor, isbn));
            Console.WriteLine("Livro cadastrado com sucesso.");
        }
        else
        {
            Console.WriteLine("Já existe um livro com este ISBN.");
        }
    }

    // Exibe todos os livros com título, autor, ISBN e status (disponível ou não)
    public void ListarLivros()
    {
        foreach (var livro in livros)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, ISBN: {livro.Isbn}, Disponível: {livro.Disponivel}");
        }
    }

    // Empresta um livro disponível para um usuário existente
    public void EmprestarLivro(int idUsuario, string isbn)
    {
        var usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);
        var livro = livros.FirstOrDefault(l => l.Isbn == isbn && l.Disponivel);

        if (usuario != null && livro != null)
        {
            livro.Disponivel = false;  // marca como emprestado
            usuario.Emprestimos.Add(new Emprestimo(livro));  // registra o empréstimo
            Console.WriteLine("Livro emprestado com sucesso.");
        }
        else
        {
            Console.WriteLine("Usuário não encontrado ou livro indisponível.");
        }
    }

    // Devolve um livro emprestado por um usuário
    public void DevolverLivro(int idUsuario, string isbn)
    {
        var usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);
        if (usuario != null)
        {
            // encontra empréstimo em aberto com o ISBN
            var emprestimo = usuario.Emprestimos
                .FirstOrDefault(e => e.Livro.Isbn == isbn && e.DataDevolucao == null);

            if (emprestimo != null)
            {
                emprestimo.Devolver();  // registra data de devolução
                Console.WriteLine("Livro devolvido com sucesso.");
            }
            else
            {
                Console.WriteLine("Empréstimo não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }
    }

    // Mostra relatório de todos os usuários e o status dos empréstimos
    public void ExibirRelatorios()
    {
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"\nUsuário: {usuario.Nome}");
            foreach (var emprestimo in usuario.Emprestimos)
            {
                var status = emprestimo.DataDevolucao.HasValue ? "Devolvido" : "Em aberto";
                Console.WriteLine($" - {emprestimo.Livro.Titulo} ({status})");
            }
        }
    }
}
