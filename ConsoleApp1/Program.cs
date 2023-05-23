using DataAccessRepoDb.Entities;
using DataAccessRepoDB.Business;
using Microsoft.Data.SqlClient;
using RepoDb;
using System;
using System.Diagnostics.Metrics;

Console.WriteLine("Data Access with RepoDB!");

var movies = new MovieBusiness();

Console.WriteLine("Elija una opcion para ejecutar la funcion:");
Console.WriteLine("1.InsertarMovieModo1");
Console.WriteLine("2.InsertarMovieModo2");
Console.WriteLine("3.TraerMovies");
Console.WriteLine("4.UpdatearMovie");
Console.WriteLine("5.DeletearMovies");
var opcion = Console.ReadLine();
switch (Convert.ToInt32(opcion))
{
    case 1:
        movies.InsertarMovieModo1();
        break;
    case 2:
        movies.InsertarMovieModo2();
        break;
    case 3:
        var movie = movies.TraerMovies();
        break;
    case 4:
        movies.UpdatearMovie();
        break;
    case 5:
        movies.DeletearMovies();
        break;
}



Console.ReadKey();