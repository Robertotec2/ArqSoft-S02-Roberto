using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class Juego
    {
        private readonly List<string> _palabras = new()
        {
            "arquitectura", "interfaz", "polimorfismo",
            "encapsulamiento", "herencia"
        };

        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        public Juego()
        {
            var random = new Random();
            _palabraSecreta = _palabras[random.Next(_palabras.Count)];
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            while (_intentosRestantes > 0)
            {
                MostrarTablero();

                if (VerificarVictoria())
                {
                    Console.WriteLine($"\n¡Ganaste! La palabra era: {_palabraSecreta}");
                    PreguntarReinicio();
                    return;
                }

                Console.Write("\nIngresa una letra: ");
                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(input)) continue;

                char letra = input[0];

                if (_letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("Ya usaste esa letra. Presiona cualquier tecla...");
                    Console.ReadKey();
                    continue;
                }

                _letrasUsadas.Add(letra);

                if (!_palabraSecreta.Contains(letra))
                    _intentosRestantes--;
            }

            MostrarTablero();
            Console.WriteLine($"\nPerdiste. La palabra era: {_palabraSecreta}");
            PreguntarReinicio();
        }

        private bool VerificarVictoria()
        {
            return _palabraSecreta.All(c => _letrasUsadas.Contains(c));
        }

        private void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            MostrarAhorcado();
            Console.WriteLine($"Intentos restantes: {_intentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");
            Console.Write("Palabra: ");

            foreach (char c in _palabraSecreta)
                Console.Write(_letrasUsadas.Contains(c) ? $"{c} " : "_ ");

            Console.WriteLine();
        }

        private void PreguntarReinicio()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                new Juego().Jugar();
            }
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
            Console.WriteLine(etapas[6 - _intentosRestantes]);
        }
    }
}