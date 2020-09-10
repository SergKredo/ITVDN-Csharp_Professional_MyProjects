﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Task2
{
    /*Задание 2
Преобразуйте пример событийной блокировки таким образом, чтобы вместо ручной обработки
использовалась автоматическая.
 */
    class Program
    {
        static AutoResetEvent autoResetEvent;  // Объект AutoReset уведомляет ожидающий поток о том, что произошло событие.
        static string text;
        static StreamWriter writer = File.CreateText("LogDate.log");  // Создание файлового потока для записи данных в текстовый файл
        public static void MyMethod(object number)  // Статический метод, сообщенный с пулом потоков
        {
            Random random = new Random();
            text = String.Format("Основной поток ожидает событие от потока № - {0}.\n"+new string('*', random.Next(10, 100)), number);
            writer.WriteLine(text); // Запись данных в текстовый файл
            Console.WriteLine(text);
            Thread.Sleep(300);  // Остановка потока на заданное количество миллисекунд
            text = String.Format("Основной поток получил уведомление о событии от потока № - {0}.\n" + new string('+', random.Next(10, 100)), number);
            writer.WriteLine(text);
            Console.WriteLine(text);
            autoResetEvent.Set();  // Устанавливает сигнальное состояние собятия, что позволяет продолжить одному или нескольким ожидающим потокам
        }
        static void Main(string[] args)
        {
            autoResetEvent = new AutoResetEvent(false);
            for (int i = 1; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(MyMethod, i);  // Помещает метод в очередь на выполнение, содержащий данные для использования методом
                // Метод выполняется, когда доступен поток из пула потоков
                autoResetEvent.WaitOne();  // Блокирует текущий поток для получения сигнала объектом WaitHandle
            }
            Thread.Sleep(2000);
            writer.Close();
            Console.ReadKey();
        }
    }
}
/*
 Results:
------------------------------------------------------------------------------------------------------------------------------------------
Основной поток ожидает событие от потока № - 1.
***********************
Основной поток получил уведомление о событии от потока № - 1.
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 2.
**********************************************************************
Основной поток получил уведомление о событии от потока № - 2.
+++++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 3.
************************************************************************************
Основной поток получил уведомление о событии от потока № - 3.
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 4.
***************************************************
Основной поток получил уведомление о событии от потока № - 4.
++++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 5.
******************************************************************
Основной поток получил уведомление о событии от потока № - 5.
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 6.
***********************
Основной поток получил уведомление о событии от потока № - 6.
+++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 7.
*************************************
Основной поток получил уведомление о событии от потока № - 7.
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 8.
***************************************************
Основной поток получил уведомление о событии от потока № - 8.
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 9.
***************************************************
Основной поток получил уведомление о событии от потока № - 9.
++++++++++++++++++++++++++++++++++++++
Основной поток ожидает событие от потока № - 10.
******************************************************************
Основной поток получил уведомление о событии от потока № - 10.
+++++++++++++++++++++++++++++++++++++++++++++++++++


 */