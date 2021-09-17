using LevelServices.Interfaces;
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

            var service = SetupService(expectedMaps);

            Assert.That(service.BaseMaps, Is.EqualTo(expectedMaps));
        }

        [Test]
        public void SetCurrentMap_GivenNoLoadedMaps_ThrowsArgumentException()
        {
            var service = new TileBasedLevelService<string>();
            Assert.That(() => service.SetCurrentMap(0), Throws.ArgumentException.With.Message.EqualTo("Cannot set current map, base maps have not been loaded"));
        }

        [Test]
        public void SetCurrentMap_GivenNegativeIndex_ThrowsArgumentException()
        {
            var service = new TileBasedLevelService<string>();
            Assert.That(() => service.SetCurrentMap(-5), Throws.ArgumentException.With.Message.EqualTo("Cannot set current map, index cannot be negative"));
        }

        [Test]
        public void SetCurrentMap_GivenIndexMoreThanMaps_ThrowsArgumentException()
        {
            var maps = new[] { "String 1", "Test 2", "Array Item 3" };

            var service = SetupService(maps);

            Assert.That(() => service.SetCurrentMap(maps.Length + 5), Throws.ArgumentException.With.Message.EqualTo("Cannot set current map, index is higher than loaded maps length"));
        }

        [Test]
        public void SetCurrentMap_GivenValidIndex_SetsCurrentMapProperty()
        {
            var maps = new[] { "String 1", "Test 2", "Array Item 3" };

            var service = SetupService(maps);
            service.SetCurrentMap(1);
            Assert.That(service.CurrentMap, Is.EqualTo(maps[1]));
        }

        private TileBasedLevelService<T> SetupService<T>(T[] dataToSet)
        {
            var memStream = new MemoryStream();
            var serializer = new XmlSerializer(typeof(T[]));
            serializer.Serialize(memStream, dataToSet);

            // Set to position zero before passing in the stream.
            memStream.Position = 0;
            var service = new TileBasedLevelService<T>();

            service.SetBaseMaps(memStream);

            return service;
        }
    }
}