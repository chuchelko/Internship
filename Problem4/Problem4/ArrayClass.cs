namespace Problem4;

internal class ArrayClass<T>
{
    private T[] array;
    public int Length => array.Length;
    public ArrayClass(int size = 2)
    {
        array = new T[size];
    }
    public void Add(T item)
    {
        T[] newArray = new T[array.Length + 1];
        Array.Copy(array, newArray, array.Length);
        newArray[newArray.Length - 1] = item;
        array = newArray;
    }
    public void Delete(int index)
    {
        if (index < 0 || index >= array.Length)
            throw new ArgumentOutOfRangeException();
        T[] newArray = new T[array.Length - 1];
        for(int i = 0; i < index; i++)
            newArray[i] = array[i];
        for (int i = index; i < array.Length - 1; i++)
            newArray[i] = array[i + 1];
        array = newArray;
    }
    public T this[int index]
    {
        get { return array[index]; }
        set 
        {
            if(index >=0 && index < array.Length)
                array[index] = value;
        }
    }

}
