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

namespace modern_calculator.Controls
{
    /// <summary>
    /// Interaction logic for NoteControl.xaml
    /// </summary>
    public partial class NoteControl : UserControl
    {
        Point CurrentMousePosition;
        Point StartPos;
        private const int EdgePadding = 3;
        public NoteControl()
        {
            InitializeComponent();
            RenderTransform = new TranslateTransform();
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
                //diff = new Vector(0,0);
                NoteTitle.ReleaseMouseCapture();
            if (NoteTitle.IsMouseCaptured)
            {
                (RenderTransform as TranslateTransform).X += diff.X;
                (RenderTransform as TranslateTransform).Y += diff.Y;
                CurrentMousePosition = e.GetPosition(Parent as Window);
            }
        }
        private void NoteTitle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (NoteTitle.IsMouseCaptured)
            {
                NoteTitle.ReleaseMouseCapture();
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
            if (e.Key == Key.Return) { 
                Input.Text += "\r\n";
                Input.CaretIndex = Input.Text.Length;
            }
        }
    }
}
