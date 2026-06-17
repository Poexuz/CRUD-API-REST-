vamos a hacer un mapa mental de una Api rest en visual studio con C# usando sqlite como base de datos y thunderclient para interactuar.
tiene que tener:

2 modelos
2 Dto
2 service
2 controllers
El resultado debe ser capas de usar métodos http CRUD (Create Read Update Delete)

-----------------------------------------------------------

Modelo 1: Usuario
ID
Nombre
Mail
Lista<Juegos>
Saldo

Dto 1: Usuario
Nombre
Mail
Lista<Juegos>
Saldo

Service 1: Usuario
Constructor
UsoDTO
Add
Read
Update
Delete
Controller 1: Usuario
Acceso a todos los métodos de service


-----------------------------------------------------------
Modelo 1: Juego
ID
Nombre
Descripción
Tags (Enum)
Costo

Dto 1: Usuario
Nombre
Descripcion
Costo

Service 1: Usuario
Constructor
UsoDTO
Add
Read
Update
Delete

Controller 1: Usuario
Acceso a todos los métodos de service
---
