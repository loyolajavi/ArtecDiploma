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
            
            var Propiedades = typeof(T).GetProperties().ToList();

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
