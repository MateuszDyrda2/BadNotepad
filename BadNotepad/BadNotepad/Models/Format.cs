using BadNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BadNotepad.Models
{
    public class Format : ViewModelBase
    {
        int m_fontSize;
        FontFamily m_fontFamily;

        public Format(FontFamily fontFamily, int fontSize)
        {
            m_fontFamily = fontFamily;
            m_fontSize = fontSize;
        }

        public int FontSize { 
            get => m_fontSize; 
            set {
                m_fontSize = value;
                OnPropertyChanged(nameof(FontSize));
            } 
        }
        public FontFamily FontFamily { 
            get => m_fontFamily;
            set {
                m_fontFamily = value;
                OnPropertyChanged(nameof(FontFamily));
            } 

        }
    }
}
