using BadNotepad.Commands;
using BadNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BadNotepad.ViewModels
{
    public class DarkWindowStyleViewModel : ViewModelBase
    {
        private ICommand m_closeCommand;
        private ICommand m_minimizeCommand;
        private ICommand m_restoreCommand;

        public ICommand CloseCommand
        {
            get
            {
                if(m_closeCommand == null)
                {
                    m_closeCommand = new RelayCommand(param => this.CloseWindow());
                }
                return m_closeCommand;
            }
        }
        public ICommand MinimizeCommand
        {
            get
            {
                if(m_minimizeCommand == null)
                {
                    m_minimizeCommand = new RelayCommand(param => this.MinimizeWindow());
                }
                return m_minimizeCommand;
            }
        }
        public ICommand RestoreCommand
        {
            get
            {
                if(m_restoreCommand == null)
                {
                    m_restoreCommand = new RelayCommand(param => this.RestoreWindow());
                }
                return m_restoreCommand;
            }
        }


        public DarkWindowStyleViewModel() {}

        public void CloseWindow()
        {
            var window = Application.Current.MainWindow;
            window.Close();
        }
        public void MinimizeWindow()
        {
            var window = Application.Current.MainWindow;
            window.WindowState = System.Windows.WindowState.Minimized;
        }
        public void RestoreWindow()
        {
            var window = Application.Current.MainWindow;
            if (window.WindowState == System.Windows.WindowState.Normal)
                window.WindowState = System.Windows.WindowState.Maximized;
            else
                window.WindowState = System.Windows.WindowState.Normal;
        }
    }
}
