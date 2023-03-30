namespace ApisDesembolsos.Models
{
    public class RequestDataModel
    {
    }

    public class REQUEST_TICKET
    {
        public string ticket { get; set; }
    }
    public class REQUEST_TICKET_AS_INT
    {
        public int ticket { get; set; }
    }

    public class REQUEST_TICKET_AND_CI
    {
        public int ticket { get; set; }
        public string ci { get; set; }
    }
    public class REQUEST_ID
    {
        public int id { get; set; }
    }
    public class REQUEST_TICKET_AND_IDPERSONA
    {
        public int ticket { get; set; }
        public int id { get; set; }
    }

    public class REQUEST_INFO_INSER_SOL
    {

        public string NOMB_OFICIAL { get; set; }
        public string AGENCIA { get; set; }
        public string SUCURSAL { get; set; }
        public int NPRESTAMO { get; set; }
        public string PRIMERA_FECHA { get; set; }
        public string CORREO_PLATAFORMA { get; set; }
        public string CORREO_OFICIAL { get; set; }
        public int TICKET { get; set; }
        public float MONTO { get; set; }
    }

    public class REQUEST_INFO_INSER_PREST
    {

        public int NPRESTAMO { get; set; }
        public int NCLIENTE { get; set; }
        public string CI { get; set; }
        public string NOMBRE { get; set; }
        public int NCUENTA { get; set; }
        public string TIPO_PRESTAMO { get; set; }
        public int ID_SOLICITUD { get; set; }

    }

    public class REQUEST_INFO_UPDATE_PREST_APTO
    {
        public int ID_PRESTAMO { get; set; }
        public string APTO { get; set; }
        public int NTRANSACCION { get; set; }
        public int MON_AP { get; set; }
        public string TIPO_PRESTAMO { get; set; }

    }

    public class REQUEST_INSER_RECONSULTA_GRUPO
    {
        public int TICKET { get; set; }
        public string PARA_CORREO { get; set; }
        public string USUARIO { get; set; }
        public string AGENCIA { get; set; }
        public int ID_SOLICITUD { get; set; }
    }
}
