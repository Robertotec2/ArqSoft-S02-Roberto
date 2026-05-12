using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class MotorAhorcado
    {
        private readonly string _palabraSecreta;
        private readonly List<char> _letrasUsadas = new();
        private int _intentosRestantes = 6;

        // Propiedades
        public string PalabraSecreta => _palabraSecreta;
        public List<char> LetrasUsadas => _letrasUsadas;
        public int IntentosRestantes => _intentosRestantes;

        public MotorAhorcado(IRepositorioPalabras repositorio)
        {
            _palabraSecreta = repositorio.ObtenerPalabraAleatoria();
        }

        // Métodos de lógica
        public bool LetraYaUsada(char letra) => _letrasUsadas.Contains(letra);

        public bool EsLetraCorrecta(char letra) => _palabraSecreta.Contains(letra);

        public void RegistrarLetra(char letra)
        {
            if (LetraYaUsada(letra)) return;

            _letrasUsadas.Add(letra);

            if (!EsLetraCorrecta(letra))
                _intentosRestantes--;
        }

        public bool Ganado()
        {
            // Usando LINQ para mayor claridad: ¿Están todas las letras de la palabra en la lista de usadas?
            return _palabraSecreta.All(c => _letrasUsadas.Contains(c));
        }

        public bool Perdido() => _intentosRestantes <= 0;
    }
}