using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using Xunit;
using CaesarsCipher;

namespace CaesarsCypherUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnsEmptyIfEmptyGiven()
        {
            Assert.Equal("", CaesarsCipher.Program.Encipher("", 5));
            
        }

        [Fact]
        public void DoesntEncypherSymbolsOrDigits()
        {
            string symbols = "1!@#$%^&*(){}/-";
            Assert.Equal(symbols, CaesarsCipher.Program.Encipher(symbols, 5));

        }

        [Fact]
        public void EncypherUpperCase()
        {
            
            Assert.Equal("DEF", CaesarsCipher.Program.Encipher("ABC", 3));
            Assert.Equal("ABC", CaesarsCipher.Program.Encipher("ABC", 0));
            Assert.Equal("A", CaesarsCipher.Program.Encipher("A", 26));
            Assert.Equal("BCD", CaesarsCipher.Program.Encipher("XYZ", 4));
            Assert.Equal("FGHIJ", CaesarsCipher.Program.Encipher("EFGHI", 1));
            //Assert.Equal("CaESars cYpHer", CaesarsCipher.Program.Encipher("abc", 3));
            Assert.Equal("D/E6F", CaesarsCipher.Program.Encipher("C/D6E", 1));
        }

        [Fact]
        public void EncypherLowerCase()
        {
            Assert.Equal("def", CaesarsCipher.Program.Encipher("abc", 3));
            Assert.Equal("abc", CaesarsCipher.Program.Encipher("abc", 0));
            Assert.Equal("a", CaesarsCipher.Program.Encipher("a", 26));
            Assert.Equal("bcd", CaesarsCipher.Program.Encipher("xyz", 4));
            Assert.Equal("fghij", CaesarsCipher.Program.Encipher("efghi", 1));
            Assert.Equal("d/e6f", CaesarsCipher.Program.Encipher("c/d6e", 1));
        }

        [Fact]
        public void MixedCase()
        {
            Assert.Equal("DbFTbst dZqIfs", CaesarsCipher.Program.Encipher("CaESars cYpHer", 1));
            Assert.Equal("E/dd- XJe6", CaesarsCipher.Program.Encipher("A/zz- TFa6", 4));
        }

        [Fact]
        public void NegativeKeyCycle()
        {
            Assert.Equal("yza", CaesarsCipher.Program.Encipher("abc", -2));
            Assert.Equal("A", CaesarsCipher.Program.Encipher("A", -26));
            Assert.Equal("6dEfgh ", CaesarsCipher.Program.Encipher("6fGhij ", -28));
            Assert.Equal("rst", CaesarsCipher.Program.Encipher("xyz", -110));

        }
        [Fact]
        public void PositiveKeyCycle()
        {
            Assert.Equal("cde", CaesarsCipher.Program.Encipher("abc", 2));
            Assert.Equal("A", CaesarsCipher.Program.Encipher("A", 26));
            Assert.Equal("6hIjkl ", CaesarsCipher.Program.Encipher("6fGhij ", 28));
            Assert.Equal("def", CaesarsCipher.Program.Encipher("xyz", 110));
        }
        [Fact]
        public void Decipher()
        {
            Assert.Equal("CaESars cYpHer", CaesarsCipher.Program.Decipher("DbFTbst dZqIfs", 1));
            Assert.Equal("A/zz- TFa6", CaesarsCipher.Program.Decipher("E/dd- XJe6", 4));
            Assert.Equal("abc", CaesarsCipher.Program.Decipher("yza", -2));
            Assert.Equal("A", CaesarsCipher.Program.Decipher("A", -26));
            Assert.Equal("rst", CaesarsCipher.Program.Decipher("xyz", 110));
        }

    }
}
