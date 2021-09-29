namespace BallPrototype
{
    public class ShootingBallController
    {
        private readonly ShootingBallView _shootingBallView;
        private readonly ShootingBallModel _shootingBallModel;

        public ShootingBallController(ShootingBallView shootingBallView, ShootingBallModel shootingBallModel)
        {
            _shootingBallView = shootingBallView;
            _shootingBallModel = shootingBallModel;
        }
        
        public void IncreaseSize()
        {
           _shootingBallView.IncreaseSize(_shootingBallModel.SizeChangeSpeed);
        }

        public void IncreaseColliderRadiusSize()
        {
            _shootingBallView.IncreaseColliderRadiusSize(_shootingBallModel.RadiusChangeSpeed);
        }

        public void Move()
        {
          _shootingBallView.Move(_shootingBallModel.Speed);
        }
    }
}