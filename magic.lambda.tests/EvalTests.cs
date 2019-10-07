/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace magic.lambda.tests
{
    public class EvalTests
    {
        [Fact]
        public void InvokeCustomSignal()
        {
            var lambda = Common.Evaluate(@"foo");
            Assert.Equal("OK", lambda.Children.First().Value);
        }

        [Fact]
        public void InvokeNonExistingSignal_Throws()
        {
            Assert.Throws<ApplicationException>(() => Common.Evaluate(@"foo_XXX"));
        }

        [Fact]
        public async Task InvokeEvalAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.src
wait.eval
   set-value:x:@.src
      :OK
");
            Assert.Equal("OK", lambda.Children.First().Value);
        }

        [Fact]
        public async Task InvokeEvalAsync_Throws()
        {
            await Assert.ThrowsAsync<ApplicationException>(async () => await Common.EvaluateAsync(@"
.src
eval
   wait.eval
      set-value:x:@.src
         :OK
"));
        }
    }
}
