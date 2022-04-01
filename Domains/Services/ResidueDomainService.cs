using Billing.Domains.Services.Contracts;
using Billing.Repositories.Contracts;

namespace Billing.Domains.Services
{
    public class ResidueDomainService : IResidueDomainService
    {
        private readonly IResidueRepository _residueRepository;

        public ResidueDomainService (IResidueRepository residueRepository)
        {
            _residueRepository = residueRepository;
        }

        public bool InsertResidue(int product, int quantity)
        {
            try
            {
                _residueRepository.InsertResidue(product, quantity);
                return true;        
            }
            catch (System.Exception exception)
            {

                throw exception;
            }
        }
    }
}
