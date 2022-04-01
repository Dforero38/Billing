namespace Billing.Domains.Services.Contracts
{
    public interface IResidueDomainService
    {
        bool InsertResidue(int product, int quantity);
    }
}
