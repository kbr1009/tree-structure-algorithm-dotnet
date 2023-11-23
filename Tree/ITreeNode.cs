namespace Tree
{
    public interface ITreeNode<T>
    {
        T Parent { get; set; }

        IList<T> Children { get; set; }

        T FindNode(string name);

        void DisplayTree(int depth = 0);

        string ToString(int depth = 0);

        T AddChild(T child);

        T RemoveChild(T child);

        bool TryRemoveChild(T child);

        T ClearChildren();

        bool TryRemoveOwn();

        T RemoveOwn();
    }
}
