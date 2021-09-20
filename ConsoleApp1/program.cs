using System;
using MySql.Data.MySqlClient;
using entityLayer;
using dataAccessLayer;
using System.Collections.Generic;

namespace VentaProducto
{
	class program
	{
		public static void Main(string[] args)
		{
			Producto objproducto = new Producto();
			Venta objventa = new Venta();
			Conexion.Conectar();
			List<Producto> listproductos = new List<Producto> ();
			List<Venta> listadeventas = new List<Venta>();
			List<DetalleVenta> listadetalle = new List<DetalleVenta>();





            int valor;
			double valor1;
            Boolean seguir=true;

			while (seguir) {
				Console.WriteLine("vas a utilizar el programa");
				Console.WriteLine("1.si");
				Console.WriteLine("2.no");
				
				valor = Convert.ToInt16(Console.ReadLine());

				if (valor == 1)
				{
					Console.WriteLine("Que proceso deseas realizar?");
					Console.WriteLine("1. Administar Productos");
					Console.WriteLine("2. Consultar Venta");
					Console.WriteLine("3. Registrar Venta");
					Console.WriteLine("4. Cancelar Venta");
					Console.WriteLine("5. Listar Venta");

					
					switch (Convert.ToInt32(Console.ReadLine()))
					{

						case 1:

							Console.WriteLine("Administrar Productos");
							Console.WriteLine("1. Consultar Productos");
							Console.WriteLine("2. Registrar Productos");
							Console.WriteLine("3. Modificar Productos");
							Console.WriteLine("4. Eliminar Productos");
							Console.WriteLine("5. Listar Productos");

							

							switch (Convert.ToInt32(Console.ReadLine()))

							{
								case 1:
									Console.WriteLine("Consultar");
									Console.WriteLine("Indica ID del producto");
									Producto objcosnproducto = new ProductoDAO().Consultar(Convert.ToInt16(Console.ReadLine()));
									if (objcosnproducto.getID() == 0 && objcosnproducto.getPrecio()==0.0)
									{
										Console.WriteLine("Vuelve a intentarlo");
									}
									else {
										Console.WriteLine(objcosnproducto);
									}

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
									Producto objmodproducto = new ProductoDAO().Consultar(Convert.ToInt16(Console.ReadLine()));
									if (objmodproducto.getID() == 0)
									{
										Console.WriteLine("Vuelve a intentarlo");
									}
									else {
										objproducto.setID(objmodproducto.getID());
										Console.WriteLine("Indica Nombre del producto");
										objproducto.setName(Console.ReadLine());
										Console.WriteLine("Indica el Precio");
										objproducto.setPrecio(Convert.ToDouble(Console.ReadLine()));

										Console.WriteLine(objproducto.ToString());

										new ProductoDAO().Modificar(objproducto);
									}

									break;

								case 4:
									Boolean eliminar = true;

									Console.WriteLine("Eliminar");
									while (eliminar)
									{
										Console.WriteLine("Indica ID del producto");
										Producto objproductotmp = new ProductoDAO().Consultar(Convert.ToInt16(Console.ReadLine()));
										if (objproductotmp.getID() == 0)
										{
											Console.WriteLine("Vuelve a intentar");
										}
										else
										{
											Console.WriteLine(objproductotmp.getID()+"  " + objproductotmp.getName());
											
											Console.WriteLine("1. Eliminar");
											Console.WriteLine("2. Volver al menu");
											switch (Convert.ToInt32(Console.ReadLine()))
											{
												case 1:
													Console.WriteLine("Eliminado");
													new ProductoDAO().Eliminar(objproductotmp.getID());
													eliminar = false;
													break;
												case 2:
													eliminar = false;
													break;
												default:
													eliminar = true;
													break;
											}
										}
									}

									break;

								case 5:
									Console.WriteLine("Lista de Productos");
									listproductos= new ProductoDAO().listproductos();
									for (int i = 0; i < listproductos.Count; i++) {
										Console.WriteLine(listproductos[i]);
									}

									break;

								default:
									break;
							}

							break;

						case 2:

							Console.WriteLine("Consultar Venta");
							Console.WriteLine("Lista de ventas");
							listadeventas = new VentaDAO().listventas();
							for(int i = 0; i < listadeventas.Count; i++)
                            {
								Console.WriteLine("ID: " + listadeventas[i].getID()+'\n'
									+"Registro: "+listadeventas[i].getRegistro());
                            }
							Console.WriteLine("Indica el ID de la venta");
							objventa=new VentaDAO().Consultar(Convert.ToInt16(Console.ReadLine()));
							if(objventa.getID()==0 && objventa.getSubtotal()==0.0){
								Console.WriteLine("Vuelve a intentar");
							}
							else {
								Console.WriteLine("ID: " + objventa.getID() + '\n'
								+ "Igv: " + objventa.getIgv() + '\n'
								+ "Descuento: " + objventa.getDescuento() + '\n'
								+ "Monto: " + objventa.getSubtotal() + '\n'
								+ "Total: " + (objventa.getSubtotal() + objventa.getIgv() - objventa.getDescuento()) + '\n'
								+ "Registro: " + objventa.getRegistro());
								for (int i = 0; i < objventa.GetDetalleVentas().Count; i++)
									Console.WriteLine("Nombre: " + objventa.GetDetalleVentas()[i].getobjproducto().getName() + '\n'
										+ "Costo: " + objventa.GetDetalleVentas()[i].getobjproducto().getPrecio() + '\n'
										+ "Registro: " + objventa.GetDetalleVentas()[i].getobjproducto().getRegistro() + '\n'
										+ "Cantidad: " + objventa.GetDetalleVentas()[i].getCantidad());
							}
							
							

							break;

						case 3:
							double subsuma = 0.0;
							double subdescuento = 0.0;
							double subtotal = 0.0;
							double subIgv = 0.0;
							Boolean volver = true;
							

							Console.WriteLine("Registrar Venta");
							listproductos = new ProductoDAO().listproductos();
							for (int i = 0; i < listproductos.Count; i++)
							{
								Console.WriteLine(listproductos[i]);
							}
							while (volver)
							{
								
								Console.WriteLine("Indica el ID producto a comprar");
								objproducto = new ProductoDAO().Consultar(Convert.ToInt32(Console.ReadLine()));
								Console.WriteLine("Indica la cantidad");
								int cantidad = Convert.ToInt32(Console.ReadLine());
								DetalleVenta objdetalleventa = new DetalleVenta(
									0,
									objproducto,
									cantidad
									);
								listadetalle.Add(objdetalleventa);

								for (int i = 0; i < listadetalle.Count; i++)
								{
									subsuma = subsuma + (listadetalle[i].getobjproducto().getPrecio() * listadetalle[i].getCantidad());
								}

								decimal smonto = ((decimal)Math.Round(subsuma, 2));
								Console.WriteLine("Monto: " + smonto);
								if (subsuma < 50)
								{
									Console.WriteLine("No hay descuento");
								}
								else if (subsuma > 51 && subsuma < 100)
								{
									Console.WriteLine("El monto aplica con 5% de descuento");
									subdescuento = 5 * subsuma / 100;
									subsuma = subsuma - subdescuento;
								}
								else
								{
									Console.WriteLine("El monto aplica con 10% de descuento");
									subdescuento = 10 * subsuma / 100;
									subsuma = subsuma - subdescuento;
								}
								decimal monto = ((decimal)Math.Round(subsuma, 2));
								decimal descuento = ((decimal)Math.Round(subdescuento, 2));

								subIgv = (18 * subsuma) / 100;
								decimal Igv = ((decimal)Math.Round(subIgv, 2));

								Console.WriteLine("Igv: " + Igv);
								subtotal = subsuma + subIgv;
								decimal total = ((decimal)Math.Round(subtotal, 2));
								Console.WriteLine("Total: " + total);
								objventa = new Venta(
									0,
									(double)Igv,
									(double)descuento,
									(double)monto,
									new DateTime(),
									listadetalle
									);


								Console.WriteLine("1. Agregar otro producto");
								Console.WriteLine("2. Modificar compra");
								Console.WriteLine("3. Realizar compra");
								

																		int option = Convert.ToInt32(Console.ReadLine());
																		if (option == 1)
																		{
																			volver = true;
																		}else if (option==2) {
																			Boolean modificar = true;
																			int contador = 0;
																			while (modificar)
																			{
																				Console.WriteLine("Lista");
																				for (int i = 0; i < listadetalle.Count; i++)
																				{
																					Console.WriteLine(i + 1 + ".-" + listadetalle[i]);
																					contador++;
																				}
																				Console.WriteLine("Indique el item a modificar");
																				int item = Convert.ToInt32(Console.ReadLine());
																				if (item > 0 && item <= contador)
																				{
																					Console.WriteLine("Indique el nuevo producto o indique 0 para borrar");
																					int newproducto = Convert.ToInt32(Console.ReadLine());
																					if (newproducto == 0)
																					{
																						listadetalle.RemoveAt(item - 1);
																					}
																					else if (newproducto > 0)
																					{
																						Producto objproductotemp = new ProductoDAO().Consultar(newproducto);
																						if (objproductotemp.getID() == 0)
																						{
																							Console.WriteLine("Intentalo denuevo");
																						}
																						else
																						{
																							Console.WriteLine("Indique la cantidad");
																							int modcantidad = Convert.ToInt32(Console.ReadLine());
																							listadetalle[item - 1].setobjproducto(objproductotemp);
																							listadetalle[item - 1].setCantidad(modcantidad);
																						}
																					}
																					else
																					{
																						Console.WriteLine("Intentalo denuevo");
																					}
																				}
																				else {
																					Console.WriteLine("Indica un numero dentro de la lista");
																					modificar = true;
																				}

																				subsuma = 0;
																				for (int i = 0; i < listadetalle.Count; i++)
																				{
																					subsuma = subsuma + (listadetalle[i].getobjproducto().getPrecio() * listadetalle[i].getCantidad());
																				}

																				decimal smonto1 = ((decimal)Math.Round(subsuma, 2));
																				Console.WriteLine("Monto: " + smonto1);
																				if (subsuma < 50)
																				{
																					Console.WriteLine("No hay descuento");
																				}
																				else if (subsuma > 51 && subsuma < 100)
																				{
																					Console.WriteLine("El monto aplica con 5% de descuento");
																					subdescuento = 5 * subsuma / 100;
																					subsuma = subsuma - subdescuento;
																				}
																				else
																				{
																					Console.WriteLine("El monto aplica con 10% de descuento");
																					subdescuento = 10 * subsuma / 100;
																					subsuma = subsuma - subdescuento;
																				}
																				decimal monto1 = ((decimal)Math.Round(subsuma, 2));
																				decimal descuento1 = ((decimal)Math.Round(subdescuento, 2));

																				subIgv = (18 * subsuma) / 100;
																				decimal Igv1 = ((decimal)Math.Round(subIgv, 2));

																				Console.WriteLine("Igv: " + Igv1);
																				subtotal = subsuma + subIgv;
																				decimal total1 = ((decimal)Math.Round(subtotal, 2));
																				Console.WriteLine("Total: " + total1);
																				objventa = new Venta(
																					0,
																					(double)Igv1,
																					(double)descuento1,
																					(double)monto1,
																					new DateTime(),
																					listadetalle
																					);

																				Console.WriteLine("1. Realizar compra");
																				Console.WriteLine("2. Seguir Modificando");
																				switch (Convert.ToInt32(Console.ReadLine())) 
																				{
																					case 1:
																						Console.WriteLine("Realizar compra");
																						if ((double)total1 > 0 && (double)total1 <= 3000) {
																							Console.WriteLine("1. Efectivo");
																							Console.WriteLine("1. Tarjeta");
																							switch (Convert.ToInt32(Console.ReadLine())) {
																								case 1:
																									Console.WriteLine("Pagado");
																									new VentaDAO().Registrar(objventa);
																									modificar = false;
																									volver = false;
																									break;

																								case 2:
																									Console.WriteLine("Pagado");
																									new VentaDAO().Registrar(objventa);
																									modificar = false;
																									volver = false;
																									break;

																								default:
																									Console.WriteLine("Intentalo denuevo");
																									break;
																							}
																						} else if ((double)total1 >3001) {
																							Console.WriteLine("El monto es muy alto, solo se puede pagar con tarjeta");
																							Console.WriteLine("1. Tajeta");
																							Console.WriteLine("2. Cancelar venta");
																							switch (Convert.ToInt32(Console.ReadLine())) {
																								case 1:
																									Console.WriteLine("Pagado");
																									new VentaDAO().Registrar(objventa);
																									modificar = false;
																									volver = false;
																									break;

																								case 2:
																									Console.WriteLine("Cancelado");
																									modificar = false;
																									volver = false;
																									break;

																								default:
																									Console.WriteLine("Intentalo denuevo");
																									break;
																							}
																						}
																						break;

																					case 2:
																						Console.WriteLine("Seguir modificando");
																						modificar = true;
																						break;
																					default:
																						Console.WriteLine("Intentalo denuevo");
																						break;
																				}
																			}
																		}else if (option == 3)
																		{
																			volver = false;
																			Console.WriteLine("Realizar compra");
																			if ((double)total > 0 && (double)total <= 3000)
																			{
																				Console.WriteLine("1. Efectivo");
																				Console.WriteLine("1. Tarjeta");
																				switch (Convert.ToInt32(Console.ReadLine()))
																				{
																					case 1:
																						Console.WriteLine("Pagado");
																						new VentaDAO().Registrar(objventa);
												
																						
																						break;

																					case 2:
																						Console.WriteLine("Pagado");
																						new VentaDAO().Registrar(objventa);
												
																						
																						break;

																					default:
																						Console.WriteLine("Intentalo denuevo");
																						break;
																				}
																			}
																			else if ((double)total > 3001)
																			{
																				Console.WriteLine("El monto es muy alto, solo se puede pagar con tarjeta");
																				Console.WriteLine("1. Tajeta");
																				Console.WriteLine("2. Cancelar venta");
																				switch (Convert.ToInt32(Console.ReadLine()))
																				{
																					case 1:
																						Console.WriteLine("Pagado");
																						new VentaDAO().Registrar(objventa);
												
																						
																						break;

																					case 2:
																						Console.WriteLine("Cancelado");
												
																						
																						break;

																					default:
																						Console.WriteLine("Intentalo denuevo");
																						break;
																				}
																			}
																			break;
																		}
																		else
																		{
																			Console.WriteLine("Volver a intentar");
																		}
							
							}
							
							break;

						case 4:

							Console.WriteLine("Cancelar Venta");
							Console.WriteLine("Indica el ID de la venta");
							Producto objcancelproducto = new ProductoDAO().Consultar(Convert.ToInt32(Console.ReadLine()));
							if (objcancelproducto.getID() == 0 && objcancelproducto==new Producto())
							{
								Console.WriteLine("Vuelve a intentarlo");
							}
							else {
								new VentaDAO().Cancelar(objcancelproducto.getID());
							}

							

							break;

						case 5:
							Console.WriteLine("Lista de ventas");
							listadeventas = new VentaDAO().listventas();
							for (int i = 0; i < listadeventas.Count; i++)
							{
								Console.WriteLine("ID: " + listadeventas[i].getID() + '\n'
									+ "Registro: " + listadeventas[i].getRegistro());
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

		}
	}
}
