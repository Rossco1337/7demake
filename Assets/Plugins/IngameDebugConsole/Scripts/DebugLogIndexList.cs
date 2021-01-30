using System;

namespace IngameDebugConsole
{
    public class DebugLogIndexList
    {
        private int[] indices;

        public DebugLogIndexList()
        {
            indices = new int[64];
            Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index] => indices[index];

        public void Add(int index)
        {
            if (Count == indices.Length)
                Array.Resize(ref indices, Count * 2);

            indices[Count++] = index;
        }

        public void Clear()
        {
            Count = 0;
        }

        public int IndexOf(int index)
        {
            return Array.IndexOf(indices, index);
        }
    }
}