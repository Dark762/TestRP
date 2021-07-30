using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiVersion("1.0")]
    [ApiController, Route("Producto")]
    public class ProductoController : ControllerBase
    {
        private IConfiguration _configuration;

        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("health")]
        public IActionResult health()
        {
            return Ok("Hello");
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Producto producto)
        {

            try
            {
                int rowsAffected = 0;

                using (IDbConnection db = new SqlConnection(_configuration.GetSection("CustomerConnection").Value))
                {
                    //string sqlQuery = "Insert Into Producto (Nombre, Precio, Stock, FechaRegistro) Values(@Nombre, @Precio, @Stock, @FechaRegistro)";

                    string sqlQuery = "exec USP_INS_PRODUCTO @Nombre, @Precio, @Stock, @FechaRegistro";

                    rowsAffected = db.Execute(sqlQuery, producto);
                }

                if (rowsAffected > 0)
                {
                    return StatusCode(201);

                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch
            {

                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Producto producto)
        {
            try
            {
                int rowsAffected = 0;

                using (IDbConnection db = new SqlConnection(_configuration.GetSection("CustomerConnection").Value))
                {

                    string sqlQuery = "exec USP_UPD_PRODUCTO @Id, @Nombre, @Precio, @Stock, @FechaRegistro";

                    rowsAffected = db.Execute(sqlQuery, producto);
                }

                if (rowsAffected > 0)
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch
            {
                this.HttpContext.Response.StatusCode = 500;
                return Ok(false);
            }
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult GetAll()
        {

            try
            {
                List<Producto> Productos = new List<Producto>();

                using (IDbConnection db = new SqlConnection(_configuration.GetSection("CustomerConnection").Value))
                {

                    Productos = db.Query<Producto>("Select * From Producto").ToList();
                }

                if (Productos.Count > 0)
                {
                    return Accepted("", Productos);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("GetById")]

        public IActionResult GetById(int Id)
        {
            try
            {

                Producto producto = new Producto();

                using (IDbConnection db = new SqlConnection(_configuration.GetSection("CustomerConnection").Value))
                {

                    producto = db.Query<Producto>("Select * From Producto where Id = " + Id.ToString()).ToList().FirstOrDefault();
                }

                if (producto != null)
                {
                    return Accepted("", producto);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] int Id)
        {
            try
            {
                int rowsAffected = 0;

                using (IDbConnection db = new SqlConnection(_configuration.GetSection("CustomerConnection").Value))
                {

                    string sqlQuery = "exec USP_DEL_PRODUCTO @Id";

                    var values = new { Id = Id };

                    rowsAffected = db.Execute(sqlQuery, values);
                }

                if (rowsAffected > 0)
                {
                    return Accepted("", Id);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
