using Microsoft.Extensions.DependencyInjection;

namespace MotorcycleStore.UI.WinForms.Services;

public class NavigationService
{
    private readonly IServiceProvider _provider;

    public NavigationService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public void NavigateTo<TForm>(Form currentForm) where TForm : Form
    {
      
        currentForm?.Hide();

        
        var newForm = _provider.GetRequiredService<TForm>();
        newForm.Show();
    }
}


