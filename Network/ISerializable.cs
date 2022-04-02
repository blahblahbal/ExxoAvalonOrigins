using System.IO;

namespace ExxoAvalonOrigins.Network;

public interface ISerializable
{
    /// <summary>
    /// Method used to implement binary serialization for this class
    /// </summary>
    /// <param name="writer"></param>
    void Write(BinaryWriter writer);

    /// <summary>
    /// Method used to implement binary deserialization for this class
    /// </summary>
    /// <param name="reader"></param>
    void Read(BinaryReader reader);
}