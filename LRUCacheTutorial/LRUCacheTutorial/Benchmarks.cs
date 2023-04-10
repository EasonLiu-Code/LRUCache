using BenchmarkDotNet.Attributes;
using LRUCacheTutorial;

[MemoryDiagnoser]
public class WriteBenchmarks
{
    // 保证写入的数据有一定的重复性，借此来测试LRU的最差时间复杂度
    private const int Capacity = 1000;
    private const int DataSize = 10_0000;
    
    private List<int> _data;

    [GlobalSetup]
    public void Setup()
    {
        _data = new List<int>();
        var shared = Random.Shared;
        for (int i = 0; i < DataSize; i++)
        {
            _data.Add(shared.Next(0, DataSize / 10));
        }
    }
    
    [Benchmark]
    public void LRUCache_V1()
    {
        var cache = new LRUCache<int, int>(Capacity);
        foreach (var item in _data)
        {
            cache.Put(item, item);
        }
    }
    
    [Benchmark]
    public void LRUCache_V2()
    {
        var cache = new LRUCache_V2<int, int>(Capacity);
        foreach (var item in _data)
        {
            cache.Put(item, item);
        }
    }
    
    [Benchmark]
    public void LRUCache_V3()
    {
        var cache = new LRUCache_V3<int, int>(Capacity);
        foreach (var item in _data)
        {
            cache.Put(item, item);
        }
    }
}

public class ReadBenchmarks
{
    // 保证写入的数据有一定的重复性，借此来测试LRU的最差时间复杂度
    private const int Capacity = 1000;
    private const int DataSize = 10_0000;
    
    private List<int> _data;
    private LRUCache<int, int> _cacheV1;
    private LRUCache_V2<int, int> _cacheV2;
    private LRUCache_V3<int, int> _cacheV3;

    [GlobalSetup]
    public void Setup()
    {
        _cacheV1 = new LRUCache<int, int>(Capacity);
        _cacheV2 = new LRUCache_V2<int, int>(Capacity);
        _cacheV3 = new LRUCache_V3<int, int>(Capacity);
        _data = new List<int>();
        var shared = Random.Shared;
        for (int i = 0; i < DataSize; i++)
        {
            int dataToPut  = shared.Next(0, DataSize / 10);
            int dataToGet = shared.Next(0, DataSize / 10);
            _data.Add(dataToGet);
            _cacheV1.Put(dataToPut, dataToPut);
            _cacheV2.Put(dataToPut, dataToPut);
            _cacheV3.Put(dataToPut, dataToPut);
        }
    }
    
    [Benchmark]
    public void LRUCache_V1()
    {
        foreach (var item in _data)
        {
            _cacheV1.Get(item);
        }
    }
    
    [Benchmark]
    public void LRUCache_V2()
    {
        foreach (var item in _data)
        {
            _cacheV2.Get(item);
        }
    }
    
    [Benchmark]
    public void LRUCache_V3()
    {
        foreach (var item in _data)
        {
            _cacheV3.Get(item);
        }
    }
}