using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaIOON.Models;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly DbManager _dbManager;

    public UsuariosController(DbManager dbManager)
    {
        _dbManager = dbManager;
    }

    [HttpPost]
    public IActionResult RegisterUser(Usuarios usuarios)
    {
        // Aquí puedes validar los datos de entrada

        _dbManager.InsertUser(usuarios);

        return Ok("registrado con exito...");
    }
}
