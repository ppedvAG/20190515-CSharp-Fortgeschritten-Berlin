using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WPFMitSpeichern
{
    class FileSimpleBinStore : IStore
    {
        public Filme Load()
        {
            FileStream fileStream = new FileStream("Datei.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryWriter = new BinaryFormatter();
            var filme = (Filme)binaryWriter.Deserialize(fileStream);
            fileStream.Close();
            return filme;
        }

        public void Save(Filme filme)
        {
            FileStream fileStream = new FileStream("Datei.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binaryWriter = new BinaryFormatter();
            binaryWriter.Serialize(fileStream, filme);
            fileStream.Close();
        }
    }
}
