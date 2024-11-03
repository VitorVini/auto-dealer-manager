using System.Collections.Generic;

namespace AutoDealerManager.Infra.CrossCutting.Identity.ViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<string> Providers { get; set; }
    }
}
