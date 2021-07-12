using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionConfig {
  public class Connection {
    SqlConnection con = new SqlConnection();
    SqlTransaction transaction;
    public Connection() {
      con.ConnectionString = @"Data Source=Lucas;Initial Catalog=Banco_Teste;Integrated Security=True";
    }

    public SqlConnection StartConnection() {
      if(con.State.Equals(System.Data.ConnectionState.Closed)) {
        con.Open();
        transaction = con.BeginTransaction();
      }
      return con;
    }

    public void CloseConnection() {
      if(con.State.Equals(System.Data.ConnectionState.Open)) {
        con.Close();
      }
    }



    // =============== TRANSACTION ===============
    public SqlTransaction Transaction() {
      return transaction;
    }

    public void CommitTransaction() {
      transaction.Commit();
    }

    public void RollbackTransaction() {
      transaction.Rollback();
    }

  }
}
