// <copyright file="TileBasedLevelService.cs" company="Luke Parker">
// Copyright (c) Luke Parker. All rights reserved.
// </copyright>

namespace LevelServices
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using LevelServices.Interfaces;

    /// <summary>
    /// Implements the <see cref="ILevelService{TMapData}"/> for tile based levels.
    /// </summary>
    /// <typeparam name="TMapData">The data type for the map data.</typeparam>
    public class TileBasedLevelService<TMapData> : ILevelService<TMapData>
    {
        /// <summary>
        /// Gets the loaded base maps.
        /// </summary>
        public TMapData[] BaseMaps { get; private set; }

        /// <summary>
        /// Gets the currently selected map.
        /// </summary>
        public TMapData CurrentMap { get; private set; }

        /// <summary>
        /// Loads maps from the provided <see cref="Stream"/> deserialized using <see cref="XmlSerializer"/>.
        /// </summary>
        /// <param name="mapStream">Stream to provide </param>
        public void SetBaseMaps(Stream mapStream)
        {
            if (mapStream == null)
            {
                throw new ArgumentNullException(nameof(mapStream));
            }

            var serializer = new XmlSerializer(typeof(TMapData[]));
            BaseMaps = (TMapData[])serializer.Deserialize(mapStream);
        }

        /// <inheritdoc />
        public void SetCurrentMap(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Cannot set current map, index cannot be negative");
            }

            if (BaseMaps == null)
            {
                throw new ArgumentException("Cannot set current map, base maps have not been loaded");
            }

            if (index > BaseMaps.Length)
            {
                throw new ArgumentException("Cannot set current map, index is higher than loaded maps length");
            }

            CurrentMap = BaseMaps[index];
        }
    }
}
