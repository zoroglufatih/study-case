
using StudyCase.Application.ViewModels;

namespace StudyCase.API
{
    public static class BaseUrl
    {
        public static string ChangedUrl(UrlViewModel model)
        {
            if (model.Delay > 0)
            {
                return "https://run.mocky.io/v3/" + model.Id + "?mocky-delay=" + model.Delay + "s";
            }
            return "https://run.mocky.io/v3/" + model.Id;
        }
    }
}
