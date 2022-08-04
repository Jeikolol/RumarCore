using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RumarApp.Infraestructure
{
    public static class EnumerableExtensions
    {
        public static SelectList ToSelectList<T, TP1, TP2>(
            this IEnumerable<T> list,
            Expression<Func<T, TP1>> valueProperty,
            Expression<Func<T, TP2>> textProperty,
            object selectedValue = null) where T : class
        {
            var valueExpression = (MemberExpression)valueProperty.Body;
            var dataValueField = valueExpression.Member.Name;

            var textExpression = (MemberExpression)textProperty.Body;
            var dataTextField = textExpression.Member.Name;

            return ToSelectList(list, dataValueField, dataTextField, selectedValue);
        }

        public static SelectList ToSelectList<T>(
            this IEnumerable<T> list,
            string valueProperty,
            string textProperty,
            object selectedValue = null) where T : class
        {
            var result = new SelectList(list, valueProperty, textProperty, selectedValue);

            return result;
        }

        public static MultiSelectList ToMultiSelectList<T, TP1, TP2>(
            this IEnumerable<T> list,
            Expression<Func<T, TP1>> valueProperty,
            Expression<Func<T, TP2>> textProperty,
            IEnumerable<TP1> selectedValues = null) where T : class
        {
            var valueExpression = (MemberExpression)valueProperty.Body;
            var dataValueField = valueExpression.Member.Name;

            var textExpression = (MemberExpression)textProperty.Body;
            var dataTextField = textExpression.Member.Name;

            var result = new MultiSelectList(list, dataValueField, dataTextField, selectedValues);

            return result;
        }
    }
}
