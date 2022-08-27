
public class AgenciaData
{
    public string? NombreAgencia { get; set; }
    public string? Direccion { get; set; }
    public decimal? Aforo { get; set; }
    public decimal? CapacidadActual { get; set; }
    public decimal? Altitud { get; set; }
    public decimal? Latitud { get; set; }

    public string horarioAtencion {get;set;}

    public AgenciaData(string nombreAgencia, string direccion, decimal aforo, decimal capacidadActual, decimal altitud, decimal latitud,string horarioAtencion)
    {
        this.NombreAgencia = nombreAgencia;
        this.Direccion = direccion;
        this.Aforo = aforo;
        this.CapacidadActual = capacidadActual;
        this.Altitud = altitud;
        this.Latitud = latitud;
        this.horarioAtencion=horarioAtencion;
    }

    public AgenciaData(string? nombreAgencia, string? direccion, decimal? aforo, decimal? capacidadActual, decimal? altitud, decimal? latitud, string horarioCierreAtencion)
    {
        NombreAgencia = nombreAgencia;
        Direccion = direccion;
        Aforo = aforo;
        CapacidadActual = capacidadActual;
        Altitud = altitud;
        Latitud = latitud;
    }
}
