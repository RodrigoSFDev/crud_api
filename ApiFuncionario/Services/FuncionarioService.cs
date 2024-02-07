using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFuncionario.Interface;
using ApiFuncionario.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiFuncionario.Services
{
    public class FuncionarioService : IFuncionario
    {
        private readonly Context _context;
        public FuncionarioService(Context context)
        {
            _context = context;
        }

        public async Task<ServerResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                if (novoFuncionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Informar dados";
                    serverResponse.Sucesso = false;
                    return serverResponse;
                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();
                serverResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (System.Exception ex)
            {

                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
                if (funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Nenhum funcionario encontrado";
                    serverResponse.Sucesso = false;
                }
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serverResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (System.Exception ex)
            {

                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServerResponse<FuncionarioModel> serverResponse = new ServerResponse<FuncionarioModel>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(func => func.Id == id);
                if (funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Nenhum funcionario encontrado";
                    serverResponse.Sucesso = false;
                }
                serverResponse.Dados = funcionario;
            }
            catch (System.Exception ex)
            {
                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                serverResponse.Dados = await _context.Funcionarios.ToListAsync();
                if (serverResponse.Dados.Count == 0)
                {
                    serverResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch (System.Exception ex)
            {
                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<FuncionarioModel>>> InativoFuncionario(int id)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if (funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Nenhum funcionario encontrado";
                    serverResponse.Sucesso = false;
                }
                funcionario!.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();
                serverResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (System.Exception ex)
            {

                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);
                if (funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Nenhum funcionario encontrado";
                    serverResponse.Sucesso = false;
                }
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();
                serverResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (System.Exception ex)
            {

                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;

            }
            return serverResponse;
        }
    }
}