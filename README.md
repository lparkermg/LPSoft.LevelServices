# LPSoft.LevelServices
Simple handling for levels.

## Usage

### Setting Maps

To set maps you need to setup a new service, with the expected data type that the map will be, for example:

```
// Data structure of the map data.
public class MapData
{
    public int Seed { get; set; }

    public int[] Data { get; set; }
}

// Somewhere in code.
var service = new LevelService<MapData>();
```

This will setup a new `LevelService` set to load data of the `MapData` type.

With that in place you will need to run the `SetBaseMaps` function providing a stream with the map data. The provided stream has to be an array of the specified data type otherwise the `XmlSerializer` will not be able to deserialize the stream.

Map setup example:
```
// Data to be serialised.
var mapData = new[] {
    new MapData() { Seed = 1, Data = new[] { 1, 2, 3} },
};

// Serialisation into the memory stream.
var memoryStream = new MemoryStream();
var serializer = new XmlSerializer(typeof(MapData[]))
serializer.Serialize(memoryStream, mapData);

// Setting the Base Maps in the LevelService.
service.SetBaseMaps(memoryStream);
```

### Selecting current map

The `LevelService` provides the option for it to manage the selected map if should it be required. This is done by calling the `SetCurrentMap` function and providing a suitable index.

This function will throw an exception if the base maps haven't been setup before hand or if the provided index is invalid.
