``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.23430.1000)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2


```
|      Method |      Mean |     Error |    StdDev |     Gen0 |     Gen1 | Allocated |
|------------ |----------:|----------:|----------:|---------:|---------:|----------:|
| LRUCache_V1 | 15.379 ms | 0.2881 ms | 0.3318 ms | 750.0000 | 218.7500 |   4.65 MB |
| LRUCache_V2 |  6.993 ms | 0.1205 ms | 0.1340 ms | 703.1250 | 226.5625 |   4.23 MB |
| LRUCache_V3 |  5.722 ms | 0.1142 ms | 0.1971 ms | 585.9375 | 187.5000 |   3.53 MB |
