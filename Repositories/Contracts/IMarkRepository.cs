using Billing.Domain.Entity;
using System.Collections.Generic;

namespace Billing.Repositories.Contracts
{
    public interface IMarkRepository
    {
        public List<Mark> GetMarks();
        public Mark GetMarkByID(int MarkId);
        public void InsertMark(Mark mark);
        public void DeleteMark(int markID);
        public void UpdateMark(Mark mark);
        public void SaveMark();

    }
}
