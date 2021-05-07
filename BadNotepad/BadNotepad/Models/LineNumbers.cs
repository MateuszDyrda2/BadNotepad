using BadNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadNotepad.Models
{
    public class LineNumbers : ViewModelBase
    {
        private string m_text;
        private int m_len;
        private CustomTextBox m_textBox;
        public string Text {
            get => m_text;
            set {
                m_text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public LineNumbers(CustomTextBox customTextBox)
        {
            m_textBox = customTextBox;
            Populate();
        }
        private void Populate()
        {
            string temp = string.Empty;
            m_len = m_textBox.LineCount;
            for (int i = 0; i < m_len; i++)
            {
                temp += (( i + 1 ).ToString() + System.Environment.NewLine);
            }
            Text = temp;
        }
        public void Update()
        {
            if(m_textBox.LineCount != (m_len + 1))
            {
                while ((m_len + 1) < m_textBox.LineCount)
                {
                    ++m_len;
                    Text += ((m_len + 1).ToString() + System.Environment.NewLine);
                }
                if((m_len + 1) > m_textBox.LineCount)
                {
                    int i = 0;
                    int toStay;
                    m_len = toStay = m_textBox.LineCount;
                    for (; i < Text.Length && toStay > 0; ++i)
                    {
                        if(Text[i] == '\n')
                        {
                            --toStay;
                        }
                    }
                    Text = Text.Remove(i);
                    m_len--;

                }
            }
        }
    }
}
