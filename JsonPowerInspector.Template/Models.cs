using System.Text.Json.Serialization;

namespace JsonPowerInspector.Template;

[JsonSerializable(typeof(ApplicationJsonTypes))]
public partial class PowerTemplateJsonContext : JsonSerializerContext { }

public class ApplicationJsonTypes
{
    public JsonFileInfo JsonFileInfo { get; set; }
}

public class JsonFileInfo
{
    public string DataPath { get; set; }
    public ObjectDefinition MainObjectDefinition { get; set; }
    public ObjectDefinition[] ReferencedObjectDefinition { get; set; }
}

public class ObjectDefinition
{
    public string ObjectTypeName { get; set; }
    public ObjectPropertyInfo[] Properties { get; set; }
}

public class ObjectPropertyInfo
{
    public enum PropertyType
    {
        String,
        Number,
        Object,
        Bool,
        Array,
        Dictionary
    }

    public PropertyType Type { get; set; }
    public string Name { get; set; }
}

public class NumberProperty : ObjectPropertyInfo
{
    public record struct NumberRange(double Lower, double Upper);

    public enum NumberType
    {
        Int,
        Float
    }

    public enum PrecisionType
    {
        Bit8,
        Bit16,
        Bit32,
        Bit64,
    }

    public enum SignType
    {
        Signed,
        Unsigned
    }

    public NumberType Number { get; set; }
    public PrecisionType Precision { get; set; }
    public SignType Sign { get; set; }
    public NumberRange Range { get; set; }
}

public class ObjectProperty : ObjectPropertyInfo
{
    public string ObjectTypeName { get; set; }
}

public class ArrayProperty : ObjectPropertyInfo
{
    public string ArrayElementTypeName { get; set; }
}

public class DictionaryProperty : ObjectPropertyInfo
{
    public string KeyTypeName { get; set; }
    public string ValueTypeName { get; set; }
}