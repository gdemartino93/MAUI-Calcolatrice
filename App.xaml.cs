using MAUI_Calcolatrice.MVVM;

namespace MAUI_Calcolatrice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CalculatorView();
        }
    }
}
