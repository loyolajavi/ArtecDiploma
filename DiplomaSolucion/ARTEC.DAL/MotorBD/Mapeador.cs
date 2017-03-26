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
            IList<PropertyInfo> Propiedades = typeof(T).GetProperties().ToList();
            List<T> ListaResultado = new List<T>();

            foreach (var row in unDataSet.Tables[0].Rows)
            {
                var Item = CargarPropiedad<T>((DataRow) row, Propiedades);
                ListaResultado.Add(Item);
            }

            return ListaResultado;
        }


        private static T CargarPropiedad<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T unaInstancia = new T();

            foreach (var prop in properties)
            {
                prop.SetValue(unaInstancia, row[prop.Name], null);
            }
            return unaInstancia;
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