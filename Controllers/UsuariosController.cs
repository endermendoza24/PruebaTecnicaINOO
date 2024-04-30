using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous] 
    public IActionResult RegisterUser(Usuarios usuarios)
    {
        //  Validar los datos de entrada
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (_dbManager.ExisteUsuarioPorCorreo(usuarios.Correo))
        {
            return Conflict("El correo electrónico ya está registrado");
        }

        _dbManager.InsertarUsuario(usuarios);


        return Ok("Usuario registrado exitosamente");
    }
}
