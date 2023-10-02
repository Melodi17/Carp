using System.Collections;

namespace Carp.preprocessor;

public class ObjectStream<T> : IEnumerable<T>
{
    public bool HasNext => this._index < this._source.Count;
    
    private int _index = 0;
    private List<T> _source;
    public ObjectStream(IEnumerable<T> source)
    {
        this._source = source.ToList();
    }
    
    public T Next() => this._source[this._index++];
    public T Peek() => this._source[this._index];
    public void Reset() => this._index = 0;

    public IEnumerator<T> GetEnumerator()
    {
        while (this.HasNext)
            yield return this.Next();
    }
    
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
