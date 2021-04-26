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
            document.Filename = string.Empty;
            document.Path = string.Empty;
            mainVM.AddNewDocument(document);
            mainVM.SetMainDocument(document);
        }
        public void SaveFile()
        {
            File.WriteAllText(mainVM.CurrentDocument.Path, mainVM.CurrentDocument.Content);
            mainVM.CurrentDocument.IsTouched = false;
        }
        public void SaveFileAs()
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Text File (*.txt)|*.txt";
            if(saveFile.ShowDialog() == true)
            {
                mainVM.CurrentDocument.Filename = saveFile.SafeFileName;
                mainVM.CurrentDocument.Path = saveFile.FileName;
                File.WriteAllText(mainVM.CurrentDocument.Path, mainVM.CurrentDocument.Content);
                mainVM.CurrentDocument.IsTouched = false;
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

    }
}
