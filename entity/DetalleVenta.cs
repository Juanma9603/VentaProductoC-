using System;
using System.Collections.Generic;
using System.Text;

namespace VentaProducto
{
	public class DetalleVenta
	{
		private int Id_Producto;
		private int Id_Venta;

		
			public DetalleVenta()
			{
				this.Id_Producto = 0;
				this.Id_Venta = 0;
			}

			public DetalleVenta(int Id_Producto, int Id_Venta)
			{
				this.Id_Producto = Id_Producto;
				this.Id_Venta = Id_Venta;
			}

			public void setId_Producto(int Id_Producto) {
				this.Id_Producto = Id_Producto;
			}

			public int getId_Producto() {
				return this.Id_Producto;
			}

			public void setId_Venta(int Id_Venta) {
				this.Id_Venta = Id_Venta;
			}

			public int getId_Venta() {
				return this.Id_Venta;
			}

		public override string ToString()
		{
			return "Id_Producto: " + Id_Producto + "\n"
				+ "Id_Venta: " + Id_Venta;
		}
	}
	
}
