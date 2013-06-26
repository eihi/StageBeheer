using System.Windows;
using System.Windows.Controls;

namespace StageManager.Views
{
    /// <summary>
    /// Interaction logic for DocentenView.xaml
    /// </summary>
    public partial class DocentenOverzichtView : UserControl
    {
        public DocentenOverzichtView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BringIntoView();
        }
    }
}
