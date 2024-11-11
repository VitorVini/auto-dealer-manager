using System.Linq;
using System.Web.Mvc;

namespace AutoDealerManager.CrossCutting.Helpers.Validations
{
    public class ValidationUtils
    {
        public static string ObterErroValidacaoViewModel(ModelStateDictionary ModelState)
        {
            
            return string.Join(",", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
        }
    }
}
