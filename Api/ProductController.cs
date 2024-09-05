using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api;

[Route("")]
public class ProductController(MyDbContext context) : ControllerBase
{
    
    [HttpGet]
    [Route("api/products")]
    public ActionResult GetProducts()
    {
        //SQL alternative: return Ok(context.Products.FromSqlRaw($"select * from \"Products\"").ToList());
        return Ok(context.Products.ToList());
    }
    
    [HttpPost]
    [Route("api/products")]
    public ActionResult CreateProduct([FromBody] Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
        return Ok(product);
    }
}