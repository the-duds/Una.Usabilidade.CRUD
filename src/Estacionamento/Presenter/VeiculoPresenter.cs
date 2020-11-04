﻿using Estacionamento.Application.Interfaces.Boundaries.Veiculos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Presenter
{
    public class VeiculoPresenter : IVeiculoOutputPort
    {
        /// <summary>
        /// O resultado viewmodel da rota.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        /// Produz o resultado 404 notfound.
        /// </summary>
        /// <param name="message">Output da rota.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// Produz o resultado de sucesso do endpoint.
        /// </summary>
        /// <param name="output">Output da rota.</param>
        public void Success(VeiculoOutput output) => this.ViewModel = new OkObjectResult(output);

        /// <summary>
        /// Produz o resultado bad request 400, de forma amigável
        /// </summary>
        /// <param name="message">Output da rota.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);

        /// <summary>
        /// Produz o resultado bad request 400, de forma amigável
        /// </summary>
        /// <param name="errors">Coleção de erros de validação de dados.</param>
        public void WriteError(IReadOnlyCollection<Flunt.Notifications.Notification> errors)
        {
            var erros = new Models.ErrorModel(errors);
            this.ViewModel = new BadRequestObjectResult(erros);
        }
    }
}
