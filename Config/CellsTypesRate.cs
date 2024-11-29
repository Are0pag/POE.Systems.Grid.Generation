using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Scripts.Systems.GridGeneration
{
    [Serializable]
    public class CellsTypesRate
    {
        [SerializeField] private List<TypeRate> _gridTypes = new();
        private Random _random = new();

        /// <summary>
        ///     Returns the cell type based on its frequency parameter (set in the inspector)
        /// </summary>
        /// <returns></returns>
        public IGridCellData GetCellType() {
            foreach (var item in from item in _gridTypes
                     let index = _random.Next(0, TypeRate.MAX_RATE)
                     where index < item.Frequency
                     select item)
                return item.Cell.Value;

            return _gridTypes.First().Cell.Value;
        }
    }
}