using Avvr.Kappusta.Kappusta.Common.Model;
using static TUnit.Assertions.Assert;

namespace Avvr.Kappusta.Kappusta.Common.Tests.Unit.Model;

internal class EntityTests
{
    [Test]
    public async Task Test1()
    {
        var entity1 = new DerivedEntity(100);
        var entity2 = new DerivedEntity(100);

        await That(entity1).IsEqualTo(entity2);
    }

    private sealed class DerivedEntity : Entity<int>
    {
        public DerivedEntity(int id)
            : base(id) { }
    }
}