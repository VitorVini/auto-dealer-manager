using System;

namespace AutoDealerManager.CrossCutting.Helpers.Validations
{
    public class WebsiteValidoUtils
    {
        public static bool IsUrlValid(string url)
        {
            Uri uriResult;
            bool isValid = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                           && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return isValid;
        }
    }
}
