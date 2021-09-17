using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LevelServices.Test
{
    public class TileBasedLevelServiceTests
    {
        [Test]
        public void SetBaseMaps_GivenNullMapData_ThrowsArgumentNullException()
        {
            var service = new TileBasedLevelService<string>();
            Assert.That(() => service.SetBaseMaps(null), Throws.ArgumentNullException);
        }

        [Test]
        public void SetBaseMaps_GivenValidMapData_SetsBaseMaps()
        {
            var expectedMaps = new[] { "String 1", "Test 2", "Array Item 3" };

            var memStream = new MemoryStream();
            var serializer = new XmlSerializer(typeof(string[]));
            serializer.Serialize(memStream, expectedMaps);

            // Set to position zero before passing in the stream.
            memStream.Position = 0;
            var service = new TileBasedLevelService<string[]>();

            service.SetBaseMaps(memStream);

            Assert.That(service.BaseMaps, Is.EqualTo(expectedMaps));
        }
    }
}