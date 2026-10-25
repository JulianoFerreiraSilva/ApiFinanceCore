namespace ControleFinanceiro.Application.Categorias.Query.PesquisarPorId
{
    public class PesquisaPorIdRespose
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool Ativa { get; set; }
    }
}
