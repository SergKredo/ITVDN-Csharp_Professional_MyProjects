﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task_2_Converter_Temperature
{
        /*Задание 2
    Создайте свою пользовательскую сборку по примеру сборки CarLibrary из урока, сборка будет
    использоваться для работы с конвертером температуры.*/
    class ConverterTemperature : BaseConverter  // Объявление класса ConverterTemperature, который наследует члены абстрактного базового класса BaseConverter
    {
        private TextBox textBox_Kelvine;
        private TextBox textBox_Farinhate;
        private TextBox textBox_Celcia;
        public ConverterTemperature(TextBox textBox_Kelvine, TextBox textBox_Farinhate, TextBox textBox_Celcia)
            : base(textBox_Kelvine, textBox_Farinhate, textBox_Celcia)
        {
            // Присвоение параметров конструктора полям класса
            this.textBox_Kelvine = textBox_Kelvine;
            this.textBox_Farinhate = textBox_Farinhate;
            this.textBox_Celcia = textBox_Celcia;
        }


        public override double ConvertCelciaToKelvine(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return Convert.ToDouble(grad) + 273.15;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return Convert.ToDouble(grad) + 273.15;
            }
        }

        public override double ConvertCelciaToFarinhate(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) * (9 / 5d)) + 32;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) * (9 / 5d)) + 32;
            }
        }

        public override double ConvertKelvineToCelcia(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return Convert.ToDouble(grad) - 273.15;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return Convert.ToDouble(grad) - 273.15;
            }

        }
        public override double ConvertKelvineToFarinhate(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) - 273.15) * (9 / 5d) + 32;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) - 273.15) * (9 / 5d) + 32;
            }
        }

        public override double ConvertFarinhateToCelcia(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d);
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d);
            }
        }

        public override double ConvertFarinhateToKelvine(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d) + 273.15;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d) + 273.15;
            }
        }


        public override void textBox_Kelvine_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            bool right = true;

            if (text.Text != "" && kelvin && !text.Text.StartsWith(".") && !text.Text.StartsWith(",") && (!textKelvin.Contains(",") || (textKelvin.IndexOf(',') == text.Text.LastIndexOf(','))) && (!textKelvin.Contains(".") || (textKelvin.IndexOf('.') == text.Text.LastIndexOf('.'))))
            {
                if (text.Text != "-")
                {
                    farinhate = celcia = false;
                    try
                    {
                        foreach (char item in charMassive)
                        {
                            if (text.Text.EndsWith(item.ToString()))
                            {
                                degreeKelvin = Convert.ToDouble(text.Text.Replace('.', ','));
                                textKelvin = text.Text;
                                right = false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        foreach (char item in charMassive)
                        {
                            if (text.Text.StartsWith(item.ToString()) && text.Text.EndsWith(item.ToString()))
                            {
                                degreeKelvin = Convert.ToDouble(text.Text.Replace(',', '.'));
                                textKelvin = text.Text;
                                right = false;
                            }
                        }
                    }
                    if (right != false)
                    {
                        this.textBox_Kelvine.Text = degreeKelvin.ToString();
                        textKelvin = degreeKelvin.ToString();
                    }
                    this.textBox_Farinhate.Text = ConvertKelvineToFarinhate(degreeKelvin).ToString();
                    this.textBox_Celcia.Text = ConvertKelvineToCelcia(degreeKelvin).ToString();
                    farinhate = celcia = true;
                }
            }
            else if (text.Text.StartsWith(",") || text.Text.StartsWith("."))
            {
                this.textBox_Kelvine.Text = degreeKelvin.ToString();
                textKelvin = degreeKelvin.ToString();
            }
            else if ((textKelvin.Contains(",") || textKelvin.Contains(".")) && text.Text != "" && kelvin)
            {
                this.textBox_Kelvine.Text = degreeKelvin.ToString();
                textKelvin = degreeKelvin.ToString();
            }
            else if (kelvin)
            {
                textKelvin = "";
                degreeKelvin = 0;
            }
        }

        public override void textBox_Celcia_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            bool right = true;
            if (text.Text != "" && celcia && !text.Text.StartsWith(".") && !text.Text.StartsWith(",") && (!textCelcia.Contains(",") || (textCelcia.IndexOf(',') == text.Text.LastIndexOf(','))) && (!textCelcia.Contains(".") || (textCelcia.IndexOf('.') == text.Text.LastIndexOf('.'))))
            {
                if (text.Text != "-")
                {
                    farinhate = kelvin = false;
                    try
                    {
                        foreach (char item in charMassive)
                        {
                            if (text.Text.EndsWith(item.ToString()))
                            {
                                degreeCelcia = Convert.ToDouble(text.Text.Replace('.', ','));
                                textCelcia = text.Text;
                                right = false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        foreach (char item in charMassive)
                        {
                            if (text.Text.StartsWith(item.ToString()) && text.Text.EndsWith(item.ToString()))
                            {
                                degreeCelcia = Convert.ToDouble(text.Text.Replace(',', '.'));
                                textCelcia = text.Text;
                                right = false;
                            }
                        }
                    }
                    if (right != false)
                    {
                        this.textBox_Celcia.Text = degreeCelcia.ToString();
                        textCelcia = degreeCelcia.ToString();
                    }
                    this.textBox_Farinhate.Text = ConvertCelciaToFarinhate(degreeCelcia).ToString();
                    this.textBox_Kelvine.Text = ConvertCelciaToKelvine(degreeCelcia).ToString();
                    farinhate = kelvin = true;
                }
            }
            else if (text.Text.StartsWith(",") || text.Text.StartsWith("."))
            {
                this.textBox_Celcia.Text = degreeCelcia.ToString();
                textCelcia = degreeCelcia.ToString();
            }
            else if ((textCelcia.Contains(",") || textCelcia.Contains(".")) && text.Text != "" && celcia)
            {
                this.textBox_Celcia.Text = degreeCelcia.ToString();
                textCelcia = degreeCelcia.ToString();
            }
            else if (celcia)
            {
                textCelcia = "";
                degreeCelcia = 0;
            }
        }


        public override void textBox_Farinhate_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            bool right = true;
            if (text.Text != "" && farinhate && !text.Text.StartsWith(".") && !text.Text.StartsWith(",") && (!textFarinhate.Contains(",") || (textFarinhate.IndexOf(',') == text.Text.LastIndexOf(','))) && (!textFarinhate.Contains(".") || (textFarinhate.IndexOf('.') == text.Text.LastIndexOf('.'))))
            {
                if (text.Text != "-")
                {
                    celcia = kelvin = false;
                    try
                    {
                        foreach (char item in charMassive)
                        {
                            if (text.Text.EndsWith(item.ToString()))
                            {
                                degreeFarinhate = Convert.ToDouble(text.Text.Replace('.', ','));
                                textFarinhate = text.Text;
                                right = false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        foreach (char item in charMassive)
                        {
                            if (text.Text.StartsWith(item.ToString()) && text.Text.EndsWith(item.ToString()))
                            {
                                degreeFarinhate = Convert.ToDouble(text.Text.Replace(',', '.'));
                                textFarinhate = text.Text;
                                right = false;
                            }
                        }
                    }
                    if (right != false)
                    {
                        this.textBox_Farinhate.Text = degreeFarinhate.ToString();
                        textFarinhate = degreeFarinhate.ToString();
                    }
                    this.textBox_Kelvine.Text = ConvertFarinhateToKelvine(degreeFarinhate).ToString();
                    this.textBox_Celcia.Text = ConvertFarinhateToCelcia(degreeFarinhate).ToString();
                    celcia = kelvin = true;
                }
            }
            else if (text.Text.StartsWith(",") || text.Text.StartsWith("."))
            {
                this.textBox_Farinhate.Text = degreeFarinhate.ToString();
                textFarinhate = degreeFarinhate.ToString();
            }
            else if ((textFarinhate.Contains(",") || textFarinhate.Contains(".")) && text.Text != "" && farinhate)
            {
                this.textBox_Farinhate.Text = degreeFarinhate.ToString();
                textFarinhate = degreeFarinhate.ToString();
            }
            else if (farinhate)
            {
                textFarinhate = "";
                degreeFarinhate = 0;
            }
        }
    }
}
