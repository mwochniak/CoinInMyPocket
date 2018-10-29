using Microsoft.Extensions.Configuration;

namespace TakeRecipeEasily.Infrastructure.Settings
{
    public static class SettingsExtensions
    {
        public static TSettingsModel GetSettings<TSettingsModel>(this IConfiguration configuration, string sectionName = "") where TSettingsModel : class, new()
        {
            if (string.IsNullOrEmpty(sectionName))
            {
                sectionName = typeof(TSettingsModel).Name.Replace("Settings", string.Empty).Replace("Config", string.Empty);
            }

            var model = new TSettingsModel();
            configuration.GetSection(sectionName).Bind(model);
            return model;
        }
    }
}
