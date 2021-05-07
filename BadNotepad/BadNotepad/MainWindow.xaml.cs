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
            DataContext = new MainWindowViewModel(textBox);
        }

        private void lb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            object lbi = ((sender as ListBox).SelectedItem as object);
            (DataContext as MainWindowViewModel).ChangeDocument(lbi);
        }

        private void ToggleButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (DataContext as MainWindowViewModel).TryClosing(sender, e);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            (DataContext as MainWindowViewModel).LineNumbers.Update();
        }
    }
}
