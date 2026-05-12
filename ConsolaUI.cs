using System;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;

        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }

        public static string SolicitarCategoria()
        {
            Console.Clear();
            Console.WriteLine("=== ELIJA UNA CATEGORÍA ===");
            Console.WriteLine("1. Arquitectura");
            Console.WriteLine("2. POO");
            Console.WriteLine("3. .NET");
            Console.Write("\nSeleccione (1-3): ");
            return Console.ReadLine();
        }

        public void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            MostrarAhorcado();

            Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");

            // Se mantiene el método de las pistas
            if (_motor.MostrarPista)
                Console.WriteLine($"Pista: la palabra empieza con '{_motor.PalabraSecreta[0]}'");

            Console.Write("Palabra: ");
            foreach (char c in _motor.PalabraSecreta)
                Console.Write(_motor.LetrasUsadas.Contains(c) ? $"{c} " : "_ ");

            Console.WriteLine();
        }

        public char PedirLetra()
        {
            Console.Write("\nIngresa una letra: ");
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? ' ' : char.ToLower(input[0]);
        }

        public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);

        public bool PreguntarOtraVez()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            return Console.ReadLine()?.ToLower() == "s";
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                "  -----\n  |   |\n      |\n      |\n      |\n      |\n=========",
                "  -----\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                "  -----\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                "  -----\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                "  -----\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                "  -----\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                "  -----\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
            };
            int indice = Math.Clamp(6 - _motor.IntentosRestantes, 0, 6);
            Console.WriteLine(etapas[indice]);
        }
    }
}