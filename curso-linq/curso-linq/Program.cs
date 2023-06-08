// See https://aka.ms/new-console-template for more information
using curso_linq;


LinqQueries queries = new LinqQueries();

// Toda la coleccion
// ImprimirValores(queries.TodaLaColeccion());

// Libros despues del 2000
// ImprimirValores(queries.LibrosDespuesDel2000());

// Libros que tengan más de 250 páginas y el título contenga las palabras in Action
// ImprimirValores(queries.Libros250PaginasTituloInAction());

// Todos los libros tienen status
// Console.WriteLine($"Todos los libros tienen status: {queries.TodosLosLibrosTienenStatus()}");

// Alguno de los libros fue publicado en 2005
// Console.WriteLine($"Algun libro publicado en 2005: {queries.AlgunLibroPublicado2005()}");

// Libros que contengan Python
// ImprimirValores(queries.LibrosDePython());

// Libros que categoria que contenga Java ordenados Ascendente
// ImprimirValores(queries.LibrosDeJavaPorNombreAscendente());

// Libros que tengan mas de 450 paginas, ordenados por numero de paginas en forma descendente
// ImprimirValores(queries.LibrosPaginas450PorPaginasDescendente());

// 3 libros con fecha de publicación más reciente que estén categorizados en Java.
// ImprimirValores(queries.TresPrimerosLibrosOrdenadosPorFecha());

// tercer y cuarto libro de los que tengan más de 400 páginas
// ImprimirValores(queries.TercerCuartoLibroDeMAs400Pag());

// Select selecciona el título y el número de páginas de los primeros 3 libros de la colección.
// ImprimirValores(queries.TresPrimeroLibrosDelaColeccion());

// Con el operador Count, retorna el número de libros que tengan entre 200 y 500 páginas.
// Console.WriteLine($"Cantidad libros que tengan entre 200 y 500 páginas: {queries.CantidadDeLibrosEntre200y500Pag()}");

// Fecha de publicacion menor de todos los libros
//Console.WriteLine($"Fecha menor de publicacion: {queries.FechaDePublicacionMenor()}");

// NUmero de paginas del libro con mayor número de páginas en la colección.
//Console.WriteLine($"numero de paginas del libro con mayor numero paginas: {queries.NUmeroDePagLibroMayor()}");

// Libro con menor numero de paginas
//var libroMenorPag = queries.LibroConMenorNumeroDePaginas();
//Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");

// Libro con la fecha de publicación más reciente
//var libroFechaReciente = queries.LibroConFechaPublicacionMasReciente();
//Console.WriteLine($"{libroFechaReciente.Title} - {libroFechaReciente.PublishedDate}");

// Sumar cantidad de paginas de los libros que tengas 0 a 500 paginas
//Console.WriteLine($"Cantidad de libros que tengan 0 a 500 paginas: {queries.SumaTodasLasPaginasLibrosEntre0y500()}");

// Libros publicados despues del 2015
//Console.WriteLine($"Libros despues del 2015: {queries.TitulosDeLibrosDespuesDel2015Concatenados()}");

// Promedio de caracteres del titulo de los libros
//Console.WriteLine($"Promedio de caracteres titulo: {queries.PromedioCaracteresTitulo()}");

// Libros publicados despues del 2000 agrupados por Año
//ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAño());

// Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookup = queries.DiccionarioDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'A');

// Libros filtrados con la clausula join
ImprimirValores(queries.LibrosDespuesDel2015ConMasDe500Pag());


void ImprimirValores(IEnumerable<Book> listadelibros)
{
	Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
	foreach (var item in listadelibros)
	{
		Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
	}
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
	foreach (var grupo in ListadeLibros)
	{
		Console.WriteLine("");
		Console.WriteLine($"Grupo: {grupo.Key}");
		Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
		foreach (var item in grupo)
		{
			Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
		}
	}
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
	Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
	foreach (var item in ListadeLibros[letra])
	{
		Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
	}
}