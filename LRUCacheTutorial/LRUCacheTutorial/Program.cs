// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LRUCacheTutorial;


var summary = BenchmarkRunner.Run<WriteBenchmarks>();
var summary2 = BenchmarkRunner.Run<ReadBenchmarks>();  
