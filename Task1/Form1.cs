using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Library _lib;

        public Form1()
        {
            InitializeComponent();
            _lib = new Library();
            textBox1.Validating += TextBox1_Validating;
            textBox2.Validating += TextBox2_Validating;
            textBox3.Validating += TextBox3_Validating;
            textBox4.Validating += TextBox4_Validating;
        }

        private void TextBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider4.SetError(textBox4, "Вы ничего не ввели");
                return;
            }

            errorProvider4.Clear();
        }

        private void TextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out int N))
            {
                errorProvider3.SetError(textBox3, "Неверно введено число");
                return;
            }
            errorProvider3.Clear();
        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider2.SetError(textBox2, "Вы ничего не ввели");
                return;
            }

            errorProvider2.Clear();
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Вы ничего не ввели");
                return;
            }

            errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && int.TryParse(textBox3.Text, out int year) && year > 1700 && year <= DateTime.Now.Year)
            {
                _lib.AddBook(new Book { Author = textBox2.Text, Title = textBox1.Text, Year = year });
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();

            foreach (Book book in _lib.GetBooks())
            {
                listBox1.Items.Add(book.ToString());
            }
        }

        private void UpdateListBoxAfterSearch(List<Book> aaa)
        {
            listBox1.Items.Clear();

            foreach (Book book in aaa)
            {
                listBox1.Items.Add(book.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    if (radioButton1.Checked)
                    {
                       UpdateListBoxAfterSearch(_lib.SearchByAuthor(textBox4.Text));
                    }
                    else if (radioButton2.Checked)
                    {
                        UpdateListBoxAfterSearch(_lib.SearchByTitle(textBox4.Text));
                    }
                    else if (radioButton3.Checked)
                    {
                        UpdateListBoxAfterSearch(_lib.SearchByYear(int.Parse(textBox4.Text)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }   
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            UpdateListBox();
        }
    }
}
