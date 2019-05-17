using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMitSpeichern
{
    public interface IStore
    {
        void Save(Filme filme);
        Filme Load();
    }
}
