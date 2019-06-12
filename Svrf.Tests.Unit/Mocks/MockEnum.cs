using System.Runtime.Serialization;

namespace Svrf.Tests.Unit.Mocks
{
    internal enum MockEnum
    {
        [EnumMember(Value = "testEnumField1")]
        TestEnumFieldOne,
        [EnumMember(Value = "testEnumField2")]
        TestEnumFieldTwo
    }
}
