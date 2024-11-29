using UnityEngine;
using Zenject;

namespace Scripts.Systems.GridGeneration
{
    public class GridGenerationInstaller : MonoInstaller
    {
        [SerializeField] internal SceneSettings SceneSettings;
        [SerializeField] private Config _config;

        public override void InstallBindings() {
            Container.Bind<DirectionCalculator>().AsSingle().WithArguments(SceneSettings.Grid);
            Container.Bind<Randomizer>().AsSingle().WithArguments(_config.GenerationSettings);

            Container.Bind<PlaceCreator>().To<PlaceCreatorHexagonal>().AsSingle().WithArguments(_config.CellsTypesRate);
            Container.Bind<CreationController>().To<CreationControllerHexagonal>().AsSingle().WithArguments(SceneSettings.StartPosition);
            Container.Bind<GenerationBehaviour>().AsSingle();

            Container.Bind<SceneSettings>().FromInstance(SceneSettings).AsSingle();
            Container.Bind<GridBuilder>().FromInstance(SceneSettings.GridBuilder).AsSingle();
        }

        protected virtual void GetConfig() { }
    }
}