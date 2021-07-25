using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CP380_B1_BlockList.Models;



namespace TestBlock
{
    [TestClass]
    public class TestCalculateHash
    {
        [TestMethod]
        public void TestGenesisBlock()
        {
            // NOTE: inputString is == "0001-01-01 12:00:00 AM--0-[]"
            var dt = new System.DateTime(0);
            var block = new Block(dt, "", new List<Payload>());
            Assert.AreEqual("wPdk2JeNwKVj6W81T9QZsJrUg6RR+E5kS+Gjo33lm5I=", block.Hash);
        }

        [TestMethod]
        public void TestMineGenesisBlockNonce()
        {
            var dt = new System.DateTime(0);
            var block = new Block(dt, "", new List<Payload>());
            block.Mine(2);
            Assert.AreEqual(2430, block.Nonce);
        }

        [TestMethod]
        public void TestMineGenesisBlockHash()
        {
            var dt = new System.DateTime(0);
            var block = new Block(dt, "", new List<Payload>());
            block.Mine(2);
            Assert.AreEqual("CCtB4okuetq1eFoWjmlGSqm9MQw5bQVDgK8mjasBCws=", block.Hash);
        }

        [TestMethod]
        public void TestBlockWithPreviousHash()
        {
            var dt = new System.DateTime(0);
            var previousHash = "wPdk2JeNwKVj6W81T9QZsJrUg6RR+E5kS+Gjo33lm5I=";
            var block = new Block(dt, previousHash, new List<Payload>());
            Assert.AreEqual("S5gde9qo8tOzzioa5XvboAgAg+UbkUqf3hkR3yGSIgU=", block.Hash);
        }

        [TestMethod]
        public void TestMineBlockWithPreviousHash()
        {
            var dt = new System.DateTime(0);
            var previousHash = "wPdk2JeNwKVj6W81T9QZsJrUg6RR+E5kS+Gjo33lm5I=";
            var block = new Block(dt, previousHash, new List<Payload>());
            block.Mine(2);
            Assert.AreEqual(1980, block.Nonce);
            Assert.AreEqual("CCbdM7TlXH8fJgbQKk8BaoYj2nOVBgx0sMs5P0lHhJ0=", block.Hash);
        }

        [TestMethod]
        public void TestBlockWithPayloadHash()
        {
            //
            // NOTE: input string = "0001-01-01 12:00:00 AM--0-[{\"User\":\"test\",\"TransactionType\":0,\"Amount\":0,\"Item\":\"item\"}]"
            //
            var dt = new System.DateTime(0);
            var payload = new List<Payload>() { new Payload("test", TransactionTypes.BUY, 0, "item") };
            var block = new Block(dt, "", payload);
            Assert.AreEqual("HDrIu8h6RPfm9vyb6LYwU3XJN7INQ6ab44s/egmLfi8=", block.Hash);
        }

        [TestMethod]
        public void TestMineWithAllFieldsUsed()
        {
            var dt = new System.DateTime(0);
            var payload = new List<Payload>() { 
                new Payload("test", TransactionTypes.BUY, 0, "item"),
                new Payload("test", TransactionTypes.SELL, 3, "second-item") 
            };
            var previousHash = "wPdk2JeNwKVj6W81T9QZsJrUg6RR+E5kS+Gjo33lm5I=";
            var block = new Block(dt, previousHash, payload);
            block.Mine(2);
            Assert.AreEqual(1635, block.Nonce);
            Assert.AreEqual("CCiy4uRQmu1hcU4NFyPXK8E47bIYrDH5PxMiBJuOUB8=", block.Hash);
        }
    }
}
