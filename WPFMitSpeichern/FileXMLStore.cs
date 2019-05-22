using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Serialization;

namespace WPFMitSpeichern
{
    class FileXMLStore : IStore
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
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Filme));
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {

                    var filme = (Filme)xmlSerializer.Deserialize(fileStream);
                    return filme;
                }
            }
            else
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
            saveFileDialog.Filter = "Xml|*.xml";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() ?? false)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Filme));
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                {
                    xmlSerializer.Serialize(xmlWriter, filme);
                }
            }
        }
    }
}
