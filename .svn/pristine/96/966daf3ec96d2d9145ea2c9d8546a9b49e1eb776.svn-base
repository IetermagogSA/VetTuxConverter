using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace VetTux_Converter.General
{
    class GeneralProcedures
    {
        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the length limit for a given field on a LINQ object ... or zero if not known
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><remarks></span>
        /// You can use the results from this method to dynamically 
        /// set the allowed length of an INPUT on your web page to
        /// exactly the same length as the length of the database column.  
        /// Change the database and the UI changes just by
        /// updating your DBML and recompiling.
        /// <span class="code-SummaryComment"></remarks></span>
        public static int GetLengthLimit(object obj, string field)
        {
            int dblenint = 0;   // default value = we can't determine the length

            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(field);
            // Find the Linq 'Column' attribute
            // e.g. [Column(Storage="_FileName", DbType="NChar(256) NOT NULL", CanBeNull=false)]
            object[] info = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
            // Assume there is just one
            if (info.Length == 1)
            {
                ColumnAttribute ca = (ColumnAttribute)info[0];
                string dbtype = ca.DbType;

                if (dbtype.StartsWith("NChar") || dbtype.StartsWith("NVarChar") || dbtype.StartsWith("VarChar"))
                {
                    int index1 = dbtype.IndexOf("(");
                    int index2 = dbtype.IndexOf(")");
                    string dblen = dbtype.Substring(index1 + 1, index2 - index1 - 1);
                    int.TryParse(dblen, out dblenint);
                }
                if(dbtype.StartsWith("NText"))
                {
                    dblenint = 50;
                }
            }
            return dblenint;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// If you don't care about truncating data that you are setting on a LINQ object, 
        /// use something like this ...
        /// <span class="code-SummaryComment"></summary></span>
        public static void SetAutoTruncate(object obj, string field, string value)
        {
            int len = GetLengthLimit(obj, field);
            if (len == 0) throw new ApplicationException("Field '" + field +
                    "'does not have length metadata");

            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(field);
            if (value.Length > len)
            {
                prop.SetValue(obj, value.Substring(0, len), null);
            }
            else
                prop.SetValue(obj, value, null);
        }
    }
}
