using System.Collections;

namespace LRUCacheTutorial;

// 实现 IEnumerable 接口，方便遍历
public class LRUCache<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private readonly LinkedList<TKey> _list;

    private readonly Dictionary<TKey, TValue> _dictionary;

    private readonly int _capacity;
    
    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _list = new LinkedList<TKey>();
        _dictionary = new Dictionary<TKey, TValue>();
    }

    public TValue Get(TKey key)
    {
        if (_dictionary.TryGetValue(key, out var value))
        {
            // 在链表中删除 key，然后将 key 添加到链表的尾部
            // 这样就可以保证链表的尾部就是最近访问的数据，链表的头部就是最久没有被访问的数据
            // 但是在链表中删除 key 的时间复杂度是 O(n)，所以这个算法的时间复杂度是 O(n)
            _list.Remove(key);
            _list.AddLast(key);
            return value;
        }

        return default;
    }

    public void Put(TKey key, TValue value)
    {
        if (_dictionary.TryGetValue(key, out _))
        {
            // 如果插入的 key 已经存在，将 key 对应的值更新，然后将 key 移动到链表的尾部
            _dictionary[key] = value;
            _list.Remove(key);
            _list.AddLast(key);
        }
        else
        {          
            if (_list.Count == _capacity)
            {
                // 缓存满了，删除链表的头部，也就是最久没有被访问的数据
                _dictionary.Remove(_list.First.Value);
                _list.RemoveFirst();
            }

            _list.AddLast(key);
            _dictionary.Add(key, value);
        }
    }

    public void Remove(TKey key)
    {
        if (_dictionary.TryGetValue(key, out _))
        {
            _dictionary.Remove(key);
            _list.Remove(key);
        }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        foreach (var key in _list)
        {
            yield return new KeyValuePair<TKey, TValue>(key, _dictionary[key]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
