using BadNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BadNotepad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DarkWindowStyleViewModel darkWindow;
        public MainWindowViewModel()
        {
            darkWindow = new DarkWindowStyleViewModel();
        }

        public DarkWindowStyleViewModel DarkWindow { get => darkWindow;  }
    }
}
