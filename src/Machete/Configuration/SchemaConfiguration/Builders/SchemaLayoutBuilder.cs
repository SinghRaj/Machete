﻿namespace Machete.SchemaConfiguration.Builders
{
    using System;
    using Translators;


    public class SchemaLayoutBuilder<TSchema> :
        ISchemaLayoutBuilder<TSchema>
        where TSchema : Entity
    {
        readonly ISchemaLayoutBuilder<TSchema> _schemaBuilder;

        public SchemaLayoutBuilder(ISchemaLayoutBuilder<TSchema> schemaBuilder)
        {
            _schemaBuilder = schemaBuilder;
        }

        Type ISchemaLayoutBuilder<TSchema>.GetImplementationType<T>()
        {
            return _schemaBuilder.GetImplementationType<T>();
        }

        public ILayoutParserFactory<T, TSchema> GetLayout<T>()
            where T : Layout
        {
            return _schemaBuilder.GetLayout<T>();
        }

        public void Add<T>(ILayoutParserFactory<T, TSchema> factory)
            where T : Layout
        {
            _schemaBuilder.Add(factory);
        }

        public void Add<T>(ILayoutFormatter<T> formatter)
            where T : Layout
        {
            _schemaBuilder.Add(formatter);
        }

        public void SetTranslateFactoryProvider(IEntityTranslateFactoryProvider<TSchema> entityTranslateFactoryProvider)
        {
            _schemaBuilder.SetTranslateFactoryProvider(entityTranslateFactoryProvider);
        }
    }
}