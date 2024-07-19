using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace _1CToCyberDiplomaConverter
{
    public static class AdditionalFunctions
    {
        public static readonly Regex regexNumbers = new Regex("[^0-9]+");
        public static readonly Regex regexLetters = new Regex(@"^[a-zA-Zа-яА-Я]+$");
        public static readonly Regex regexLettersLowerCase = new Regex(@"^[a-zа-я]+$");
        public static readonly Regex regexLettersUpperCase = new Regex(@"^[A-ZА-Я]+$");

        public static void NumberPreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (e.Key == Key.Back)
                if (textBox.Text.Remove(textBox.Text.Length - 1, 1).Length <= 0) e.Handled = true;
        }

        public static void NumberPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            e.Handled = regexNumbers.IsMatch(e.Text);
            if (!e.Handled)
                if (int.Parse(textBox.Text + e.Text) > 1000000) e.Handled = true;
        }

        public static void AuthorPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string text = (sender as TextBox).Text;
            e.Handled = !regexLetters.IsMatch(e.Text);
            if (e.Handled) return;
            bool isMatchedLowerCase = regexLettersLowerCase.IsMatch(e.Text);
            if (text.Length == 0)
            { if (isMatchedLowerCase) e.Handled = true; }
            else if (text.Remove(0, text.Length - 1) == " " && isMatchedLowerCase) e.Handled = true;
        }

        public static void TextPreviewKeyDown(object sender, KeyEventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (e.Key == Key.Space)
                if (text.Length == 0) e.Handled = true;
                else if (text.Remove(0, text.Length - 1) == " ") e.Handled = true;
        }

        public sealed class StringWriterWithEncoding : StringWriter
        {
            public override Encoding Encoding { get; }

            public StringWriterWithEncoding(Encoding encoding)
            {
                Encoding = encoding;
            }
        }
    }
}
