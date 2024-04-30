using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaIOON.Models;

[ApiController]
[Route("[controller]")]
public class NegociosController : ControllerBase
{
    private readonly DbManager _dbManager;

    public NegociosController(DbManager dbManager)
    {
        _dbManager = dbManager;
    }

    [HttpPost]
    public IActionResult RegisterUser(Negocios negocios)
    {


        _dbManager.InsertarNegocio(negocios);

        return Ok("Registrado con exito");
    }
}
