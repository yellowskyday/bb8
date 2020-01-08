namespace Zmijica
{
    public class NivoSrednji : Nivo
    {
        public NivoSrednji(int brzina) : base(true, true, brzina, true, 10, PonasanjePremaVocu.Razno, false, false, false, 0)
        {
        }
        public NivoSrednji() : base(true, true, 300, true, 10, PonasanjePremaVocu.Razno, false, false, false, 0)
        {
        }
    }
}
