<div id="top"></div>

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/CharlyMoreno/FifaWorldCupGD6TN">
    <img src="Mundial/LogoWorldCupSquare.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">FifaWorldCup - GD6TN - UTN FRM</h3>

  <p align="center">
    Proyecto desarrollado como Trabajo Final de la Cátedra Gestión de Datos 2022 - Universidad Tecnológica Nacional FRM.
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Contenidos</summary>
  <ol>
    <li>
      <a href="#about-the-project">Proyecto</a>
      <ul>
        <li><a href="#built-with">Tecnologías</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Como Empezar</a>
      <ul>
        <li><a href="#prerequisites">Requisitos</a></li>
        <li><a href="#installation">Instalacion</a></li>
      </ul>
    </li>
    <li><a href="#contact">Autores</a></li>
  </ol>
</details>



## Proyecto

[![Product Name Screen Shot][product-screenshot1]](https://github.com/CharlyMoreno/FifaWorldCupGD6TN)

Este Proyecto nace como idea para presentar de Trabajo Final para la cátedra Gestión de Datos. La idea era poder llevar un registro detallado de todos los Mundiales de Fútbol Masculino realizados hasta la fecha. Para la presentación se trabajó con el MUNDIAL RUSIA 2018, donde se cargaron todos los datos de dicho mundial.

En la base de datos presentada se encontrarán los datos de las 32 selecciones que participaron, de los 736 jugadores que jugaron dicho mundial y además los datos de los 64 partidos disputados.

Posibles agregados:
* Datos estadísticos por Partido como: - Tarjetas Amarillas, TarjetasRojas, Posesión por equipo, Remates al Arco, Pases, Pelotas Perdidas entre otras. 
* Incidencias del partido: Tarjeta Amarilla, Tarjeta Roja,Cambios, Goles, Asistencias, Córner, Etc, especificando en qué minuto y que jugador fue el que lo hizo. 

Datos que podemos obtener:

A modo de ejemplo mostramos las posibles consultas que podemos hacerle a esta base de datos.

* Edad promedio de las selecciones que participaron en el mundial 2018.
   ```sql
   select avg(2018-year(jugador.fechaNacimiento)) as 'Promedio de edad en el mundial 2018' from jugador, jugadorSeleccion, mundial where jugador.id_jugador=jugadorSeleccion id_jugador and jugadorSeleccion.id_mundial=mundial.id_mundial and year(mundial.fechaInicio)=2018;
   ```
* Jugador más joven que jugó el mundial 2018.
   ```sql
    select min(2018-year(jugador.fechaNacimiento)) as 'Promedio de edad en el mundial 2018', jugador.nombre as 'nombre' from jugador, jugadorSeleccion, mundial where jugador.id_jugador=jugadorSeleccion.id_jugador and jugadorSeleccion.id_mundial=mundial.id_mundial and year(mundial.fechaInicio)=2018;
   ```
* Jugadores de Argentina
   ```sql
    SELECT * FROM seleccion AS s,jugadorseleccion AS js,jugador AS j WHERE s.nombre= 'Argentina' AND js.id_seleccion=s.id_seleccion AND js.id_jugador=j.id_jugador;
   ```
* Jugador más grande que jugó el mundial 2018.
   ```sql
        select j.nombre, j.fechaNacimiento from jugador j, jugadorseleccion j2, mundial m
        where j.id_jugador = j2.id_jugador and j2.id_mundial = m.id_mundial and m.fechaInicio
        like '2018%' group by j.id_jugador order by j.fechaNacimiento asc limit 1;
   ```
* Jugador más alto que jugó el mundial 2018.
   ```sql
        select j.nombre, j.altura from jugador j, jugadorseleccion j2,
        mundial m where j.id_jugador = j2.id_jugador and j2.id_mundial = m.id_mundial and
        m.fechaInicio like '2018%' and j.altura = (select max(j.altura) from jugador j,
        jugadorseleccion j2, mundial m where j.id_jugador = j2.id_jugador and j2.id_mundial =
        m.id_mundial);
   ```

Y así se pueden obtener infinidad de datos estadísticos pertencientes a un mundial.

[![Product Name Screen Shot][product-screenshot2]](https://github.com/CharlyMoreno/FifaWorldCupGD6TN)

### Tecnologías

Tecnologías usadas en este proyecto.

* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [MySQL](https://www.mysql.com/)

<!-- GETTING STARTED -->
## Como Empezar

Si queremos ejecutar este programa en nuestro entorno local debemos hacer lo siguiente.

### Requisitos

Tener instalado [Visual Studio 2019](https://visualstudio.microsoft.com/es/downloads/) o versiones superiores
Tener instalado y ejecutando una instancia de [MySQL](https://www.mysql.com/downloads/)

### Instalación

_Dicho proyecto está hecho para trabajar con una Base de Datos MYSQL local, pero de igual forma se puede sustituir por una Base de Datos Online_

1. Cargar Script [scriptMundial](https://github.com/CharlyMoreno/FifaWorldCupGD6TN/blob/master/ScriptBD/scriptMundial.sql)
2. Modificar [App.Config] (https://github.com/CharlyMoreno/FifaWorldCupGD6TN/blob/master/Mundial/Mundial/App.config)
    Aca debemos configurar el ConnectionString con las credenciales válidas para poder acceder a nuestra base de datos, ya sea local o en línea.
   ```xml
   <add key ="ConnectionString" value ="server=localhost;database=fifaworldcup;userid=root;password=root"/>
   ```
3. Compilar proyecto y ejecutar.


<!-- CONTACT -->
## Autores

FifaWorldCup - GD6TN

Universidad Tecnológica Nacional - FRM

Gestión de Datos - 2022

* Carlos Alejandro Moreno 
* Tomás Izuel
* Julián Di Rocco
* Dario Angel Jose Lopez

Proyecto: [https://github.com/CharlyMoreno/FifaWorldCupGD6TN](https://github.com/CharlyMoreno/FifaWorldCupGD6TN)


<p align="right">(<a href="#top">Vovler Arriba</a>)</p>


[product-screenshot1]: https://i.imgur.com/vDqMIf0.jpeg
[product-screenshot2]: https://i.imgur.com/0dGfiGn.jpeg
