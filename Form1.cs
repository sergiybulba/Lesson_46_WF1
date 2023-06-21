/* WinForms, 03.06.2023												
												
task № 1:												
При наведенні на кнопку - та відстрибує у випадкову позицію на клієнтській області форми 
(але не виходячи за межі вікна) - є приклад в убегающая кнопка.exe.
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
    public partial class Form1 : Form
    {
        public Form1()      // в заголовку форми відображаються розміри клієнтської області форми і координати кнопки
        {
            InitializeComponent();
            this.Text = $"Form_width: {this.ClientRectangle.Width}, form_height: {this.ClientRectangle.Height}, " +
                        $"button.X = {button1.Location.X}, button.Y = {button1.Location.Y}";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            int a = random.Next(this.ClientRectangle.Width - button1.Width);    // координата Х - не більше ширини клієнтської області
            int b = random.Next(this.ClientRectangle.Height - button1.Height);  // координата Y - не більше висоти клієнтської області

            button1.Location = new Point(a, b);
            this.Text = $"Form_width: {this.ClientRectangle.Width}, form_height: {this.ClientRectangle.Height}, " +
                        $"button.X = {button1.Location.X}, button.Y = {button1.Location.Y}";        // зміна заголовку при зміні розташування кнопки
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Text = $"Form_width: {this.ClientRectangle.Width}, form_height: {this.ClientRectangle.Height}, " +
                        $"button.X = {button1.Location.X}, button.Y = {button1.Location.Y}";        // зміна заголовку при зміні розміру форми
        }
    }
}
