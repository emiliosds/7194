using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [Route("v1/Lab")]
    public class LabController : ControllerBase
    {
        [HttpGet]
        [Route("cache")]
        [AllowAnonymous]
        public string Cache() => DateTime.Now.ToLongTimeString();

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Anonimo";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => "Autenticado";

        [HttpGet]
        [Route("administrador")]
        [Authorize(Roles = "administrador")]
        public string Administrador() => "Administrador";

        [HttpGet]
        [Route("gerente")]
        [Authorize(Roles = "gerente")]
        public string Gerente() => "Gerente";

        [HttpGet]
        [Route("colaborador")]
        [Authorize(Roles = "colaborador")]
        public string Colaborador() => "Colaborador";

        [HttpGet]
        [Route("suporte")]
        [Authorize(Roles = "suporte")]
        public string Suporte() => "Suporte";

        [HttpGet]
        [Route("cobranca")]
        [Authorize(Roles = "cobranca")]
        public string Cobranca() => "Cobrança";

        [HttpGet]
        [Route("suporte-ou-cobranca")]
        [Authorize(Roles = "suporte,cobranca")]
        public string SuporteOuCobranca() => "Suporte ou cobrança";

        [HttpGet]
        [Route("suporte-e-cobranca")]
        [Authorize(Roles = "suporte")]
        [Authorize(Roles = "cobranca")]
        public string SuporteEhCobranca() => "Suporte e cobrança";

        [HttpGet]
        [Route("relatorio")]
        [Authorize(Policy = "relatorio")]
        public string Relatorio() => "Relatório";
    }
}