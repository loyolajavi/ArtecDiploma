﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;

namespace ARTEC.FRAMEWORK.Persistencia
{
    public class Mapeador
    {

        private static Hashtable _propiedades;

        private static Hashtable LasPropiedades
        {
            get
            {
                if (_propiedades == null)
                    _propiedades = new Hashtable();
                return _propiedades;
            }
            set { _propiedades = value; }
        }

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



        //private static object CargarPropiedad(Type valType, DataRow row, int Nro)
        //{

        //    var unaInstancia = Activator.CreateInstance(valType);
        //    var properties = unaInstancia.GetType().GetProperties();

        //    foreach (var prop in properties)
        //    {
        //        Type unTipo = prop.PropertyType;
        //        //ver si es primitivo, string, decimal, int,etc y si es va el setvalue, else voy por el recursivo
        //        try
        //        {
        //            if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
        //            {
        //                if (Nro <= 2)
        //                {
        //                    if (unTipo.Name != "List`1")
        //                    {
        //                        prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row, Nro + 1), null);
        //                    }
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



        private static void ObtenerPropiedades(object targetObject, Type targetType)
        {
            var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;

            if (_propiedades == null)
            {
                List<PropertyInfo> propertyList = new List<PropertyInfo>();
                PropertyInfo[] objectProperties = targetType.GetProperties(flags);
                foreach (PropertyInfo currentProperty in objectProperties)
                {
                    //Type unTipo = currentProperty.PropertyType;
                    //if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
                    //{
                    //    var InstanciaProp = Activator.CreateInstance(unTipo);
                    //    ObtenerPropiedades(InstanciaProp, unTipo);
                    //}
                    //else
                    //{
                    propertyList.Add(currentProperty);
                    //}

                }
                _propiedades = new Hashtable();
                _propiedades[targetType.FullName] = propertyList;
            }

            if (_propiedades[targetType.FullName] == null)
            {
                List<PropertyInfo> propertyList = new List<PropertyInfo>();
                PropertyInfo[] objectProperties = targetType.GetProperties(flags);
                foreach (PropertyInfo currentProperty in objectProperties)
                {
                    propertyList.Add(currentProperty);
                }
                _propiedades[targetType.FullName] = propertyList;
            }
        }



        public static List<T> MapearDataReaderListaObjetos<T>(DataSet unDataSet) where T : new()
        {
            Type businessEntityType = typeof(T);
            List<T> entitys = Activator.CreateInstance<List<T>>();
            //T miObjeto = new T();

            foreach (DataRow row in unDataSet.Tables[0].Rows)
            {
                T Item = (T)SetearPropiedad(businessEntityType, (DataRow)row);
                entitys.Add(Item);
            }
            return entitys;
        }



        private static object SetearPropiedad(Type valType, DataRow row)
        {
            var unaInstancia = Activator.CreateInstance(valType);
            ObtenerPropiedades(unaInstancia, valType);
            List<PropertyInfo> sourcePoperties = LasPropiedades[valType.FullName] as List<PropertyInfo>;


            foreach (PropertyInfo item in sourcePoperties) 
            {
                foreach (DataColumn unaColumna in row.Table.Columns)
                {
                    //if (item.Name.ToUpper() == unaColumna.ColumnName.ToUpper())
                    //{
                        //string _tipoProp = item.PropertyType.ToString();
                        //PropertyInfo info = item;
                        if ((item != null) && item.CanWrite)
                        {
                            try
                            {
                                if (item.PropertyType.IsClass && !typeof(String).IsAssignableFrom(item.PropertyType))
                                {
                                    if (item.PropertyType.Name != "List`1")
                                    {
                                        item.SetValue(unaInstancia, SetearPropiedad(item.PropertyType, row), null);
                                    }
                                }
                                else
                                {
                                    if (item.Name.ToUpper() == unaColumna.ColumnName.ToUpper())
                                    {
                                        item.SetValue(unaInstancia, row[item.Name], null);
                                        break;
                                    }
                                    
                                }
                            }
                            catch (Exception es)
                            {
                                break;
                            }

                        }
                    //}
                }
            }
            return unaInstancia;
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

                    //if (unTipo.IsPrimitive || typeof(String).IsAssignableFrom(unTipo) || typeof(DateTime).IsAssignableFrom(unTipo) || typeof(Decimal).IsAssignableFrom(unTipo))
                    //{
                    //    prop.SetValue(unaInstancia, row[prop.Name], null);
                    //}
                    //else if (!typeof(ICollection).IsAssignableFrom(unTipo) && Nro <=2)
                    //{
                    //    if (unTipo.IsClass)
                    //    {
                    //        prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row, Nro + 1), null);
                    //    }
                    //}

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

//**************************************BACKUP DE LO UTLIMO POR REFLECTION AL 17-05-2017 SIN CACHEAR-********************************************
//public static List<T> Mapear<T>(DataSet unDataSet) where T : new()
//        {
//            List<T> ListaResultado = Activator.CreateInstance<List<T>>();

//            //CON ESTA LINEA ANDABA EL MAPEADOR
//            //var Propiedades = typeof(T).GetProperties().ToList();
//            //var Propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
//            Type unTipo = typeof(T);

//            foreach (var row in unDataSet.Tables[0].Rows)
//            {
//                T Item = (T)CargarPropiedad(unTipo, (DataRow)row);
//                ListaResultado.Add(Item);
//            }

//            return ListaResultado;
//        }







//        public static T MapearUno<T>(DataSet unDataSet) where T : new()
//        {
//            var Resultado = Activator.CreateInstance<T>();
//            var Propiedades = Resultado.GetType().GetProperties();
//            Type unTipo = typeof(T);

//            foreach (var row in unDataSet.Tables[0].Rows)
//            {
//                Resultado = (T)CargarPropiedad(unTipo, (DataRow)row);
//            }

//            T result = (T)Convert.ChangeType(Resultado, typeof(T));
//            return result;

//            //return Resultado;
//        }

//       private static object CargarPropiedad(Type valType, DataRow row)
//        {

//            var unaInstancia = Activator.CreateInstance(valType);
//            var properties = unaInstancia.GetType().GetProperties();

//            foreach (var prop in properties)
//            {
//                Type unTipo = prop.PropertyType;
//                try
//                {

//                    //if (unTipo.IsPrimitive || typeof(String).IsAssignableFrom(unTipo) || typeof(DateTime).IsAssignableFrom(unTipo) || typeof(Decimal).IsAssignableFrom(unTipo))
//                    //{
//                    //    prop.SetValue(unaInstancia, row[prop.Name], null);
//                    //}
//                    //else if (!typeof(ICollection).IsAssignableFrom(unTipo) && Nro <=2)
//                    //{
//                    //    if (unTipo.IsClass)
//                    //    {
//                    //        prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row, Nro + 1), null);
//                    //    }
//                    //}

//                    if (unTipo.IsClass && !typeof(String).IsAssignableFrom(unTipo))
//                    {
//                            if (unTipo.Name != "List`1")
//                            {
//                                prop.SetValue(unaInstancia, CargarPropiedad(unTipo, row), null);
//                            }
//                    }
//                    else
//                    {

//                        prop.SetValue(unaInstancia, row[prop.Name], null);

//                    }
//                }
//                catch (Exception es)
//                {
//                }
//            }

//            //T result = (T)Convert.ChangeType(unaInstancia, typeof(T));
//            //return result;

//            return unaInstancia;
//        }
//**************************************FINBACKUP DE LO UTLIMO POR REFLECTION AL 17-05-2017 SIN CACHEAR-********************************************