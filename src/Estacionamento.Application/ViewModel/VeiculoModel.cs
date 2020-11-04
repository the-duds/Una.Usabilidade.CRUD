﻿using Flunt.Notifications;
using Flunt.Validations;

namespace Estacionamento.Application.ViewModel
{
    public class VeiculoModel : Notifiable, IValidatable
    {
       //public string Id { get; set; }
        public string Placa { get; set; }
        public string NomeMotorista { get; set; }
        public string CpfMototista { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
      

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires().IsNotNullOrEmpty(Placa, nameof(Placa), "Placa não pode ser vazio")
                .Requires().IsNotNullOrEmpty(NomeMotorista, nameof(NomeMotorista), "Nome do Motorista, não pode ser vazio")
                .Requires().IsNotNullOrEmpty(CpfMototista, nameof(CpfMototista), "CPF do Motorista não pode ser vazio")
                .Requires().HasMaxLen(Placa, 3, nameof(Placa), "Placa ter mais de 7 char - Valores possiveis: Sim ou Não")

            );
        }
    }

    

}
