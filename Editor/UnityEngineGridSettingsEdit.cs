using UnityEditor;
using UnityEngine;

namespace Scripts.Systems.GridGeneration.CustomEdit
{
    [CustomEditor(typeof(GridBuilder))]
    public class UnityEngineGridSettingsEdit : Editor
    {
        private bool _isSettingsIsCorrect;

        public override void OnInspectorGUI() {
            SetUnityGrid();
        }

        private void SetUnityGrid() {
            var grid = FindFirstObjectByType<Grid>();

            if (_isSettingsIsCorrect)
                return;

            grid.cellSwizzle = GridLayout.CellSwizzle.XYZ;
            grid.cellLayout = GridLayout.CellLayout.Hexagon;

            _isSettingsIsCorrect = true;
        }
    }
}