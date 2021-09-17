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
        public TMapData BaseMaps { get; private set; }

        /// <inheritdoc />
        public void SetBaseMaps(Stream mapStream)
        {
            if (mapStream == null)
            {
                throw new ArgumentNullException(nameof(mapStream));
            }

            var serializer = new XmlSerializer(typeof(TMapData));
            BaseMaps = (TMapData)serializer.Deserialize(mapStream);
        }
    }
}
