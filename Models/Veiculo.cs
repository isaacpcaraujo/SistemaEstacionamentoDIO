using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {

        private string _placa;

        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa 
        {
            get { return _placa; }
            set
            {
                _placa = value.ToUpper();
            }
        }
        public Veiculo(string modelo, string cor, string placa)
        {
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
        }
    }
}