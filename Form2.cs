/* WinForms, 03.06.2023												
												
task № 2:												
Реалізувати додаток, який виглядає так само, як завдання - малювання кнопками.
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
    public partial class Form2 : Form
    {
        Button [] buttons = new Button[50];
        int firstX, firstY, startX, startY, endX, endY, index = 0;
        int but_width, but_height;
        bool isMove = false, isStop = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)       // кнопка down - фіксація початкової координати кнопки
        {
            firstX = startX = e.X;                                            // початкові позиції кнопки
            firstY = startY = e.Y;
            this.Text = $"StartX = {startX}, StartY = {startY}";
            isMove = true;                                                  // дозвіл формувати кнопку за рухом мишки
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)       // режим малювання кнопки на формі
        {
            if (isMove)                             // якщо є дозвіл формувати кнопку
            {
                endX = e.X;                         // фіксація фінальної координати кнопки
                endY = e.Y;
                but_width = (endX - firstX);        // розрахунок ширини і висоти кнопки
                but_height = (endY - firstY);
                if (but_width <= 0 || but_height <= 0)            // окремі умови якщо фінальні координати кнопки менше стартових
                {
                    if (but_width < 0 && but_height > 0)
                    {
                        startX = endX;
                        but_width = Math.Abs(but_width);
                    }
                    else if (but_width > 0 && but_height < 0)
                    {
                        startY = endY;
                        but_height = Math.Abs(but_height);
                    }
                    else if (but_width < 0 && but_height < 0)
                    {
                        startX = endX;
                        startY = endY;
                        but_width = Math.Abs(but_width);
                        but_height = Math.Abs(but_height);
                    }
                }

                if (!isStop)                                // якщо кнопка не створена - фіксація початкових властивостей і процес малювання кнопки на формі 
                {
                    this.buttons[index] = new Button();
                    this.SuspendLayout();
                    this.buttons[index].Name = "button " + index;
                    this.buttons[index].Text = "button " + (index + 1);
                    this.buttons[index].TabIndex = index;
                    this.buttons[index].UseVisualStyleBackColor = true;
                    this.buttons[index].Location = new Point(startX, startY);
                    this.buttons[index].Size = new Size(but_width, but_height);
                    this.buttons[index].Visible = true;


                    isStop = true;                                  // кнопка створена
                    this.Controls.Add((Control)buttons[index]);
                }
                else                                                    // якщо кнопка створена - фіксація нової стартової координати кнопки і її розмірів
                {
                    this.buttons[index].Location = new Point(startX, startY);
                    this.buttons[index].Size = new Size(but_width, but_height);
                }

            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)         // фіксація створення кнопки по відпусканню кнопки мишки
        {
            isMove = false; isStop = false;             // кнопка створена і режим малювання кнопки завершений
            if (but_width < 23 || but_height < 23)      // якщо кнопка маленька - почати спочатку
            {
                MessageBox.Show("The button is too small!", "Error");
                buttons[index].Dispose();
            }
            else
            {
                endX = e.X;                         // фіксація фінальної координати кнопки
                endY = e.Y;
                but_width = (endX - firstX);        // розрахунок ширини і висоти кнопки
                but_height = (endY - firstY);
                if (but_width <= 0 || but_height <= 0)            // окремі умови якщо фінальні координати кнопки менше стартових
                {
                    if (but_width < 0 && but_height > 0)
                    {
                        startX = endX;
                        but_width = Math.Abs(but_width);
                    }
                    else if (but_width > 0 && but_height < 0)
                    {
                        startY = endY;
                        but_height = Math.Abs(but_height);
                    }
                    else if (but_width < 0 && but_height < 0)
                    {
                        startX = endX;
                        startY = endY;
                        but_width = Math.Abs(but_width);
                        but_height = Math.Abs(but_height);
                    }
                }
                this.buttons[index].Location = new Point(startX, startY);        // фіксація нової стартової координати кнопки і її розмірів
                this.buttons[index].Size = new Size(but_width, but_height);
                this.Text = this.Text + $", endX = {endX}, endY = {endY}";
                index++;
            }
        }
    }
}
