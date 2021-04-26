using BadNotepad.ViewModel;

namespace BadNotepad.Models
{
    public class Document : ViewModelBase
    {
        private string m_path;

        public Document(string path, string filename, string content)
        {
            m_path = path;
            m_filename = filename;
            m_content = content;
            m_isTouched = false;
        }
        public Document(string path, string filename)
        {
            m_path = path;
            m_filename = filename;
            m_isTouched = false;
        }

        public Document()
        {
            m_isTouched = true;
        }

        private string m_filename;
        private string m_content;
        private bool m_isTouched;

        public string Path { 
            get => m_path;
            set {
                m_path = value;
                OnPropertyChanged(nameof(Path));
            }
        }
        public string Filename { 
            get => m_filename;
            set {
                m_filename = value;
                OnPropertyChanged(nameof(Filename));
            }
        }
        public string Content { 
            get => m_content;
            set {
                m_content = value;
                OnPropertyChanged(nameof(Content));
                IsTouched = true;
            } 
        }
        public bool IsNew { get => string.IsNullOrEmpty(Path) || string.IsNullOrEmpty(Filename); }
        public bool IsTouched {
            get => m_isTouched;
            set { 
                m_isTouched = value;
                OnPropertyChanged(nameof(IsTouched));
            }
        }
    }
}
