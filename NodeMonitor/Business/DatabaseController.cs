using DatabaseLib.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NodeMonitor.Business
{
    public class DatabaseController
    {
        public bool CheckConnection()
        {
            try
            {
                var context = new nmDBContext();
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