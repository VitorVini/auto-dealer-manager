namespace AutoDealerManager.CrossCutting.Helpers.Validations
{
    public class PrecoValidoUtils
    {
        public static bool ValidarPreco(decimal preco)
        {
            return preco >= 0;
        }
    }
}
