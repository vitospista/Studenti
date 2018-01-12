﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // creo array con i numeri da 1 a 100
            // 2  3  4  5  6  7  8  9 10 11 12 13 14 15 ... 100
            // 0  1  2  3  4  5  6  7  8  9 10 11 12 13 ...  98

            // parto da 2, pongo a 0 tutti i numeri dell'array
            // che sono multipli di 2.
            // 2  3  0  5  0  7  0  9  0 11  0 13  0 15 ...   0
            // 0  1  2  3  4  5  6  7  8  9 10 11 12 13 ...  98

            // poi passo a 3, elimino tutti i multipli di 3
            // che non sono già stati "eliminati".
            // 2  3  0  5  0  7  0  0  0 11  0 13  0  0 ...   0
            // 0  1  2  3  4  5  6  7  8  9 10 11 12 13 ...  98

            // trovo il prossimo numero != 0, ed elimino i suoi multipli.

            // continuo fino a 100.

            // ho l'array finale con i numeri primi e tanti 0 in mezzo.

            // conto i numeri primi (cioè tutti i numeri dell'array != 0)

            // creo un nuovo array lungo quanti sono i numeri primi

            // itero sull'array originale, e quando incontro un numero != 0
            // lo metto nel nuovo array.

            // 2 3 0 5 0 7
            // 2 3 5 7
        }
    }
}
