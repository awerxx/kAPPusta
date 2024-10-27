using static TUnit.Assertions.Assert;

namespace Avvr.Kappusta.Kappusta.Common.Tests.Unit.Model;

public class EntityTests
{
    [Test]
    public async Task Test1() => await That(true).IsTrue();
}