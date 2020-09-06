/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System.Linq;
using Xunit;
using magic.node;
using magic.node.extensions;

namespace magic.lambda.tests
{
    public class ReferenceTests
    {
        [Fact]
        public void ReferenceCheck()
        {
            var lambda = Common.Evaluate(@".foo
   bar
reference:x:-");
            Assert.True(lambda.Children.Skip(1).First().Value is Node);
            Assert.Equal(".foo", lambda.Children.Skip(1).First().GetEx<Node>().Name);
            Assert.Equal("bar", lambda.Children.Skip(1).First().GetEx<Node>().Children.First().Name);
        }
    }
}
