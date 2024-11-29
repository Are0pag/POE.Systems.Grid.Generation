using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Systems.GridGeneration
{
    public sealed class GridBuilder : MonoBehaviour
    {
        private GenerationBehaviour _generationBehaviour;
        private Transform _goParent;

        [Inject]
        internal void Construct(GenerationBehaviour generationBehaviour, SceneSettings sceneSettings) {
            _generationBehaviour = generationBehaviour;
            _goParent = sceneSettings.Parent;
        }

        public GenerationInfoCallback SetMapInfo() {
            return _generationBehaviour.SetLocationRecursive();
        }

        public void InstantiateMap(Dictionary<Vector3, IGridCellData> positionsOfCells) {
            foreach (var cell in positionsOfCells) {
                var newCell = Instantiate(cell.Value.Prefab, cell.Key, Quaternion.identity, _goParent);
#if UNITY_EDITOR
                SetCleanName(cell, newCell);
#endif
            }
        }

#if UNITY_EDITOR
        private void SetCleanName(KeyValuePair<Vector3, IGridCellData> cell, GameObject newCell) {
            var nameOfCell = cell.Value.Prefab.name;
            string[] names = { "Original", "Forest", "Grass", "Rock" };
            foreach (var name in names)
                if (nameOfCell.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                    newCell.name = name;
        }

        [ContextMenu(nameof(CreateMapInEdit))]
        public void CreateMapInEdit() {
            InstantiateMap(SetMapInfo().MapInfo);
        }
#endif
    }
}