using System.Threading.Tasks;
using OneAppHNI.Configuration.Dto;

namespace OneAppHNI.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
        Task ChangeCauHinh(CauHinhDto input);
    }
}
