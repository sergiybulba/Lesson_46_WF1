/* WinForms, 03.06.2023												
												
task № 4:												
Користувачеві дається 7 секунд, щоб здійснити максимально можливу кількість кліків по кнопці. 
Після закінчення часу показати MessageBox, який повідомляє набрану кількість кліків, 
та максимальний рекорд за підсумками всіх спроб.
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
    public partial class Form4_1 : Form
    {
        private int[] results = new int[100];       // масив результатів
        private int counter = 0;                    // лічильник клацань мишкою
        private int index = 0;                      // індекс масиву результатів
        private bool first_push = true;             // показник першого нажаття кнопки 2
        private DateTime timeStart = new DateTime();
        public Form4_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      // кнопка 1 - старт гри
        {
            label1.Visible = true;                  // лейбли - видимі
            label2.Visible = true;
            label2.Text = "Your time: " + timer1.Interval/1000 + " seconds";    // інтервал в сек
            button1.Enabled = false;                                // активувати/деактивувати кнопки
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)      // кнопка 2 - необхідно клацати по ній
        {
            if (first_push)                 // якщо перше клацання
            {
                timer1.Start();             // то запустити таймер
                first_push = false;         // деактивувати перше нажаття
                timeStart = DateTime.Now;   // час початку клацання
                label1.Visible = false;     // невидимий лейбл
            }
            //зворотній відлік
            label2.Text = (timer1.Interval/1000 - (DateTime.Now - timeStart).Seconds).ToString();
            counter++;                      // при всіх клацаннях збільшувати лічильник на 1
        }
        private void button3_Click(object sender, EventArgs e)          // кнопка 3 показує максимальний результат
        {
            MessageBox.Show(results.Max() + " clicks", "Max result");
        }

        private void timer1_Tick(object sender, EventArgs e)            // подія таймеру:
        {
            timer1.Stop();                                              // зупинити подальший зворотній відлік таймеру
            button2.Enabled = false;
            label2.Visible = false;
            MessageBox.Show(counter + " clicks", "Current result");     // показати поточний результат
            button1.Enabled = true;                                     // активувати/деактивувати кнопки
            button3.Enabled = true;
            results[index] = counter;                                   // записати в масив поточний результат
            counter = 0;                                                // обнулити лічильник
            index++;                                                    // збільшити індекс
            first_push = true;                                          // активувати перше нажаття кнопки
        }
    }
}
