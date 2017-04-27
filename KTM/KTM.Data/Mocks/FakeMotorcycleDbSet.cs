
namespace KTM.Data.Mocks
{
    using System.Linq;
    using Models.EntityModels;
    public class FakeMotorcycleDbSet:FakeDbSet<Motorcycle>
    {
        public override Motorcycle Find(params object[] keyValues)
        {
            int wantedId = (int) keyValues[0];
            this.set.FirstOrDefault(m => m.Id == wantedId);

            return base.Find(keyValues);
        }
    }
}
