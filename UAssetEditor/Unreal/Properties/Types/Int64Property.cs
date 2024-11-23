using UAssetEditor.Binary;


namespace UAssetEditor.Unreal.Properties.Types;

public class Int64Property : AbstractProperty<long>
{
    public override void Read(Reader reader, PropertyData? data, Asset? asset = null,
        ESerializationMode mode = ESerializationMode.Normal)
    {
        Value = mode == ESerializationMode.Zero ? 0 : reader.Read<long>();
    }

    public override void Write(Writer writer, UProperty property, Asset? asset = null, ESerializationMode mode = ESerializationMode.Normal)
    {
        writer.Write(Value);
    }
}