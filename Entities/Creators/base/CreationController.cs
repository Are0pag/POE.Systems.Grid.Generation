using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    internal abstract class CreationController
    {
        protected readonly PlaceCreator _placeCreator;
        protected readonly Randomizer _rand;
        protected readonly Vector3 _startPosition;
        protected int _radius;
        protected PlaceInfoCallback _resultsOfCreation;

        internal CreationController(PlaceCreator placeCreator, Randomizer rand, Vector3 startPosition) {
            _placeCreator = placeCreator;
            _rand = rand;
            _startPosition = startPosition;
        }

        internal virtual PlaceInfoCallback Generate(in PlaceInfoCallback resultsOfCreation) {
            _resultsOfCreation = resultsOfCreation;
            var placeCenterPosition = GetCenterPositionOfGeneratingPlace();
            return GenerateNewPlace(placeCenterPosition);
        }

        protected virtual Vector3 GetCenterPositionOfGeneratingPlace() {
            // Means that it is firs place generates
            return _resultsOfCreation == null
                ? _startPosition
                : GetCenterPositionOfNextPlace();
        }

        protected abstract Vector3 GetCenterPositionOfNextPlace();
        protected abstract PlaceInfoCallback GenerateNewPlace(Vector3 placeCenterPosition);
    }
}