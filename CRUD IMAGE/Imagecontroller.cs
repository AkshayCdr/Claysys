
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using WatchWorld.Models;

namespace WatchWorld.Controllers
{
    public class ImageController : Controller
    {

        public ActionResult Index()
        {

            List<ImageModel> images = GetImagesFromDatabase();
            return View(images);
        }

        private List<ImageModel> GetImagesFromDatabase()
        {
            List<ImageModel> images = new List<ImageModel>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SPS_Registration", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            images.Add(new ImageModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ImageData = Convert.ToBase64String((byte[])reader["ImageData"])
                            });
                        }
                    }
                }
            }
            return images;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(file.ContentLength);
                    }

                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("SPI_Registration", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageData;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            byte[] imageData = GetImageDataById(id);

            if (imageData != null)
            {

                string base64Image = Convert.ToBase64String(imageData);
                ViewBag.ImageData = base64Image;
                ViewBag.Id = id;

                return View(id);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    byte[] newImageData;
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        newImageData = binaryReader.ReadBytes(file.ContentLength);
                    }

                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("SPU_Registration", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = newImageData;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    /
                }
            }

            return View();
        }

        private byte[] GetImageDataById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SPS_ImageById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    return (byte[])cmd.ExecuteScalar();
                }
            }
        }

        private void UpdateImageDataById(int id, byte[] imageData)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SPU_ImageById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageData;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {

            byte[] imageData = GetImageDataById(id);

            if (imageData != null)
            {
                string base64Image = Convert.ToBase64String(imageData);
                ViewBag.ImageData = base64Image;
                ViewBag.Id = id;

                return View(id);
            }

            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SPD_Registration", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
            }

            return RedirectToAction("Index");
        }

        private void DeleteImageById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Images WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}
