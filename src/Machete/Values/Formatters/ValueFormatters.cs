﻿namespace Machete.Values.Formatters
{
    using System;


    public static class ValueFormatters
    {
        public static readonly IValueFormatter<string> String = new StringValueFormatter();
        public static readonly IValueFormatter<byte> Byte = new ValueTypeValueFormatter<byte>("D");
        public static readonly IValueFormatter<short> Short = new ValueTypeValueFormatter<short>("D");
        public static readonly IValueFormatter<int> Int = new ValueTypeValueFormatter<int>("D");
        public static readonly IValueFormatter<long> Long = new ValueTypeValueFormatter<long>("D");
        public static readonly IValueFormatter<decimal> Decimal = new ValueTypeValueFormatter<decimal>("F2");
        public static readonly IValueFormatter<Guid> Guid = new ValueTypeValueFormatter<Guid>("N");
        public static readonly IValueFormatter<DateTime> DateTime = new ValueTypeValueFormatter<DateTime>("O");
        public static readonly IValueFormatter<DateTimeOffset> DateTimeOffset = new ValueTypeValueFormatter<DateTimeOffset>("O");
    }
}