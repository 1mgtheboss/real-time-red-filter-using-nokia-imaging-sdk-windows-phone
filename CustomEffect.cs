/**
 Note: This is an entry in the Nokia Original Imaging Effect Wiki Challenge 2014Q2. This application demonstrates the implementation of real-time red filter using Nokia Imaging SDK.
 * Developer: Manojit Ghosh
 */


using Nokia.Graphics.Imaging;

namespace RealtimeFilterDemo
{
    public class CustomEffect : CustomEffectBase
    {
        public CustomEffect(IImageProvider source) : base(source)
        {
        }

        protected override void OnProcess(PixelRegion sourcePixelRegion, PixelRegion targetPixelRegion)
        {
            var sourcePixels = sourcePixelRegion.ImagePixels;
            var targetPixels = targetPixelRegion.ImagePixels;

            sourcePixelRegion.ForEachRow((index, width, position) =>
            {
                for (int x = 0; x < width; ++x, ++index)
                {
                    // the only supported color format is ColorFormat.Bgra8888

                    uint pixel = sourcePixels[index]&0xffff0000; //Green & Blue components are removed using Bitwise-AND operator
              
                    targetPixels[index] = pixel;
                }
            });
        }
    }
}
