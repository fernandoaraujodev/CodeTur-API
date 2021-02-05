using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    //Properties => Launch => applicationUrl
    //IP SENAI 192.168.5.64

    //IP


    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Route("signup")]
        [HttpPost]
        //props( command, [fromservices] manipular/handler)
        public GenericCommandResult SingUp(CriarUsuarioCommand command,[FromServices] CriarUsuarioHandle handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
