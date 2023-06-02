using AdminSiteAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AdminSiteAPI.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("api/login")]
        public bool doLogin([FromBody] Login login)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHAITRASHEN-LT;Initial Catalog=AdminSite;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from LoginUsers where username=@username AND password=@password", con);
            cmd.Parameters.AddWithValue("@username", login.username);
            cmd.Parameters.AddWithValue("@password", login.password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}