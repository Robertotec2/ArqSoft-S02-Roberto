using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _categorias = new()
        {
            { "1", new List<string> { "arquitectura", "componente", "descomposicion", "dependencia", "acoplamiento" } },
            { "2", new List<string> { "polimorfismo", "encapsulamiento", "herencia", "abstraccion", "clase" } },
            { "3", new List<string> { "ensamblado", "namespace", "interfaz", "delegado", "middleware" } }
        };

        private string _opcionSeleccionada = "1";

        public void ConfigurarCategoria(string opcion)
        {
            if (_categorias.ContainsKey(opcion))
                _opcionSeleccionada = opcion;
        }

        public string ObtenerPalabraAleatoria()
        {
            var lista = _categorias[_opcionSeleccionada];
            var random = new Random();
            return lista[random.Next(lista.Count)];
        }
    }
}