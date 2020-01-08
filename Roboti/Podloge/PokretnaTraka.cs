using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti.Podloge
{
    public class PokretnaTraka
    {
        List<Podloga> podloge = new List<Podloga>();
        int vreme = 0;
        public PokretnaTraka()
        {
            var ran = new Random();
            for (int i = 0; i < 5; i++)
            {
                podloge.Add(new Nista());
            }
            for (int i = 0; i < 20; i++)
            {
                int broj = ran.Next(0, 4);
                if (broj == 0)
                    podloge.Add(new Trava());
                if (broj == 1)
                    podloge.Add(new Kutija());
                if (broj == 2)
                    podloge.Add(new Oblak());
                if (broj == 4)
                    podloge.Add(new Zid());
            }
            podloge.Add(new KutijaR2D2());
        }

        public Podloga vrati(int i)
        {
            if(i< podloge.Count)
                return podloge[i];
            return new Nista();
        }
    }
}
