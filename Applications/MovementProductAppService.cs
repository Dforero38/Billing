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
        private readonly IMovementBillDomainService _movementBillDomainService;

        public MovementProductAppService(IMovementProductDomainService movementProductDomainService, 
                                         IMapper mapper, IResidueDomainService residueDomainService, IMovementBillDomainService movementBillDomainService)
        {
            _movementProductDomainService = movementProductDomainService;
            _residueDomainService = residueDomainService;
            _mapper = mapper;
            _movementBillDomainService = movementBillDomainService;
            
        }
        public bool InsertMovementProduct(CreateMovementProductDTO movementProductDTO)
        {
            try
            {
                MovementProduct movementProductMap = _mapper.Map<CreateMovementProductDTO, MovementProduct>(movementProductDTO);
                var result = _movementProductDomainService.InsertMovementProduct(movementProductMap);
                if (result)
                {
                    var result1 = _residueDomainService.InsertResidue(movementProductDTO.IdProduct, movementProductDTO.Quantity);
                    if (result1)
                    {
                        var result2 = _movementBillDomainService.SumTotalMovementBill(movementProductDTO.IdMovementBill, (int)movementProductDTO.TotalValue);
                        result = result2;
                    }
                }

                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateMovementProduct(CreateMovementProductDTO movementProductDTO)
        {
            try
            {
                var infoMovementProduct = _movementProductDomainService.GetMovementProductByID(movementProductDTO.Id);
                var result = _residueDomainService.UpdateResidue(infoMovementProduct.IdProduct, infoMovementProduct.Quantity);
                if (result)
                {
                    MovementProduct movementProductMap = _mapper.Map<CreateMovementProductDTO, MovementProduct>(movementProductDTO);
                    var result1 = _movementProductDomainService.UpdateMovementProduct(movementProductMap);
                    var result2 = _movementBillDomainService.RestTotalMovementBill(movementProductDTO.IdMovementBill, (int)movementProductDTO.TotalValue);
                       if (result2 && result1)
                    {
                        var result3 = _residueDomainService.InsertResidue(movementProductDTO.IdProduct, movementProductDTO.Quantity);
                        var result4 = _movementBillDomainService.SumTotalMovementBill(movementProductDTO.IdMovementBill, (int)movementProductDTO.TotalValue);
                        if (result3 && result4)
                        {
                            result = result4;
                        }                                      
                    }
                }                  
                return result;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public List<MovementProductDTO> GetMovementProduct(int idMovementBill)
        {
            try
            {
                var result = _movementProductDomainService.GetMovementProduct(idMovementBill);
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
                var infoMovementProduct = _movementProductDomainService.GetMovementProductByID(movementProductID);
                var result4 = _movementBillDomainService.SumTotalMovementBill(infoMovementProduct.IdMovementBill, (int)infoMovementProduct.TotalValue);
                var result1 = _residueDomainService.UpdateResidue(infoMovementProduct.IdProduct, infoMovementProduct.Quantity);
                if (result1) { 
                    var result = _movementProductDomainService.DeleteMovementProduct(movementProductID);
                    return result;
                }
                return result1;
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }
    }
}
