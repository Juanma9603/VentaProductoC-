using System;
using MySql.Data.MySqlClient;
using entityLayer;
using dataAccessLayer;



namespace VentaProducto
{
	class program
	{
		public static void Main(string[] args)
		{
			Producto objproducto = new Producto();
			Venta objventa = new Venta();
			Conexion.Conectar();





            String option;
            int valor;
			double valor1;
            Boolean seguir=true;

			while (seguir) {
				Console.WriteLine("vas a utilizar el programa");
				Console.WriteLine("1.si");
				Console.WriteLine("2.no");
				option = Console.ReadLine();
				valor = Convert.ToInt16(option);

				if (valor == 1)
				{
					Console.WriteLine("Hello World!");
					seguir = false;

					Console.WriteLine("Que proceso deseas realizar?");
					Console.WriteLine("1. Administar Productos");
					Console.WriteLine("2. Consultar Venta");
					Console.WriteLine("3. Registrar Venta");
					Console.WriteLine("4. Cancelar Venta");
					Console.WriteLine("5. Listar Venta");

					int option1 = Convert.ToInt32(Console.ReadLine());
					switch (option1)
					{

						case 1:

							Console.WriteLine("Administrar Productos");
							Console.WriteLine("1. Consultar Productos");
							Console.WriteLine("2. Registrar Productos");
							Console.WriteLine("3. Modificar Productos");
							Console.WriteLine("4. Eliminar Productos");
							Console.WriteLine("5. Listar Productos");

							int option2 = Convert.ToInt32(Console.ReadLine());

							switch (option2)

							{
								case 1:
									Console.WriteLine("Consultar");
									Console.WriteLine("Indica ID del producto");
									Console.WriteLine(new ProductoDAO().Consultar(Convert.ToInt16(Console.ReadLine())));

									break;

								case 2:

									Console.WriteLine("Registrar");
									Console.WriteLine("Indica Nombre del producto");
									objproducto.setName(Console.ReadLine());
									Console.WriteLine("Indica el Precio");
									valor1 = Convert.ToDouble(Console.ReadLine());
									objproducto.setPrecio(valor1);

									Console.WriteLine(objproducto.ToString());

									new ProductoDAO().Registrar(objproducto);
									

									break;

								case 3:

									Console.WriteLine("Modificar");
									Console.WriteLine("Indica ID del producto");
									objproducto.setID(Convert.ToInt16(Console.ReadLine()));
									Console.WriteLine("Indica Nombre del producto");
									objproducto.setName(Console.ReadLine());
									Console.WriteLine("Indica el Precio");
									valor1 = Convert.ToDouble(Console.ReadLine());
									objproducto.setPrecio(valor1);

									Console.WriteLine(objproducto.ToString());

									new ProductoDAO().Modificar(objproducto);


									break;

								case 4:
									Console.WriteLine("Eliminar");
									Console.WriteLine("Indica ID del producto");
									new ProductoDAO().Eliminar(Convert.ToInt16(Console.ReadLine()));

									break;

								default:
									break;
							}

							break;

						default:
							break;

							
					}


				}
				else if (valor == 2)
				{
					Console.WriteLine("Saliste, vuleve pronto");
					seguir = false;
				}
				else
				{
					Console.WriteLine("vuelve a intentarlo");
					seguir = true;
				}
			}

			/*Console.ReadKey();
			objproducto.setID(1);
			objproducto.setName("pan");
			objproducto.setPrecio(1.0);
			objproducto.setCantidad(2);*/

			
			
		}
	}
}
