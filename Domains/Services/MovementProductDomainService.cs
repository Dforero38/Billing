using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.Repositories.Contracts;
using System.Collections.Generic;

namespace Billing.Domains.Services
{
    public class MovementProductDomainService : IMovementProductDomainService
    {
        private readonly IMovementProductRepository _movementProductRepository;
        public MovementProductDomainService (IMovementProductRepository movementProductRepository)
        {
            _movementProductRepository = movementProductRepository;
        }
        public bool InsertMovementProduct(MovementProduct movementProduct)
        {
            try
            {
                _movementProductRepository.InsertMovementProduct(movementProduct);
                return true;
            }
            catch 
            {

                return false;
            }
        }
        public bool UpdateMovementProduct(MovementProduct movementProduct)
        {
            try
            {
                _movementProductRepository.UpdateMovementProduct(movementProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<MovementProduct> GetMovementProduct()
        {
            try
            {
                return _movementProductRepository.GetMovementProducts();
            }
            catch
            {
                return new List<MovementProduct>();
            }
        }



        public bool DeleteMovementProduct(int movementProductID)
        {
            try
            {
                _movementProductRepository.DeleteMovementProduct(movementProductID);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
