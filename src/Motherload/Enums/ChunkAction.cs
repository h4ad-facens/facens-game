namespace Motherload.Models
{
    /// <summary>
    /// Enum para as ações possiveis para os chunks
    /// </summary>
    public enum ChunkAction
    {
        UNLOADED = 0,
        TO_LOAD = 1,
        LOADED = 2,
        DO_NOTHING = 3,
        DESTROY = 4,
    }
}
