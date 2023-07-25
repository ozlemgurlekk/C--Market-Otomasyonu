using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication37
{
    class sqlbaglantisi
    {
       public SqlConnection baglanti()
        { 
     
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FUNPM7I;Initial Catalog=marketdepo;Integrated Security=True");
            baglanti.Open();
            return baglanti; ;
        }
    }
}
