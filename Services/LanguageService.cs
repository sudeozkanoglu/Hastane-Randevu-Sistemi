using Microsoft.Extensions.Localization;
using System.Reflection;

namespace webProjeSon.Services
{
    public class SharedResource
    {

    }
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;
        public LanguageService(IStringLocalizerFactory localizer)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = localizer.Create(nameof(SharedResource), assemblyName.Name);
        }
        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}
