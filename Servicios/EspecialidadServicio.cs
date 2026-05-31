using SistemaCitas.Modelos;
using SistemaCitas.Validaciones;

namespace SistemaCitas.Servicios
{
    public class EspecialidadServicio
    {
        private List<Especialidad> _especialidades = new List<Especialidad>();
        private int _contadorId = 1;

        public Especialidad Registrar(string nombre, string descripcion)
        {
            Validador.ValidarCampoRequerido(nombre, "Nombre");
            Validador.ValidarCampoRequerido(descripcion, "Descripcion");

            if (_especialidades.Any(e => e.Nombre.ToLower() == nombre.ToLower()))
                throw new InvalidOperationException($"La especialidad '{nombre}' ya existe.");

            var especialidad = new Especialidad(_contadorId++, nombre, descripcion);
            _especialidades.Add(especialidad);
            Console.WriteLine($"Especialidad registrada: {especialidad}");
            return especialidad;
        }

        public Especialidad BuscarPorId(int id)
        {
            var especialidad = _especialidades.FirstOrDefault(e => e.Id == id);
            if (especialidad == null)
                throw new KeyNotFoundException($"No se encontro especialidad con Id {id}.");
            return especialidad;
        }

        public List<Especialidad> ObtenerTodas()
        {
            return _especialidades;
        }
    }
}
