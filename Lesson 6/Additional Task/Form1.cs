﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;


namespace Additional_Task
{
    public static class Main
    {

    }
    public partial class TextBox : Form
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                Assembly assembly = Assembly.LoadFrom(@path);
                Type[] types = assembly.GetTypes();
                string namespaces = null;

                foreach (Type item in types)
                {
                    this.textBox1.Text += (namespaces == null) ? "namespace " + item.Namespace + Environment.NewLine + "{" + Environment.NewLine : null;
                    namespaces = item.Namespace;
                    string padding = new string(' ', 5);
                    if (item.IsClass)
                    {
                        this.textBox1.Text += padding+"class ";
                    }

                    if (item.IsValueType)
                    {                  
                        this.textBox1.Text += padding + "struct ";
                    }

                    if (item.IsEnum)
                    {
                        padding = "";
                        this.textBox1.Text += padding + "enum ";
                        padding = new string(' ', 5);
                    }

                    if (item.IsInterface)
                    {
                        this.textBox1.Text += padding + "interface ";
                    }

                    
                    this.textBox1.Text += item.Name + Environment.NewLine + padding+"{" + Environment.NewLine;

                    padding = new string(' ', 15);
                    this.textBox1.Text += padding+"Methods:".ToUpper() + Environment.NewLine;

                    foreach (MethodInfo items in item.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                    {
                        bool enter = true;
                        padding = new string(' ', 15);
                        if (items.IsPublic)
                        {
                            padding = enter ? padding : "";
                            enter = false;
                            this.textBox1.Text += padding+"public ";
                        }

                        if (items.IsPrivate)
                        {
                            padding = enter ? padding : "";
                            enter = false;
                            this.textBox1.Text += padding + "private ";
                        }

                        if (items.IsStatic)
                        {
                            padding = enter ? padding : "";
                            enter = false;
                            this.textBox1.Text += padding + "static ";
                        }

                        if (items.IsAbstract)
                        {
                            padding = enter ? padding : "";
                            enter = false;
                            this.textBox1.Text += padding + "abstract ";
                        }

                        if (items.IsVirtual)
                        {
                            padding = enter ? padding : "";
                            enter = false;
                            this.textBox1.Text += padding + "virtual ";
                        }
                        if(enter)
                        {
                            this.textBox1.Text += padding;
                        }

                        this.textBox1.Text += items.ReturnType.Name + " " + items.Name + "(";
                        ParameterInfo[] parameters = items.GetParameters();
                        string text = null;
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            this.textBox1.Text += parameters[i].ParameterType.Name +" "+ parameters[i].Name;
                            text += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                            if (i + 1 < parameters.Length)
                            {
                                this.textBox1.Text += ", ";
                                text+= ", ";
                            }
                        }
                        this.textBox1.Text += ")" + Environment.NewLine;
                    }

                    padding = new string(' ', 5);
                    this.textBox1.Text += padding+"}" + Environment.NewLine + "\r\n";

                }
                this.textBox1.Text += "}" + Environment.NewLine;
            }
        }

        private void TextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
