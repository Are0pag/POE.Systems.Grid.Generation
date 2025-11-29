using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    internal class MapSpawner
    {
        internal void Spawn(Dictionary<Vector3, IGridCellData> positionsOfCells, Transform parent) {
            foreach (var cell in positionsOfCells) {
                var newCell = GameObject.Instantiate(cell.Value.Prefab, cell.Key, Quaternion.identity, parent);
                
                #if UNITY_EDITOR
                SetCleanName(cell, newCell);
                #endif
            }
        }
        
        internal async UniTask SpawnSmoothlyAsync(Dictionary<Vector3, IGridCellData> positionsOfCells, Transform parent, float secondsDelayBetweenSpawns) {
            foreach (var cell in positionsOfCells) {
                var newCell = GameObject.Instantiate(cell.Value.Prefab, cell.Key, Quaternion.identity, parent);
                await UniTask.Delay(TimeSpan.FromSeconds(secondsDelayBetweenSpawns));
                
                #if UNITY_EDITOR
                SetCleanName(cell, newCell);
                #endif
            }
        }
        
        #if UNITY_EDITOR
        protected void SetCleanName(KeyValuePair<Vector3, IGridCellData> cell, GameObject newCell) {
            var nameOfCell = cell.Value.Prefab.name;
            string[] names = { "Original", "Forest", "Grass", "Rock" };
            foreach (var name in names)
                if (nameOfCell.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                    newCell.name = name;
        }
        #endif
    }
}