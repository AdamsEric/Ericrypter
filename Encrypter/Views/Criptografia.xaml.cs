namespace Encrypter
{
    using Ericrypter.ViewModels;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Criptografia : Window
    {
        public Criptografia()
        {
            InitializeComponent();
            DataContext = new CriptografiaViewModel();
        }
    }
}
