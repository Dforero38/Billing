using AutoMapper;
using Billing.Applications.Contracts;
using Billing.Domain.Entity;
using Billing.Domains.Services.Contracts;
using Billing.DTOs;
using System.Collections.Generic;

namespace Billing.Applications
{
    public class MovementProductAppService : IMovementProductAppService
    {
        private readonly IMovementProductDomainService _movementProductDomainService;
        private readonly IMapper _mapper;
        private readonly IResidueDomainService _residueDomainService;

        public MovementProductAppService(IMovementProductDomainService movementProductDomainService, 
                                         IMapper mapper, IResidueDomainService residueDomainService)
        {
            _movementProductDomainService = movementProductDomainService;
            _residueDomainService = residueDomainService;
            _mapper = mapper;
            
        }
        public bool InsertMovementProduct(MovementProductDTO movementProductDTO)
        {
            try
            {
                MovementProduct movementProductMap = _mapper.Map<MovementProductDTO, MovementProduct>(movementProductDTO);
                var result = _movementProductDomainService.InsertMovementProduct(movementProductMap);
                if (result)
                {
                    var result1 = _residueDomainService.InsertResidue(movementProductDTO.IdProduct, movementProductDTO.Quantity);
                    result = result1;
                }
                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateMovementProduct(MovementProductDTO movementProductDTO)
        {
            try
            {
                MovementProduct movementProductMap = _mapper.Map<MovementProductDTO, MovementProduct>(movementProductDTO);
                var result = _movementProductDomainService.UpdateMovementProduct(movementProductMap);
                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public List<MovementProductDTO> GetMovementProduct()
        {
            try
            {
                var result = _movementProductDomainService.GetMovementProduct();
                List<MovementProductDTO> movementProduct = _mapper.Map<List<MovementProduct>, List<MovementProductDTO>>(result);
                return movementProduct;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public bool DeleteMovementProduct(int movementProductID)
        {
            try
            {
                var result = _movementProductDomainService.DeleteMovementProduct(movementProductID);
                return result;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }
    }
}
