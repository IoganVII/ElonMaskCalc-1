using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EM.Calc.WinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Core.Calc Calc;

        private void Form1_Load(object sender, EventArgs e)
        {
            Calc = new Core.Calc();

            string[] operations = Calc.Operations
                .Select(o => o.Name)
                .ToArray();

            cbOperation.Items.AddRange(operations);
        }
        

        private void btnExec_Click(object sender, EventArgs e)
        {
            // получить операнды
            var values = tbInput.Text
                .Split(' ')
                .Select(Convert.ToDouble)
                .ToArray();

            // получить операцию
            var operation = cbOperation.Text;

            // делаем расчёт
            var result = Calc.Execute(operation, values);

            // Выводим результат
            lblResult.Text = $"{result}";
        }
    }
}
