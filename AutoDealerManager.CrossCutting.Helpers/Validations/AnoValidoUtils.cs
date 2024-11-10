using System;

namespace AutoDealerManager.CrossCutting.Helpers.Validations
{
    public static class AnoValidoUtils
    {
        public static bool ValidarAno(int ano)
        {
            int anoAtual = DateTime.Now.Year;
            return ano <= anoAtual && ano >= 1800;
        }
    }
}
