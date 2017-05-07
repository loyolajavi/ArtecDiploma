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
        
        public static List<T> Mapear<T>(DataSet unDataSet) where T : new()
        {
            List<T> ListaResultado = Activator.CreateInstance<List<T>>();

            //CON ESTA LINEA ANDABA EL MAPEADOR
            //var Propiedades = typeof(T).GetProperties().ToList();
            var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var row in unDataSet.Tables[0].Rows)
            {
                var Item = CargarPropiedad<T>((DataRow)row, Propiedades);
                ListaResultado.Add(Item);
            }

            return ListaResultado;
        }







        public static T MapearUno<T>(DataSet unDataSet) where T : new()
        {
            var ListaResultado = Activator.CreateInstance<T>();
            var Propiedades = ListaResultado.GetType().GetProperties();

            foreach (var row in unDataSet.Tables[0].Rows)
            {
                ListaResultado = CargarPropiedad<T>((DataRow)row, Propiedades);
            }

            return ListaResultado;
        }



        private static T CargarPropiedad<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {

            var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T unaInstancia = Activator.CreateInstance<T>();

            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsClass && !prop.PropertyType.IsPrimitive)
                {
                    if (typeof(String).IsAssignableFrom(prop.PropertyType))
                    {
                        //if (prop.CanWrite)
                        //{
                        try
                        {
                            prop.SetValue(unaInstancia, row[prop.Name].ToString(), null);
                        }
                        catch (Exception es)
                        {
                        }
                        //}
                    }
                    else
                    {
                        //if (prop.CanWrite)
                        //{
                        try
                        {
                            if (prop.PropertyType.Name != "List`1")
                            {
                                prop.SetValue(unaInstancia, CargarPropiedad(prop.PropertyType, row), null);
                            }

                        }
                        catch (Exception es)
                        {
                        }
                        //}
                    }
                }
                else
                {
                    //if (prop.CanWrite)
                    //{
                    try
                    {
                        prop.SetValue(unaInstancia, row[prop.Name], null);
                    }
                    catch (Exception es)
                    {
                    }
                    //}
                }

            }
            //T result = (T)Convert.ChangeType(unaInstancia, typeof(T));
            //return result;

            return unaInstancia;

        }



        //public static List<T> CargarPropiedad<T>(DataSet unDataSet) where T : new()
        //{


        //    List<T> ListaResultado = Activator.CreateInstance<List<T>>();


        //    foreach (DataRow row in unDataSet.Tables[0].Rows)
        //    {

        //        var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //        T unaInstancia = Activator.CreateInstance<T>();

        //        foreach (var prop in Propiedades)
        //        {
        //            if (prop.PropertyType.IsClass && !prop.PropertyType.IsPrimitive)
        //            {
        //                if (typeof(String).IsAssignableFrom(prop.PropertyType))
        //                {
        //                    //if (prop.CanWrite)
        //                    //{
        //                    try
        //                    {
        //                        prop.SetValue(unaInstancia, row[prop.Name].ToString(), null);
        //                    }
        //                    catch (Exception es)
        //                    {
        //                    }
        //                    //}
        //                }
        //                else
        //                {
        //                    //if (prop.CanWrite)
        //                    //{
        //                    try
        //                    {
        //                        if (prop.PropertyType.Name != "List`1")
        //                        {
        //                            prop.SetValue(unaInstancia, CargarPropiedad(prop.PropertyType, row), null);
        //                        }

        //                    }
        //                    catch (Exception es)
        //                    {
        //                    }
        //                    //}
        //                }
        //            }
        //            else
        //            {
        //                //if (prop.CanWrite)
        //                //{
        //                try
        //                {
        //                    prop.SetValue(unaInstancia, row[prop.Name], null);
        //                }
        //                catch (Exception es)
        //                {
        //                }
        //                //}
        //            }

        //        }
        //        //T result = (T)Convert.ChangeType(unaInstancia, typeof(T));
        //        //return result;

        //        ListaResultado.Add(unaInstancia);
        //    }

        //    return ListaResultado;

        //}


        //**************************************FALTA HACER EL CARGARPROPIEDADUNO, Y DPS CAMBIARLES EL NOMBRE A MAPEAR Y MAPEARUNO************************************
        public static List<T> CargarPropiedad<T>(DataSet unDataSet) where T : new()
        {


            List<T> ListaResultado = Activator.CreateInstance<List<T>>();


            foreach (DataRow row in unDataSet.Tables[0].Rows)
            {

                T unaInstancia = Activator.CreateInstance<T>();

                //var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);//ESTABA ESTE CODIGO
                var Propiedades = unaInstancia.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                
                foreach (var prop in Propiedades)
                {

                    Type unTipo = prop.PropertyType;

                    if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
                    {
                        try
                        {
                            if (unTipo.Name != "List`1")
                            {
                                prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row), null);
                            }
                        }
                        catch (Exception es)
                        {
                        }
                    }
                    else
                    {
                         try
                        {
                            prop.SetValue(unaInstancia, row[prop.Name], null);
                        }
                        catch (Exception es)
                        {
                        }
                    }
                }

                ListaResultado.Add(unaInstancia);
            }

            return ListaResultado;

        }



        private static object CargarPropiedad(Type valType, DataRow row)
        {
            var unaInstancia = Activator.CreateInstance(valType);
            var properties = unaInstancia.GetType().GetProperties();

            foreach (var prop in properties)
            {
                Type unTipo = prop.PropertyType;

                if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
                {
                    try
                    {
                        if (unTipo.Name != "List`1")
                        {
                            prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row), null);
                        }
                    }
                    catch (Exception es)
                    {
                    }
                }
                else
                {
                    try
                    {
                        prop.SetValue(unaInstancia, row[prop.Name], null);
                    }
                    catch (Exception es)
                    {
                    }
                }
            }
            return unaInstancia;
        }

    }
}
