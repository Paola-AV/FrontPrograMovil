namespace FrontEndMaui;

public partial class InicioCliente : ContentPage
{
	public InicioCliente()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new FormularioPeticion());
    }
}