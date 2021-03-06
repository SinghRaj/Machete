﻿namespace Machete.HL7
{
    using System;
    using Configuration.SchemaConfiguration;
    using Configuration.SchemaConfiguration.Configurators;
    using Machete;
    using Machete.Configuration;


    public static class HL7SchemaFactoryExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="configure"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="SchemaConfigurationException"></exception>
        public static ISchema<T> CreateHL7<T>(this ISchemaFactorySelector selector, Action<IHL7SchemaConfigurator<T>> configure = null)
            where T : HL7Entity
        {
            var configurator = new HL7SchemaConfigurator<T>();

            configure?.Invoke(configurator);

            configurator.ValidateConfiguration();

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