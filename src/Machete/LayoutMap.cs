﻿namespace Machete
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Configuration;
    using Internals.Extensions;
    using StructureConfiguration;
    using StructureConfiguration.Specifications;


    public abstract class LayoutMap<TLayout, TSchema> :
        ILayoutSpecification<TSchema>
        where TLayout : Layout
        where TSchema : Entity
    {
        protected LayoutSpecification<TLayout, TSchema> Specification { get; }

        protected LayoutMap()
        {
            Specification = new LayoutSpecification<TLayout, TSchema>();
        }

        protected void Entity<T>(Expression<Func<TLayout, Entity<T>>> propertyExpression, int position, Action<IEntityConfigurator<T>> configure = null)
            where T : TSchema
        {
            var propertyInfo = propertyExpression.GetPropertyInfo();

            var specification = new EntityLayoutPropertySpecification<TLayout, TSchema, T, Entity<T>>(propertyInfo, position, x => x);

            configure?.Invoke(specification);

            Specification.Add(propertyInfo.Name, specification);
        }

        protected void Entity<T>(Expression<Func<TLayout, EntityList<T>>> propertyExpression, int position, Action<IEntityConfigurator<T>> configure = null)
            where T : TSchema
        {
            var propertyInfo = propertyExpression.GetPropertyInfo();

            var specification = new EntityListLayoutPropertySpecification<TLayout, TSchema, T, EntityList<T>>(propertyInfo, position, x => x);

            configure?.Invoke(specification);

            Specification.Add(propertyInfo.Name, specification);
        }

        protected void Layout<T>(Expression<Func<TLayout, Layout<T>>> propertyExpression, int position, Action<ILayoutConfigurator<T>> configure = null)
            where T : Layout
        {
            var propertyInfo = propertyExpression.GetPropertyInfo();

            var specification = new LayoutLayoutPropertySpecification<TLayout, TSchema, T>(propertyInfo, position);

            configure?.Invoke(specification);

            Specification.Add(propertyInfo.Name, specification);
        }

        protected void Layout<T>(Expression<Func<TLayout, LayoutList<T>>> propertyExpression, int position, Action<ILayoutConfigurator<T>> configure = null)
            where T : Layout
        {
            var propertyInfo = propertyExpression.GetPropertyInfo();

            var specification = new LayoutListLayoutPropertySpecification<TLayout, TSchema, T>(propertyInfo, position);

            configure?.Invoke(specification);

            Specification.Add(propertyInfo.Name, specification);
        }

        public IEnumerable<ValidateResult> Validate()
        {
            return Specification.Validate();
        }

        public Type TemplateType => Specification.TemplateType;

        public IEnumerable<Type> GetReferencedLayoutTypes()
        {
            return Specification.GetReferencedLayoutTypes();
        }

        public void Apply(IStructureBuilder<TSchema> builder)
        {
            Specification.Apply(builder);
        }
    }
}