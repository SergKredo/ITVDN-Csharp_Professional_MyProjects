﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Additional_Task
{
    abstract class Human
    {
        OpenFileDialog openFileDialog;
        Form TextBox;
        public readonly string name;
        public readonly string lastName;

        protected Human(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            this.openFileDialog = new OpenFileDialog();
            this.TextBox = new Form();
        }

        public void OpenToBaseBankDate(Human human)
        {
            InvokeAttribute(human);
            if (human.GetType().Name == "Other")
            {
                Console.WriteLine(new string('-', 100)+"\r\nUnfortunately, you are denied access to the company's banking data!\r\n" + new string('-', 100));
            }
            else if (human.GetType().Name == "Director")
            {
                if (this.openFileDialog.ShowDialog(TextBox) == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    string text = File.ReadAllText(path, Encoding.UTF8);
                    Console.WriteLine(new string('-', 100) + "\r\nYou have gained access to banking operations in the company!\r\nBank data:\r\n" + text + "\r\n" + new string('-', 100));
                }
            }
            else
            {
                Console.WriteLine(new string('-', 100) + "\r\nUnfortunately, you do not have access to the company's banking data, but you can use other data permitted for your access level!\r\n" + new string('-', 100));
            }
        }
        static void InvokeAttribute(Human human)
        {
            Type person = human.GetType();
            object[] attribute = person.GetCustomAttributes(typeof(AccessLevelAttribute), false);
            foreach (AccessLevelAttribute item in attribute)
            {
                item.Access(human);
            }
        }
    }
}
