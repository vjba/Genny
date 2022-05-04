using Genny.Services;
using System;
using Xunit;

namespace Genny.Test
{
    public class GeneratorServiceTests
    {
        private readonly IGeneratorService systemUnderTest;

        public GeneratorServiceTests() => systemUnderTest = new GeneratorService();

        [Fact]
        public void UuidGenerator_List_IsValid()
        {
            // arrange
            var uuids = systemUnderTest.Uuids(100);

            var isUuid = true;
            // act
            foreach (var uuid in uuids)
            {
                isUuid = Guid.TryParse(uuid.ToString(), out _);

                if (!isUuid)
                {
                    break;
                }
            }

            // assert
            Assert.True(isUuid);
        }

        [Fact]
        public void IntGenerator_List_IsValid()
        {
            // arrange
            var ints = systemUnderTest.Ints(100, int.MinValue, int.MaxValue);

            // act
            var isInt = true;

            foreach (var num in ints)
            {
                isInt = int.TryParse(num.ToString(), out _);

                if (!isInt)
                {
                    break;
                }
            }

            // assert
            Assert.True(isInt);
        }
    }
}
