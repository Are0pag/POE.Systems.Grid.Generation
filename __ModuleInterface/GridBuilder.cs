using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Systems.GridGeneration
{
    public sealed class GridBuilder : MonoBehaviour
    {
        private GenerationBehaviour _generationBehaviour;
        private Transform _goParent;
        private MapSpawner _mapSpawner;

        [Inject]
        internal void Construct(GenerationBehaviour generationBehaviour, SceneSettings sceneSettings, MapSpawner mapSpawner) {
            _generationBehaviour = generationBehaviour;
            _goParent = sceneSettings.Parent;
            _mapSpawner = mapSpawner;
        }

        public GenerationInfoCallback SetMapInfo() 
            => _generationBehaviour.SetLocationRecursive();

        public void InstantiateMap(Dictionary<Vector3, IGridCellData> positionsOfCells) 
            => _mapSpawner.Spawn(positionsOfCells, _goParent);

        public async UniTask InstantiateMapSmoothlyAsync(Dictionary<Vector3, IGridCellData> positionsOfCells, float secondsDelayBetweenSpawns) 
            => await _mapSpawner.SpawnSmoothlyAsync(positionsOfCells, _goParent, secondsDelayBetweenSpawns);
    }
}