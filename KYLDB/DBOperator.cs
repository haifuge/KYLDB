using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB
{
    public class DBOperator
    {
        public static DataTable QuerySql(string sql)
        {
            using(SqlConnection conn=new SqlConnection())
            {
                conn.ConnectionString= System.Configuration.ConfigurationManager.ConnectionStrings["KYL"].ConnectionString;
                conn.Open();
                SqlCommand comd = new SqlCommand(sql, conn);
                SqlDataReader reader = comd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
        public static void ExecuteSql(string sql)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KYL"].ConnectionString;
                conn.Open();
                SqlCommand comd = new SqlCommand(sql, conn);
                comd.ExecuteNonQuery();
            }
        }
        public static List<T> getListFromTable<T>(DataTable dt)
        {
            List<T> objs = new List<T>();
            Type temp = typeof(T);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T obj = Activator.CreateInstance<T>();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name.ToLower() == column.ColumnName.ToLower())
                        {
                            if (dr[column.ColumnName] == DBNull.Value)
                            {
                                pro.SetValue(obj, " ", null);
                                break;
                            }
                            else
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                                break;
                            }
                        }
                    }
                }
                objs.Add(obj);
            }
            return objs;
        }
    }
}
