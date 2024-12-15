using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    /// <summary>
    ///     Intermediate callcack necessary for the implementation of the internal logic of the module
    /// </summary>
    internal class PlaceInfoCallback
    {
        internal readonly List<Vector3> Edged = new();
        internal readonly Dictionary<Vector3, IGridCellData> PositionsOfCells = new();
        internal Vector3 PlaceCenter;
    }
}