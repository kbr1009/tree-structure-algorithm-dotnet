using Xunit.Abstractions;

namespace TreeTest
{
    public class Test
    {
        private readonly ITestOutputHelper _output;

        public Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Tree構造から検索をかけ正しくオブジェクトが取得できる()
        {
            var root = new TestData("A");
            var ca1 = new TestData("A-1");
            var ca2 = new TestData("A-2");
            var cb1 = new TestData("A-1-1");
            var cb2 = new TestData("A-2-1");

            root.AddChild(ca1)
                .AddChild(ca2);
            ca1.AddChild(cb1);
            ca2.AddChild(cb2);

            var searchResult = root.FindNode(cb1.Name);
            if (searchResult != null)
            {
                _output.WriteLine("Found: " + searchResult.Name);
            }
            else
            {
                _output.WriteLine("Not Found");
            }
            Assert.True(searchResult != null);
            Assert.Equal(cb1.Name, searchResult.Name);
        }

        [Fact]
        public void 正しいフォーマットでTree構造の文字列が出力される()
        {
            var root = new TestData("A");
            var ca1 = new TestData("A-1");
            var ca2 = new TestData("A-2");
            var cb1 = new TestData("A-1-1");
            var cb2 = new TestData("A-2-1");

            root.AddChild(ca1)
                .AddChild(ca2);
            ca1.AddChild(cb1);
            ca2.AddChild(cb2);

            var output = $"- {root.Name}\r\n  - {ca1.Name}\r\n    - {cb1.Name}\r\n  - {ca2.Name}\r\n    - {cb2.Name}\r\n";
            _output.WriteLine(root.ToString());
            Assert.Equal(root.ToString(), output);
        }

        [Fact]
        public void コンソール上にTree構造を出力することができる()
        {
            var root = new TestData("A");
            var ca1 = new TestData("A-1");
            var ca2 = new TestData("A-2");
            var cb1 = new TestData("A-1-1");
            var cb2 = new TestData("A-2-1");

            root.AddChild(ca1)
                .AddChild(ca2);
            ca1.AddChild(cb1);
            ca2.AddChild(cb2);

            root.DisplayTree();
        }
    }
}