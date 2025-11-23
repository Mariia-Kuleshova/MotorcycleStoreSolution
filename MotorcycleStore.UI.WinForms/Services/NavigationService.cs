using Microsoft.Extensions.DependencyInjection;

public class NavigationService
{
    private readonly IServiceProvider _provider;

    public NavigationService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public void NavigateTo<TForm>(Form currentForm) where TForm : Form
    {
        // Закриваємо поточну форму
        currentForm?.Hide();

        // Створюємо нову форму через DI
        var newForm = _provider.GetRequiredService<TForm>();
        newForm.Show();
    }
}


