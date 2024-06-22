using UnityEngine;

namespace PersonalLibrary.pUnity.pUI
{
    public class HSLColor
    {
        // What is HSL color? => https://en.wikipedia.org/wiki/HSL_and_HSV
        public float hue;        // range: 0 -> 360 degrees => representation: 0 -> 6f. The natural color.
        public float saturation; // range: 0 -> 100%        => representation: 0 -> 1f. Less saturation = moving closer to color grey (tone).
        public float lightness;  // range: 0 -> 100%        => representation: 0 -> 1f. 0.5f = original color; 0 <- = darker (shade); -> 1f = lighter (tint).

        // Constructor.
        public HSLColor(float H, float S, float L)
        {
            hue = H;
            saturation = S;
            lightness = L;
        }

        #region Public Methods
        public Color HSLToRGB(HSLColor hsl)
        {
            // convert hsl to rgb.
            Color rgb = Color.red; //holder.
            return rgb;
        }

        public HSLColor RGBToHSL(Color rgb)
        {
            // Convert rgb to hsl
            HSLColor hsl = new HSLColor(6f, 1, .5f); //holder.
            return hsl;
        }
        #endregion
    }
}
