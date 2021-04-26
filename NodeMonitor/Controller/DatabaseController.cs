using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NodeMonitor.Models;

namespace NodeMonitor.Controller
{
    public class DatabaseController
    {
        public bool CheckConnection(nmDBContext context)
        {
            try
            {
                context.Database.OpenConnection();
                context.Database.CloseConnection();
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
    }
}