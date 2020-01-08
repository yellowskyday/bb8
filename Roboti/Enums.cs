using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public enum PodlogaEnum
    {
        Trava,
        Zid,
        Provalija,
        Oblak
    }

    public enum Udar
    {
        Da,
        Ne
    }

    public enum Kraj
    {
        Ne,
        Prosao,
        Izgubio
    }
    public enum Smer
    {
        Gore,
        Dole,
        Levo,
        Desno
    }

    public enum Efekat
    {
        DodajPoene,
        DodajZivot,
        OduzmiZivot,
        UkloniPrepreku,
        R2D2
    }
}
