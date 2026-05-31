namespace SistemaCitas.Modelos
{

    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Especialidad Especialidad { get; set; }

        public Medico(int id, string nombre, string email, Especialidad especialidad)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return $"[{Id}] Dr. {Nombre} - {Especialidad.Nombre}";
        }
    }
}
