/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2021, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System.Linq;
using Xunit;
using magic.node.extensions;

namespace magic.lambda.tests
{
    public class ExistsTests
    {
        [Fact]
        public void ExistsTrue()
        {
            var lambda = Common.Evaluate(@".dest
   foo
exists:x:-/*");
            Assert.True(lambda.Children.Skip(1).First().GetEx<bool>());
        }

        [Fact]
        public void ExistsFalse()
        {
            var lambda = Common.Evaluate(@".dest
exists:x:-/*");
            Assert.False(lambda.Children.Skip(1).First().GetEx<bool>());
        }
    }
}
