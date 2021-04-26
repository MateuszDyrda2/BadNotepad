using BadNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using BadNotepad.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BadNotepad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private BarCommands darkWindow;
        private ObservableCollection<Document> documents;
        private Document m_currentDocument;
        private FileSystem m_fileSystem;
        public MainWindowViewModel()
        {
            m_fileSystem = new FileSystem(this);
            darkWindow = new BarCommands(m_fileSystem);
            documents = new ObservableCollection<Document>();
            documents.CollectionChanged += DocumentChanged;
        }

        private void DocumentChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach(var x in e.OldItems)
                {

                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(var x in e.NewItems)
                {

                }
            }
        }

        public BarCommands DarkWindow { get => darkWindow;  }
        public ObservableCollection<Document> Documents { get => documents; }
        public FileSystem FileSystem { get => m_fileSystem; }
        public Document CurrentDocument { 
            get => m_currentDocument;
            set {
                m_currentDocument = value;
                OnPropertyChanged(nameof(CurrentDocument));
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

    }
}
