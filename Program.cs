using Ahorcado;

Console.WriteLine("¿Qué juego quieres jugar?");
Console.WriteLine("  1 — Ahorcado");
Console.WriteLine("  2 — Viborita");
Console.Write("Opción: ");
var opcion = Console.ReadLine();

if (opcion == "2")
{
    var motor = new Ahorcado.MotorViborita();
    var ui = new Ahorcado.ConsolaUIViborita(motor);

    Console.CursorVisible = false;

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();
        var tecla = ui.LeerTecla();

        if (tecla == ConsoleKey.Q) break;
        if (tecla != ConsoleKey.NoName)
            motor.CambiarDireccion(tecla);

        motor.Avanzar();
        Thread.Sleep(150); // velocidad del juego
    }

    ui.MostrarTablero();
    ui.MostrarMensaje(motor.Ganado()
        ? "\n¡Ganaste! Llegaste a 10 puntos."
        : "\nGame over.");
}
else
{
    // Codigo anterior del ahorcado
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
}