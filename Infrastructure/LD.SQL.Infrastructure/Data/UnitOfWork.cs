using SD.BuildingBlocks.Infrastructure;
using System.Threading.Tasks;

namespace LD.SQL.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private LDDBContext dbContext;

        public UnitOfWork(LDDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public int AffectedRows { get; private set; }

        public int Commit()
        {
            AffectedRows = dbContext.SaveChanges();
            return AffectedRows;
        }

        public async Task<int> CommitAsync()
        {
            AffectedRows = await dbContext.SaveChangesAsync();
            return AffectedRows;
        }

    }
}
