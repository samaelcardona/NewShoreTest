# NewShoreTechnicalTest

Proyecto creado apartir del enunciado de la prueba de desarrollo de NewShore,
La cual solicita un itinerario para un viaje aereo de un punto a otro,
Nos solicitan calcular la ruta de acuerdo a las paradas y los vuelos de conexion 
que se deban hacer. para el caculo se utiliza un algoritmo en anchura o BFS,
En general es una Api Restful con .Net core, Tiene una arquitectura por capas, 
utiliza entityframework como orm, base de datos SQL SERVER.

## Instalación

1. Clone el repositorio: `git clone https://github.com/samaelcardona/NewShoreTest.git`
2. Abra el proyecto con VisualStudio y en la carpeta scripts encontrara un script para crear la base de datos.
3. Ejecute el script en dos pasos:
	- ejecute la primera linea para crear la base de datos,
	- ejecute el resto de codigo para crear las tablas. 
4. EJecute la solucion. 

## Uso

Cuando ejecute la solucion puede probarlo con el UI de swagger 
(En la carpeta Models/ApiModels y la clase JsonRequestBodySchemaFilter 
podra cambiar los parametros para probarla con swagger), 
o puede realizar peticiones con postman o la aplicacion de preferencia
para pruebas y documentacion de API's.
