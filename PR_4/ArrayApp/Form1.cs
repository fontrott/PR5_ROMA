using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ArrayApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void SortDelegate();
        public delegate void RangeDelegate();
        public void SortDel()
        {
            SortDelegate sortDelegate = Sort;
            sortDelegate();
        }
        public void RangeDel()
        {
            RangeDelegate rangeDelegate = Range;
            rangeDelegate();
        }
        public void Sort()
        {
            try
            {
                string input = txtArrayInput.Text;
                if (String.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Строка пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArrayInput.Clear();
                    txtRange.Clear();
                    txtSortedArray.Clear();
                }
                else
                {
                    int[] array = input.Split(' ').Select(x => int.Parse(x)).ToArray();
                    ShellSortAndRangeArray<int> arrayHandler = new ShellSortAndRangeArray<int>(array);
                    txtSortedArray.Text = String.Join(", ", arrayHandler.array);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Вы ввели что-то непонятное ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArrayInput.Clear();
                txtRange.Clear();
                txtSortedArray.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то не так! ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArrayInput.Clear();
                txtRange.Clear();
                txtSortedArray.Clear();
            }
        }
        public void Range()
        {
            try
            {
                string input = txtArrayInput.Text;
                if (String.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Вы ничего не ввели в textbox", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArrayInput.Clear();
                    txtRange.Clear();
                    txtSortedArray.Clear();
                }
                double[] array = input.Split(' ').Select(s => Double.Parse(s.Trim())).ToArray();
                ShellSortAndRangeArray<double> arrayHandler = new ShellSortAndRangeArray<double>(array);
                double range = arrayHandler.n;
                txtRange.Text = range.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Вы ввели что-то непонятное ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArrayInput.Clear();
                txtRange.Clear();
                txtSortedArray.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то не так! ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(ex.Message);
                txtArrayInput.Clear();
                txtRange.Clear();
                txtSortedArray.Clear();
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            SortDel();
        }
        private void btn_range_Click(object sender, EventArgs e)
        {
            RangeDel();
        }
    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtArrayInput.Clear();
            txtRange.Clear();
            txtSortedArray.Clear();
        }
        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newF = new Form2();
            newF.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
