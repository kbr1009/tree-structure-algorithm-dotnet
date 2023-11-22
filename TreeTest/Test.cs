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
            var cb1 = new TestData("A-2-1");

            root
                .AddChild(ca1)
                .AddChild(ca2);
            ca2.AddChild(cb1);

            var searchResult = root.FindNode("A-2-1");
            if (searchResult != null)
            {
                _output.WriteLine("Found: " + searchResult.Name);
            }
            else
            {
                _output.WriteLine("Not Found");
            }

            root.DisplayTree();

            _output.WriteLine(root.ToString());

            Assert.True(searchResult != null);
            Assert.Equal(cb1.Name, searchResult.Name);
        }
    }
}