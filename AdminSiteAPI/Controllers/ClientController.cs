using AdminSiteAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AdminSiteAPI.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        [Route("api/Admin/getclientList")]
        public List<Client> Index()
        {
            List<Client> clients = new List<Client>();
            SqlConnection con = new SqlConnection(@"Data Source=CHAITRASHEN-LT;Initial Catalog=AdminSite;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Clients", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clients.Add(new Client
                {
                    id = dr["id"].ToString(),
                    clientname = dr["clientname"].ToString(),
                    clientpermission = dr["clientpermission"].ToString(),
                    dateofBirth = dr["dateofBirth"].ToString(),
                 
                });
            }
            return clients;

        }



        [HttpGet]
        [Route("api/Admin/getClientListbyID/{id}")]
        public Client getClientListbyID(int id)
        {
            Client client = new Client();
            SqlConnection con = new SqlConnection(@"Data Source=CHAITRASHEN-LT;Initial Catalog=AdminSite;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Clients where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                client.id = dr["id"].ToString();
                client.clientname = dr["clientname"].ToString();
                client.clientpermission = dr["clientpermission"].ToString();
                client.dateofBirth = dr["dateofBirth"].ToString();
 
            }
            return client;
        }

    }
}
