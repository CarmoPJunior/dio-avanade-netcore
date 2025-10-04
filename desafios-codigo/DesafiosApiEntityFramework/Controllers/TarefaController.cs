using DesafiosApiEntityFramework.Context;
using DesafiosApiEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafiosApiEntityFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            // caso contrário retornar OK com a tarefa encontrada

            var tarefa = await _context
                    .Tarefas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Id == id); ;

            if (tarefa == null)
            {
                return NotFound(new { mensagem = $"Tarefa com ID {id} não encontrada." });
            }
            return Ok(tarefa);
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF
            var tarefas = await _context.Tarefas
              .AsNoTracking()
              .OrderBy(p => p.Id)
              .ToListAsync();

            return Ok(tarefas);
        }

        [HttpGet("obter-por-titulo")]
        public async Task<IActionResult> ObterPorTitulo(string titulo)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData

            if (string.IsNullOrWhiteSpace(titulo))
            {
                return BadRequest(new { mensagem = "O título não pode ser vazio." });
            }

            var tarefas = await _context.Tarefas
                    .AsNoTracking()
                    .Where(p => p.Titulo.Contains(titulo))
                    .OrderBy(p => p.Id)
                    .ToListAsync();

            if (tarefas == null || !tarefas.Any())
            {
                return NotFound(new { mensagem = $"Nenhuma tarefa encontrada com o título: {titulo}" });
            }
            return Ok(tarefas);
        }


        [HttpGet("obter-por-data")]
        public async Task<IActionResult> ObterPorData(DateTime data)
        {
            var tarefas = await _context.Tarefas
                .AsNoTracking()
                .Where(x => x.Data.Date == data.Date)
                .ToListAsync();

            if (tarefas.Count == 0)
            {
                return NotFound(new { mensagem = $"Nenhuma tarefa encontrada na data {data:dd/MM/yyyy}" });
            }

            return Ok(tarefas);
        }

        [HttpGet("obter-por-status")]
        public async Task<IActionResult> ObterPorStatus(EnumStatusTarefa status)
        {

            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var tarefas = await _context.Tarefas
                .AsNoTracking()
                .Where(x => x.Status == status)
                .ToListAsync();

            if (tarefas.Count == 0)
            {
                return NotFound(new { mensagem = $"Nenhuma tarefa encontrada com status {status}" });
            }

            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
            {
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            }

            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = await _context.Tarefas.FindAsync(id);

            if (tarefaBanco == null)
            {
                return NotFound(new { mensagem = $"Tarefa com ID {id} não encontrada" });
            }

            if (tarefa.Data == DateTime.MinValue)
            {
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            }

            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            await _context.SaveChangesAsync();

            return Ok(tarefaBanco);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var tarefaBanco = await _context.Tarefas.FindAsync(id);

            if (tarefaBanco == null)
            {
                return NotFound(new { mensagem = $"Tarefa com ID {id} não encontrada" });
            }
            // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)

            _context.Tarefas.Remove(tarefaBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
