namespace Genny.Services
{
    /// <summary>
    /// Interface for Generator Service
    /// </summary>
    public interface IGeneratorService
    {
        /// <summary>
        /// Generates a list of Int32 within bounds
        /// </summary>
        /// <param name="numberOfItems">Number of ints</param>
        /// <param name="floor">Lowest value of ints</param>
        /// <param name="ceiling">Highest value of ints</param>
        /// <returns>List of Int32</returns>
        ICollection<int> Ints(int numberOfItems, int floor, int ceiling);

        /// <summary>
        /// Generates a list of longs / Int64 within bounds
        /// </summary>
        /// <param name="numberOfItems">Number of longs</param>
        /// <param name="floor">Lowest value of longs</param>
        /// <param name="ceiling">Highest value of longs</param>
        /// <returns>List of Int64</returns>
        ICollection<long> Longs(int numberOfItems, long floor, long ceiling);

        /// <summary>
        /// Generates a list of UInt32 within bounds
        /// </summary>
        /// <param name="numberOfItems">Number of uints</param>
        /// <param name="floor">Lowest value of uints</param>
        /// <param name="ceiling">Highest value of uints</param>
        /// <returns>List of UInt32</returns>
        ICollection<uint> UInts(int numberOfItems, uint floor, uint ceiling);

        /// <summary>
        /// Generates a list of ulongs / UInt64 within bounds
        /// </summary>
        /// <param name="numberOfItems">Number of ulongs</param>
        /// <param name="floor">Lowest value of ulongs</param>
        /// <param name="ceiling">Highest value of ulongs</param>
        /// <returns>List of UInt64</returns>
        ICollection<ulong> ULongs(int numberOfItems, ulong floor, ulong ceiling);

        /// <summary>
        /// Generates a list UUIDs / GUIDs
        /// </summary>
        /// <param name="numberOfItems">Numbers of UUIDs</param>
        /// <returns>List of UUID</returns>
        ICollection<Guid> Uuids(int numberOfItems);
    }
}
