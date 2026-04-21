namespace ListaDoble
{
    class Jaula
    {
        public Leon? Leon { get; set; }
        public Jaula? Sig { get; set; }
        public Jaula? Ant { get; set; }

        public Jaula(Leon leon)
        {
            Leon = leon;
            Sig = null;
            Ant = null;
        }
    }
}