﻿namespace Machete.Values
{
    using System;


    /// <summary>
    /// A missing value array is used when the source fragment is missing.
    /// </summary>
    /// <typeparam name="TValue">The value type</typeparam>
    public class MissingValueArray<TValue> :
        ValueArray<TValue>
    {
        Type IValue.ValueType => typeof(TValue);
        bool IValue.HasValue => false;
        bool IValue.IsPresent => false;
        TextSlice IValue.Slice => Slice.Missing;

        public Value<TValue> this[int index]
        {
            get { throw new ValueMissingException("The value is missing."); }
        }

        bool ValueArray<TValue>.TryGetValue(int index, out Value<TValue> value)
        {
            throw new ValueMissingException("The value is missing.");
        }
    }
}