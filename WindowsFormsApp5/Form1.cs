using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // private ListBox listBoxTasks = new ListBox();

        // Обработчик события нажатия на кнопку "Добавить"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string task = textBoxTask.Text.Trim();
            if (!string.IsNullOrEmpty(task))
            {
                listBoxTasks.Items.Add(task);
                textBoxTask.Clear();
            }
        }

        // Обработчик события нажатия на кнопку "Удалить"
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxTasks.SelectedIndex;
            if (selectedIndex >= 0)
            {
                listBoxTasks.Items.RemoveAt(selectedIndex);
            }
        }

        // Обработчик события нажатия на кнопку "Редактировать"
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxTasks.SelectedIndex;
            if (selectedIndex >= 0)
            {
                string editedTask = ShowEditDialog(listBoxTasks.SelectedItem.ToString());
                if (!string.IsNullOrEmpty(editedTask))
                {
                    listBoxTasks.Items[selectedIndex] = editedTask;
                }
            }
        }

        // Метод для отображения диалогового окна редактирования задачи
        private string ShowEditDialog(string currentTask)
        {
            using (Form editForm = new Form())
            {
                editForm.Text = "Редактирование задачи";
                editForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                editForm.StartPosition = FormStartPosition.CenterScreen;

                TextBox textBoxEdit = new TextBox();
                textBoxEdit.Text = currentTask;
                textBoxEdit.Dock = DockStyle.Fill;

                Button buttonSave = new Button();
                buttonSave.Text = "Сохранить";
                buttonSave.DialogResult = DialogResult.OK;

                editForm.Controls.Add(textBoxEdit);
                editForm.Controls.Add(buttonSave);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    return textBoxEdit.Text.Trim();
                }
                else
                {
                    return currentTask;
                }
            }
        }
    }
}
