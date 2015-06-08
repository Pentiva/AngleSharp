﻿namespace AngleSharp.Dom.Css
{
    using System;
    using AngleSharp.Css;
    using AngleSharp.Css.Values;
    using AngleSharp.Extensions;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/perspective
    /// Gets the distance from the user to the z=0 plane. It is used to
    /// apply a perspective transform to the element and its content. If it
    /// 0 or a negative value, no perspective transform is applied.
    /// </summary>
    sealed class CssPerspectiveProperty : CssProperty
    {
        #region Fields

        static readonly IValueConverter<Length> StyleConverter = 
            Converters.LengthConverter.Or(Keywords.None, Length.Zero);

        #endregion

        #region ctor

        internal CssPerspectiveProperty()
            : base(PropertyNames.Perspective, PropertyFlags.Animatable)
        {
        }

        #endregion

        #region Properties

        internal override IValueConverter Converter
        {
            get { return StyleConverter; }
        }

        #endregion

        #region Methods

        protected override Object GetDefault(IElement element)
        {
            return Length.Zero;
        }

        protected override Object Compute(IElement element)
        {
            return StyleConverter.Convert(Value);
        }

        protected override Boolean IsValid(CssValue value)
        {
            return StyleConverter.Validate(value);
        }

        #endregion
    }
}
