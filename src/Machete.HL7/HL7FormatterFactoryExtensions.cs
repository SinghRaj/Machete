﻿namespace Machete.HL7
{
    using System;
    using Configuration;
    using FormatterConfiguration;


    public static class HL7FormatterFactoryExtensions
    {
        /// <summary>
        /// Create an HL7 formatter with the specified schema, which can be optionally configured.
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="schema">The schema used for parsing content</param>
        /// <param name="configure">An optional configuration callback</param>
        /// <typeparam name="TSchema">The formatter's schema type</typeparam>
        /// <typeparam name="TLayout"></typeparam>
        /// <returns>An initialized parser, ready to use</returns>
        /// <exception cref="SchemaConfigurationException"></exception>
        public static IFormatter<TSchema> CreateHL7<TSchema>(this IFormatterFactorySelector selector, ISchema<TSchema> schema,
            Action<IHL7FormatterConfigurator<TSchema>> configure = null)
            where TSchema : HL7Entity
        {
            var configurator = new HL7FormatterConfigurator<TSchema>(schema);

            configure?.Invoke(configurator);

            configurator.ValidateSpecification();

            try
            {
                return configurator.Build();
            }
            catch (Exception exception)
            {
                throw new SchemaConfigurationException("The HL7 schema could not be built (see InnerException for details).", exception);
            }
        }
        
        /// <summary>
        /// Create an HL7 formatter with the specified schema, which can be optionally configured.
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="schema">The schema used for parsing content</param>
        /// <param name="configure">An optional configuration callback</param>
        /// <typeparam name="TSchema">The formatter's schema type</typeparam>
        /// <typeparam name="TLayout"></typeparam>
        /// <returns>An initialized parser, ready to use</returns>
        /// <exception cref="SchemaConfigurationException"></exception>
        public static IFormatter<TSchema, TLayout> CreateHL7<TSchema, TLayout>(this IFormatterFactorySelector selector, ISchema<TSchema> schema,
            Action<IHL7FormatterConfigurator<TSchema>> configure = null)
            where TSchema : HL7Entity
            where TLayout : HL7Layout
        {
            var configurator = new HL7LayoutFormatterConfigurator<TSchema, TLayout>(schema);

            configure?.Invoke(configurator);

            configurator.ValidateSpecification();

            try
            {
                return configurator.Build();
            }
            catch (Exception exception)
            {
                throw new SchemaConfigurationException("The HL7 schema could not be built (see InnerException for details).", exception);
            }
        }
    }
}