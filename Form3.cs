/* WinForms, 03.06.2023												
												
task № 3:												
Додаток показує, скільки часу в секундах залишилося до НР/ДР/
закінчення предмета WinForms (19.08.2023 12:00)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_46_WF_1
{
    public partial class Form3 : Form
    {
        DateTime dataExam = new DateTime(2023, 8, 19, 12, 0, 0);
        public Form3()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToLongTimeString();
            label4.Text = ((int)(dataExam - DateTime.Now).TotalSeconds).ToString() + " seconds";
        }
    }
}
