namespace SistemaCitas.Modelos
{

    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Especialidad(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre}";
        }
    }
}
