namespace ListaDoble
{
    class Leon
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Leon(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }

        public override string ToString()
        {
            return $"Leon: {Nombre}, Edad: {Edad}";
        }
    }
}