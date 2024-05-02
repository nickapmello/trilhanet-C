using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes
            if (Suite != null && Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException("Capacidade da suíte insuficiente para o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (DiasReservados <= 0 || Suite == null)
            {
                throw new InvalidOperationException("Dados da reserva incompletos para calcular a diária.");
            }
            
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplicar desconto de 10% para reservas de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplicando 10% de desconto
            }

            return valor;
        }
    }
}
