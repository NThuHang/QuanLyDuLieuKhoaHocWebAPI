using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL.Helper
{
    public class StoreParameterInfo
    {
        public string StoreProcedureName { get; set; }
        public List<Object> StoreProcedureParams { get; set; }
    }
    public interface IDatabaseHelper
    {
        void SetConnectionString(string connectionString);
        string OpenConnection();
        string OpenConnectionAndBeginTransaction();
        string CloseConnection();
        string CloseConnectionAndEndTransaction(bool isRollbackTransaction);

        string ExecuteNoneQuery(string strquery);

        DataTable ExecuteQueryToDataTable(string strquery, out string msgError);

        object ExecuteScalar(string strquery, out string msgError);

        #region Execute StoreProcedure
        string ExecuteSProcedure(string sprocedureName, params object[] paramObjects);
      
        DataTable ExecuteSProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects);
        DataSet ExecuteSProcedureReturnDataset(out string msgError, string sprocedureName, params object[] paramObjects);
        string ExecuteSProcedure(SqlConnection sqlConnection, string sprocedureName, params object[] paramObjects);
        string ExecuteSProcedureWithTransaction(string sprocedureName, params object[] paramObjects);
        List<string> ExecuteScalarSProcedure(List<StoreParameterInfo> storeParameterInfos);
        List<string> ExecuteSProcedureWithTransaction(List<StoreParameterInfo> storeParameterInfos);
     
        object ExecuteScalarSProcedure(out string msgError, string sprocedureName, params object[] paramObjects);
     
        object ExecuteScalarSProcedureWithTransaction(out string msgError, string sprocedureName, params object[] paramObjects);
       
        List<object> ExecuteScalarSProcedure(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos);
        
        List<object> ExecuteScalarSProcedureWithTransaction(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos);
       
        List<Object> ReturnValuesFromExecuteSProcedure(out string msgError, string sprocedureName, int outputParamCountNumber, params object[] paramObjects);
        
        #endregion 
    }
}
