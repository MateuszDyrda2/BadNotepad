using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BadNotepad.Models
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
        }

        private void InsertTab(ref int pos)
        {
            string tab = new string(' ', 4);
            Text = Text.Insert(pos, tab);
            pos += 4;
        }

        private void HandleBrackets(Key key, KeyEventArgs e)
        {
            if((Keyboard.Modifiers & ModifierKeys.Shift) != 0) //Shift is pressed
            {
                switch(key)
                {
                    case Key.D0: {
                            int caret = CaretIndex;
                            if (caret != 0 && caret < Text.Length && Text.ElementAt(caret) == ')')
                            {
                                CaretIndex += 1;
                                e.Handled = true;
                            }
                        }break;
                    case Key.D9: {
                            int caret = CaretIndex;
                            Text = Text.Insert(CaretIndex, "()");
                            CaretIndex = caret + 1;
                            e.Handled = true;
                        }break;
                    case Key.OemOpenBrackets: {
                            int caret = CaretIndex;
                            string insert = string.Empty;
                            if (GetLineLength(GetLineIndexFromCharacterIndex(caret)) != 0)
                            {
                                caret += 2;
                                insert = System.Environment.NewLine;
                            }
                            Text = Text.Insert(CaretIndex, insert + "{ }");
                            CaretIndex = caret + 2;
                            e.Handled = true;
                        }break;
                }
            }
            else if(key == Key.OemOpenBrackets)
            {
                int caret = CaretIndex;
                Text = Text.Insert(CaretIndex, "[]");
                CaretIndex = caret + 2;
                e.Handled = true;
            }
        }
        void SaveDocument()
        {
            Document doc = DataContext as Document;
            if(doc != null)
            {
                FileSystem.SaveDocument(doc);
            }
        }
        void SaveDocumentAs()
        {
            Document doc = DataContext as Document;
            if(doc != null)
            {
                FileSystem.SaveDocumentAs(doc);
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            var key = e.Key == Key.System ? e.SystemKey : e.Key;
            bool ctrl = (Keyboard.Modifiers & ModifierKeys.Control) != 0;
            bool alt = (Keyboard.Modifiers & ModifierKeys.Alt) != 0;
            bool shift = (Keyboard.Modifiers & ModifierKeys.Shift) != 0;

            if (key == Key.Tab)
            {
                int pos = CaretIndex;
                InsertTab(ref pos);
                CaretIndex = pos;
                e.Handled = true;
            }
            HandleBrackets(key, e);
            if (ctrl)
            {
                switch (key)
                {
                    case Key.Enter: {
                            int linePos = GetLineIndexFromCharacterIndex(CaretIndex);
                            int charPos = GetCharacterIndexFromLineIndex(linePos);
                            Text = Text.Insert(charPos, System.Environment.NewLine);
                            CaretIndex = charPos;
                            e.Handled = true;
                        }break;
                    case Key.X: {
                            if (string.IsNullOrEmpty(SelectedText))
                            {
                                int caretPos = base.CaretIndex;
                                int linePos = GetLineIndexFromCharacterIndex(caretPos);
                                int charPos = GetCharacterIndexFromLineIndex(linePos);
                                Select(charPos, GetLineLength(linePos));
                            }
                            Cut();
                            e.Handled = true;
                        } break;
                    case Key.D: {
                            int caretPos = base.CaretIndex;
                            int linePos = GetLineIndexFromCharacterIndex(caretPos);
                            int charPos = GetCharacterIndexFromLineIndex(linePos);
                            int len = GetLineLength(linePos);
                            if(len == 0)
                            {
                                AppendText(System.Environment.NewLine);
                            }
                            else
                            {
                                if(linePos == LineCount - 1)
                                {
                                    AppendText(System.Environment.NewLine);
                                    len += System.Environment.NewLine.Length;
                                }
                                Select(charPos, len);
                                Copy();
                                CaretIndex = charPos + len;
                                Paste();
                                CaretIndex = charPos + 2 * len - 2;
                            }
                        e.Handled = true;
                        } break;
                    case Key.S: {
                            if (shift)
                            {
                                SaveDocumentAs();
                            }
                            else
                            {
                                SaveDocument();            
                            }
                            e.Handled = true;
                        } break;
                    case Key.C: {
                            if (string.IsNullOrEmpty(SelectedText))
                            {
                                int caretPos = base.CaretIndex;
                                int linePos = GetLineIndexFromCharacterIndex(caretPos);
                                int charPos = GetCharacterIndexFromLineIndex(linePos);
                                Select(charPos, GetLineLength(linePos));
                            }
                            Copy();
                            e.Handled = true;
                        }break;
                }
            }
        }
    }
}
