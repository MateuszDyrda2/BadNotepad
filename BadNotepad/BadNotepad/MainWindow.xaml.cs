using BadNotepad.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace BadNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void lb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            object lbi = ((sender as ListBox).SelectedItem as object);
            (DataContext as MainWindowViewModel).ChangeDocument(lbi);
        }
    }
}
