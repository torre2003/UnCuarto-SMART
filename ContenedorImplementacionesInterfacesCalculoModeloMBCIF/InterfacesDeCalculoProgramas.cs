using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloMBCIF;
using FuzzyCore;
using System.Collections;

namespace ContenedorImplementacionesInterfacesCalculoModeloMBCIF
{

    #region ICalculosNodo_programas
    //***********************************************************************************************
    //************************    ICalculosNodo_programas
    //***********************************************************************************************
    [Serializable()]
    public class ICalculosNodo_programas : ICalculosNodo
    {

        string id_nivel_academico = "";
        public ICalculosNodo_programas(string id_nivel_academico)
        {
            this.id_nivel_academico = id_nivel_academico;
        }
        
        
        
        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }
           
            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }


        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {
            VariableDifusa m_alumnos = fuzzy.Entradas["matricula alumnos"];
            VariableDifusa acreditacion = fuzzy.Entradas["acreditacion"];
            VariableDifusa nivel_academico = fuzzy.Entradas[id_nivel_academico];
            VariableDifusa estado = fuzzy.Salidas["estado"];

            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("normal")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("alto")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("muy_alto")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_corto") & nivel_academico.Es("normal")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_corto") & nivel_academico.Es("alto")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_corto") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_medio") & nivel_academico.Es("normal")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_medio") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_medio") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("muy_alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("normal")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("alto")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_corto") & nivel_academico.Es("normal")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_corto") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_corto") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_medio") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_medio") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_medio") & nivel_academico.Es("muy_alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("muy_alto")).Entonces(estado, "excelente");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("normal")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_corto") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_corto") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_corto") & nivel_academico.Es("muy_alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_medio") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_medio") & nivel_academico.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_medio") & nivel_academico.Es("muy_alto")).Entonces(estado, "excelente");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("normal")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("alto")).Entonces(estado, "excelente");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("muy_alto")).Entonces(estado, "excelente");
            
            double salida = (double)estado.Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;


            


        }

        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso); 
        }
    }

    #endregion


    #region interfaceCalculoNivelesAcademicos
    //***********************************************************************************************
    //************************    InterfaceCalculoNivelesAcademicos
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculoNivelesAcademicos : ICalculosNodo
    {
        string[] salidas_1 = new string[] { "pesimo", "regular", "excelente" };
        string[] salidas_2 = new string[] { "pesimo","malo" ,"regular", "bueno","excelente" };
        string[] salidas_3 = new string[] { "pesimo", "pesimo", "malo", "regular", "bueno", "excelente", "excelente" };
        string[] salidas_4 = new string[] { "pesimo", "pesimo", "malo", "malo", "regular", "bueno", "bueno", "excelente", "excelente" };
        string[] salidas_5 = new string[] { "pesimo", "pesimo", "malo", "malo", "regular", "regular", "regular", "bueno", "bueno", "excelente", "excelente" };
        string[] salidas_6 = new string[] { "pesimo", "pesimo", "pesimo", "malo", "malo", "regular", "regular", "regular", "bueno", "bueno", "excelente", "excelente", "excelente" };

        string[] salidas_actual = null;
        string[] entradas_difusas = new string[] { "calificado", "destacado", "eminente" };
        ArrayList id_profesores = new ArrayList();



        public InterfaceCalculoNivelesAcademicos(string[] profesores)
        {
            for (int i = 0; i < profesores.Length; i++)
            {
                agregarProfesor(profesores[i]);
            }
        }

        public void agregarProfesor(string id_profesor)
        {
            id_profesores.Add(id_profesor);
            switch (id_profesores.Count)
            {
                case 1:
                    salidas_actual = salidas_1;
                    break;
                case 2:
                    salidas_actual = salidas_2;
                    break;
                case 3:
                    salidas_actual = salidas_3;
                    break;
                case 4:
                    salidas_actual = salidas_4;
                    break;
                case 5:
                    salidas_actual = salidas_5;
                    break;
                case 6:

                    salidas_actual = salidas_6;
                    break;
            }
        }
                
        public ArrayList crearCombinaciones(int longitud, string[] posibilidades)
        {
            if (longitud == 1)
            {
                ArrayList array = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                    array.Add(posibilidades[i]);    
                return array;
            }
            else
            {
                ArrayList retorno = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                {
                    ArrayList aux = crearCombinaciones(longitud - 1,posibilidades);
                    foreach (string item in aux)
                    {
                        retorno.Add(posibilidades[i] + ":" + item);
                    }
                }
                return retorno;
            }
        }


        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }

            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }

        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {
            ArrayList combinaciones = crearCombinaciones(id_profesores.Count, new string[]{"0","1","2"});
            foreach (string combinacion in combinaciones)
            {
                string[] estado_profesores = combinacion.Split(':');
                int puntaje_estados = 0;
                ExpresionDifusa antecedentes = new ExpresionDifusa(0);
                for (int i = 0; i < estado_profesores.Length; i++)
                {
                    int n_estado = Int32.Parse(estado_profesores[i]);
                    puntaje_estados += n_estado;
                    if (i == 0)
                        antecedentes = fuzzy.Entradas[(string)id_profesores[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)id_profesores[i]].Es(entradas_difusas[n_estado]);
                }
                fuzzy.Si(antecedentes).Entonces(fuzzy.Salidas["estado"], salidas_actual[puntaje_estados]);
            }
            double salida = (double)fuzzy.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }
         

        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso); 
        }
    }
#endregion


    #region interfaceCalculoProfesores
    //***********************************************************************************************
    //************************    InterfaceCalculoProfesores
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculoProfesores : ICalculosNodo
    {
        string[] salidas_actual = new string[] { "pesimo","malo" ,"regular", "bueno","excelente" };
        string[] entradas_difusas = new string[] { "bajo", "medio", "alto" };
        double[] limite_derecho_rango = new double[] {1,3,4,6,8};
        ArrayList caracteristicas = new ArrayList();



        public InterfaceCalculoProfesores()
        {
            caracteristicas.Add("publicaciones isi-wos");
            caracteristicas.Add("publicaciones scielo");
            caracteristicas.Add("publicaciones equivalentes");
            caracteristicas.Add("impacto");
        }

                
        public ArrayList crearCombinaciones(int longitud, string[] posibilidades)
        {
            if (longitud == 1)
            {
                ArrayList array = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                    array.Add(posibilidades[i]);    
                return array;
            }
            else
            {
                ArrayList retorno = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                {
                    ArrayList aux = crearCombinaciones(longitud - 1,posibilidades);
                    foreach (string item in aux)
                    {
                        retorno.Add(posibilidades[i] + ":" + item);
                    }
                }
                return retorno;
            }
        }


        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }

            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }

        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {
            ArrayList combinaciones = crearCombinaciones(caracteristicas.Count, new string[]{"0","1","2"});
            foreach (string combinacion in combinaciones)
            {
                string[] combinacion_estado = combinacion.Split(':');
                int puntaje_estados = 0;
                ExpresionDifusa antecedentes = new ExpresionDifusa(0);
                for (int i = 0; i < combinacion_estado.Length; i++)
                {
                    int n_estado = Int32.Parse(combinacion_estado[i]);
                    puntaje_estados += n_estado;
                    if (i == 0)
                        antecedentes = fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                }

                fuzzy.Si(antecedentes).Entonces(fuzzy.Salidas["estado"], salidas_actual[indice_salida(puntaje_estados)]);
            }
            double salida = (double)fuzzy.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }


        public int indice_salida(int puntaje_estados)
        {
            for (int i = 0; i < limite_derecho_rango.Length; i++)
            {
                if (puntaje_estados <= limite_derecho_rango[i])
                    return i;
            }
            return -666;
        }



        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso); 
        }
    }
#endregion


    #region InterfaceCalculosSeccionesPostgrado
    //***********************************************************************************************
    //************************    InterfaceCalculosSeccionesPostgrado
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculosSeccionesPostgrado : ICalculosNodo
    {
        string[] salidas_actual = new string[] { "pesimo", "malo", "regular", "bueno", "excelente" };
        string[] entradas_difusas = new string[] { "bajo", "medio", "alto" };
        double[] limite_derecho_rango = new double[] { 1, 3, 4, 6, 8 };
        ArrayList programas = new ArrayList();



        public InterfaceCalculosSeccionesPostgrado(string[] programas)
        {
            for (int i = 0; i < programas.Length; i++)
            {
                this.programas.Add(programas[i]);    
            }
            limite_derecho_rango = creaVectorLimiteDerechoRango(programas.Length);
        }


        public double[] creaVectorLimiteDerechoRango(int cantidad_de_programas)
        {
            double[] arreglo_retorno = new double[] { 1,1,1,1,1 };
            if (cantidad_de_programas == 1)
            {
                arreglo_retorno = new double[]{0,666,1,666,2};
                return arreglo_retorno;
            }
            if (cantidad_de_programas == 2)
                return new double[] { 0, 1, 2, 3, 4 };
            int numeros_restantes_por_repartir = (3 * cantidad_de_programas) - cantidad_de_programas;
            numeros_restantes_por_repartir -= 5;
            int[] orden_de_aumento = new int[] {0,4,1,3,2,2};
            int pos_actual = 0;
            for (int i = numeros_restantes_por_repartir; i >= 0; i--)
            {
                if (pos_actual >= orden_de_aumento.Length)
                    pos_actual = 0;
                arreglo_retorno[orden_de_aumento[pos_actual]]++;
                pos_actual++;
            }

            double acumulado = 0;
            for (int i = 0; i < arreglo_retorno.Length; i++)
            {
                acumulado += arreglo_retorno[i];
                arreglo_retorno[i] = acumulado - 1;
            }
            return arreglo_retorno;
        }



        public ArrayList crearCombinaciones(int longitud, string[] posibilidades)
        {
            if (longitud == 1)
            {
                ArrayList array = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                    array.Add(posibilidades[i]);
                return array;
            }
            else
            {
                ArrayList retorno = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                {
                    ArrayList aux = crearCombinaciones(longitud - 1, posibilidades);
                    foreach (string item in aux)
                    {
                        retorno.Add(posibilidades[i] + ":" + item);
                    }
                }
                return retorno;
            }
        }


        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }

            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }

        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {
            ArrayList combinaciones = crearCombinaciones(programas.Count, new string[] { "0", "1", "2" });
            foreach (string combinacion in combinaciones)
            {
                string[] combinacion_estado = combinacion.Split(':');
                int puntaje_estados = 0;
                ExpresionDifusa antecedentes = new ExpresionDifusa(0);
                for (int i = 0; i < combinacion_estado.Length; i++)
                {
                    int n_estado = Int32.Parse(combinacion_estado[i]);
                    puntaje_estados += n_estado;
                    if (i == 0)
                        antecedentes = fuzzy.Entradas[(string)programas[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)programas[i]].Es(entradas_difusas[n_estado]);
                }

                fuzzy.Si(antecedentes).Entonces(fuzzy.Salidas["estado"], salidas_actual[indice_salida(puntaje_estados)]);
            }
            double salida = (double)fuzzy.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }


        public int indice_salida(int puntaje_estados)
        {
            for (int i = 0; i < limite_derecho_rango.Length; i++)
            {
                if (puntaje_estados <= limite_derecho_rango[i])
                    return i;
            }
            return -666;
        }



        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso);
        }
    }
    #endregion

    #region InterfaceCalculosPersonas
    //***********************************************************************************************
    //************************    InterfaceCalculosPersonas
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculosPersonas : ICalculosNodo
    {
        string[] salidas_actual = new string[] { "pesimo", "malo", "regular", "bueno", "excelente" };
        string[] entradas_difusas = new string[] { "bajo", "medio", "alto" };
        double[] limite_derecho_rango = new double[] { 1, 3, 4, 6, 8 };
        ArrayList caracteristicas = new ArrayList();



        public InterfaceCalculosPersonas(string[] caracteristica)
        {
            for (int i = 0; i < caracteristica.Length; i++)
            {
                this.caracteristicas.Add(caracteristica[i]);    
            }
            limite_derecho_rango = creaVectorLimiteDerechoRango(caracteristica.Length);
        }


        public double[] creaVectorLimiteDerechoRango(int cantidad_de_programas)
        {
            double[] arreglo_retorno = new double[] { 1,1,1,1,1 };
            if (cantidad_de_programas == 1)
            {
                arreglo_retorno = new double[]{0,666,1,666,2};
                return arreglo_retorno;
            }
            if (cantidad_de_programas == 2)
                return new double[] { 0,1,2,3,4};
            int numeros_restantes_por_repartir = (3 * cantidad_de_programas) - cantidad_de_programas;
            numeros_restantes_por_repartir -= 5;
            int[] orden_de_aumento = new int[] {0,4,1,3,2,2};
            int pos_actual = 0;
            for (int i = numeros_restantes_por_repartir; i >= 0; i--)
            {
                if (pos_actual >= orden_de_aumento.Length)
                    pos_actual = 0;
                arreglo_retorno[orden_de_aumento[pos_actual]]++;
                pos_actual++;
            }

            double acumulado = 0;
            for (int i = 0; i < arreglo_retorno.Length; i++)
            {
                acumulado += arreglo_retorno[i];
                arreglo_retorno[i] = acumulado - 1;
            }
            return arreglo_retorno;
        }



        public ArrayList crearCombinaciones(int longitud, string[] posibilidades)
        {
            if (longitud == 1)
            {
                ArrayList array = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                    array.Add(posibilidades[i]);
                return array;
            }
            else
            {
                ArrayList retorno = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                {
                    ArrayList aux = crearCombinaciones(longitud - 1, posibilidades);
                    foreach (string item in aux)
                    {
                        retorno.Add(posibilidades[i] + ":" + item);
                    }
                }
                return retorno;
            }
        }


        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }

            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }

        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {
            ArrayList combinaciones = crearCombinaciones(caracteristicas.Count, new string[] { "0", "1", "2" });
            foreach (string combinacion in combinaciones)
            {
                string[] combinacion_estado = combinacion.Split(':');
                int puntaje_estados = 0;
                ExpresionDifusa antecedentes = new ExpresionDifusa(0);
                for (int i = 0; i < combinacion_estado.Length; i++)
                {
                    int n_estado = Int32.Parse(combinacion_estado[i]);
                    puntaje_estados += n_estado;
                    if (i == 0)
                        antecedentes = fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                }

                fuzzy.Si(antecedentes).Entonces(fuzzy.Salidas["estado"], salidas_actual[indice_salida(puntaje_estados)]);
            }
            double salida = (double)fuzzy.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }


        public int indice_salida(int puntaje_estados)
        {
            for (int i = 0; i < limite_derecho_rango.Length; i++)
            {
                if (puntaje_estados <= limite_derecho_rango[i])
                    return i;
            }
            return -666;
        }



        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso);
        }
    }
    #endregion

    #region InterfaceCalculosGenerica
    //***********************************************************************************************
    //************************    InterfaceCalculosGenerica
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculosGenerica : ICalculosNodo
    {
        string[] salidas_actual = new string[] { "pesimo", "malo", "regular", "bueno", "excelente" };
        string[] entradas_difusas = new string[] { "bajo", "medio", "alto" };
        double[] limite_derecho_rango = new double[] { 1, 3, 4, 6, 8 };
        ArrayList caracteristicas = new ArrayList();



        public InterfaceCalculosGenerica(string[] caracteristica)
        {
            for (int i = 0; i < caracteristica.Length; i++)
            {
                this.caracteristicas.Add(caracteristica[i]);
            }
            limite_derecho_rango = creaVectorLimiteDerechoRango(caracteristica.Length);
        }


        public double[] creaVectorLimiteDerechoRango(int cantidad_de_programas)
        {
            double[] arreglo_retorno = new double[] { 1, 1, 1, 1, 1 };
            if (cantidad_de_programas == 1)
            {
                arreglo_retorno = new double[] { 0, 666, 1, 666, 2 };
                return arreglo_retorno;
            }
            if (cantidad_de_programas == 2)
                return new double[] { 0, 1, 2, 3, 4 };
            int numeros_restantes_por_repartir = (3 * cantidad_de_programas) - cantidad_de_programas;
            numeros_restantes_por_repartir -= 5;
            int[] orden_de_aumento = new int[] { 0, 4, 1, 3, 2, 2 };
            int pos_actual = 0;
            for (int i = numeros_restantes_por_repartir; i >= 0; i--)
            {
                if (pos_actual >= orden_de_aumento.Length)
                    pos_actual = 0;
                arreglo_retorno[orden_de_aumento[pos_actual]]++;
                pos_actual++;
            }

            double acumulado = 0;
            for (int i = 0; i < arreglo_retorno.Length; i++)
            {
                acumulado += arreglo_retorno[i];
                arreglo_retorno[i] = acumulado - 1;
            }
            return arreglo_retorno;
        }



        public ArrayList crearCombinaciones(int longitud, string[] posibilidades)
        {
            if (longitud == 1)
            {
                ArrayList array = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                    array.Add(posibilidades[i]);
                return array;
            }
            else
            {
                ArrayList retorno = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                {
                    ArrayList aux = crearCombinaciones(longitud - 1, posibilidades);
                    foreach (string item in aux)
                    {
                        retorno.Add(posibilidades[i] + ":" + item);
                    }
                }
                return retorno;
            }
        }


        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }

            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }

        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {
            ArrayList combinaciones = crearCombinaciones(caracteristicas.Count, new string[] { "0", "1", "2" });
            foreach (string combinacion in combinaciones)
            {
                string[] combinacion_estado = combinacion.Split(':');
                int puntaje_estados = 0;
                ExpresionDifusa antecedentes = new ExpresionDifusa(0);
                for (int i = 0; i < combinacion_estado.Length; i++)
                {
                    int n_estado = Int32.Parse(combinacion_estado[i]);
                    puntaje_estados += n_estado;
                    if (i == 0)
                        antecedentes = fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                }

                fuzzy.Si(antecedentes).Entonces(fuzzy.Salidas["estado"], salidas_actual[indice_salida(puntaje_estados)]);
            }
            double salida = (double)fuzzy.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }


        public int indice_salida(int puntaje_estados)
        {
            for (int i = 0; i < limite_derecho_rango.Length; i++)
            {
                if (puntaje_estados <= limite_derecho_rango[i])
                    return i;
            }
            return -666;
        }



        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso);
        }
    }
    #endregion



    #region ICalculosPublicaciones
    //***********************************************************************************************
    //************************    ICalculosPublicaciones
    //***********************************************************************************************
    [Serializable()]
    public class ICalculosPublicaciones : ICalculosNodo
    {

        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }

            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }


        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {

            VariableDifusa p_impacto = fuzzy.Entradas["promedio de impacto publicaciones"];
            VariableDifusa t_publicaciones = fuzzy.Entradas["tasa de publicaciones anuales"];

            VariableDifusa estado = fuzzy.Salidas["estado"];


            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("limitado")).Entonces(estado, "pesimo");
            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("bajo")).Entonces(estado, "malo");
            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("medio")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("limitado")).Entonces(estado, "malo");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("bajo")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("medio")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("limitado")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("bajo")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("medio")).Entonces(estado, "bueno");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("alto")).Entonces(estado, "excelente");								



            double salida = (double)estado.Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;





        }

        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso);
        }
    }

    #endregion

}
