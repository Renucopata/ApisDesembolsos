using ApisDesembolsos.Handlers;
using ApisDesembolsos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApisDesembolsos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {

    

        [HttpGet("{CAGE}/{IDapp}")]
        public IActionResult Roles(Int64 CAGE, int IDapp)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            try
            {
                return Ok(pro.roles(CAGE, IDapp));
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = pro.roles(CAGE,IDapp)});
            }
           
        }



        [HttpPost] // Probada y funcionando
        [Route("solEnv")]
        public IActionResult solicitudEnvios([FromBody] REQUEST_ID data)
        {
            

            Procedures pro = new Procedures();
            ModelState.Clear();
            return Ok(pro.SpTraerSoliEnvios(data));
        }

      
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
  
            return Ok(pro.insertPlan(data));
        }

 
        [HttpPost] //Probado 
        [Route("GetPccuPendiente")]
        public IActionResult GetPccuPendiente([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
       
            return Ok(pro.PccuPendiente(data));
        }

        [HttpPost] //Probando
        [Route("acepPCCU")]
        public void pccuAceptado([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.PccuACEPTADO(data);

        }

        [HttpPost] //Probando
        [Route("procPCCU")]
        public void pccuProcesado([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.PccuProcesado(data);

        }

        [HttpPost]    //Probando
        [Route("errorPCCU")]
        public void pccuError([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.PccuError(data);

        }

        [HttpPost] //Probado
        [Route("solCompara")]
        public void solCompara([FromBody] REQUEST_TICKET_AND_CI data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.solicitudCompara(data);

        }

        [HttpPost] //Probando
        [Route("solProcesado")]
        public void solProcesado([FromBody] REQUEST_ID data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
            pro.solicitudProcesado(data);

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
        [Route("SPinserSol")] //Probada y funcionando
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
        [Route("getCiPersona")] //Probada y funcionando
        public IActionResult getCiPersona([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
     
            return Ok(pro.getCiPersona(data));
        }


        [HttpPost] //Probada y funcionando
        [Route("getCiPersona2")]
        public IActionResult getCiPersona2([FromBody] REQUEST_TICKET_AS_INT data)
        {
            Procedures pro = new Procedures();
            ModelState.Clear();
       
            return Ok(pro.getCiPersona2(data));
        }
    }
}
