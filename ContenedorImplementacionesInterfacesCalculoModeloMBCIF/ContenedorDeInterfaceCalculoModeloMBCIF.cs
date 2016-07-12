using FuzzyCore;
using ModeloMBCIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContenedorImplementacionesInterfacesCalculoModeloMBCIF
{
  
    
    
    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------
    // Implementaciones ICalculosSistema
    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------

    //****************************************
    // s_mina
    //****************************************
    [Serializable()]
    public class ICalculosSistema_mina : ICalculosSistema
    {
        
        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Poco") & fuzzy.Entradas["s2"].Es("Poco") & fuzzy.Entradas["s3"].Es("Poco")).Entonces(fuzzy.Salidas["Sistema mina"], "Poco");
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Poco") & fuzzy.Entradas["s2"].Es("Poco") & fuzzy.Entradas["s3"].Es("Mucho")).Entonces(fuzzy.Salidas["Sistema mina"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Poco") & fuzzy.Entradas["s2"].Es("Mucho") & fuzzy.Entradas["s3"].Es("Poco")).Entonces(fuzzy.Salidas["Sistema mina"], "Poco");
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Poco") & fuzzy.Entradas["s2"].Es("Mucho") & fuzzy.Entradas["s3"].Es("Mucho")).Entonces(fuzzy.Salidas["Sistema mina"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Mucho") & fuzzy.Entradas["s2"].Es("Poco") & fuzzy.Entradas["s3"].Es("Poco")).Entonces(fuzzy.Salidas["Sistema mina"], "Poco");
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Mucho") & fuzzy.Entradas["s2"].Es("Poco") & fuzzy.Entradas["s3"].Es("Mucho")).Entonces(fuzzy.Salidas["Sistema mina"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Mucho") & fuzzy.Entradas["s2"].Es("Mucho") & fuzzy.Entradas["s3"].Es("Poco")).Entonces(fuzzy.Salidas["Sistema mina"], "Poco");
            fuzzy.Si(fuzzy.Entradas["s1"].Es("Mucho") & fuzzy.Entradas["s2"].Es("Mucho") & fuzzy.Entradas["s3"].Es("Mucho")).Entonces(fuzzy.Salidas["Sistema mina"], "Mucho");
            double salida = (double)fuzzy.Salidas["Sistema mina"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }
    }


    //***************************************
    // s1
    //****************************************
    [Serializable()]
    public class ICalculosSistema_s1 : ICalculosSistema
    {
        
        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Poco") & fuzzy.Entradas["n12"].Es("Poco") & fuzzy.Entradas["n13"].Es("Poco")).Entonces(fuzzy.Salidas["Produccion"], "Poco");
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Poco") & fuzzy.Entradas["n12"].Es("Poco") & fuzzy.Entradas["n13"].Es("Mucho")).Entonces(fuzzy.Salidas["Produccion"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Poco") & fuzzy.Entradas["n12"].Es("Mucho") & fuzzy.Entradas["n13"].Es("Poco")).Entonces(fuzzy.Salidas["Produccion"], "Poco");
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Poco") & fuzzy.Entradas["n12"].Es("Mucho") & fuzzy.Entradas["n13"].Es("Mucho")).Entonces(fuzzy.Salidas["Produccion"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Mucho") & fuzzy.Entradas["n12"].Es("Poco") & fuzzy.Entradas["n13"].Es("Poco")).Entonces(fuzzy.Salidas["Produccion"], "Poco");
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Mucho") & fuzzy.Entradas["n12"].Es("Poco") & fuzzy.Entradas["n13"].Es("Mucho")).Entonces(fuzzy.Salidas["Produccion"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Mucho") & fuzzy.Entradas["n12"].Es("Mucho") & fuzzy.Entradas["n13"].Es("Poco")).Entonces(fuzzy.Salidas["Produccion"], "Poco");
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Mucho") & fuzzy.Entradas["n12"].Es("Mucho") & fuzzy.Entradas["n13"].Es("Mucho")).Entonces(fuzzy.Salidas["Produccion"], "Mucho");
            double salida = (double)fuzzy.Salidas["Produccion"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }
    }


    //***************************************
    // s2
    //****************************************
    [Serializable()]
    public class ICalculosSistema_s2 : ICalculosSistema
    {
        
        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n21"].Es("Mucho") & fuzzy.Entradas["n22"].Es("Mucho")).Entonces(fuzzy.Salidas["Reduccion"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["n21"].Es("Mucho") & fuzzy.Entradas["n22"].Es("Poco")).Entonces(fuzzy.Salidas["Reduccion"], "Poco");
            fuzzy.Si(fuzzy.Entradas["n21"].Es("Poco") & fuzzy.Entradas["n22"].Es("Mucho")).Entonces(fuzzy.Salidas["Reduccion"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["n21"].Es("Poco") & fuzzy.Entradas["n22"].Es("Poco")).Entonces(fuzzy.Salidas["Reduccion"], "Poco");
            double salida = (double)fuzzy.Salidas["Reduccion"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }
    }

    //***************************************
    // s3
    //****************************************
    [Serializable()]
    public class ICalculosSistema_s3 : ICalculosSistema
    {
        
        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            
            fuzzy.Si(fuzzy.Entradas["n31"].Es("Mucho")).Entonces(fuzzy.Salidas["Transporte"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["n31"].Es("Poco")).Entonces(fuzzy.Salidas["Transporte"], "Poco");
            double salida = (double)fuzzy.Salidas["Transporte"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }
    }




    
    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------
    // Implementaciones ICalculosNodos
    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------

    //****************************************
    // n11
    //****************************************
    [Serializable()]
    public class ICalculosNodo_n11 : ICalculosNodo
    {

        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }
            if (Math.Abs(suma_de_influencias) > 0.4)
            {
                suma_de_influencias = (suma_de_influencias / Math.Abs(suma_de_influencias)) * 0.4f;
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
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Poco") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Poco") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Poco") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ingenieros"].Es("Mucho") & fuzzy.Entradas["Numero de Tecnicos"].Es("Mucho") & fuzzy.Entradas["Numero de Mineros"].Es("Mucho") & fuzzy.Entradas["Numero de Operarios LHD"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de operarios presentes"], "Mucho");
            double salida = (double)fuzzy.Salidas["Numero de operarios presentes"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }

        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["Numero de operarios presentes"].Restablecer();
            fuzzy.Salidas["Numero de operarios presentes"].Fuzzyficar(peso); 
        }
    }

    //****************************************
    // n12
    //****************************************
    [Serializable()]
    public class ICalculosNodo_n12 : ICalculosNodo
    {

        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }
            if (Math.Abs(suma_de_influencias) > 0.4)
            {
                suma_de_influencias = (suma_de_influencias / Math.Abs(suma_de_influencias)) * 0.4f;
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
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Perforaciones Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Perforacion, agentes, recursos"], "Mucho");
            double salida = (double)fuzzy.Salidas["Perforacion, agentes, recursos"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return salida;
        }


        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["Perforacion, agentes, recursos"].Restablecer();
            fuzzy.Salidas["Perforacion, agentes, recursos"].Fuzzyficar(peso ); 
        }
    }

    //****************************************
    // n13
    //****************************************
    [Serializable()]
    public class ICalculosNodo_n13 : ICalculosNodo
    {

        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }
            if (Math.Abs(suma_de_influencias) > 0.4)
            {
                suma_de_influencias = (suma_de_influencias / Math.Abs(suma_de_influencias)) * 0.4f;
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
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Poco") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Poco") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Poco")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Tronaduras Planificadas"].Es("Mucho") & fuzzy.Entradas["Agentes Directos Involucrados"].Es("Mucho") & fuzzy.Entradas["Agentes Indirectos Involucrados"].Es("Mucho")).Entonces(fuzzy.Salidas["Tronaduras, agentes, recursos"], "Mucho");
            double salida = (double)fuzzy.Salidas["Tronaduras, agentes, recursos"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return salida;
        }


        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["Tronaduras, agentes, recursos"].Restablecer();
            fuzzy.Salidas["Tronaduras, agentes, recursos"].Fuzzyficar(peso ); 
        }

    }


    //****************************************
    // n21
    //****************************************
    [Serializable()]
    public class ICalculosNodo_n21 : ICalculosNodo
    {

        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }
            if (Math.Abs(suma_de_influencias) > 0.4)
            {
                suma_de_influencias = (suma_de_influencias / Math.Abs(suma_de_influencias)) * 0.4f;
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
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Poco") & fuzzy.Entradas["Control Remoto"].Es("Poco") & fuzzy.Entradas["Robotizados"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de martillos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Poco") & fuzzy.Entradas["Control Remoto"].Es("Poco") & fuzzy.Entradas["Robotizados"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de martillos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Poco") & fuzzy.Entradas["Control Remoto"].Es("Mucho") & fuzzy.Entradas["Robotizados"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de martillos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Poco") & fuzzy.Entradas["Control Remoto"].Es("Mucho") & fuzzy.Entradas["Robotizados"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de martillos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Mucho") & fuzzy.Entradas["Control Remoto"].Es("Poco") & fuzzy.Entradas["Robotizados"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de martillos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Mucho") & fuzzy.Entradas["Control Remoto"].Es("Poco") & fuzzy.Entradas["Robotizados"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de martillos"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Mucho") & fuzzy.Entradas["Control Remoto"].Es("Mucho") & fuzzy.Entradas["Robotizados"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de martillos"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Control Manual"].Es("Mucho") & fuzzy.Entradas["Control Remoto"].Es("Mucho") & fuzzy.Entradas["Robotizados"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de martillos"], "Mucho");
            double salida = (double)fuzzy.Salidas["Numero de martillos"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return salida;
        }

        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["Numero de martillos"].Restablecer();
            fuzzy.Salidas["Numero de martillos"].Fuzzyficar(peso ); 
        }
    }


    //****************************************
    // n22
    //****************************************
    [Serializable()]
    public class ICalculosNodo_n22 : ICalculosNodo
    {

        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }
            if (Math.Abs(suma_de_influencias) > 0.4)
            {
                suma_de_influencias = (suma_de_influencias / Math.Abs(suma_de_influencias)) * 0.4f;
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
            fuzzy.Si(fuzzy.Entradas["Numero de Ricotus"].Es("Poco") & fuzzy.Entradas["Numero de Cachorreros"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de agentes que intervienen"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ricotus"].Es("Poco") & fuzzy.Entradas["Numero de Cachorreros"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de agentes que intervienen"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Numero de Ricotus"].Es("Mucho") & fuzzy.Entradas["Numero de Cachorreros"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de agentes que intervienen"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Numero de Ricotus"].Es("Mucho") & fuzzy.Entradas["Numero de Cachorreros"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de agentes que intervienen"], "Mucho");
            double salida = (double)fuzzy.Salidas["Numero de agentes que intervienen"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return salida;
        }



        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["Numero de agentes que intervienen"].Restablecer();
            fuzzy.Salidas["Numero de agentes que intervienen"].Fuzzyficar(peso ); 
        }
    }






    //****************************************
    // n31
    //****************************************
    [Serializable()]
    public class ICalculosNodo_n31 : ICalculosNodo
    {

        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }
            if (Math.Abs(suma_de_influencias) > 0.4)
            {
                suma_de_influencias = (suma_de_influencias / Math.Abs(suma_de_influencias)) * 0.4f;
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
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Poco") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Poco") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Poco")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Poco");
            fuzzy.Si(fuzzy.Entradas["Operativos"].Es("Mucho") & fuzzy.Entradas["Capacidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Velocidad de los Trenes"].Es("Mucho") & fuzzy.Entradas["Productividad de los Trenes"].Es("Mucho")).Entonces(fuzzy.Salidas["Numero de Trenes Disponibles"], "Mucho");

            double salida = (double)fuzzy.Salidas["Numero de Trenes Disponibles"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return salida;
        }


        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["Numero de Trenes Disponibles"].Restablecer();
            fuzzy.Salidas["Numero de Trenes Disponibles"].Fuzzyficar(peso); 
        }
    }




    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------
    // Implementaciones ICalculosInfluecias
    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------

    //****************************************
    // i_n11_n12
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n11_n12 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida);
        }
    }

    //****************************************
    // i_n11_n13
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n11_n13 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida);
        }
    }

    //****************************************
    // i_n11_n31
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n11_n31 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n11"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida);
        }
    }

    //****************************************
    // i_n12_n21
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n12_n21 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n12"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida );
        }
    }

    //****************************************
    // i_n13_n11
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n13_n11 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n13"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida);
        }
    }

    //****************************************
    // i_n13_n22
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n13_n22 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n13"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida);
        }
    }

    //****************************************
    // i_n21_n12
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n21_n12 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n21"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida );
        }
    }

    //****************************************
    // i_n21_n13
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n21_n13 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n21"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida);
        }
    }

    //****************************************
    // i_n21_n22
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n21_n22 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n21"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida );
        }
    }

    //****************************************
    // i_n22_n11
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n22_n11 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n22"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida );
        }
    }

    //****************************************
    // i_n22_n31
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n22_n31 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n22"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida );
        }
    }

    //****************************************
    // i_n31_n11
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n31_n11 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n31"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida );
        }
    }

    //****************************************
    // i_n31_n22
    //****************************************
    [Serializable()]
    public class ICalculosInfluencia_i_n31_n22 : ICalculosInfluencias
    {

        public double calculoPeso(InferenciaDifusa fuzzy)
        {
            fuzzy.Si(fuzzy.Entradas["n31"].Es("Normal")).Entonces(fuzzy.Salidas["Influencia"], "Normal");
            double salida = (double)fuzzy.Salidas["Influencia"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            
            return (0.5f * salida);
        }
    }




    

}
