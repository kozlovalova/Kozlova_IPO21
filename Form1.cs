using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Алгоритмы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Очищаем поле результата
            textBoxR.Clear();

            try
            {
                // Получаем введённые значения, используется вещественный тип данных(десятичное число)//а так же преобразование строки в число
                double x = double.Parse(textBoxX.Text);
                double y = double.Parse(textBoxY.Text);
                double z = double.Parse(textBoxZ.Text);

                //1: Вычисляем cos(x) и cos(y), используется ститический метод из класса Math
                double cosX = Math.Cos(x);
                double cosY = Math.Cos(y);
                textBoxR.AppendText($"1) cos(x) = cos({x}) = {cosX:F3}\r\n"); // добавление текста в конец  //возвращение в начало строки и  новая строка
                textBoxR.AppendText($"2) cos(y) = cos({y}) = {cosY:F3}\r\n"); //F3 - спецификатор, который покажет число с 3мя цифрами после запятой 



                //2: |cos(x) − cos(y)|
                double resultSave = Math.Abs(cosX - cosY); //число джелается положительным, даже если оно отрицательное
                textBoxR.AppendText($"3) |cos(x) − cos(y)|  = {resultSave:F3}\r\n"); //добавляет текст в конце 

                //3: sin^2(y)
                double sin2Y = Math.Pow(Math.Sin(y), 2); //Math.Pow выводит первое число в степень второго
                textBoxR.AppendText($"4) sin^2(y) = (sin({y}))^2 = {sin2Y:F3}\r\n");

                //4: Показатель степени: 1 + 2*sin^2(y)
                double exponent = 1 + 2 * sin2Y;
                textBoxR.AppendText($"5) Показат степени: 1 + 2×sin^2(y) =  {exponent:F3}\r\n");

                //5: Возводим |cos(x) − cos(y)| в степень
                double part1 = Math.Pow(resultSave, exponent);//число, которое будет исп для возведение в степень
                textBoxR.AppendText($"6) |cos(x) − cos(y)|^(1 + 2×sin^2(y)) = {part1:F3}\r\n");

                //6: Вычисляем 2 часть: 1 + z + z^2/2 + z^3/3 + z^4/4
                double z2 = Math.Pow(z, 2);
                double z3 = Math.Pow(z, 3);
                double z4 = Math.Pow(z, 4);
                double part2 = 1 + z + z2 / 2 + z3 / 3 + z4 / 4;

                textBoxR.AppendText($"7) 1 + z + z^2/2 + z^3/3 + z^4/4\r\n");
                textBoxR.AppendText($"   = 1 + {z} + ({z2:F3})/2 + ({z3:F3})/3 + ({z4:F3})/4\r\n");
                textBoxR.AppendText($"   = 1 + {z} + {z2 / 2:F3} + {z3 / 3:F3} + {z4 / 4:F3} = {part2:F3}\r\n");

                //7: Итог: w = part1 * part2
                double w = part1 * part2;
                textBoxR.AppendText($"\r\n");
                textBoxR.AppendText($"Результат: w = {part1:F3} × {part2:F3} = {w:F3}\r\n");
                textBoxR.AppendText($"Округлённый результат: {w:F2}");
            }
            //обработка ошибок в программе 
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка расчёта", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


       

        private void button2_Click(object sender, EventArgs e)
        {

            richTextBox.Clear(); //чистит старый текст
            richTextBox.ForeColor = Color.Black; // обычный цвет для всех этапов

            // 1. Чтение X 
            double x;//присвоили значение
            if (!double.TryParse(tbX.Text, out x))// eсли НЕ получилось преобразовать текст в число ,выполнить блок if
            {
                richTextBox.Text = "1) Ошибка: неверное значение X";
                return; // выход из метода
            }
            richTextBox.AppendText("1) Введён X = " + x + "\r\n"); //добавить текст в конец //приклеиваем значение переменной x

            // 2. Чтение Y 
            double y;
            if (!double.TryParse(tbY.Text, out y))
            {
                richTextBox.AppendText("2) Ошибка: неверное значение Y\r\n");
                return;
            }
            richTextBox.AppendText("2) Введён Y = " + y + "\r\n");

            // 3. Выбор функции f(x) 
            double fx = 0; //начальное значение(на всякий)
            string func = ""; //строка запоминает, какую функцию выбрали

            if (rbCos.Checked)
            {
                fx = Math.Cos(x);
                func = "cos(x)";
            }
            else if (rbSqr.Checked)
            {
                fx = x * x;
                func = "sqr(x)";
            }
            else if (rbExt.Checked)
            {
                fx = Math.Exp(x);
                func = "exp(x)";
            }

            richTextBox.AppendText("3) Выбрана функция: " + func + "\r\n"); //func переменная с помощью которой запоминаем назв выбранной функции
            richTextBox.AppendText("4) f(x) = " + fx + "\r\n");

            // 4) Вычисление xy 
            double xy = x * y;
            richTextBox.AppendText("5) Произведение xy = " + xy + "\r\n");

            //5) Основной алгоритм 
            double c = 0; //обьявляем переменную с

            if (xy > 12)
            {
                richTextBox.AppendText("6) Условие: xy > 12 — формула №1\r\n");

                double t = Math.Tan(y);
                if (Math.Abs(t) < 0.000001) //модуль 
                {
                    richTextBox.AppendText("7) Ошибка: ctg(y) не существует (tan(y)=0)\r\n");
                    return;
                }

                c = Math.Pow(fx, 3) + 1 / t; // f^3(x) + ctg(y)
            }
            else if (xy < 7)
            {
                richTextBox.AppendText("6) Условие: xy < 7 — формула №2\r\n");

                c = Math.Sinh(Math.Pow(fx, 3)) + y * y; // sh(f^3) + y^2 //гиперболический синус
            }
            else
            {
                richTextBox.AppendText("6) Условие: 7 <= xy <= 12 — формула №3\r\n");

                c = Math.Cos(x - Math.Pow(fx, 3)); // cos(x - f^3)
            }

            // 6) Финальный вывод 
            richTextBox.AppendText("7) Результат: ");

            // теперь делаем результат красным
            richTextBox.SelectionStart = richTextBox.Text.Length;
            richTextBox.SelectionColor = Color.Red;
            richTextBox.AppendText(c.ToString());
            richTextBox.SelectionColor = Color.Black;
        }



        private void tbX_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}


