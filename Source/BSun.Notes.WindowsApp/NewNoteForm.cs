using System.Windows.Forms;
using System;
using BSun.Notes.Core;

namespace BSun.Notes.WindowsApp
{
   public partial class NewNoteForm : Form
   {
      private readonly NoteController _controller;
      

      public NewNoteForm(NoteController controller)
      {
         _controller = controller;

         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         textBoxTitle.DataBindings.Add(new Binding(nameof(TextBox.Text), _controller.Model, nameof(INoteModel.Title)));
         textBoxText.DataBindings.Add(new Binding(nameof(TextBox.Text), _controller.Model, nameof(INoteModel.Text)));

         //comboBoxCategories.DataSource = CategoryManager.Categories;
         //comboBoxCategories.DataBindings.Add(new Binding("SelectedItem", _controller.Model, "Category", true, DataSourceUpdateMode.OnPropertyChanged));

         _controller.Model.Saved += (sender1, e1) => ShowSaveConfirmation();
      }
      private void ShowSaveConfirmation()
      {
         MessageBox.Show("Note saved successfully!", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void buttonNewNote_Click(object sender, EventArgs e)
      {
         //var newNoteForm = new MainForm(_controller);
         //newNoteForm.Show();
      }
      public void PrepopulateNoteFields(string title, string text)
      {
         // Setze den vorausgefüllten Titel und Text
         //textBoxTitle.Text = title;
         //textBoxText.Text = text;
      }

      private void buttonAddCategory_Click(object sender, EventArgs e)
      {
         //string newCategory = Prompt.ShowDialog("Neue Kategorie:", "Kategorie hinzufügen");
         //if (!string.IsNullOrEmpty(newCategory) && !CategoryManager.Categories.Contains(newCategory))
         //{
         //   CategoryManager.Categories.Add(newCategory);
         //   comboBoxCategories.DataSource = null; // Datenbindung zurücksetzen
         //   comboBoxCategories.DataSource = CategoryManager.Categories;
         //}
      }

      private void textBoxText_TextChanged(object sender, EventArgs e)
      {
         _controller.ChangeText(textBoxText.Text);
      }

      private void textBoxTitle_TextChanged(object sender, EventArgs e)
      {
         _controller.ChangeTitle(textBoxTitle.Text);
      }

      private void buttonSave_Click(object sender, EventArgs e)
      {
         _controller.SaveNote();
      }
   }
}
