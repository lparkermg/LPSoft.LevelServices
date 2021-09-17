// <copyright file="ILevelService.cs" company="Luke Parker">
// Copyright (c) Luke Parker. All rights reserved.
// </copyright>

namespace LPSoft.LevelServices.Interfaces
{
    using System.IO;

    /// <summary>
    /// Interface for a level service implementation.
    /// </summary>
    /// <typeparam name="TMapData">The data type for map files.</typeparam>
    public interface ILevelService<TMapData>
    {
        /// <summary>
        /// Loads the base map layouts from the provided stream.
        /// </summary>
        /// <param name="mapStream">Stream to load the map data from.</param>
        void SetBaseMaps(Stream mapStream);

        /// <summary>
        /// Sets the current map.
        /// </summary>
        /// <param name="index">The index of the map to be set.</param>
        void SetCurrentMap(int index);
    }
}
