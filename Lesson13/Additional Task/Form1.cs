﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Additional_Task
{
        /*Создайте приложение WindowsForms. На главной форме приложения разместите 3 кнопки с
    названиями: IsComplete, End, Callback. Организуйте обработчики нажатия на кнопки таким
    образом, чтобы они инициировали асинхронное выполнение некоторого метода (метод
    определите сами, можно воспользоваться чем-то вроде Add или более абстрактного Compute).
    Для каждой из кнопок завершение асинхронного метода должно отслеживаться
    соответствующим образом:
        - IsComplete – с использованием значения свойства IsComplete
        - End – просто применяя EndInvoke
        - Callback – с использованием callback метода*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
