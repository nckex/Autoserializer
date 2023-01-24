using AutoSerializer.Definitions;

namespace AutoSerializer.Tests.Protos
{
    [AutoSerialize, AutoDeserialize]
    public partial class PrimitiveTypesProto
    {
        public byte ByteValue { get; set; }
        public sbyte SByteValue { get; set; }
        public short ShortValue { get; set; }
        public ushort UShortValue { get; set; }
        public int IntValue { get; set; }
        public uint UIntValue { get; set; }
        public long LongValue { get; set; }
        public ulong ULongValue { get; set; }
        public decimal DecimalValue { get; set; }
        public double DoubleValue { get; set; }
        public float FloatValue { get; set; }
        public char CharValue { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not PrimitiveTypesProto)
            {
                return false;
            }

            PrimitiveTypesProto other = (PrimitiveTypesProto)obj;
            return ByteValue == other.ByteValue
                && SByteValue == other.SByteValue
                && ShortValue == other.ShortValue
                && UShortValue == other.UShortValue
                && IntValue == other.IntValue
                && UIntValue == other.UIntValue
                && LongValue == other.LongValue
                && ULongValue == other.ULongValue
                && DecimalValue == other.DecimalValue
                && DoubleValue == other.DoubleValue
                && FloatValue == other.FloatValue
                && CharValue == other.CharValue;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(ByteValue);
            hashCode.Add(SByteValue);
            hashCode.Add(ShortValue);
            hashCode.Add(UShortValue);
            hashCode.Add(IntValue);
            hashCode.Add(UIntValue);
            hashCode.Add(LongValue);
            hashCode.Add(ULongValue);
            hashCode.Add(DecimalValue);
            hashCode.Add(DoubleValue);
            hashCode.Add(FloatValue);
            hashCode.Add(CharValue);
            return hashCode.ToHashCode();
        }
    }
}
