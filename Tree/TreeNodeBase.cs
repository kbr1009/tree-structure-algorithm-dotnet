namespace Tree
{
    public abstract class TreeNodeBase<T> : ITreeNode<TreeNodeBase<T>> where T : class
    {
        protected TreeNodeBase<T> _parent;

        public virtual TreeNodeBase<T> Parent
        {
            get => _parent;
            set => _parent = value;
        }

        protected IList<TreeNodeBase<T>> _children;

        public virtual IList<TreeNodeBase<T>> Children
        {
            get => _children ??= new List<TreeNodeBase<T>>();
            set => _children = value;
        }

        public virtual T? FindNode(string name) => null;

        public virtual void DisplayTree(int depth = 0) { }

        public virtual string ToString(int depth = 0) => string.Empty;

        public virtual TreeNodeBase<T> AddChild(TreeNodeBase<T> child)
        {
            if (child == null)
                throw new ArgumentNullException("failed: argument data is null.");

            this.Children.Add(child);
            child.Parent = this;

            return this;
        }

        public virtual TreeNodeBase<T> RemoveChild(TreeNodeBase<T> child)
        {
            this.Children.Remove(child);
            return this;
        }

        public virtual bool TryRemoveChild(TreeNodeBase<T> child)
            => this.Children.Remove(child);

        public virtual TreeNodeBase<T> ClearChildren()
        {
            this.Children.Clear();
            return this;
        }

        public virtual TreeNodeBase<T> RemoveOwn()
        {
            TreeNodeBase<T> parent = this.Parent;
            parent.RemoveChild(this);
            return parent;
        }

        public virtual bool TryRemoveOwn()
        {
            TreeNodeBase<T> parent = this.Parent;
            return parent.TryRemoveChild(this);
        }
    }
}
