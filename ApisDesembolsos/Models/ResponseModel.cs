using System.ComponentModel.DataAnnotations;

namespace ApisDesembolsos.Models
{
    public class ResponseModel
    {

        public Int64 ID_SOLICITUD { get; set; }
        public string NOMBRE_OFICIAL { get; set; }

        [Required(ErrorMessage = "Introduzca su agencia")]
        public string AGENCIA { get; set; }

        [Required(ErrorMessage = "Introduzca su sucursal")]
        public string SUCURSAL { get; set; }

        [Required(ErrorMessage = "Introduzca el número de operación")]
        public Int64? NPRESTAMO { get; set; }

        [Required(ErrorMessage = "Especifíque primera fecha de pago")]
        public DateTime? PRIMERA_FECHA { get; set; }

        public string CORREO_PLATAFORMA { get; set; }
        public string CORREO_OFICIAL { get; set; }

        [Required(ErrorMessage = "Introducir el número de ticket")]
        public Int64? TICKET { get; set; }

        public DateTime FECHAHORA { get; set; }
        public string ESTADO { get; set; }
        public string RES_BUROS { get; set; }
        public string RES_PCCU { get; set; }
        public float MONTO { get; set; }
        public string ENLACE { get; set; }
    }

    public class SpResponse
    {
        public string Nomb_oficial { get; set; }
        public string Agencia { get; set; }
        public string Sucursal { get; set; }
        public Int64 NPrestamo { get; set; }
        public Int64 ticket { get; set; }
        public string PrimFecha { get; set; }
        public string CorreoPlataforma { get; set; }
        public string CorreoOficial { get; set; }
        public Int64 Id_Solicitud { get; set; }

    }

    public class SpResponseNsoli
    {
        public Int64 N_Solicitud { get; set; }
    }

    public class SpFullInfoPrestamoResponse
    {
        public Int64 ID_PRESTAMO { get; set; }
        public Int64 NPRESTAMO { get; set; }
        public Int64 NCLIENTE { get; set; }
        public string CI { get; set; }
        public string NOMBRE { get; set; }
        public Int64 NCUENTA { get; set; }
        public string APTO { get; set; }
        public Int64 MON_AP { get; set; }
        public Int64 NTRANSACCION { get; set; }
        public string TIPO_PRESTAMO { get; set; }
        public Int64 ID_SOLICITUD { get; set; }

    }

    public class SpSlctConPccu
    {
        public Int64 TIKET { get; set; }
        public Int64 ID_PERSONA { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string AP_CASADA { get; set; }
        public string NOMBRE { get; set; }
        public string CI { get; set; }
        public string usuario { get; set; }
        public string para_correo { get; set; }
        public string agencia { get; set; }
    }

    public class CI_RESPONSE
    {
        public string ci { get; set; }
    }
    public class ESTADO_RESPONSE
    {
        public string ESTADO { get; set; }
    }

    public class TICKET_RESPONSE
    {
        public Int64 TICKET { get; set; }
    }

    public partial class CARGO_RESPONSE
    {
        public Int64 IdTabla { get; set; }

        public Int64? IdApp { get; set; }

        public string? Rol { get; set; }

        public string? Descripcion { get; set; }
    }

}
