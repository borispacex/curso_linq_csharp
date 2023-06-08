
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace curso_linq
{
	public class LinqQueries
	{
		private List<Book> librosCollection = new List<Book>();

		public LinqQueries()
		{
			using (StreamReader reader = new StreamReader("books.json"))
			{
				string json = reader.ReadToEnd();
				this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
			}
		}

		public IEnumerable<Book> TodaLaColeccion()
		{
			return this.librosCollection;
		}

		public IEnumerable<Book> LibrosDespuesDel2000()
		{
			// Extension Method
			// return this.librosCollection.Where(p => p.PublishedDate.Year > 2000);
			// Query Expresion
			return from l in this.librosCollection where l.PublishedDate.Year > 2000 select l;
		}
		public IEnumerable<Book> Libros250PaginasTituloInAction()
		{
			// Extension Method
			// return this.librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));
			// Query Expresion
			return from l in this.librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
		}
		public bool TodosLosLibrosTienenStatus()
		{
			return this.librosCollection.All(p => p.Status != string.Empty);
		}
		public bool AlgunLibroPublicado2005()
		{
			return this.librosCollection.Any(p => p.PublishedDate.Year == 2005);
		}
		public IEnumerable<Book> LibrosDePython()
		{
			return this.librosCollection.Where(p => p.Categories.Contains("Python"));
		}
		public IEnumerable<Book> LibrosDeJavaPorNombreAscendente()
		{
			return this.librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
		}
		public IEnumerable<Book> LibrosPaginas450PorPaginasDescendente()
		{
			return this.librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
		}
		public IEnumerable<Book> TresPrimerosLibrosOrdenadosPorFecha()
		{
			return this.librosCollection
				.Where(p => p.Categories.Contains("Java"))
				.OrderByDescending(p => p.PublishedDate.Year)
				.Take(3);
		}
		public IEnumerable<Book> TercerCuartoLibroDeMAs400Pag()
		{
			return this.librosCollection
				.Where(p => p.PageCount > 400)
				.Take(4)	// toma 4
				.Skip(2);	// salta 2
		}
		public IEnumerable<Book> TresPrimeroLibrosDelaColeccion()
		{
			return this.librosCollection.Take(3)
				// .Select(p => new { Title = p.Title, PCount = p.PageCount });
				.Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
		}
		public int CantidadDeLibrosEntre200y500Pag()
		{
			// return this.librosCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).Count();
			return this.librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
		}
		public DateTime FechaDePublicacionMenor()
		{
			return this.librosCollection.Min(p => p.PublishedDate);
		}
		public int NUmeroDePagLibroMayor()
		{
			return this.librosCollection.Max(p => p.PageCount);
		}
		public Book? LibroConMenorNumeroDePaginas()
		{
			return this.librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
		}
		public Book? LibroConFechaPublicacionMasReciente()
		{
			return this.librosCollection.MaxBy(p => p.PublishedDate);
		}
		public int SumaTodasLasPaginasLibrosEntre0y500()
		{
			return this.librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
		}
		public string TitulosDeLibrosDespuesDel2015Concatenados()
		{
			return this.librosCollection.Where(p => p.PublishedDate.Year > 2015)
				.Aggregate("", (TitulosLibros, next) => {
					if (TitulosLibros != string.Empty) TitulosLibros += " - " + next.Title;
					else TitulosLibros += next.Title;
					return TitulosLibros;
				});
		}
		public double PromedioCaracteresTitulo()
		{
			return this.librosCollection.Average(p => p.Title.Length);
		}
		public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAño()
		{
			return this.librosCollection.Where(p => p.PublishedDate.Year > 2000).GroupBy(p => p.PublishedDate.Year);
		}
		public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
		{
			return this.librosCollection.ToLookup(p => p.Title[0], p => p);
		}
		public IEnumerable<Book> LibrosDespuesDel2015ConMasDe500Pag()
		{
			var librosDespuesdel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);
			var librosConMasde400Pag = librosCollection.Where(p => p.PageCount > 500);

			return librosDespuesdel2005.Join(librosConMasde400Pag, p => p.Title, x => x.Title, (p, x) => p);

			//var result = from booksAfter2005 in books
			//			 join booksPublishedAfter2005 in books
			//			 on booksAfter2005.Title equals booksPublishedAfter2005.Title
			//			 where booksAfter2005.PageCount >= 500 && booksPublishedAfter2005.PublishedDate.Year > 2005
			//			 select booksAfter2005;
		}
	}
}
