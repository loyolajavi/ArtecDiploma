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
        //    List<T> ListaResultado = new List<T>();
        //    try
        //    {
        //        IList<PropertyInfo> Propiedades = typeof(T).GetProperties().ToList();
        //        foreach (var row in unDataSet.Tables[0].Rows)
        //        {
        //            var Item = CargarPropiedad<T>((DataRow)row, Propiedades);
        //            ListaResultado.Add(Item);
        //        }
        //    }
        //    catch (Exception es)
        //    {
        //        throw;
        //    }
        //    return ListaResultado;
        //}


        //private static T CargarPropiedad<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        //{
        //    T unaInstancia = new T();

        //    foreach (var prop in properties)
        //    {
        //        if (prop.CanWrite)
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


        //public static T MapearUno<T>(DataSet unDataSet) where T : new()
        //{
        //    T ListaResultado = new T();
        //    try
        //    {
        //        IList<PropertyInfo> Propiedades = typeof(T).GetProperties().ToList();
        //        foreach (var row in unDataSet.Tables[0].Rows)
        //        {
        //            ListaResultado = CargarPropiedad<T>((DataRow)row, Propiedades);
        //        }
        //    }
        //    catch (Exception es)
        //    {
        //        throw;
        //    }
        //    return ListaResultado;
        //}


        public static List<T> Mapear<T>(DataSet unDataSet) where T : new()
        {
            List<T> ListaResultado = Activator.CreateInstance<List<T>>();
            //List<T> ListaResultado = CreateAGenericListContainingOneObject<T>();
            //try
            //{
            var Propiedades = typeof(T).GetProperties().ToList();

            foreach (var row in unDataSet.Tables[0].Rows)
            {
                var Item = CargarPropiedad<T>((DataRow)row, Propiedades);
                ListaResultado.Add(Item);
            }
            //}
            //catch (Exception es)
            //{
            //    throw;
            //}
            return ListaResultado;
        }

        private static IEnumerable<object> CreateAListContainingOneObject(Type type)
        {
            var del = typeof(Mapeador).GetMethod("CreateAGenericListContainingOneObject",
                BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(type);
            return del.Invoke(null, new object[] { }) as IEnumerable<object>;
        }

        private static List<T> CreateAGenericListContainingOneObject<T>()
            where T : new()
        {
            return new List<T> { new T() };
        }

        public static T MapearUno<T>(DataSet unDataSet) where T : new()
        {
            var ListaResultado = Activator.CreateInstance<T>();
            //try
            //{
            var Propiedades = ListaResultado.GetType().GetProperties();

            foreach (var row in unDataSet.Tables[0].Rows)
            {
                ListaResultado = CargarPropiedad<T>((DataRow)row, Propiedades);
            }
            //}
            //catch (Exception es)
            //{
            //    throw;
            //}
            return ListaResultado;
        }

        private static T CargarPropiedad<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            //Con esta linea funcionaba el mapeador ->
            //var unaInstancia = Activator.CreateInstance<T>();
            var unaInstancia = Activator.CreateInstance(typeof(T));

            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsClass && !prop.PropertyType.IsPrimitive)
                {
                    if (typeof(String).IsAssignableFrom(prop.PropertyType))
                    {
                        if (prop.CanWrite)
                        {
                            try
                            {
                                prop.SetValue(unaInstancia, row[prop.Name].ToString(), null);
                            }
                            catch (Exception es)
                            {
                            }
                        }
                    }
                    else
                    {
                        if (prop.CanWrite)
                        {
                            try
                            {
                                prop.SetValue(unaInstancia, CargarPropiedad(prop.PropertyType, row), null);
                            }
                            catch (Exception es)
                            {
                            }
                        }
                    }
                }
                else
                {
                    if (prop.CanWrite)
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

            }
            T result = (T)Convert.ChangeType(unaInstancia, typeof(T));
            return result;
        }


        private static object CargarPropiedad(Type valType, DataRow row)
        {
            var unaInstancia = Activator.CreateInstance(valType);
            var properties = unaInstancia.GetType().GetProperties();

            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsClass && !prop.PropertyType.IsPrimitive)
                {
                    if (typeof(String).IsAssignableFrom(prop.PropertyType))
                    {
                        if (prop.CanWrite)
                        {
                            try
                            {
                                prop.SetValue(unaInstancia, row[prop.Name].ToString(), null);
                            }
                            catch (Exception es)
                            {
                            }
                        }
                    }
                    else
                    {
                        if (prop.CanWrite)
                        {
                            try
                            {
                                prop.SetValue(unaInstancia, CargarPropiedad(prop.PropertyType, row), null);
                            }
                            catch (Exception es)
                            {
                            }
                        }
                    }

                }
                else
                {
                    if (prop.CanWrite)
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
            }
            return unaInstancia;
        }

    }
}
