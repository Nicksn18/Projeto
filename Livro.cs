public class Livro
{
    // Propriedade para armazenar o título do livro
    public string? Titulo { get; set; }

    // Propriedade para armazenar o nome do autor
    public string? Autor { get; set; }

    // Propriedade para armazenar o código ISBN do livro
    public string? Isbn { get; set; }

    // Propriedade para saber se o livro está disponível para empréstimo
    public bool Disponivel { get; set; } = true;

   
    public Livro() { }

    // Construtor que recebe título, autor  ao criar o livro
    public Livro(string titulo, string autor, string isbn)
    {
        Titulo = titulo;
        Autor = autor;
        Disponivel = true;
    }
}