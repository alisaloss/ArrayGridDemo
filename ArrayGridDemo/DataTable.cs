using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayGridDemo
{
    public static class DataTableHelper
    {
        // Converts a 2D array into a DataTable for binding to a DataGrid
        public static DataTable ToDataTable(double[,] array, string colPrefix = "C")
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            var table = new DataTable();

            // Create columns
            for (int c = 0; c < cols; c++)
                table.Columns.Add($"{colPrefix}{c}", typeof(double));

            // Populate rows
            for (int r = 0; r < rows; r++)
            {
                var row = table.NewRow();
                for (int c = 0; c < cols; c++)
                    row[c] = array[r, c];
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
