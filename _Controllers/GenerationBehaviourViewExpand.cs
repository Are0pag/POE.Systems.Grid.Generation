namespace Scripts.Systems.GridGeneration
{
    internal class GenerationBehaviourViewExpand : GenerationBehaviour
    {
        public GenerationBehaviourViewExpand(CreationController creationController, DirectionCalculator directionCalculator, Randomizer rand) 
            : base(creationController, directionCalculator, rand) {
        }

        protected override void FixateProgress() {
            base.FixateProgress();
            
            _callback.CentersOfSections.Add(_previousResultsOfCreation.PlaceCenter);
        }
    }
}