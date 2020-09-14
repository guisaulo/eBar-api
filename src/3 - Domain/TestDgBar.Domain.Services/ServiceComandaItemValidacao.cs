using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestDgBar.Domain.Core.Interfaces.Repositories;
using TestDgBar.Domain.Core.Interfaces.Services;
using TestDgBar.Domain.Entities;
using TestDgBar.Domain.Services.Constants;

namespace TestDgBar.Domain.Services
{
    public class ServiceComandaItemValidacao : IServiceComandaItemValidacao
    {
        private readonly IRepositoryComandaItem repositoryComandaItem;
        private readonly IServiceComanda serviceComanda;
        private readonly IServiceItem serviceItem;

        public ServiceComandaItemValidacao(
            IRepositoryComandaItem repositoryComandaItem,
            IServiceComanda serviceComanda,
            IServiceItem serviceItem)
        {
            this.repositoryComandaItem = repositoryComandaItem;
            this.serviceComanda = serviceComanda;
            this.serviceItem = serviceItem;
        }

        public void ValidarInserirComandaItem(ComandaItem comandaItem)
        {
            ValidarSeItemExiste(comandaItem.ItemId);
            ValidarSeComandaExiste(comandaItem.ComandaId);
            ValidarQuantidadeSucosComanda(comandaItem);
        }

        public void ValidarSeComandaExiste(int comandaId)
        {
            var comanda = serviceComanda.ObterComanda(comandaId);
            if (comanda == default)
                throw new ValidationException(Properties.Resources.ComandaNaoExiste);
        }

        public void ValidarQuantidadeSucosComanda(ComandaItem comandaItem)
        {
            var quantidadeSucosComanda = repositoryComandaItem.GetAll().Where(c => c.ComandaId == comandaItem.ComandaId && c.ItemId == ItemConstants.Suco).Count();
            if (comandaItem.ItemId == ItemConstants.Suco && quantidadeSucosComanda >= ItemConstants.QuantidadeSucosPermitidaPorComanda)
                throw new ValidationException(Properties.Resources.QuantidadeSucosPermitida);
        }

        public void ValidarSeItemExiste(int itemId)
        {
            var comanda = serviceItem.ObterItem(itemId);
            if (comanda == default)
                throw new ValidationException(Properties.Resources.ItemNaoExiste);
        }
    }
}