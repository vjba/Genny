using Genny.Api.Services;
using System;
using Xunit;

namespace Genny.Api.Test
{
    public class GeneratorServiceTests
    {
        private readonly IGeneratorService systemUnderTest;

        public GeneratorServiceTests() => systemUnderTest = new GeneratorService();

        [Fact]
        public void IntGenerator_List_IsValid()
        {
            var ints = systemUnderTest.Ints(100, int.MinValue, int.MaxValue);

            foreach (var num in ints)
            {
                Assert.True(int.TryParse(num.ToString(), out _));
            }
        }

        [Fact]
        public void LongGenerator_List_IsValid()
        {
            var longs = systemUnderTest.Longs(100, long.MinValue, long.MaxValue);

            foreach (var num in longs)
            {
                Assert.True(long.TryParse(num.ToString(), out _));
            }
        }

        [Fact]
        public void UIntGenerator_List_IsValid()
        {
            var uints = systemUnderTest.UInts(100, uint.MinValue, uint.MaxValue);

            foreach (var num in uints)
            {
                Assert.True(uint.TryParse(num.ToString(), out _));
            }
        }

        [Fact]
        public void ULongGenerator_List_IsValid()
        {
            // arrange
            var ulongs = systemUnderTest.ULongs(100, ulong.MinValue, ulong.MaxValue);

            foreach (var num in ulongs)
            {
                Assert.True(ulong.TryParse(num.ToString(), out _));
            }
        }

        [Fact]
        public void UuidGenerator_List_IsValid()
        {
            // arrange
            var uuids = systemUnderTest.Uuids(100);

            foreach (var num in uuids)
            {
                Assert.True(Guid.TryParse(num.ToString(), out _));
            }
        }
    }
}
