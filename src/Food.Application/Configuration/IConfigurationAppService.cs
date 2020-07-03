using System.Threading.Tasks;
using Food.Configuration.Dto;

namespace Food.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
