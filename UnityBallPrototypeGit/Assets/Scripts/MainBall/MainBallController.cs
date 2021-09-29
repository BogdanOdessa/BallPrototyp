namespace BallPrototype
{
    public class MainBallController
    {
        private readonly MainBallView _mainBallView;
        private readonly MainBallModel _mainBallModel;

        public MainBallController(MainBallView mainBallView, MainBallModel mainBallModel)
        {
            _mainBallView = mainBallView;
            _mainBallModel = mainBallModel;
        }
        
        public void ReduceSize()
        {
            _mainBallView.ReduceSize(_mainBallModel.SizeChangeSpeed);
        }

        public void Move()
        {
            _mainBallView.Move(_mainBallModel.Speed);
        }
    }
}