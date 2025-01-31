using Models;

public class Bebida : Producto {

    public static int nextId = 1;
    public int Id {get; private set;}
    public bool EsAlcoholica {get;set;}

public Bebida(string nombre, double precio, bool esAlcoholica): base(nombre, precio) {
    Id = nextId++;
   EsAlcoholica = esAlcoholica;
}

    public override void MostrarDetalles() {
        string llevaAlcohol = EsAlcoholica ? "Sí" : "No";
        Console.WriteLine($"Bebida: {Nombre}, Precio {Precio:C}, ¿Es alcohólica? {llevaAlcohol} ");
    }
}