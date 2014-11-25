﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Extensions;
    using System;

    sealed class SubsetValueConverter<T> : IValueConverter<T>
    {
        readonly IValueConverter<T> _converter;
        readonly Int32 _start;
        readonly Int32 _end;

        public SubsetValueConverter(IValueConverter<T> converter, Int32 start = 0, Int32 end = Int32.MaxValue)
        {
            _converter = converter;
            _start = start;
            _end = end;
        }

        public Boolean TryConvert(CSSValue value, Action<T> setResult)
        {
            var items = value as CSSValueList;

            if (items == null || items.Length < _start || items.Length > _end)
                return false;

            return _converter.TryConvert(items.Subset(_start, _end).Reduce(), setResult);
        }

        public Boolean Validate(CSSValue value)
        {
            var items = value as CSSValueList;

            if (items == null || items.Length < _start || items.Length > _end)
                return false;

            return _converter.Validate(items.Subset(_start, _end).Reduce());
        }
    }
}
