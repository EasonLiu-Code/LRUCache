``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.23430.1000)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2


```
|      Method |      Mean |     Error |    StdDev |
|------------ |----------:|----------:|----------:|
| LRUCache_V1 | 18.977 ms | 0.3432 ms | 0.3042 ms |
| LRUCache_V2 |  1.993 ms | 0.0397 ms | 0.0664 ms |
| LRUCache_V3 |  1.705 ms | 0.0327 ms | 0.0389 ms |
