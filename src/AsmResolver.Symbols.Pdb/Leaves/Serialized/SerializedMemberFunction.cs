using AsmResolver.IO;

namespace AsmResolver.Symbols.Pdb.Leaves.Serialized;

/// <summary>
/// Provides a lazily initialized implementation of <see cref="MemberFunction"/> that is read from a PDB image.
/// </summary>
public class SerializedMemberFunction : MemberFunction
{
    private readonly PdbReaderContext _context;
    private readonly uint _returnTypeIndex;
    private readonly uint _declaringTypeIndex;
    private readonly uint _thisTypeIndex;
    private readonly ushort _parameterCount;
    private readonly uint _argumentListIndex;

    /// <summary>
    /// Reads a member function from the provided input stream.
    /// </summary>
    /// <param name="context">The reading context in which the function is situated in.</param>
    /// <param name="typeIndex">The index to assign to the type.</param>
    /// <param name="reader">The input stream to read from.</param>
    public SerializedMemberFunction(PdbReaderContext context, uint typeIndex, BinaryStreamReader reader)
        : base(typeIndex)
    {
        _context = context;
        _returnTypeIndex = reader.ReadUInt32();
        _declaringTypeIndex = reader.ReadUInt32();
        _thisTypeIndex = reader.ReadUInt32();
        CallingConvention = (CodeViewCallingConvention) reader.ReadByte();
        Attributes = (MemberFunctionAttributes) reader.ReadByte();
        _parameterCount = reader.ReadUInt16();
        _argumentListIndex = reader.ReadUInt32();
        ThisAdjuster = reader.ReadUInt32();
    }

    /// <inheritdoc />
    protected override CodeViewType? GetReturnType()
    {
        return _context.ParentImage.TryGetLeafRecord(_returnTypeIndex, out var leaf) && leaf is CodeViewType type
            ? type
            : _context.Parameters.ErrorListener.BadImageAndReturn<CodeViewType>(
                $"Member function {TypeIndex:X8} contains an invalid return type index {_returnTypeIndex:X8}.");
    }

    /// <inheritdoc />
    protected override CodeViewType? GetDeclaringType()
    {
        return _context.ParentImage.TryGetLeafRecord(_declaringTypeIndex, out var leaf) && leaf is CodeViewType type
            ? type
            : _context.Parameters.ErrorListener.BadImageAndReturn<CodeViewType>(
                $"Member function {TypeIndex:X8} contains an invalid declaring type index {_declaringTypeIndex:X8}.");
    }

    /// <inheritdoc />
    protected override CodeViewType? GetThisType()
    {
        return _context.ParentImage.TryGetLeafRecord(_thisTypeIndex, out var leaf) && leaf is CodeViewType type
            ? type
            : _context.Parameters.ErrorListener.BadImageAndReturn<CodeViewType>(
                $"Member function {TypeIndex:X8} contains an invalid this-type index {_thisTypeIndex:X8}.");
    }

    /// <inheritdoc />
    protected override ArgumentList? GetArguments()
    {
        if (_argumentListIndex == 0)
            return null;

        return _context.ParentImage.TryGetLeafRecord(_argumentListIndex, out var leaf) && leaf is ArgumentList list
            ? list
            : _context.Parameters.ErrorListener.BadImageAndReturn<ArgumentList>(
                $"Member function {TypeIndex:X8} contains an invalid argument list index {_argumentListIndex:X8}.");
    }
}
