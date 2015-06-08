﻿namespace AngleSharp.Dom.Css
{
    using System;
    using AngleSharp.Css;
    using AngleSharp.Extensions;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/unicode-bidi
    /// </summary>
    sealed class CssUnicodeBidiProperty : CssProperty
    {
        #region ctor

        internal CssUnicodeBidiProperty()
            : base(PropertyNames.UnicodeBidi)
        {
        }

        #endregion

        #region Properties

        internal override IValueConverter Converter
        {
            get { return Converters.UnicodeModeConverter; }
        }

        #endregion

        #region Methods

        protected override Object GetDefault(IElement element)
        {
            return UnicodeMode.Normal;
        }

        protected override Object Compute(IElement element)
        {
            return Converters.UnicodeModeConverter.Convert(Value);
        }

        protected override Boolean IsValid(CssValue value)
        {
            return Converters.UnicodeModeConverter.Validate(value);
        }

        #endregion
    }
}
