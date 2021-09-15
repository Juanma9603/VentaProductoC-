using System;
using System.Collections.Generic;
using System.Text;

namespace VentaProducto
{
	public class Venta
	{
		private int ID;
		private double Descuento;
		private double Subtotal;
		private DateTime Registro;


		public Venta()
		{
			this.ID = 0;
			this.Descuento = 0.0;
			this.Subtotal = 0.0;
			this.Registro = new DateTime();
		}

		public Venta(int ID, double Descuento, double Subtotal, DateTime Registro) 
		{
			this.ID = ID;
			this.Descuento = Descuento;
			this.Subtotal = Subtotal;
			this.Registro = Registro;
		}

		public void setID(int ID)
		{
			this.ID = ID;
		}

		public int getID()
		{
			return this.ID;
		}

		public void setDescuento(double Descuento)
		{
			this.Descuento = Descuento;
		}

		public double getDescuento()
		{
			return this.Descuento;
		}

		public void setSubtotal(double Subtotal)
		{
			this.Subtotal = Subtotal;
		}

		public double getSubtotal()
		{
			return this.Subtotal;
		}

		public void setRegsitro(DateTime Registro)
		{
			this.Registro = Registro;
		}

		public DateTime getRegistro()
		{
			return this.Registro;
		}

		public override string ToString()
		{
			return "ID: " + ID + "\n"
				+ "Descuento: " + Descuento + "\n"
				+ "Subtotal: " + Subtotal + "\n"
				+ "Registro: " + Registro;
		}
	}
}
