using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ImportData
{
    public static class DataTableSchemaCompare
    {
        public static bool SchemaEquals(this DataTable dt, DataTable value)
        {
            if (dt.Columns.Count != value.Columns.Count)
                return false;

            var dtColumns = dt.Columns.Cast<DataColumn>();
            var valueColumns = value.Columns.Cast<DataColumn>();


            var exceptCount = dtColumns.Except(valueColumns, DataColumnEqualityComparer.Instance).Count();
            return (exceptCount == 0);


        }
    }
}
