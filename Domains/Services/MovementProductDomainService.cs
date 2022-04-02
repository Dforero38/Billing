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

        public List<MovementProduct> GetMovementProduct(int idMovementBill)
        {
            try
            {
                return _movementProductRepository.GetMovementProducts(idMovementBill);
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

        public MovementProduct GetMovementProductByID(int movementProductID)
        {
            try
            {
                return _movementProductRepository.GetMovementProductByID(movementProductID);

                

            }
            catch
            {

                return new MovementProduct();
            }
        }

    }
}
