using modern_calculator.MVVM.Model;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace modern_calculator.Core
{
    static internal class FileWorker
    {
        public static async void Save()
        {
            await Task.Run(() =>
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream("notes", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    foreach (var note in AppState.Notes)
                        formatter.Serialize(stream, note);
                }
                using (Stream stream = new FileStream("settings", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, AppState.Settings);
                }
            });
        }
        public static void Load()
        {
            IFormatter formatter = new BinaryFormatter();
            List<Note> notes = new List<Note>();
            if (!File.Exists("notes"))
            {
                notes.Add(new Note()
                {
                    Id = 0,
                    PosX = 0,
                    PosY = 0,
                    Text = "Hello!\nHere you can store your notes!"
                });
                AppState.Notes = notes;
            }
            else
            {
                using (Stream stream = new FileStream("notes", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    while (stream.Position < stream.Length)
                        notes.Add((Note)formatter.Deserialize(stream));
                }
            }
            if (!File.Exists("settings"))
            {
                AppState.Settings = new SettingsModel();
            }
            else
            {
                using (Stream stream = new FileStream("settings", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    AppState.Settings = (SettingsModel)formatter.Deserialize(stream);
                }
            }
            AppState.Notes = notes;
        }
    }
}
