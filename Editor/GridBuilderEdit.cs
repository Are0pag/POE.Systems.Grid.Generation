using UnityEditor;
using UnityEngine;

namespace Scripts.Systems.GridGeneration.CustomEdit
{
    [CustomEditor(typeof(GridBuilder))]
    [CanEditMultipleObjects]
    public class GridBuilderEdit : Editor
    {
        private GridBuilder _target;

        public override void OnInspectorGUI() {
            AddButtons();
            base.OnInspectorGUI();
        }

        private void AddButtons() {
            GetTarget();

            if (Application.isPlaying && GUILayout.Button(nameof(_target.CreateMapInEdit))) _target.CreateMapInEdit();
        }

        private void GetTarget() {
            _target = _target ? _target : target as GridBuilder;
        }
    }
}