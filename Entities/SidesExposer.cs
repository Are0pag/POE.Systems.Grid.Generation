using System;

namespace Scripts.Systems.GridGeneration
{
    internal class SidesExposer : IDisposable
    {
        internal void GetUpperAndLowerSides(GenerationInfoCallback genCall, PlaceInfoCallback placeCall) {
            var upperPointOfCurrentPlace = (placeCall.PlaceCenter + genCall.Directions[DirectionsOfGrid.UpRight] * placeCall.Radius).y;
            if (genCall.UpperSideMapY < upperPointOfCurrentPlace)
                genCall.UpperSideMapY = upperPointOfCurrentPlace;
            
            var lowerPointOfCurrentPlace = (placeCall.PlaceCenter + genCall.Directions[DirectionsOfGrid.DownLeft] * placeCall.Radius).y;
            if (genCall.LowerSideMapY > lowerPointOfCurrentPlace)
                genCall.LowerSideMapY = lowerPointOfCurrentPlace;
        }

        public void Dispose() {
            
        }
    }
}