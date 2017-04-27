
namespace KTM.Data.Mocks
{
    using System.Linq;
    using Models.EntityModels;
   public class FakeCategoryDbSet:FakeDbSet<Category>
    {
         public override Category Find(params object[] keyValues)
        {
            int wantedId = (int) keyValues[0];
            this.set.FirstOrDefault(c => c.Id == wantedId);

            return base.Find(keyValues);
        }
    }
}
