# Ingenieria Web
## Enero-Junio 2019 Semestre 102

## Ing. Jorge Moya

### Examen parcial 1 

* Realiza un CRUD del siguiente modelo. 
* Inicializa la  base de datos de sqlite y agrega la tabla ganados.
* Genera un controlador base con sus respectivas acciones para Index, Crear, Detalles , Editar y Borrar
* Genera todas las vistas correspondientes. 
* Genera una clase repositorio y agrega todas las acciones correspondientes. 
* Sube tus resultados a git, si tienes almenos 3 commits tendrás puntos extras. 


Modelo
```
Ganados {
    int id,
    string tipoanimal , // vaca, pollo o chivo
    string nombre , // why not
    int peso , // entero en Kilos
    string color , 
}
 
```


Commandos de git
```bash
## inicializa el repositorio
git init
## agrega todos los archivos
git add .
## Realiza un commit 
git commit -m 'Pregunta 1 del examen '
## Enlaza tu repositorio con el creado para este examen (git@git ... es el url de tu proyecto)
git remote add origin git@gl01.itculiacan.edu.mx:jmoya/s100movilesp1r2.git
## Sube al final 
git push origin master

```

Commandos de dotnet
```
dotnet new 
## lea la ayuda para saber que tipo de proyecto crear 
dotnet new -h
## lea ayuda para los generadores de codigo, pon atencion a los parametros lo usaras par acrear controladores y vistas
dotnet aspnet-codegenerator -h

```