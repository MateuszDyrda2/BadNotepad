using BadNotepad.Commands;
using BadNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BadNotepad.ViewModels
{
    public class PopupWindowViewModel : ViewModelBase
    {
        private string m_text;
        private Action<object> m_b1Action;
        private Action<object> m_b2Action;
        private ICommand m_b1Command;
        private ICommand m_b2Command;
        public PopupWindowViewModel(string text, Action<object> b1Action, Action<object> b2Action)
        {
            Text = text;
            m_b1Action = b1Action;
            m_b2Action = b2Action;
            m_b1Command = new RelayCommand(m_b1Action);
            m_b2Command = new RelayCommand(m_b2Action);
        }
        public ICommand B1Command
        {
            get
            {
                if (m_b1Command == null)
                {
                    m_b1Command = new RelayCommand(m_b1Action);
                }
                return m_b1Command;
            }
        }

        public ICommand B2Command
        {
            get
            {
                if (m_b2Command == null)
                {
                    m_b2Command = new RelayCommand(m_b2Action);
                }
                return m_b2Command;
            }
        }

        public string Text { 
            get => m_text;
            set {
                m_text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

    }

  
}
