using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;

namespace EinsteinDumper.Infrastructure.FizzBuzz
{
    public class FizzBuzzRepository : IFizzBuzzRepository, IDisposable
    {
        const string path = "..\\fizzbuzz.txt";

        private readonly ILogger<FizzBuzzRepository> logger;
        private readonly FileStream fileStream;

        private bool disposedValue;

        public FizzBuzzRepository(ILogger<FizzBuzzRepository> logger)
        {
            this.logger = logger;
            this.fileStream = File.Open(path, FileMode.OpenOrCreate);
        }

        public async void Add(string number)
        {
            var dateTime = DateTime.UtcNow;
            byte[] result = UTF8Encoding.UTF8.GetBytes($"{dateTime}:{number}\n");
            this.fileStream.Seek(0, SeekOrigin.End);
            await this.fileStream.WriteAsync(result, 0, result.Length);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.fileStream.Close();
                    this.fileStream.DisposeAsync();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
