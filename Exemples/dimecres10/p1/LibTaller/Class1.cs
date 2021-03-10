using System;

namespace LibTaller
{
    public class Intermitent : IIntermitent
    {
        public bool Activat { get; private set; }
        public void Activar()
        {
            Console.WriteLine("Intermitent activat");
            Activat = true;
        }
    }

    public class Cotxe : ICotxe
    {
        public Cotxe(IIntermitent intermitentE, IIntermitent intermitentD)
        {
            IntermitentE = intermitentE;
            IntermitentD = intermitentD;
        }

        public IIntermitent IntermitentE { get; private set; } 
        public IIntermitent IntermitentD { get; private set; } 

        public void Activa4Intermitents()
        {
            IntermitentE.Activar();
            IntermitentD.Activar();
        }
    }
}
