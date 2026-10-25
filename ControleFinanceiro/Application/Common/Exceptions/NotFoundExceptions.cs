namespace ControleFinanceiro.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entidade, object identificador)
            : base($"{entidade} com o identificador '{identificador}' não foi encontrado")
        {
        }
    }
}
