using AutoSerializer.Tests.Protos;

namespace AutoSerializer.Tests
{
    public class SerializationTests
    {
        private readonly PrimitiveTypesProto _primitiveTypesProto;
        private const int _primitiveTypesProtoSize = sizeof(byte)
                + sizeof(sbyte)
                + sizeof(short)
                + sizeof(ushort)
                + sizeof(int)
                + sizeof(uint)
                + sizeof(long)
                + sizeof(ulong)
                + sizeof(decimal)
                + sizeof(double)
                + sizeof(float)
                + sizeof(char); // == 60

        public SerializationTests()
        {
            _primitiveTypesProto = new PrimitiveTypesProto
            {
                ByteValue = 10,
                SByteValue = -10,
                ShortValue = -20,
                UShortValue = 20,
                IntValue = -30,
                UIntValue = 30,
                LongValue = -40,
                ULongValue = 40,
                DecimalValue = 50.5m,
                DoubleValue = 60.6d,
                FloatValue = 70.7f,
                CharValue = 'C'
            };
        }

        [Fact]
        public void Should_Serialize_PrimitiveTypes()
        {
            // Arrange
            var buffer = new byte[_primitiveTypesProtoSize];
            using var stream = new MemoryStream(buffer);

            // Act
            _primitiveTypesProto.Serialize(stream);

            // Assert
            var offset = 0;
            
            Assert.Equal(_primitiveTypesProtoSize, stream.Position);

            Assert.Equal(10, buffer[offset++]);
            Assert.Equal(-10, (sbyte)buffer[offset++]);

            Assert.Equal(-20, BitConverter.ToInt16(buffer, offset));
            offset += sizeof(short);

            Assert.Equal(20, BitConverter.ToUInt16(buffer, offset));
            offset += sizeof(ushort);

            Assert.Equal(-30, BitConverter.ToInt32(buffer, offset));
            offset += sizeof(int);

            Assert.Equal((uint)30, BitConverter.ToUInt32(buffer, offset));
            offset += sizeof(uint);

            Assert.Equal(-40, BitConverter.ToInt64(buffer, offset));
            offset += sizeof(long);

            Assert.Equal((ulong)40, BitConverter.ToUInt64(buffer, offset));
            offset += sizeof(ulong);

            var decimalBits = new int[sizeof(int)];
            decimalBits[0] = BitConverter.ToInt32(buffer, offset);
            offset += sizeof(int);
            decimalBits[1] = BitConverter.ToInt32(buffer, offset);
            offset += sizeof(int);
            decimalBits[2] = BitConverter.ToInt32(buffer, offset);
            offset += sizeof(int);
            decimalBits[3] = BitConverter.ToInt32(buffer, offset);
            offset += sizeof(int);

            var decimalValue = new Decimal(decimalBits);
            Assert.Equal(50.5m, decimalValue);

            Assert.Equal(60.6d, BitConverter.ToDouble(buffer, offset));
            offset += sizeof(double);

            Assert.Equal(70.7f, BitConverter.ToSingle(buffer, offset));
            offset += sizeof(float);

            Assert.Equal('C', BitConverter.ToChar(buffer, offset));
            offset += sizeof(char);

            Assert.Equal(offset, stream.Position);
        }

        [Fact]
        public void Should_Deserialize_PrimitiveTypes()
        {
            // Arrange
            var deserializedObject = new PrimitiveTypesProto();
            var offset = 0;
            var buffer = new byte[_primitiveTypesProtoSize];
            using var stream = new MemoryStream(buffer);
            _primitiveTypesProto.Serialize(stream);

            // Act
            deserializedObject.Deserialize(buffer, ref offset);

            // Assert
            Assert.Equal(_primitiveTypesProto, deserializedObject);
        }
    }
}