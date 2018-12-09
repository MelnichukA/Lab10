using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab8Lib;

namespace Lab10
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gvPass.AutoGenerateColumns = false;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Имя";
            gvPass.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Country";
            column.Name = "Страна";
            column.Width = 50;
            gvPass.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Region";
            column.Name = "Город";
            gvPass.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Place";
            column.Name = "Место выдачи";
            gvPass.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Prop";
            column.Name = "Место прописки";
            gvPass.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PassSer";
            column.Name = "Серия паспорта";
            gvPass.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "PassNum";
            column.Name = "Номер паспорта";
            gvPass.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "HasMarried";
            column.Name = "Женат(Замужем)";
            gvPass.Columns.Add(column);

            bindSrcPass.Add(new Pass("Анна", "Україна", "Николаев", "Центральный район", "Пер.Первомайский 75", 550033, "ЕР", true));
            EventArgs args = new EventArgs();
            OnResize(args);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pass pass = new Pass();
            PassForm ft = new PassForm(pass);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcPass.Add(pass);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Pass pass = (Pass)bindSrcPass.List[bindSrcPass.Position];
            PassForm ft = new PassForm(pass);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcPass.List[bindSrcPass.Position] = pass;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcPass.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcPass.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
