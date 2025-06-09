public class Emprestimo
{
    public Livro Livro { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public Emprestimo(Livro livro)
    {
        Livro = livro;
        DataEmprestimo = DateTime.Now;
    }

    public void Devolver()
    {
        DataDevolucao = DateTime.Now;
        Livro.Disponivel = true;
    }
}