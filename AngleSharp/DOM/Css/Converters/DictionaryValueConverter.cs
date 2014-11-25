﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    sealed class DictionaryValueConverter<T> : IValueConverter<T>
    {
        readonly Dictionary<String, T> _values;

        public DictionaryValueConverter(Dictionary<String, T> values)
        {
            _values = values;
        }

        public Boolean TryConvert(CSSValue value, Action<T> setResult)
        {
            var temp = default(T);

            if (!_values.TryGetValue(value, out temp))
                return false;

            setResult(temp);
            return true;
        }

        public Boolean Validate(CSSValue value)
        {
            var mode = default(T);
            return _values.TryGetValue(value, out mode);
        }
    }
}
