using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ConnectionConfig;

namespace Utilidades {
  public class Database {
    public static DataTable RetornaInfoTable(string sqlquery) {
      DataTable table = new DataTable();
      Connection con = new Connection();
      SqlCommand cmd = new SqlCommand();
      SqlDataAdapter adapter = new SqlDataAdapter();
      try {
        cmd.Connection = con.StartConnection();
        cmd.Transaction = con.Transaction();
        cmd.CommandText = sqlquery;
        adapter.SelectCommand = cmd;
        adapter.Fill(table);
        con.CommitTransaction();
      } catch(Exception exception) {
        con.RollbackTransaction();
      } finally {
        con.CloseConnection();
      }
      return table;
    }

    public static DataTable RetornaInfoTable(SqlCommand cmd) {
      DataTable table = new DataTable();
      Connection con = new Connection();
      SqlDataAdapter adapter = new SqlDataAdapter();
      try {
        cmd.Connection = con.StartConnection();
        cmd.Transaction = con.Transaction();
        adapter.SelectCommand = cmd;
        adapter.Fill(table);
        con.CommitTransaction();
      } catch(Exception exception) {
        con.RollbackTransaction();
      } finally {
        con.CloseConnection();
      }
      return table;
    }



    public static bool ExecutarComando(params string[] sqlquerys) {
      Connection con = new Connection();
      SqlCommand cmd = new SqlCommand();
      bool ok = false;
      try {
        cmd.Connection = con.StartConnection();
        cmd.Transaction = con.Transaction();
        foreach(var query in sqlquerys) {
          cmd.CommandText = query;
          cmd.ExecuteNonQuery();
        }
        con.CommitTransaction();
        ok = true;
      } catch(Exception exception) {
        con.RollbackTransaction();
      } finally {
        con.CloseConnection();
      }
      return ok;
    }

    public static int ExecutaComandoRetornaID(string insert_query, string select_query) {
      int ID = -1;
      Connection con = new Connection();
      SqlCommand cmd = new SqlCommand();
      DataTable table = new DataTable();
      SqlDataAdapter adapter = new SqlDataAdapter();
      try {
        cmd.Connection = con.StartConnection();
        cmd.Transaction = con.Transaction();

        cmd.CommandText = insert_query;
        cmd.ExecuteNonQuery();

        cmd.CommandText = select_query;
        adapter.SelectCommand = cmd;
        adapter.Fill(table);
        foreach(DataRow row in table.Rows) {
          ID = Int32.Parse(row["id"].ToString());
        }
        con.CommitTransaction();
      } catch(Exception exception) {
        con.RollbackTransaction();
      } finally {
        con.CloseConnection();
      }
      return ID;
    }





  }
}
