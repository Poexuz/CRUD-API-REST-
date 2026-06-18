
Guia de posibles Requests

-----------------------------------------------------------

Usuario:

// Mostrar todos los usuarios
GET
https://localhost:tuPuerto/Usuario


// Crear usuario
POST (Agregar json con: Nombre y mail)
https://localhost:tuPuerto/Usuario


// Cambiar usuario
PUT (Cambios en json)
https://localhost:tuPuerto/Usuario/1


// Eliminar usuario
DELETE
https://localhost:tuPuerto/Usuario/3

-----------------------------------------------------------

Juego:

// Mostrar todos los usuarios
GET
https://localhost:tuPuerto/Juego


// Crear usuario
POST (Agregar json con: Nombre y descripcion)
https://localhost:tuPuerto/Juego


// Cambiar usuario en id tal
PUT (Cambios en json)
https://localhost:tuPuerto/Juego/1


// Eliminar usuario en id tal
DELETE 
https://localhost:tuPuerto/Juego/3

-----------------------------------------------------------

Coleccion:

// Para mostrar todo
GET all
https://localhost:tuPuerto/Coleccion


// Para mostrar todos los juegos de un usuario
GET Usuarios (Agregar numero del usuario a Query parameters)
https://localhost:tuPuerto/Coleccion/usuario/{id}


// Para mostrar todos los usuarios qu tienen el juego
GET Juego (Agregar numero del juego a Query parameters)
https://localhost:tuPuerto/Coleccion/Juego/{id}


// Agregar un juego a un usuario
POST (Agregar json con: UsuarioId y JuegoId)
https://localhost:tuPuerto/Coleccion


// Cambiar Coleccion
PUT (Cambios en json)
https://localhost:tuPuerto/Coleccion


// Eliminar Coleccion
DELETE (Cambios en json)
https://localhost:tuPuerto/Coleccion

-----------------------------------------------------------


