//Esta clase la desarrolló Github Copilot. 
namespace TP05.Models;

//Crea el models Domicilio con sus atributos IdDomicilio, Calle, Numero y Departamento.
public class Domicilio
{
    public int IdDomicilio{get; set;}
    public string Calle{get; set;}
    public int Numero{get; set;}
    public string Departamento{get; set;}

    public bool domiciliosRepetidos(Domicilio DomicilioNuevo)
    {
        BD bd = new BD();
        List<Domicilio> Domicilios = bd.TraerDomicilios();
        int i = 0;
        bool validacion = true;
        while(DomicilioNuevo != Domicilios[i] && i < Domicilios.Count())
        {
            i++;
        }
        if(i < Domicilios.Count()){
            validacion = false;
        }
        return validacion;
    }
}