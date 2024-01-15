using ProductoAppMAUI.Models;
using ProductoAppMAUI.Service;
using ProductoAppMAUI.ViewModels;
using System.Windows.Input;

namespace ProductoAppMAUI;

public partial class Register : ContentPage
{

    public Register()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }

}