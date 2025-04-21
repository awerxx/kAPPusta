using Avvr.Kappusta.Kappusta.Common.Model;

namespace Avvr.Kappusta.Zoya.Domain.Entities;

public class AccountName : ValueObject
{
    private readonly string _value;

    public AccountName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty", paramName: nameof(value));

        if (value.Length > 50)
            throw new ArgumentException("Name cannot be longer than 50 characters", paramName: nameof(value));

        if (!value.All(char.IsLetterOrDigit) && char.IsDigit(value[0]))
            throw new ArgumentException("Name cannot start with a number", paramName: nameof(value));

        _value = value;
    }

    public override string ToString() => _value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}