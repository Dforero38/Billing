﻿using Billing.Domain.Entity;

namespace Billing.Repositories.Contracts
{
    public interface IResidueRepository
    {
        void InsertResidue(int product, int quantity);
    }
}
