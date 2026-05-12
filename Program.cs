using Ahorcado;

var repositorio = new PalabrasEnMemoria();
bool continuar = true;

while (continuar)
{
    string seleccion = ConsolaUI.SolicitarCategoria();
    repositorio.ConfigurarCategoria(seleccion);

    var motor = new MotorAhorcado(repositorio);
    var ui = new ConsolaUI(motor);

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();
        char letra = ui.PedirLetra();

        if (letra == ' ') continue;

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra. Presiona una tecla...");
            Console.ReadKey();
            continue;
        }

        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();

    if (motor.Ganado())
        ui.MostrarMensaje($"\n¡Felicidades! Ganaste. La palabra era: {motor.PalabraSecreta}");
    else
        ui.MostrarMensaje($"\nGame Over. La palabra era: {motor.PalabraSecreta}");

    continuar = ui.PreguntarOtraVez();
}