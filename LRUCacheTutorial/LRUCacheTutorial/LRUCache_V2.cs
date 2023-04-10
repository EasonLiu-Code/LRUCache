using System.Collections;

public class LRUCache_V2<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private readonly LinkedList<KeyValuePair<TKey, TValue>> _list;
    
    private readonly Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> _dictionary;
    
    private readonly int _capacity;
    
    public LRUCache_V2(int capacity)
    {
        _capacity = capacity;
        _list = new LinkedList<KeyValuePair<TKey, TValue>>();
        _dictionary = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
    }
    
    public TValue Get(TKey key)
    {
        if (_dictionary.TryGetValue(key, out var node))
        {
            _list.Remove(node);
            _list.AddLast(node);
            return node.Value.Value;
        }
        
        return default;
    }
    
    public void Put(TKey key, TValue value)
    {
        if (_dictionary.TryGetValue(key, out var node))
        {
            node.Value = new KeyValuePair<TKey, TValue>(key, value);
            _list.Remove(node);
            _list.AddLast(node);
        }
        else
        {
            if (_list.Count == _capacity)
            {
                _dictionary.Remove(_list.First.Value.Key);
                _list.RemoveFirst();
            }
            
            var newNode = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            _list.AddLast(newNode);
            _dictionary.Add(key, newNode);
        }
    }
    
    public void Remove(TKey key)
    {
        if (_dictionary.TryGetValue(key, out var node))
        {
            _dictionary.Remove(key);
            _list.Remove(node);
        }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}