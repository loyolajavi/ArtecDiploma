using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace ARTEC.FRAMEWORK.Persistencia
{
    public class Mapeador
    {

        //public static List<T> Mapear<T>(DataSet unDataSet) where T : new()
        //{


        //    List<T> ListaResultado = Activator.CreateInstance<List<T>>();


        //    foreach (DataRow row in unDataSet.Tables[0].Rows)
        //    {

        //        T unaInstancia = Activator.CreateInstance<T>();

        //        //var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);//ESTABA ESTE CODIGO
        //        var Propiedades = unaInstancia.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //        foreach (var prop in Propiedades)
        //        {

        //            Type unTipo = prop.PropertyType;

        //            if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
        //            {
        //                try
        //                {
        //                    if (unTipo.Name != "List`1")
        //                    {
        //                        prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row), null);
        //                    }
        //                }
        //                catch (Exception es)
        //                {
        //                }
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    prop.SetValue(unaInstancia, row[prop.Name], null);
        //                }
        //                catch (Exception es)
        //                {
        //                }
        //            }
        //        }

        //        ListaResultado.Add(unaInstancia);
        //    }

        //    return ListaResultado;

        //}



        //public static T MapearUno<T>(DataSet unDataSet) where T : new()
        //{


        //    T Resultado = Activator.CreateInstance<T>();


        //    foreach (DataRow row in unDataSet.Tables[0].Rows)
        //    {

        //        T unaInstancia = Activator.CreateInstance<T>();

        //        //var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);//ESTABA ESTE CODIGO
        //        var Propiedades = unaInstancia.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //        foreach (var prop in Propiedades)
        //        {

        //            Type unTipo = prop.PropertyType;

        //            if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
        //            {
        //                try
        //                {
        //                    if (unTipo.Name != "List`1")
        //                    {
        //                        prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row), null);
        //                    }
        //                }
        //                catch (Exception es)
        //                {
        //                }
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    prop.SetValue(unaInstancia, row[prop.Name], null);
        //                }
        //                catch (Exception es)
        //                {
        //                }
        //            }
        //        }

        //        Resultado = unaInstancia;
        //    }

        //    return Resultado;

        //}






        //private static object CargarPropiedad(Type valType, DataRow row)
        //{
        //    var unaInstancia = Activator.CreateInstance(valType);
        //    var properties = unaInstancia.GetType().GetProperties();

        //    foreach (var prop in properties)
        //    {
        //        Type unTipo = prop.PropertyType;

        //        if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
        //        {
        //            try
        //            {
        //                if (unTipo.Name != "List`1")
        //                {
        //                    prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row), null);
        //                }
        //            }
        //            catch (Exception es)
        //            {
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                prop.SetValue(unaInstancia, row[prop.Name], null);
        //            }
        //            catch (Exception es)
        //            {
        //            }
        //        }
        //    }
        //    return unaInstancia;
        //}




        public static List<T> Mapear<T>(DataSet unDataSet) where T : new()
        {
            List<T> ListaResultado = Activator.CreateInstance<List<T>>();

            //CON ESTA LINEA ANDABA EL MAPEADOR
            //var Propiedades = typeof(T).GetProperties().ToList();
            //var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Type unTipo = typeof(T);

            foreach (var row in unDataSet.Tables[0].Rows)
            {
                T Item = (T)CargarPropiedad(unTipo, (DataRow)row);
                ListaResultado.Add(Item);
            }

            return ListaResultado;
        }







        public static T MapearUno<T>(DataSet unDataSet) where T : new()
        {
            var Resultado = Activator.CreateInstance<T>();
            var Propiedades = Resultado.GetType().GetProperties();
            Type unTipo = typeof(T);

            foreach (var row in unDataSet.Tables[0].Rows)
            {
                Resultado = (T)CargarPropiedad(unTipo, (DataRow)row);
            }

            T result = (T)Convert.ChangeType(Resultado, typeof(T));
            return result;

            //return Resultado;
        }



        private static object CargarPropiedad(Type valType, DataRow row)
        {
            var unaInstancia = Activator.CreateInstance(valType);
            var properties = unaInstancia.GetType().GetProperties();

            foreach (var prop in properties)
            {
                Type unTipo = prop.PropertyType;

                try
                {
                    if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
                    {
                        if (unTipo.Name != "List`1")
                        {
                            prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row), null);
                        }
                    }
                    else
                    {

                        prop.SetValue(unaInstancia, row[prop.Name], null);

                    }
                }
                catch (Exception es)
                {
                }
            }

            //T result = (T)Convert.ChangeType(unaInstancia, typeof(T));
            //return result;

            return unaInstancia;
        }






        //public static List<T> Mapear3<T>(DataTable unDataSet) where T : new()
        //{
        //    List<T> ListaResultado = Activator.CreateInstance<List<T>>();

        //    //CON ESTA LINEA ANDABA EL MAPEADOR
        //    //var Propiedades = typeof(T).GetProperties().ToList();
        //    //var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    Type unTipo = typeof(T);

        //    foreach (var row in unDataSet.Rows)
        //    {
        //        T Item = (T)CargarPropiedad3(unTipo, (DataRow)row);
        //        ListaResultado.Add(Item);
        //    }

        //    return ListaResultado;
        //}







        //public static T MapearUno3<T>(DataSet unDataSet) where T : new()
        //{
        //    var Resultado = Activator.CreateInstance<T>();
        //    var Propiedades = Resultado.GetType().GetProperties();
        //    Type unTipo = typeof(T);

        //    foreach (var row in unDataSet.Tables[0].Rows)
        //    {
        //        Resultado = (T)CargarPropiedad3(unTipo, (DataRow)row);
        //    }

        //    T result = (T)Convert.ChangeType(Resultado, typeof(T));
        //    return result;

        //    //return Resultado;
        //}



        //private static object CargarPropiedad3(Type valType, DataRow row)
        //{
        //    var unaInstancia = Activator.CreateInstance(valType);
        //    var properties = unaInstancia.GetType().GetProperties();

        //    foreach (var prop in properties)
        //    {
        //        Type unTipo = prop.PropertyType;

        //        try
        //        {
        //            if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
        //            {
        //                if (unTipo.Name != "List`1")
        //                {
        //                    prop.SetValue(unaInstancia, CargarPropiedad3(unTipo, row), null);
        //                }
        //            }
        //            else
        //            {

        //                prop.SetValue(unaInstancia, row[prop.Name], null);

        //            }
        //        }
        //        catch (Exception es)
        //        {
        //        }
        //    }

        //    //T result = (T)Convert.ChangeType(unaInstancia, typeof(T));
        //    //return result;

        //    return unaInstancia;
        //}


     


    }
}
