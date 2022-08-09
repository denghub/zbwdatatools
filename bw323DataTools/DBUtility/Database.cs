using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace bw323DataTools
{
    class Database : IDisposable
    {
        SqlConnection _Conn;
        SqlDataReader _DataReader;
        DataTable _SchemaTable;
        SqlCommand _Command;

        public void Connect(string connectString)
        {
            Close();
            _Conn = new SqlConnection(connectString);
            _Conn.Open();
        }

        public void Close()
        {
            Dispose();
        }

        public bool Findsst()
        {
            bool st = false;
            if (_Conn.State==ConnectionState.Open)
            {
                st=true;
            }
            else
            {
                st = false; 
            }
            return st;
        }
      
        public DataSet GetSchema(string queryString)
        {
            DataSet ds = new DataSet();


            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(
                queryString, _Conn);
            adapter.FillSchema(ds, SchemaType.Mapped);

            return ds;
        }
        public  DataTable GetSchemaS(string queryString)
        {

            DataTable table = new DataTable();    //new一个数据表
            SqlDataAdapter dap = new SqlDataAdapter(queryString, _Conn);    //创建数据适配器,sql语句和连接对象传给它,
            dap.Fill(table);    //将数据表填充进适配器
            _Conn.Close();    //关闭数据连接
            return table;    //将数据表返回
        }

        public void OpenDataReader(string queryString)
        {
            _Command = new SqlCommand(queryString, _Conn);
            _SchemaTable = GetSchema(queryString).Tables[0];
            _DataReader = _Command.ExecuteReader();
        }
        public int OpenDataReaderStates(string queryString)
        {
            _Command = new SqlCommand(queryString, _Conn);
            _SchemaTable = GetSchema(queryString).Tables[0];
            _DataReader = _Command.ExecuteReader();
            return _DataReader.GetInt32(0);
        }

        public int ExecuteNonQuery(string queryString)
        {
              //连接数据库
            //SqlCommand cmd = new SqlCommand(sqlStr, Conn);


            _Command = new SqlCommand(queryString,  _Conn);

            int result = _Command.ExecuteNonQuery();    
             
            return result ;    
        }
        public void CloseDataReader()
        {
            _DataReader.Close();
        }

        public void Clear()
        {
            _SchemaTable.Clear();
        }

        public DataRow GetNextRow()
        {
            if (_DataReader.Read())
            {
                DataRow row = _SchemaTable.NewRow();

                foreach (DataColumn col in _SchemaTable.Columns)
                {
                    row[col.ColumnName] = _DataReader[col.ColumnName];
                }

                return row;
            }
            else
            {
                return null;
            }
        }



        ~Database()
        {
            Close();
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (_Conn != null)
                {
                    _Command.Cancel();
                    _DataReader.Close();

                    if (_Conn.State != ConnectionState.Closed &&
                        _Conn.State != ConnectionState.Broken)
                    {
                        _Conn.Close();
                    }

                    _Conn = null;
                }
            }
            catch
            {
            }
        }

        #endregion
    }
}
