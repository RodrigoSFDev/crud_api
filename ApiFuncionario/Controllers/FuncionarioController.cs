using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFuncionario.Interface;
using ApiFuncionario.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiFuncionario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionario _funcionarioInterface;
        public FuncionarioController(IFuncionario funcionario)
        {
            _funcionarioInterface = funcionario;
        }

        [HttpGet]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> GetFuncionarioById(int id)
        {
            ServerResponse<FuncionarioModel> serverResponse = await _funcionarioInterface.GetFuncionarioById(id);
            return Ok(serverResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> CreateFuncionarios(FuncionarioModel novoFuncionario)
        {
            return Created("", await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }
        [HttpPut]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> UpdateFuncionarios(FuncionarioModel funcionario)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = await _funcionarioInterface.UpdateFuncionario(funcionario);
            return Ok(serverResponse);
        }
        [HttpPost("inativo")]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> InativoFuncionarios(int id)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = await _funcionarioInterface.InativoFuncionario(id);
            return Ok(serverResponse);

        }
        [HttpDelete]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> DeleteFuncionarios(int id)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(serverResponse);
        }
    }
}