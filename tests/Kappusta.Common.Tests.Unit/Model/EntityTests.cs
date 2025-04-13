using Avvr.Kappusta.Kappusta.Common.Model;
using static TUnit.Assertions.Assert;

namespace Avvr.Kappusta.Kappusta.Common.Tests.Unit.Model;

public class EntityTests
{
    [Test]
    public async Task Test1() {
        var entity1  = new DerivedEntity("id");
        var entity2 = new DerivedEntity("id");

        await That(entity1).IsEqualTo(entity2);
    }

    private sealed class DerivedEntity : Entity<string> {
        public DerivedEntity(string id) : base(id)
        {
        }
    }
}

