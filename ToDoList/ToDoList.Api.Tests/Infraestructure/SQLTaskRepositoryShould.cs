namespace ToDoList.Api.Tests.Infrastructure {
	[TestFixture]
	public class SQLTaskRepositoryShould {
		[SetUp]
		public void Setup()
		{
		}

		//esta clase no tiene sentido como test unitario, deberia insertar en la BD y luego comprobar por otro lado que se ha insertado, pero tiene sentido hacer pruebas de un CRUD?????
		// Tendría que abrir un trnsacción borrar las tablas implñicadas, hacer las pruebas (si hay que insertar algo insertarlo) y luego hacer rollback a la tranasaccion.
		[Test]
		public void Should_not_exist()
		{
			Assert.True(true);
		}
	}
}
