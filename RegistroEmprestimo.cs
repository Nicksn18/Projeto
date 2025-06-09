// Struct representando o registro de datas de empréstimo e devolução
public struct RegistroEmprestimo
{
    public DateTime DataEmprestimo;
    public DateTime? DataDevolucao; // Pode ser nula caso o livro ainda não tenha sido devolvido
}