using Billing.Domain.Entity;
using Billing.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly BillingContext _context;

        public MarkRepository (BillingContext context)
        {
            _context = context;
        }
        public List<Mark> GetMarks()
        {
            return _context.Marks.ToList();
        }

        public Mark GetMarkByID(int MarkId)
        {
            return _context.Marks.Find(MarkId);
        }

        public void InsertMark(Mark mark)
        {
            _context.Marks.Add(mark);
            _context.SaveChanges();
        }

        public void DeleteMark(int markID)
        {
            Mark mark = _context.Marks.Find(markID);
            _context.Marks.Remove(mark);
            _context.SaveChanges();
        }

        public void UpdateMark(Mark mark)
        {
            _context.Entry(mark).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SaveMark()
        {
            _context.SaveChanges();
        }
    }
}

