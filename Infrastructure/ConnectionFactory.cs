using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class ConnectionFactory: IConnectionFactory
    {
        private readonly string  mdf= @"C:\Brainshark\interview\BrainWare\Web\App_Data\BrainWare.mdf";
        private readonly string connectionString = $"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename={mdf}";;
        private readonly SqlConnection _connection;

        public SqlConnection GetConnection
        {
            get
            {
                //var mdf = @"C:\Brainshark\interview\BrainWare\Web\App_Data\BrainWare.mdf";
                //var connectionString = $"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename={mdf}";

                _connection = new SqlConnection(connectionString);

                _connection.Open();
            }
        }

    }
}
