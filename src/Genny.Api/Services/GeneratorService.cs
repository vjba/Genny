namespace Genny.Services
{
    using Bogus;
    using System;
    using System.Collections.Generic;

    /// <inheritdoc/>
    public class GeneratorService : IGeneratorService
    {
        private readonly Randomizer randomizer;

        /// <inheritdoc/>
        public GeneratorService() => randomizer = new Randomizer();

        /// <inheritdoc/>
        public ICollection<int> Ints(int numberOfItems, int floor, int ceiling)
        {
            if (floor >= ceiling)
            {
                throw new ArgumentOutOfRangeException(nameof(floor), $"{nameof(floor)} must be less than {nameof(ceiling)}");
            }

            var ints = new HashSet<int>();

            while (ints.Count < numberOfItems)
            {
                ints.Add(randomizer.Number(floor, ceiling));
            }

            return ints;
        }

        /// <inheritdoc/>
        public ICollection<long> Longs(int numberOfItems, long floor, long ceiling)
        {
            if (floor >= ceiling)
            {
                throw new ArgumentOutOfRangeException(nameof(floor), $"{nameof(floor)} must be less than {nameof(ceiling)}");
            }

            var longs = new HashSet<long>();

            while (longs.Count < numberOfItems)
            {
                longs.Add(randomizer.Long(floor, ceiling));
            }

            return longs;
        }

        /// <inheritdoc/>
        public ICollection<uint> UInts(int numberOfItems, uint floor, uint ceiling)
        {
            if (floor >= ceiling)
            {
                throw new ArgumentOutOfRangeException(nameof(floor), $"{nameof(floor)} must be less than {nameof(ceiling)}");
            }

            var uints = new HashSet<uint>();

            while (uints.Count < numberOfItems)
            {
                uints.Add(randomizer.UInt(floor, ceiling));
            }

            return uints;
        }

        /// <inheritdoc/>
        public ICollection<ulong> ULongs(int numberOfItems, ulong floor, ulong ceiling)
        {
            if (floor >= ceiling)
            {
                throw new ArgumentOutOfRangeException($"{nameof(floor)}, {nameof(ceiling)}", $"{nameof(floor)} must be less than {nameof(ceiling)}");
            }

            var ulongs = new HashSet<ulong>();

            while (ulongs.Count < numberOfItems)
            {
                ulongs.Add(randomizer.ULong(floor, ceiling));
            }

            return ulongs;
        }

        /// <inheritdoc/>
        public ICollection<Guid> Uuids(int numberOfItems)
        {
            var guids = new HashSet<Guid>();

            while (guids.Count < numberOfItems)
            {
                guids.Add(Guid.NewGuid());
            }

            return guids;
        }
    }
}
