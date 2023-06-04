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

namespace modern_calculator.Controls
{
    /// <summary>
    /// Interaction logic for NoteControl.xaml
    /// </summary>
    public partial class NoteControl : UserControl
    {
        Point CurrentMousePosition = new Point(0, 0);
        public int NoteId { get; set; }
        Point CurrentPos = new Point(0, 0);
        private const int EdgePadding = 7;
        public NoteControl()
        {
            InitializeComponent();
            RenderTransform = new TranslateTransform();
            SetId();
        }
        private void SetId()
        {
            int Id = AppState.Notes.Count;
            while (AppState.Notes.Count(el => el.Id == Id)!=0)
                Id++;
            NoteId = Id;
        }
        private void NoteTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CurrentMousePosition = e.GetPosition(Parent as Window);
            NoteTitle.CaptureMouse();
        }
        private void NoteTitle_MouseMove(object sender, MouseEventArgs e)
        {
            Vector diff = e.GetPosition(Parent as Window) - CurrentMousePosition;
            if ((CurrentMousePosition.X < EdgePadding + AppState.ContentMargin
                || CurrentMousePosition.X > AppState.ContentWidth - EdgePadding + AppState.ContentMargin
                || CurrentMousePosition.Y < EdgePadding
                || CurrentMousePosition.Y > AppState.ContentHeight - EdgePadding)
                && NoteTitle.IsMouseCaptured)
                NoteTitle.ReleaseMouseCapture();
            if (NoteTitle.IsMouseCaptured)
            {
                (RenderTransform as TranslateTransform).X += diff.X;
                (RenderTransform as TranslateTransform).Y += diff.Y;
                CurrentPos.X = (RenderTransform as TranslateTransform).X;
                CurrentPos.Y = (RenderTransform as TranslateTransform).Y;
                CurrentMousePosition = e.GetPosition(Parent as Window);
            }
        }
        private void NoteTitle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (NoteTitle.IsMouseCaptured)
            {
                NoteTitle.ReleaseMouseCapture();
                AppState.Notes.Find(el => el.Id == NoteId).PosX = CurrentPos.X;
                AppState.Notes.Find(el => el.Id == NoteId).PosY = CurrentPos.Y;
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Panel.SetZIndex(this, AppState.NotesZindex++);
        }
        public void SetZIndex(int index)
        {
            Panel.SetZIndex(this, index);
        }
        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Input.Text += "\r\n";
                Input.CaretIndex = Input.Text.Length;
            }
        }
        public void SetFromClass(Note data)
        {
            NoteId = data.Id;
            Input.Text = data.Text;
            (RenderTransform as TranslateTransform).X = data.PosX;
            (RenderTransform as TranslateTransform).Y = data.PosY;
        }
        public Note Pack()
        {
            return new Note()
            {
                Id = NoteId,
                Text = Input.Text,
                PosX = CurrentPos.X,
                PosY = CurrentPos.Y
            };
        }
        private void Input_KeyUp(object sender, KeyEventArgs e)
        {
            AppState.Notes.Find(el => el.Id == NoteId).Text = Input.Text;
        }
    }
}
