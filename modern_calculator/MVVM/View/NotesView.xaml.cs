using modern_calculator.Controls;
using modern_calculator.Core;
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
        List<NoteControl> notes = new List<NoteControl>();
        private long clicks = 0;
        public NotesView()
        {
            InitializeComponent();
            notes.Add(new NoteControl());
            Field.Children.Add(notes[0]);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            NoteControl newNote = new NoteControl();
            newNote.SetZIndex(AppState.NotesZindex++);
            notes.Add(newNote);
            Field.Children.Add(newNote);
        }
    }
}
