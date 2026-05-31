using SistemaCitas.Interfaces;
using SistemaCitas.Modelos;
using SistemaCitas.Validaciones;

namespace SistemaCitas.Servicios
{

    public class CitaServicio
    {
        private List<Cita> _citas = new List<Cita>();
        private int _contadorId = 1;

        private readonly IRecordatorio _recordatorio;

        public CitaServicio(IRecordatorio recordatorio)
        {
            Validador.ValidarNoNulo(recordatorio, "Recordatorio");
            _recordatorio = recordatorio;
        }

        public Cita Agendar(Paciente paciente, Medico medico, DateTime fechaHora)
        {

            Validador.ValidarNoNulo(paciente, "Paciente");
            Validador.ValidarNoNulo(medico, "Medico");
            Validador.ValidarFechaFutura(fechaHora);

            bool medicoOcupado = _citas.Any(c =>
                c.Medico.Id == medico.Id &&
                c.FechaHora == fechaHora &&
                c.Estado == EstadoCita.Programada);

            if (medicoOcupado)
                throw new InvalidOperationException($"El Dr. {medico.Nombre} ya tiene una cita a esa hora.");

            var cita = new Cita(_contadorId++, paciente, medico, fechaHora);
            _citas.Add(cita);
            Console.WriteLine($"Cita agendada: {cita}");
            return cita;
        }

        public void Cancelar(int citaId)
        {
            var cita = BuscarPorId(citaId);

            if (cita.Estado == EstadoCita.Cancelada)
                throw new InvalidOperationException("La cita ya fue cancelada.");

            cita.Estado = EstadoCita.Cancelada;
            Console.WriteLine($"Cita #{citaId} cancelada.");
        }

        public void Reprogramar(int citaId, DateTime nuevaFechaHora)
        {
            Validador.ValidarFechaFutura(nuevaFechaHora);

            var cita = BuscarPorId(citaId);

            if (cita.Estado == EstadoCita.Cancelada)
                throw new InvalidOperationException("No se puede reprogramar una cita cancelada.");

            bool medicoOcupado = _citas.Any(c =>
                c.Medico.Id == cita.Medico.Id &&
                c.FechaHora == nuevaFechaHora &&
                c.Estado == EstadoCita.Programada &&
                c.Id != citaId);

            if (medicoOcupado)
                throw new InvalidOperationException($"El Dr. {cita.Medico.Nombre} ya tiene una cita a esa nueva hora.");

            cita.FechaHora = nuevaFechaHora;
            cita.Estado = EstadoCita.Reprogramada;
            Console.WriteLine($"Cita #{citaId} reprogramada para {nuevaFechaHora:dd/MM/yyyy HH:mm}");
        }

        public void EnviarRecordatorio(int citaId)
        {
            var cita = BuscarPorId(citaId);

            if (cita.Estado == EstadoCita.Cancelada)
                throw new InvalidOperationException("No se puede enviar recordatorio de una cita cancelada.");

            _recordatorio.EnviarRecordatorio(cita);
        }

        public List<Cita> ConsultarPorPaciente(int pacienteId)
        {
            return _citas.Where(c => c.Paciente.Id == pacienteId).ToList();
        }

        public List<Cita> ConsultarPorMedico(int medicoId)
        {
            return _citas.Where(c => c.Medico.Id == medicoId).ToList();
        }

        private Cita BuscarPorId(int id)
        {
            var cita = _citas.FirstOrDefault(c => c.Id == id);
            if (cita == null)
                throw new KeyNotFoundException($"No se encontro cita con Id {id}.");
            return cita;
        }
    }
}
