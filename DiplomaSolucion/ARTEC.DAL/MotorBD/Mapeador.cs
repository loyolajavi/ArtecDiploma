using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace ARTEC.DAL.MotorBD
{
    internal class Mapeador
    {

        public static List<T> Mapear<T>(DataSet unDataSet) where T : new()
        {
            List<T> ListaResultado = new List<T>();
            try
            {
                IList<PropertyInfo> Propiedades = typeof(T).GetProperties().ToList();
                foreach (var row in unDataSet.Tables[0].Rows)
                {
                    var Item = CargarPropiedad<T>((DataRow)row, Propiedades);
                    ListaResultado.Add(Item);
                }
            }
            catch (Exception es)
            {
                throw;
            }
            return ListaResultado;
        }


        private static T CargarPropiedad<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T unaInstancia = new T();

            try
            {
                foreach (var prop in properties)
                {
                    if (prop.CanWrite)
                    {
                        try
                        {
                            prop.SetValue(unaInstancia, row[prop.Name], null);
                        }
                        catch (IndexOutOfRangeException es)
                        {
                        }
                    }
                }
            }
            catch (Exception es)
            {
            }

            return unaInstancia;
        }


        public static T MapearUno<T>(DataSet unDataSet) where T : new()
        {
            T ListaResultado = new T();
            try
            {
                IList<PropertyInfo> Propiedades = typeof(T).GetProperties().ToList();
                foreach (var row in unDataSet.Tables[0].Rows)
                {
                    ListaResultado = CargarPropiedad<T>((DataRow)row, Propiedades);
                }
            }
            catch (Exception es)
            {
                throw;
            }
            return ListaResultado;
        }
        

    }
}



//Codigo viejo

//foreach (var row in unDataSet.)
//{
//    var item = CreateItemFromRow<T>((DataRow)row, Propiedades);
//    result.Add(item);
//}



//foreach (var row in unDataSet.Tables[0].Rows)
//{
//    foreach (PropertyInfo InformacionProperty in Propiedades)
//    {
//        T unaInstancia = new T();
//        if (InformacionProperty.CanWrite)
//        {
//            try
//            {
//                InformacionProperty.SetValue(unaInstancia, unDataSet)
//    }
//}




//while (((IDataReader)(unDataSet)).Read())
//{
//    T unaInstancia = new T();
//    foreach (PropertyInfo InformacionProperty in unaInstancia.GetType().GetProperties())
//    {

//        if (InformacionProperty.CanWrite)
//        {
//            try
//            {
//                InformacionProperty.SetValue(unaInstancia, ((IDataReader)(unDataSet))[InformacionProperty.Name], null);

//            }
//            catch (Exception es)
//            {
//                throw;
//            }
//        }
//    }
//    ListaResultado.Add(unaInstancia);
//}