using BadNotepad.ViewModel;
using BadNotepad.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using BadNotepad.Commands;
using System.Windows.Controls;

namespace BadNotepad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand m_deleteDoc;
        private BarCommands darkWindow;
        private ObservableCollection<Document> documents;
        private Document m_currentDocument;
        private FileSystem m_fileSystem;
        private Format m_format;
        private LineNumbers m_lineNumbers;
        public MainWindowViewModel(CustomTextBox customTextBox)
        {
            m_fileSystem = new FileSystem(this);
            darkWindow = new BarCommands(m_fileSystem);
            documents = new ObservableCollection<Document>();
            m_format = new Format(new System.Windows.Media.FontFamily("Consolas"), 14);
            m_lineNumbers = new LineNumbers(customTextBox);
            documents.CollectionChanged += DocumentChanged;
            FileSystem.OpenStartFile();
        }

        private void DocumentChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                CurrentDocument = Documents[Documents.Count - 1];
            }
            else if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(var x in e.NewItems)
                {

                }
            }
        }
        
        public Format Format { get => m_format; }
        public BarCommands DarkWindow { get => darkWindow; }
        public ObservableCollection<Document> Documents { get => documents; }
        public FileSystem FileSystem { get => m_fileSystem; }
        public Document CurrentDocument { 
            get => m_currentDocument;
            set {
                m_currentDocument = value;
                OnPropertyChanged(nameof(CurrentDocument));
            }
        }

        public ICommand DeleteDoc {
            get {
                if (m_deleteDoc == null)
                {
                    m_deleteDoc = new RelayCommand(ExecuteDeleteDoc);
                }
                return m_deleteDoc;
            } 
        }

        public LineNumbers LineNumbers { get => m_lineNumbers; }

        private void ExecuteDeleteDoc(object obj)
        {
            RemoveDocument(obj as Document);
        }
        private void RemoveDocument(Document doc)
        {
            if (Documents.Contains(doc))
            {
                Documents.Remove(doc);
            }
        }
        public void TryClosing(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
            {
                var button = sender as RadioButton;
                var document = button.DataContext as Document;
                if (document != null)
                {
                    RemoveDocument(document);
                }
            }
        }


        public void SetMainDocument(Document document)
        {
            CurrentDocument = document;
        }
        public void AddNewDocument(Document document)
        {
            Documents.Add(document);
        }

        public void ChangeDocument(object document)
        {
            CurrentDocument = document as Document;
        }
    }
}
