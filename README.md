Juegos de Consola en C#

Este proyecto es una pequeña colección de juegos clásicos desarrollados para la carrera de Ingeniería de Software El sistema permite elegir entre jugar al Ahorcado o a la Viborita desde el inicio
Juegos incluidos

    Ahorcado Juego de adivinar palabras organizado por categorías

    Viborita Versión del Snake que utiliza listas enlazadas para manejar el cuerpo

Detalles de estructura

    Se usa la interfaz IMotorJuego para estandarizar la lógica base de ambos juegos

    La interfaz visual de la consola está separada de la lógica interna de los motores

    El proyecto está hecho en C# siguiendo principios de programación orientada a objetos

El diagnóstico
Situación Principio violado
Juego tiene 4 responsabilidades mezcladas SRP — Single Responsibility
Principle
Las palabras están hardcodeadas en la clase DIP — Dependency Inversion
Principle
Agregar un juego nuevo requiere modificar
Juego OCP — Open/Closed Principle
