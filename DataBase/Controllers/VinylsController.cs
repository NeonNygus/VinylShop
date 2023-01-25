using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using VinylShop.Model;

namespace VinylShop.Controllers
{
    public class VinylsController : Controller
    {

        public IActionResult Index()
        {
            List<VinylModel> displayvinyl = new List<VinylModel>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=vinylshop;Port=5432;User Id=postgres;Password=6666bitch;");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from vinyl";

            NpgsqlDataReader vdr = comm.ExecuteReader();
            while(vdr.Read())
            {
                var vnlist = new VinylModel();
                //vnlist.VinylId = Convert.ToInt32(vdr["Vinyl ID"]);
                vnlist.Artist = vdr["Artist"].ToString();
                vnlist.Title = vdr["Title"].ToString();
                //vnlist.ReleaseYear = Convert.ToInt32(vdr["Release Year"]);
                vnlist.Label = vdr["Label"].ToString();
                //vnlist.CatalogueNum = vdr["Catalogue Number"].ToString();
                displayvinyl.Add(vnlist);
            }
            return View(displayvinyl);
        }
    }
}
