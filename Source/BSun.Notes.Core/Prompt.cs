using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BSun.Notes.Core
{
   public static class Prompt
   {
      public static string ShowDialog(string text, string caption)
      {
         Form prompt = new Form();
         prompt.Width = 200;
         prompt.Height = 150;
         prompt.Text = caption;
         Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
         TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 100 };
         Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 70, DialogResult = DialogResult.OK };
         confirmation.Click += (sender, e) => { prompt.Close(); };
         prompt.Controls.Add(confirmation);
         prompt.Controls.Add(textLabel);
         prompt.Controls.Add(textBox);
         prompt.AcceptButton = confirmation;

         return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
      }
   }
}
