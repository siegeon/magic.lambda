﻿/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.change
{
    /// <summary>
    /// [unwrap] slot allowing you to forward evaluate expressions in your lambda graph object.
    /// </summary>
    [Slot(Name = "unwrap")]
    public class Unwrap : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            foreach (var idx in input.Evaluate())
            {
                if (idx.Value is Expression)
                {
                    var exp = idx.Evaluate();
                    if (exp.Count() > 1)
                        throw new HyperlambdaException("Multiple sources found for [unwrap]");

                    idx.Value = exp.FirstOrDefault()?.Value;
                }
            }
        }
    }
}
