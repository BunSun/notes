using System.Windows.Forms;
using System;
using BSun.Notes.Core;

namespace BSun.Notes.WindowsApp
{
   public partial class MainForm : Form
   {
      private readonly NoteController _controller;
      

      public MainForm(NoteController controller)
      {
         _controller = controller;

         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         textBoxTitle.DataBindings.Add(new Binding(nameof(TextBox.Text), _controller.Model, nameof(INoteModel.Title)));
         textBoxText.DataBindings.Add(new Binding(nameof(TextBox.Text), _controller.Model, nameof(INoteModel.Text)));

         comboBoxCategories.DataSource = CategoryManager.Categories;
         comboBoxCategories.DataBindings.Add(new Binding("SelectedItem", _controller.Model, "Category", true, DataSourceUpdateMode.OnPropertyChanged));
      }
      private void ShowSaveConfirmation()
      {
         MessageBox.Show("Note saved successfully!", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void buttonNewNote_Click(object sender, EventArgs e)
      {
         var newNoteForm = new MainForm(_controller);
         newNoteForm.Show();
      }
      public void PrepopulateNoteFields(string title, string text)
      {
         // Setze den vorausgefüllten Titel und Text
         textBoxTitle.Text = title;
         textBoxText.Text = text;
      }

      private void textBoxTitle_TextChanged_1(object sender, EventArgs e)
      {
         _controller.ChangeTitle(textBoxTitle.Text);
      }
      private void textBoxText_TextChanged_1(object sender, EventArgs e)
      {
         _controller.ChangeText(textBoxText.Text);
      }

      private void buttonSave_Click_1(object sender, EventArgs e)
      {
         DialogResult result = MessageBox.Show("Do you want to save the note?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

         if (result == DialogResult.Yes)
         {
            _controller.SaveNote();
            ShowSaveConfirmation();
         }
         DialogResult = DialogResult.OK; // Setze DialogResult auf OK
         Close(); // Schließe das Bearbeitungsfenster
      }

      private void buttonAddCategory_Click(object sender, EventArgs e)
      {
         string newCategory = Prompt.ShowDialog("Neue Kategorie:", "Kategorie hinzufügen");
         if (!string.IsNullOrEmpty(newCategory) && !CategoryManager.Categories.Contains(newCategory))
         {
            CategoryManager.Categories.Add(newCategory);
            comboBoxCategories.DataSource = null; // Datenbindung zurücksetzen
            comboBoxCategories.DataSource = CategoryManager.Categories;
         }
      }
   }
}
