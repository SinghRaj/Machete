﻿namespace Machete
{
    using System;


    public interface QueryParser<TSchema, out T> :
        Parser<TSchema, T>
        where TSchema : Entity
    {
        QueryParser<TSchema, T> Where(Func<T, bool> predicate);

        QueryParser<TSchema, TResult> Select<TResult>(Func<T, TResult> selector);

        QueryParser<TSchema, TResult> SelectMany<TValue, TResult>(Func<T, Parser<TSchema, TValue>> selector, Func<T, TValue, TResult> projector);

        QueryParser<TSchema, TResult> SelectMany<TValue, TResult>(Func<T, Value<TValue>> selector, Func<T, TValue, TResult> projector);
    }
}