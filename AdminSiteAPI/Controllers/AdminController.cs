
using AdminSiteAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
namespace AdminSiteAPI.Controllers
{
    [ApiController]

    public class AdminController : Controller
    {
        [HttpGet]
        [Route("api/Admin/getuserList")]
        public List<User> Index()
        {
            List<User> users = new List<User>();
            //users.Add(new User { })
            SqlConnection con = new SqlConnection(@"Data Source=CHAITRASHEN-LT;Initial Catalog=AdminSite;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                users.Add(new User
                {
                    id = dr["id"].ToString(),
                    username = dr["username"].ToString(),
                    companyid = dr["companyid"].ToString(),
                    companyname = dr["companyname"].ToString(),
                    userpermission = dr["userpermission"].ToString(),
                    usertype = dr["usertype"].ToString()
                });
            }
            return users;

        }


        [HttpGet]
        [Route("api/Admin/getuserListbyID/{id}")]
        public User getuserListbyID(int id)
        {
            User usr = new User();
            SqlConnection con = new SqlConnection(@"Data Source=CHAITRASHEN-LT;Initial Catalog=AdminSite;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usr.id = dr["id"].ToString();
                usr.username = dr["username"].ToString();
                usr.companyid = dr["companyid"].ToString();
                usr.companyname = dr["companyname"].ToString();
                usr.userpermission = dr["userpermission"].ToString();
                usr.usertype = dr["usertype"].ToString();
            }
            return usr;
        }

        [HttpPost]
        [Route("api/Admin/addUser")]
        public int addUser([FromBody] User user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHAITRASHEN-LT;Initial Catalog=AdminSite;Integrated Security=True");
            con.Open();
            string sqlStr = "insert into Users values(@id,@username,@companyid,@companyname,@userpermission,@usertype)";
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            cmd.Parameters.AddWithValue("@id", user.id);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@companyid", user.companyid);
            cmd.Parameters.AddWithValue("@companyname", user.companyname);
            cmd.Parameters.AddWithValue("@userpermission", user.userpermission);
            cmd.Parameters.AddWithValue("@usertype", user.usertype);
            int result = cmd.ExecuteNonQuery();
            return result;
        }



        [HttpDelete]
        [Route("api/Admin/deleteUser/{id}")]
        public int deleteUser(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHAITRASHEN-LT;Initial Catalog=AdminSite;Integrated Security=True");
            con.Open();
            string sqlStr = "delete from Users where id=@id";
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            var user = getuserListbyID(id);
            cmd.Parameters.AddWithValue("@id", user.id);
            int result = cmd.ExecuteNonQuery();
            return result;

        }

    }
}