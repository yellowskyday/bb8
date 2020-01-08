namespace Zmijica
{
    public class NivoTezak : Nivo
    {
        public NivoTezak(int brzina) : base(true, true, brzina, true, 5, PonasanjePremaVocu.DveJabuke, false, true, false, 0)
        {
        }
        public NivoTezak() : base(true, true, 200, true, 5, PonasanjePremaVocu.DveJabuke, false, true, false, 0)
        {
        }
    }
}
