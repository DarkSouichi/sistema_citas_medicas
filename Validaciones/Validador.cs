namespace SistemaCitas.Validaciones
{
    // DRY: puse todas las validaciones aqui para no repetirlas en cada servicio
    public static class Validador
    {

        public static void ValidarCampoRequerido(string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"El campo '{nombreCampo}' es obligatorio.");
        }

        public static void ValidarFechaFutura(DateTime fecha)
        {
            if (fecha <= DateTime.Now)
                throw new ArgumentException("La fecha de la cita debe ser en el futuro.");
        }

        public static void ValidarNoNulo(object objeto, string nombreObjeto)
        {
            if (objeto == null)
                throw new ArgumentNullException($"'{nombreObjeto}' no puede ser nulo.");
        }
    }
}
