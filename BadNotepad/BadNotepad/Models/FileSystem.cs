using BadNotepad.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadNotepad.Models
{
    public class FileSystem
    {
        private MainWindowViewModel mainVM;
        public FileSystem(MainWindowViewModel viewModel)
        {
            mainVM = viewModel;
        }

        public void NewFile()
        {
            Document document = new Document();
            document.Content = string.Empty;
            document.Filename = "NewFile";
            document.Path = string.Empty;
            mainVM.AddNewDocument(document);
            mainVM.SetMainDocument(document);
        }
        public void SaveFile()
        {
            SaveDocument(mainVM.CurrentDocument);
        }
        public void SaveFileAs()
        {
            SaveDocumentAs(mainVM.CurrentDocument);
        }

        public static void SaveDocument(Document document)
        {
            if (string.IsNullOrEmpty(document.Path) || string.IsNullOrEmpty(document.Filename))
            {
                var saveFile = new SaveFileDialog();
                saveFile.Filter = "Text File (*.txt)|*.txt";
                if (saveFile.ShowDialog() == true)
                {
                    document.Filename = saveFile.SafeFileName;
                    document.Path = saveFile.FileName;
                }
            }
            else
            {
                File.WriteAllText(document.Path, document.Content);
                document.IsTouched = false;
            }
        }
        public static void SaveDocumentAs(Document document)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Text File (*.txt)|*.txt";
            if (saveFile.ShowDialog() == true)
            {
                document.Filename = saveFile.SafeFileName;
                document.Path = saveFile.FileName;
                File.WriteAllText(document.Path, document.Content);
                document.IsTouched = false;
            }
        }

        public void OpenFile()
        {
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Document document = new Document();
                document.Filename = openFile.SafeFileName;
                document.Path = openFile.FileName;
                document.Content = File.ReadAllText(openFile.FileName);
                mainVM.AddNewDocument(document);
                mainVM.SetMainDocument(document);
            }
        }
        public void OpenStartFile()
        {
            string path = "..//..//..//Resources//welcomeScreen.txt";
            string filename = "welcomeScreen.txt";
            Document document = new Document(path, filename);
            document.Content = File.ReadAllText(document.Path);
            mainVM.AddNewDocument(document);
            mainVM.SetMainDocument(document);
        }
    }
}
