﻿using Avvr.Kappusta.Kappusta.Common.Model;

namespace Avvr.Kappusta.Zoya.Domain.Entities;

public sealed class AccountId : ValueObject
{
    public AccountId(Guid value) => Value = value;

    public Guid Value { get; }

    public static AccountId Create() => new(Guid.NewGuid());

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}