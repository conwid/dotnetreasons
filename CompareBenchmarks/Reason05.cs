using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace CompareBenchmarks
{
    public class Reason05
    {
        private byte[] data = Enumerable.Range(0, 100_000).Select(i => (byte)i).ToArray();
        private MemoryStream target = new MemoryStream();

        [Benchmark]
        public async Task EncodeBase64()
        {
            target.Position = 0;
            using (var toBase64 = new ToBase64Transform())
            using (var stream = new CryptoStream(target, toBase64, CryptoStreamMode.Write, leaveOpen: true))
            {
                await stream.WriteAsync(data, 0, data.Length);
            }
        }
    }
}