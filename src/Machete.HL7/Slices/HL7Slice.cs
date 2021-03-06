﻿namespace Machete.HL7.Slices
{
    using Machete.Slices;


    public abstract class HL7Slice<TFragment> :
        TextParserSlice<TFragment>,
        IHL7Slice
        where TFragment : IHL7Slice
    {
        protected HL7Settings Settings { get; }

        protected HL7Slice(HL7Settings settings, ParseText text, TextSpan span, TextParser parser)
            : base(text, span, parser)
        {
            Settings = settings;
        }
    }
}