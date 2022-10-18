using System.ComponentModel;

namespace Aplication.Enum;

public enum ETypeField
{
    [Description("number")]
    Number = 0,
    [Description("string")]
    String = 1,
    [Description("data")]
    Data = 2
}