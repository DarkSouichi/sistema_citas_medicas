using SistemaCitas.Interfaces;
using SistemaCitas.Modelos;

namespace SistemaCitas.Recordatorios
{
    public class RecordatorioSMS : IRecordatorio
    {
        public void EnviarRecordatorio(Cita cita)
        {
            // tambien simulado
            Console.WriteLine($"[SMS] Recordatorio enviado al {cita.Paciente.Telefono}");
            Console.WriteLine($"  -> Cita con Dr. {cita.Medico.Nombre} el {cita.FechaHora:dd/MM/yyyy HH:mm}");
        }
    }
}
