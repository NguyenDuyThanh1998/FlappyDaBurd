using UnityEngine;

namespace PersonalLibrary.Extensions
{
    public static class ColorExtensions
    {
        #region Tint, Tone, Shade
        // Definition: https://www.beachpainting.com/blog/color-hue-tint-tone-and-shade/

            #region Color
            // Note: Representation of RGBA colors.
            //       Each color component is a floating point value with a range from 0 to 1.

            /// <summary>
            /// A shade is produced by "darkening" a hue or "adding black"
            /// <paramref name="intensity"/>Amount of shade to add.</paramref>
            /// </summary>
            public static Color Shade(this Color color, float intensity )
            {
                
                return color;
            }

            /// <summary>
            /// A tone is produced by "adding pure grey" (pure grey = equal parts white and black)
            /// <paramref name="intensity"/>Amount of tone to add.</paramref>
            /// </summary>
            public static Color Tone(this Color color, float intensity)
            {
                
                return color;
            }

            /// <summary>
            /// A tint is produced by "ligthening" a hue or "adding white".
            /// <paramref name="intensity"/>Amount of tint to add.</paramref>
            /// </summary>
            public static Color Tint(this Color color, float intensity)
            {
                
                return color;
            }
            #endregion

            #region Color32
            // Note: Representation of RGBA colors in 32 bit format.
            //       Each color component is a byte value with a range from 0 to 255.

            /// <summary>
            /// A shade is produced by "darkening" a hue or "adding black"
            /// <paramref name="intensity"/>Amount of shade to add.</paramref>
            /// </summary>
            public static Color32 Shade(this Color32 color, int intensity)
            {
                
                return color;
            }

            /// <summary>
            /// A tone is produced by "adding pure grey" (pure grey = equal parts white and black)
            /// <paramref name="intensity"/>Amount of tone to add.</paramref>
            /// </summary>
            public static Color32 Tone(this Color32 color, int intensity)
            {
                
                return color;
            }

            /// <summary>
            /// A tint is produced by "ligthening" a hue or "adding white".
            /// <paramref name="intensity"/>Amount of tint to add.</paramref>
            /// </summary>
            public static Color32 Tint(this Color32 color, int intensity)
            {
                
                return color;
            }
            #endregion
        #endregion
    }
}
