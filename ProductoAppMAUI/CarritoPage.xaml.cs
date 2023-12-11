using ProductoAppMAUI.Service;

namespace ProductoAppMAUI;

public partial class CarritoPage : ContentPage
{
    private readonly APIService _APIService;
    public CarritoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    private void OnClickComprar(object sender, EventArgs e)
    {

    }

    private void TappedDeleteFromCart(object sender, TappedEventArgs e)
    {

    }
}