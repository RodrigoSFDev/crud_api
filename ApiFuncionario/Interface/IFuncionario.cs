using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFuncionario.Model;

namespace ApiFuncionario.Interface
{
    public interface IFuncionario
    {
        Task<ServerResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServerResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
        Task<ServerResponse<FuncionarioModel>> GetFuncionarioById(int id);
        Task<ServerResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario);
        Task<ServerResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
        Task<ServerResponse<List<FuncionarioModel>>> InativoFuncionario(int id);
    }
}