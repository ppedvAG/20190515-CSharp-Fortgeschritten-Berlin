﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFortgeschritten_Ber
{
    class MyList
    {
        private int[] _internalArray;
        public MyList()
        {
            _internalArray = new int[0];
        }
        // Die Liste muss dynamisch erweitert werden
        public void Add(int zahl)
        {
            var newArray = new int[_internalArray.Length + 1];
            // ohne Kopierkonstruktor

            for (int i = 0; i < _internalArray.Length; i++)
            {
                newArray[i] = _internalArray[i];
            }
            newArray[_internalArray.Length] = zahl;
            _internalArray = newArray;
        }
        // Die Elemente müssen aufrücken
        public void Remove(int zahl)
        {
            if(_internalArray.Length == 0)
            {
                throw new Exception("Die Liste enthält keine Elemente.");
            }
            var newArray = new int[_internalArray.Length - 1];
            var j = 0;
            for (int i = 0; i < _internalArray.Length; i++)
            {
                if(_internalArray[i] == zahl)
                {
                    continue;
                }
                newArray[j++] = _internalArray[i];
            }
            _internalArray = newArray;
        }

    }
}
