using System;
using Scripts.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Systems.GridGeneration
{
    [Serializable]
    public struct TypeRate
    {
        internal const int MAX_RATE = 20;
        [SerializeField] public InterfaceRef<IGridCellData> Cell;

        /// <summary>
        ///     Frequency of this cell type where MAX_RATE mean 100% and 1 means 100/MAX_RATE%. Sum of all frequencies must be =
        ///     MAX_RATE
        /// </summary>
        [FormerlySerializedAs("Frequency")]
        [Tooltip("Frequency of this cell type where MAX_RATE mean 100% and 1 means 100/MAX_RATE%. \nSum of all frequencies must be = MAX_RATE")]
        [Range(0, MAX_RATE)]
        [SerializeField]
        public int Frequency;
    }
}