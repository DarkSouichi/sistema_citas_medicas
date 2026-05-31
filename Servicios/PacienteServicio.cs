using SistemaCitas.Modelos;
using SistemaCitas.Validaciones;

namespace SistemaCitas.Servicios
{

    public class PacienteServicio
    {
        private List<Paciente> _pacientes = new List<Paciente>();
        private int _contadorId = 1;

        public Paciente Registrar(string nombre, string cedula, string telefono, string email)
        {
            Validador.ValidarCampoRequerido(nombre, "Nombre");
            Validador.ValidarCampoRequerido(cedula, "Cedula");
            Validador.ValidarCampoRequerido(telefono, "Telefono");
            Validador.ValidarCampoRequerido(email, "Email");

            // verifico que no exista un paciente con la misma cedula
            if (_pacientes.Any(p => p.Cedula == cedula))
                throw new InvalidOperationException($"Ya existe un paciente con la cedula {cedula}.");

            var paciente = new Paciente(_contadorId++, nombre, cedula, telefono, email);
            _pacientes.Add(paciente);
            Console.WriteLine($"Paciente registrado: {paciente}");
            return paciente;
        }

        public Paciente BuscarPorId(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null)
                throw new KeyNotFoundException($"No se encontro paciente con Id {id}.");
            return paciente;
        }

        public List<Paciente> ObtenerTodos()
        {
            return _pacientes;
        }
    }
}
