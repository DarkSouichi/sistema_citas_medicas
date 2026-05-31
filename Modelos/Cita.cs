namespace SistemaCitas.Modelos
{
    public enum EstadoCita
    {
        Programada,
        Cancelada,
        Reprogramada
    }

    public class Cita
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime FechaHora { get; set; }
        public EstadoCita Estado { get; set; }

        public Cita(int id, Paciente paciente, Medico medico, DateTime fechaHora)
        {
            Id = id;
            Paciente = paciente;
            Medico = medico;
            FechaHora = fechaHora;
            Estado = EstadoCita.Programada;
        }

        public override string ToString()
        {
            return $"Cita #{Id} | {Paciente.Nombre} con Dr. {Medico.Nombre} | {FechaHora:dd/MM/yyyy HH:mm} | Estado: {Estado}";
        }
    }
}
