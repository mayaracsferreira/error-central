using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErrorCentral.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogService _eventLogService;

        public EventLogController(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService;
        }

        // GET: api/<EventLogController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<IEnumerable<EventLog>> Get()
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

        // GET api/eventlog/5
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

        // POST api/<EventLogController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EventLog> Post([FromBody] EventLog eventLog)
        {
            var _eventlog = _eventLogService.Salvar(eventLog);

            if (eventLog != null)
            {
                return Ok(eventLog);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT api/<EventLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
