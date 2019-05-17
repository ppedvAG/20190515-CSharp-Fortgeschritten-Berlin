using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace WPFMitSpeichern
{
    class FileBinStore : IStore
    {
        public Filme Load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.FileName = "Datei.bin";
            openFileDialog.Filter = "Binary|*.bin";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() ?? false)
            {
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter binaryWriter = new BinaryFormatter();
                    var filme = (Filme)binaryWriter.Deserialize(fileStream);
                    return filme;
                }
            }else
            {
                var filme = new Filme();
                return filme;
            }
        }

        public void Save(Filme filme)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.FileName = "Datei.bin";
            saveFileDialog.Filter = "Binary|*.bin";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() ?? false)
            {
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter binaryWriter = new BinaryFormatter();
                    binaryWriter.Serialize(fileStream, filme);
                }
            }
        }
    }
}
