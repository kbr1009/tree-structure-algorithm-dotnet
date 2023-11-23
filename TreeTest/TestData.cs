using System.Text;
using Tree;

namespace TreeTest
{
    public class TestData : TreeNodeBase<TestData>
    {
        private readonly string _name;

        public TestData(string name)
        { 
            _name = name;
        }

        public string Name => _name;

        public override TestData FindNode(string name)
        {
            if (Name == name) return this;

            foreach (var child in Children)
            {
                var found = child.FindNode(name);
                if (found != null) return (TestData)found;
            }
            return null;
        }

        public override string ToString(int depth = 0)
        {
            var sb = new StringBuilder();
            sb.Append(new string(' ', depth * 2))
                .AppendLine($"- {_name}");

            foreach (var child in Children)
            {
                sb.Append(child.ToString(depth + 1));
            }

            return sb.ToString();
        }

        public override void DisplayTree(int depth = 0)
        {
            Console.WriteLine(ToString(depth));
        }
    }
}
