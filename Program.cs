using System;

namespace ClaseAutomovil
{
    
    class Program
    {
        static void Main(string[] args)
        {
         
            Automovil automovil1 = new Automovil("Toyota", "MY-0173", "Corolla", "Rojo", 45, 13);
            Automovil automovil2 = new Automovil("Honda", "MN-1071", "Civic", "Azul", 50, 12);
            automovil1.mostrarDetalles();
            automovil1.ReabastecerCombustible(29);
            automovil1.Conducir(200);
            automovil1.PuedeConducir(100);
            Console.WriteLine("**********************************************************************************************");
            automovil2.mostrarDetalles();
            automovil2.ReabastecerCombustible(32);
            automovil2.Conducir(300);
            automovil2.PuedeConducir(200);
            Console.WriteLine("*********************************************************************************************************");
            Console.WriteLine($"Toyota puede conducir 200km: {automovil1.PuedeConducir(200)}");
            Console.WriteLine($"Honda puede conducir 300km: {automovil2.PuedeConducir(300)}");
        }

        public partial class Automovil
        {
            public string Marca { get; set; }
            public string Placa { get; set; }
            public string Modelo { get; set; }
            public string Color { get; set; }
            public double CapacidadTanqueCombustible { get; set; }
            public double NivelCombustible { get; set; } = 0;
            public double RendimientoCombustible { get; set; }

            public Automovil(string marca, string placa, string modelo, string color, double capacidadTanqueCombustible, double rendimientoCombustible)
            {
                Marca = marca;
                Placa = placa;
                Modelo = modelo;
                Color = color;
                CapacidadTanqueCombustible = capacidadTanqueCombustible;
                NivelCombustible = 0; 
                RendimientoCombustible = rendimientoCombustible;
            }
            public void mostrarDetalles()
            {

                Console.WriteLine($"Marca: {Marca}, Placa: {Placa}, Modelo: {Modelo}, Color: {Color}, Capacidad del tanque de Combustible: {CapacidadTanqueCombustible}, Rendimiento: {RendimientoCombustible}");
            }
        }
        public partial class Automovil
        {
            public void Conducir(int distancia)
            {
                double consumo = distancia / RendimientoCombustible; 
                if (consumo <= NivelCombustible)
                {
                    Console.WriteLine($"Conduciendo {distancia} Km");
                    NivelCombustible -= consumo;
                    Console.WriteLine($"Combustible restante: {NivelCombustible} galones");
                }
                else
                {
                    Console.WriteLine("No hay suficiente combustible para el viaje");
                }
            }
            
            public void ReabastecerCombustible(double cantidad)
            {
                if (cantidad > 0)
                {
                    double espacioDisponible = CapacidadTanqueCombustible - NivelCombustible;
                    if (cantidad <= espacioDisponible)
                    {
                        NivelCombustible += cantidad;
                        Console.WriteLine($"Se reabastecieron {cantidad} galones de combustible");
                    }
                    else
                    {
                        Console.WriteLine($"No es posible reabastecer mas de {espacioDisponible} galones");
                    }
                }
                else
                {
                    Console.WriteLine("La cantidad de combustible a reabastecer debe ser mayor que cero");
                }
            }


            public bool PuedeConducir(int distancia)
            {
                double consumoCombustible = distancia / RendimientoCombustible;
                return consumoCombustible <= NivelCombustible;
            }
        }


    }




}



