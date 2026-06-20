namespace GradoCeroV1.Services
{
    public class EstadoSesion
    {
        public bool EstaLogueado { get; set; } = false;

        public void IniciarSesion()
        {
            EstaLogueado = true;
        }

        public void CerrarSesion()
        {
            EstaLogueado = false;
        }
    }
}
