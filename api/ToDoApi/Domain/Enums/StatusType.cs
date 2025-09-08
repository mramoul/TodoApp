using System.Runtime.Serialization;

public enum StatusType
{
    [EnumMember(Value = "toDo")]
    toDo = 0,

    [EnumMember(Value = "doing")]
    doing = 1,

    [EnumMember(Value = "done")]
    done = 2,

    [EnumMember(Value = "void")]
    Void = 999,
}