﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.comparison.utilities
{
    /*
     * Helper class containing commonalities for comparison slots.
     */
    internal static class Common
    {
        internal static void Compare(
            ISignaler signaler, 
            Node input, 
            Func<object, object, bool> functor)
        {
            if (input.Children.Count() != 2)
                throw new ApplicationException($"Comparison operation [{input.Name}] requires exactly two operands");

            signaler.Signal("eval", input);

            var lhs = input.Children.First().GetEx<object>();
            var rhs = input.Children.Skip(1).First().GetEx<object>();
            input.Value = functor(lhs, rhs);
        }

        internal async static Task CompareAsync(
            ISignaler signaler, 
            Node input, 
            Func<object, object, bool> functor)
        {
            if (input.Children.Count() != 2)
                throw new ApplicationException($"Comparison operation [{input.Name}] requires exactly two operands");

            await signaler.SignalAsync("eval", input);

            var lhs = input.Children.First().GetEx<object>();
            var rhs = input.Children.Skip(1).First().GetEx<object>();
            input.Value = functor(lhs, rhs);
        }
    }
}