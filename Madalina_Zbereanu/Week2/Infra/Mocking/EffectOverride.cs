using System;

namespace EarlyPay.Primitives.Mocking
{
    public class EffectOverride : IEquatable<EffectOverride>
    {
        public object Case { get; }
        public object CaseType { get; }
        public object Override { get; }

        public EffectOverride(object @case, object @override)
        {
            Case = @case;
            CaseType = @case.GetType();
            Override = @override;
        }

        public bool Equals(EffectOverride other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Case, other.Case) && Equals(Override, other.Override);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EffectOverride)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Case != null ? Case.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Override != null ? Override.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}