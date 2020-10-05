namespace GreenPandaAssets.Scripts
{
    public class TruckUpgradable : AUpgradable
    {
        public TruckView TruckView;
        public TruckMechanics truckSpeed;

        private void Update()
        {
        
        }
        
        public override void Upgrade()
        {
            base.Upgrade();

            var skinLevel = -1;
            
            if (_level <= 5)
            {
                skinLevel = 1;
            }
            else if (_level <= 10)
            {
                skinLevel = 2;
            }
            else
            {
                skinLevel = 3;
            }
            
            TruckView.SetSkinLevel(skinLevel);
        }
    }
}