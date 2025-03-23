using MAUI_Calcolatrice.MVVM.ViewModels;

namespace MAUI_Calcolatrice.MVVM;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
		InitializeComponent();
		BindingContext = new CalculatorViewModel();
	}
}