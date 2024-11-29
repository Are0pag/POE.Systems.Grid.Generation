using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    public interface IGridCellData
    {
        GameObject Prefab { get; }
        bool IsMovable { get; }

        /// <summary>
        ///     A parameter from 0 to 1 that reflects the ability to move for a certain type of cell
        /// </summary>
        float MoveAbility { get; }
    }
}