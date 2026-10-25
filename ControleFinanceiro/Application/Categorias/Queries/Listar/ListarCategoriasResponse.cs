namespace ControleFinanceiro.Application.Categorias.Query.Listar
{
    public class ListarCategoriasResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }

        public bool Ativa { get; set; }
    }
}
