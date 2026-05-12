using Ahorcado;

var repositorio = new PalabrasEnMemoria();
bool jugarDeNuevo = true;

while (jugarDeNuevo)
{
    var motor = new MotorAhorcado(repositorio);
    var ui = new ConsolaUI(motor);

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();
        char letra = ui.PedirLetra();

        if (letra == ' ') continue;

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra. Presiona cualquier tecla...");
            Console.ReadKey();
            continue;
        }

        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();

    if (motor.Ganado())
        ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
    else
        ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

    jugarDeNuevo = ui.PreguntarOtraVez();
}