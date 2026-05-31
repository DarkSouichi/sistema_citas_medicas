namespace SistemaCitas.Modelos
{

    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Paciente(int id, string nombre, string cedula, string telefono, string email)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
            Telefono = telefono;
            Email = email;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} - Cedula: {Cedula}";
        }
    }
}
