using System.Text;

namespace StrategyPattern2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Compressor compressor = new Compressor();
            string data = "aabcccccaaa";

            compressor.setCompressionStrategy(new RunLengthEncoding());
            Console.WriteLine($"RLE Compression {compressor.compress(data)}");

            compressor.setCompressionStrategy(new SimpleReplacementCompression());
            Console.WriteLine($"Simple Replacement {compressor.compress(data)}");
        }
    }

    // * 인터페이스
    interface CompressionStrategy
    {
        string compress(string data);
    }

    // * 인터페이스 를 구현하는 클래스
    class RunLengthEncoding : CompressionStrategy
    {
        public string compress(string data)
        {
            StringBuilder compressed = new StringBuilder();
            int count = 1;
            for (int i = 1; i <= data.Length; i++)
            {
                if (i < data.Length && data[i] == data[i - 1])
                {
                    count++;
                }
                else
                {
                    compressed.Append(data[i - 1]);
                    compressed.Append(count);
                    count = 1;
                }
            }
            return compressed.ToString();
        }
    }

    // * 인터페이스 를 구현하는 클래스
    class SimpleReplacementCompression : CompressionStrategy
    {
        public string compress(string data)
        {
            return data.Replace("a", "1")
                   .Replace("e", "2")
                   .Replace("i", "3")
                   .Replace("o", "4")
                   .Replace("u", "5");
        }
    }

    // Context
    class Compressor
    {
        private CompressionStrategy strategy;

        public void setCompressionStrategy(CompressionStrategy strategy)
        {
            this.strategy = strategy;
        }

        public string compress(string data)
        {
            return strategy.compress(data);
        }
    }

}
