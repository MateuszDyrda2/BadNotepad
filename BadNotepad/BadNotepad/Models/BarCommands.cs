using BadNotepad.Commands;
using System.Windows;
using System.Windows.Input;

namespace BadNotepad.Models
{
    public class BarCommands
    {
        private FileSystem m_fileSystem;
        public FileSystem FileSystem { get => m_fileSystem; private set => m_fileSystem = value; }
        private ICommand m_closeCommand;
        private ICommand m_minimizeCommand;
        private ICommand m_restoreCommand;
        private ICommand m_saveCommand;
        private ICommand m_saveAsCommand;
        private ICommand m_openCommand;
        private ICommand m_newCommand;
        public ICommand CloseCommand {
            get {
                if(m_closeCommand == null)
                {
                    m_closeCommand = new RelayCommand(param => this.CloseWindow());
                }
                return m_closeCommand;
            }
        }
        public ICommand MinimizeCommand {
            get {
                if(m_minimizeCommand == null)
                {
                    m_minimizeCommand = new RelayCommand(param => this.MinimizeWindow());
                }
                return m_minimizeCommand;
            }
        }
        public ICommand RestoreCommand {
            get {
                if(m_restoreCommand == null)
                {
                    m_restoreCommand = new RelayCommand(param => this.RestoreWindow());
                }
                return m_restoreCommand;
            }
        }

        public ICommand SaveCommand {
            get {
                if(m_saveCommand == null)
                {
                    m_saveCommand = new RelayCommand(param => this.FileSystem.SaveFile());
                }
                return m_saveCommand;
            }
        }
        public ICommand SaveAsCommand {
            get {
                if(m_saveAsCommand == null)
                {
                    m_saveAsCommand = new RelayCommand(param => this.FileSystem.SaveFileAs());
                }
                return m_saveAsCommand;
            }
        }
        public ICommand OpenCommand { 
            get {
                if(m_openCommand == null)
                {
                    m_openCommand = new RelayCommand(param => this.FileSystem.OpenFile());
                }
                return m_openCommand;
            }
        }
        public ICommand NewCommand {
            get {
                if(m_newCommand == null)
                {
                    m_newCommand = new RelayCommand(param => this.FileSystem.NewFile());
                }
                return m_newCommand;
            }
        }

        public BarCommands(FileSystem fileSystem) 
        {
            FileSystem = fileSystem;
        }

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
