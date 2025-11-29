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
            Container.Bind<Randomizer>().To<RandomizerContext>().AsSingle().WithArguments(_config.DefaultGenerationSettings);
            Container.Bind<MapSpawner>().AsSingle();

            Container.Bind<PlaceCreator>().To<PlaceCreatorHexagonalViewExpand>().AsSingle().WithArguments(_config.CellsTypesRate);
            Container.Bind<CreationController>().To<CreationControllerHexagonal>().AsSingle().WithArguments(SceneSettings.StartPosition);
            Container.Bind<GenerationBehaviour>().To<GenerationBehaviourViewExpand>().AsSingle();

            Container.Bind<SceneSettings>().FromInstance(SceneSettings).AsSingle();
            Container.Bind<GridBuilder>().FromInstance(SceneSettings.GridBuilder).AsSingle();
            
            Container.Bind<Config>().FromInstance(_config).AsSingle();
        }
    }
}