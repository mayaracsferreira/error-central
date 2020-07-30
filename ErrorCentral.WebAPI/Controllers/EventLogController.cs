using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorCentral.AppDomain.DTO;
using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErrorCentral.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogService _eventLogService;

        public EventLogController(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService;
        }

        // GET: api/<EventLogController>
        /// <summary>
        /// Retorna todos os logs de erro armazenados no sistema
        /// </summary>
        /// <response code="200">Listagem feita com sucesso</response>
        /// <response code="500">Não foi possível listar os erros</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult Get()
        {
            var eventLog = _eventLogService.EventLogs().ToList();

            if (eventLog.Any())
            {
                return Ok(eventLog);
            }
            else
            {
                return NoContent();
            }
        }

        // GET ex.: api/eventlog/5
        /// <summary>
        /// Retorna todos detalhes de um log de erro dado id
        /// </summary>
        /// <response code="200">Erro retornado com sucesso</response>
        /// <response code="500">Não foi possível retornar o erro</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<EventLog> Get(int id)
        {
            var eventLog = _eventLogService.EventLogID(id);

            if (eventLog != null)
            {
                return Ok(eventLog);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Filtra os dados de acordo com os parâmetros dados pelo usuário
        /// </summary>
        /// <remarks>
        /// Enviroment can be: production, homologation or development
        /// 
        /// OrderBy can be: level or frequency (group by same description frequency)
        /// 
        /// SearchFor can be: level, description or origin
        /// 
        /// Field: Send the text you want to search in searchfor chosen option
        /// </remarks>
        /// <response code="200">Listagem de erros feita com sucesso</response>
        /// <response code="500">Não foi possível retornar a listagem filtrada</response> 
        [HttpGet("filters")]
        public ActionResult Get (string environment, string orderBy, string searchFor, string field)
        {
            List<EventFilterDTO> events = _eventLogService.Filtrar(environment, orderBy, searchFor, field);

            if (events != null)
            {
                return Ok(events);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<EventLogController>
        /// <summary>
        /// Insere um novo log de erro no sistema
        /// </summary>
        /// <response code="200">Log de erro inserido com sucesso</response>
        /// <response code="500">Não foi possível inserir o log de erro</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] EventLog eventLog)
        {
            var _eventlog = _eventLogService.Salvar(eventLog);

            return Ok(_eventlog);
        }

        // PUT api/eventlog
        /// <summary>
        /// Altera dados de algum log de erro já cadastrado, pode ser usado para arquivar um log
        /// </summary>
        /// <response code="200">Operação feita com sucesso</response>
        /// <response code="500">Não foi possível concluir a operação</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EventLog> Put(int id, [FromBody] EventLog eventLog)
        {
            var _event = _eventLogService.Atualizar(id, eventLog);
            if(_event != null)
            {
                return Ok(_event);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE ex.: api/eventlog/5
        /// <summary>
        /// Deleta um dado log de erro
        /// </summary>
        /// <response code="200">Operação feita com sucesso</response>
        /// <response code="500">Não foi possível concluir a operação</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Delete(int id)
        {
            var deletereturn = _eventLogService.Deletar(id);
            if(deletereturn)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
