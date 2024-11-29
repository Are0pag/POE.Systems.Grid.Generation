using System.Linq;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    internal class CreationControllerHexagonal : CreationController
    {
        internal CreationControllerHexagonal(PlaceCreator placeCreator, Randomizer rand, Vector3 startPosition)
            : base(placeCreator, rand, startPosition) {
        }

        protected override Vector3 GetCenterPositionOfNextPlace() {
            _radius = _rand.GetRadiusRand();
            var currentDirection = _rand.GetDirectionRand();
            var rightEdge = _resultsOfCreation.Edged.First();
            var placeCenterPosition = rightEdge + currentDirection * (_radius + 1);
            return placeCenterPosition;
        }

        protected override PlaceInfoCallback GenerateNewPlace(Vector3 placeCenterPosition) {
            return _placeCreator.CreatePlace(placeCenterPosition, _radius);
        }
    }
}