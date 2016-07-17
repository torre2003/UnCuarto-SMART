/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 16-07-2016
 * Hora: 16:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using FuzzyCore;
using ModeloMBCIF;

namespace ContenedorImplementacionesInterfacesCalculoModeloMBCIF
{
	/// <summary>
	/// Description of InterfacesCalculoGlobal.
	/// </summary>
	[Serializable()]
	public class InterfacesCalculoGlobal : ICalculosInfluencias
	{
		private readonly string IdOrigen ;
		public InterfacesCalculoGlobal(string idOrigen){
			IdOrigen = idOrigen;
		}
		
		public double calculoPeso(InferenciaDifusa fuzzy)
		{
			var nodoActual = fuzzy.Entradas[IdOrigen] ;
			var influencia = fuzzy.Salidas["Influencia"];
			
			fuzzy.Si(nodoActual.Es("pesimo")).Entonces(influencia, "altera_negativamente");
			fuzzy.Si(nodoActual.Es("malo")).Entonces(influencia, "influye_negativamente");
			fuzzy.Si(nodoActual.Es("bueno")).Entonces(influencia, "influye_positivamente");
			fuzzy.Si(nodoActual.Es("excelente")).Entonces(influencia, "altera_positivamente");
			
			
			return influencia.Defuzzyficar(Metodo.MAXIMO_IZQUIERDO);

		}
	}
}
