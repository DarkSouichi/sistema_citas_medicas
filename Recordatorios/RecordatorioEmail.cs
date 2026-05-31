using SistemaCitas.Interfaces;
using SistemaCitas.Modelos;

namespace SistemaCitas.Recordatorios
{

    public class RecordatorioEmail : IRecordatorio
    {
        public void EnviarRecordatorio(Cita cita)
        {
            // por ahora solo simulamos el envio con un mensaje en consola
            // en el futuro se conectaria con un servicio de email real
            Console.WriteLine($"[EMAIL] Recordatorio enviado a {cita.Paciente.Email}");
            Console.WriteLine($"  -> Cita con Dr. {cita.Medico.Nombre} el {cita.FechaHora:dd/MM/yyyy} a las {cita.FechaHora:HH:mm}");
        }
    }
}
