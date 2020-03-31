using System;
using System.Data;
using System.IO;

namespace CleanCode.LongMethods
{
    public class DataTableToCsvMapper
    {
        public MemoryStream Map(DataTable dataTable)
        {
            MemoryStream ReturnStream = new MemoryStream();

            StreamWriter streamWriter = new StreamWriter(ReturnStream);
            WriteColumnNames(dataTable, streamWriter);
            WriteRows(dataTable, streamWriter);
            streamWriter.Flush();
            streamWriter.Close();

            return ReturnStream;
        }

        private static void WriteRows(DataTable dataTable, StreamWriter streamWriter)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                WriteRow(dataTable, dataRow, streamWriter);
                streamWriter.WriteLine();
            }
        }

        private static void WriteRow(DataTable dataTable, DataRow dataRow, StreamWriter streamWriter)
        {
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                WriteCell(dataRow[i], streamWriter);
                WriteSeparatorIfRequired(dataTable, i, streamWriter);
            }
        }

        private static void WriteSeparatorIfRequired(DataTable dataTable, int i, StreamWriter streamWriter)
        {
            if (i < dataTable.Columns.Count - 1)
                streamWriter.Write(",");
        }

        private static void WriteCell(object dataRow, StreamWriter streamWriter)
        {
            if (!Convert.IsDBNull(dataRow))
            {
                string str = String.Format("\"{0:c}\"", dataRow.ToString()).Replace("\r\n", " ");
                streamWriter.Write(str);
            }
            else
            {
                streamWriter.Write("");
            }
        }

        private static void WriteColumnNames(DataTable dataTable, StreamWriter streamWriter)
        {
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                streamWriter.Write(dataTable.Columns[i]);
                if (i < dataTable.Columns.Count - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.WriteLine();
        }
    }
}

