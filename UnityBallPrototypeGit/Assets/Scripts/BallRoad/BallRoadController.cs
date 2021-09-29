namespace BallPrototype.BallRoad
{
    public class BallRoadController
    {
        private readonly BallRoadView _roadView;
        private readonly BallRoadModel _roadModel;
        
        public BallRoadController(BallRoadView roadView, BallRoadModel roadModel)
        { 
            _roadView = roadView; 
            _roadModel = roadModel;
        }
                
        public void ReduceSize()
        {
            _roadView.ReduceSize(_roadModel.SizeChangeSpeed);
        }
    }
}