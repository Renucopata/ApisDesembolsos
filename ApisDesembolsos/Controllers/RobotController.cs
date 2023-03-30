using ApisDesembolsos.Handlers;
using ApisDesembolsos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ApisDesembolsos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RobotController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /*[HttpPost] // Sin probar
        [Route("cargarRb")]
        public IActionResult GetPccuPendiente(ModeloDesembolso desem, string correp, string nombre)
        {
            ProceduresBuros pro = new ProceduresBuros();
            ModelState.Clear();
            return Ok(pro.CargaDatos(desem, correp, nombre));
        }*/

        [HttpPost] // Probada y funcionando
        [Route("solEnv")]
        public IActionResult solicitudEnvios([FromBody] REQUEST_ID data)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConexionBDD").ToString());

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpTraerSoliEnvios(data));
        }

        // GET api/values/5
        [HttpGet] // Probada 
        [Route("solPCCU")]
        public IActionResult GetPccu()
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SolicitudPccu());
        }

        [HttpPost] //Probado
        [Route("addPlan")]
        public IActionResult insertPlan([FromBody] REQUEST_TICKET data)
        {

            Procedures pro = new Procedures();
            ModelState.Clear();
            //pro.insertPlan(data);
            return Ok(pro.insertPlan(data));
        }

        //GetPccuPendiente controller (Rene)
        [HttpPost] //Probado 
        [Route("GetPccuPendiente")]
        public IActionResult GetPccuPendiente([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            // pro.PccuPendiente(data);
            return Ok(pro.PccuPendiente(data));
        }

        [HttpPost] //Probando
        [Route("acepPCCU")]
        public void pccuAceptado([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.PccuACEPTADO(data);
            //return Ok(pro);
        }

        [HttpPost] //Probando
        [Route("procPCCU")]
        public IActionResult pccuProcesado([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.PccuProcesado(data);
            return Ok(pro);
        }

        [HttpPost]    //Probando
        [Route("errorPCCU")]
        public IActionResult pccuError([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.PccuError(data);
            return Ok(pro);
        }

        [HttpPost] //Probado
        [Route("solCompara")]
        public IActionResult solCompara([FromBody] REQUEST_TICKET_AND_CI data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.solicitudCompara(data);
            return Ok(pro);
        }

        [HttpPost] //Probando
        [Route("solProcesado")]
        public IActionResult solProcesado([FromBody] REQUEST_ID data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.solicitudProcesado(data);
            return Ok(pro);
        }

        //NewControllers

        [HttpPost]
        [Route("SPinserSolPccu")] //Probada y funcionando
        public IActionResult SpInserSolPccu([FromBody] REQUEST_TICKET_AND_IDPERSONA data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpInsertSolPCCU(data));
        }


        [HttpPost]
        [Route("SPinserSol")] //Prueba fallida no hace el insert en la tabla
        public IActionResult SpInserSol([FromBody] REQUEST_INFO_INSER_SOL data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpInsertSol(data));
        }

        [HttpGet]  //Probada y funcionando
        [Route("SpTraerSolFallida")]
        public IActionResult SpTraerSolFallida()
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpSolFallida());
        }

        [HttpGet]
        [Route("SpTraerSol")] //Probada y funcionando
        public IActionResult SpTraerSol()
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpTraerSol());
        }

        [HttpPost]
        [Route("SpInserPrest")] //Probada y funcionando
        public IActionResult SpInserPrest([FromBody] REQUEST_INFO_INSER_PREST data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpInsertPrest(data));
        }

        [HttpPost]
        [Route("SpUpdatePresApto")] //Probada y funcionando
        public IActionResult SpUpdatePresApto([FromBody] REQUEST_INFO_UPDATE_PREST_APTO data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpUpdatePrestApto(data));
        }



        //Buros Controllers

        [HttpPost] //Funciona pero no se comprobo
        [Route("SpInserReconGrupo")]
        public IActionResult SpInserReconGrupo([FromBody] REQUEST_INSER_RECONSULTA_GRUPO data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpInserReconGrp(data));
        }

        [HttpPost] //Funciona pero no se comprobo
        [Route("SpGetConsulPccu")]
        public IActionResult SpGetConsulPccu([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpSelecConsPccu(data));
        }


        [HttpPost]
        [Route("getCiPersona")]
        public IActionResult getCiPersona([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            // pro.getCiPersona(data);
            return Ok(pro.getCiPersona(data));
        }


        [HttpPost]
        [Route("getCiPersona2")]
        public IActionResult getCiPersona2([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            //pro.getCiPersona2(data);
            return Ok(pro.getCiPersona2(data));
        }
    }
}
