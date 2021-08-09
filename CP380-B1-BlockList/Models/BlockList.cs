using System;
using System.Collections.Generic;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            // TODO
            block.PreviousHash = Chain[Chain.Count - 1].Hash;
         
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public bool IsValid()
        {
            // TODO
            bool valid = true;
            for (int i=1; i<Chain.Count; i++)
            {
                string first = Chain[i].PreviousHash;
                string last = Chain[i - 1].Hash;
                string m = Chain[i].Hash;
                if (first != last || !m.StartsWith("CC"))
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }
    }
}
