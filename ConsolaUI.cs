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

        public void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            MostrarAhorcado();

            Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");

            Console.Write("Palabra: ");
            foreach (char c in _motor.PalabraSecreta)
            {
                Console.Write(_motor.LetrasUsadas.Contains(c) ? $"{c} " : "_ ");
            }
            Console.WriteLine();
        }

        public char PedirLetra()
        {
            Console.Write("\nIngresa una letra: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) return ' ';

            return char.ToLower(input[0]);
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