using SistemaCitas.Modelos;
using SistemaCitas.Recordatorios;
using SistemaCitas.Servicios;

// =============================================
// Sistema de Gestion de Citas Medicas
// Estudiante: Welinton Corporan
// =============================================

Console.WriteLine("=== SISTEMA DE CITAS MEDICAS ===\n");

var especialidadServicio = new EspecialidadServicio();
var pacienteServicio     = new PacienteServicio();
var medicoServicio       = new MedicoServicio();
var citaServicio         = new CitaServicio(new RecordatorioEmail()); 

Console.WriteLine("-- Registrando especialidades --");
var cardiologia  = especialidadServicio.Registrar("Cardiologia",  "Especialidad del corazon");
var pediatria    = especialidadServicio.Registrar("Pediatria",    "Atencion a ninos");

Console.WriteLine("\n-- Registrando medicos --");
var doctorRamirez = medicoServicio.Registrar("Carlos Ramirez", "c.ramirez@clinica.com", cardiologia);
var doctoraMena   = medicoServicio.Registrar("Ana Santana",       "a.Santana@clinica.com",    pediatria);

Console.WriteLine("\n-- Registrando pacientes --");
var paciente1 = pacienteServicio.Registrar("Juan Perez",  "001-1234567-8", "809-555-1111", "juan@email.com");
var paciente2 = pacienteServicio.Registrar("Maria Peguero", "001-9876543-2", "809-555-2222", "maria@email.com");

Console.WriteLine("\n-- Agendando citas --");
var fecha1 = DateTime.Now.AddDays(3).Date.AddHours(9); 
var fecha2 = DateTime.Now.AddDays(5).Date.AddHours(11);

var cita1 = citaServicio.Agendar(paciente1, doctorRamirez, fecha1);
var cita2 = citaServicio.Agendar(paciente2, doctoraMena,   fecha2);

Console.WriteLine("\n-- Enviando recordatorio --");
citaServicio.EnviarRecordatorio(cita1.Id);

Console.WriteLine("\n-- Citas del paciente Juan Perez --");
var citasJuan = citaServicio.ConsultarPorPaciente(paciente1.Id);
citasJuan.ForEach(c => Console.WriteLine("  " + c));

Console.WriteLine("\n-- Citas del Dr. Ramirez --");
var citasDrRamirez = citaServicio.ConsultarPorMedico(doctorRamirez.Id);
citasDrRamirez.ForEach(c => Console.WriteLine("  " + c));

Console.WriteLine("\n-- Reprogramando cita --");
var nuevaFecha = DateTime.Now.AddDays(7).Date.AddHours(14);
citaServicio.Reprogramar(cita1.Id, nuevaFecha);

Console.WriteLine("\n-- Cancelando cita --");
citaServicio.Cancelar(cita2.Id);

Console.WriteLine("\n-- Estado final de citas de Juan --");
citaServicio.ConsultarPorPaciente(paciente1.Id).ForEach(c => Console.WriteLine("  " + c));

Console.WriteLine("\n-- Estado final de citas de Maria --");
citaServicio.ConsultarPorPaciente(paciente2.Id).ForEach(c => Console.WriteLine("  " + c));

Console.WriteLine("\n-- Demostrando OCP: ahora usamos SMS en vez de Email --");
var citaServicioSMS = new CitaServicio(new RecordatorioSMS());
var cita3 = citaServicioSMS.Agendar(paciente1, doctoraMena, DateTime.Now.AddDays(10).Date.AddHours(10));
citaServicioSMS.EnviarRecordatorio(cita3.Id);

Console.WriteLine("\n=== FIN DEL PROGRAMA ===");
