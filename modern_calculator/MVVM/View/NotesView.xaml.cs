using modern_calculator.Controls;
using modern_calculator.Core;
using modern_calculator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace modern_calculator.MVVM.View
{
    /// <summary>
    /// Interaction logic for NotesView.xaml
    /// </summary>
    public partial class NotesView : UserControl
    {
        //List<NoteControl> notes = new List<NoteControl>();
        private long clicks = 0;
        public NotesView()
        {
            InitializeComponent();
            //notes.Add(new NoteControl());
            foreach(var note in AppState.Notes)
            {
                NoteControl NewNote = new NoteControl();
                NewNote.Delete.Click += new RoutedEventHandler(Delete_Click);
                NewNote.SetFromClass(note);
                Field.Children.Add(NewNote);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            NoteControl newNote = new NoteControl();
            newNote.Delete.Click += new RoutedEventHandler(Delete_Click);
            newNote.SetZIndex(AppState.NotesZindex++);
            AppState.Notes.Add(newNote.Pack());
            Field.Children.Add(newNote);
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            AppState.Notes.Remove(AppState.Notes.Find(el => el.Id == ((NoteControl)((FrameworkElement)((FrameworkElement)((FrameworkElement)sender).Parent).Parent).Parent).NoteId));
            Field.Children.Clear();
            foreach (var note in AppState.Notes)
            {
                NoteControl NewNote = new NoteControl();
                NewNote.Delete.Click += new RoutedEventHandler(Delete_Click);
                NewNote.SetFromClass(note);
                Field.Children.Add(NewNote);
            }
        }
    }
}
