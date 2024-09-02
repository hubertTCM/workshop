namespace Leetcode.P146
{
    public class LRUCache
    {

        class Info
        {
            public int Version { get; set; }
            public int Key { get; set; }
            public int Value { get; set; }
        }

        private IDictionary<int, Info> _values = new Dictionary<int, Info>();

        private SortedDictionary<int, Info> _versions = new SortedDictionary<int, Info>();

        private int _capacity;

        int _currentVersion;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            Info info;
            if (_values.TryGetValue(key, out info))
            {
                Put(key, info.Value);
                return info.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_capacity <= 0)
            {
                return;
            }

            Info info;
            if (_values.TryGetValue(key, out info))
            {
                var oldVersion = info.Version;
                _currentVersion += 1;
                info.Version = _currentVersion;
                info.Value = value;

                _versions.Remove(oldVersion);
                _versions[info.Version] = info;
                return;
            }

            if (_values.Count < _capacity)
            {
                Add(key, value);
                return;
            }

            var oldestItem = _versions.Values.First();
            _versions.Remove(oldestItem.Version);
            _values.Remove(oldestItem.Key);
            Add(key, value);
        }

        private void Add(int key, int value)
        {
            _currentVersion += 1;
            var info = new Info()
            {
                Key = key,
                Value = value,
                Version = _currentVersion,
            };

            _versions[info.Version] = info;
            _values[info.Key] = info;
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}