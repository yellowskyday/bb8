namespace Zmijica
{
    public class NivoLak : Nivo
    {
        public NivoLak(int brzina) : base(true, false, brzina, false, 39, PonasanjePremaVocu.Jabuka, false, false, false, 0)
        {
        }
        public NivoLak() : base(true, false, 500, false, 39, PonasanjePremaVocu.Jabuka, false, false, false, 0)
        {
        }
    }
}
