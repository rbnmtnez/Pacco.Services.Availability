﻿using Pacco.Services.Availability.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Pacco.Services.Availability.Core.Entities
{
    public class AggregateId : IEquatable<AggregateId>
    {
        public Guid Value { get; }

        public AggregateId() : this(Guid.NewGuid())
        {
        }

        public AggregateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidAggregateIdException(value);
            }

            Value = value;
        }

        public bool Equals([AllowNull] AggregateId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;  
            return Value.Equals(other.Value);
        }

        public override bool Equals([AllowNull]object obj)
        {
            if (ReferenceEquals (null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;  
            return Equals((AggregateId)obj);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static implicit operator Guid(AggregateId id) => id.Value;

        public static implicit operator AggregateId(Guid aggregateId) => new AggregateId(aggregateId);

        public override string ToString() => Value.ToString();
    }
}
