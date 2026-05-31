using SistemaCitas.Modelos;
using SistemaCitas.Validaciones;

namespace SistemaCitas.Servicios
{

    public class MedicoServicio
    {
        private List<Medico> _medicos = new List<Medico>();
        private int _contadorId = 1;

        public Medico Registrar(string nombre, string email, Especialidad especialidad)
        {
            Validador.ValidarCampoRequerido(nombre, "Nombre");
            Validador.ValidarCampoRequerido(email, "Email");
            Validador.ValidarNoNulo(especialidad, "Especialidad");

            var medico = new Medico(_contadorId++, nombre, email, especialidad);
            _medicos.Add(medico);
            Console.WriteLine($"Medico registrado: {medico}");
            return medico;
        }

        public Medico BuscarPorId(int id)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null)
                throw new KeyNotFoundException($"No se encontro medico con Id {id}.");
            return medico;
        }

        public List<Medico> ObtenerTodos()
        {
            return _medicos;
        }

        public List<Medico> ObtenerPorEspecialidad(int especialidadId)
        {
            return _medicos.Where(m => m.Especialidad.Id == especialidadId).ToList();
        }
    }
}
