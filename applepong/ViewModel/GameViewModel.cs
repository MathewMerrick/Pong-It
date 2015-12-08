using System;
using System.Windows.Threading;
using System.Windows.Input;
using applepong.Model;

namespace applepong.ViewModel {

    class GameViewModel {

        private Ball _ball;
        private Paddle _leftPaddle;
        private Paddle _rightPaddle;
        private Score _score;
        private int _paddleInt = 45;
        private double _ballSpeed = 4.5;
        private int _mode = 0;
       
        private double [] _slope = new double[2]; //0 is x, 1 is y
        private DispatcherTimer timer = new DispatcherTimer();

        //Modes
        // 0 = Local
        // 1 = Client
        // 2 = Server


        public GameViewModel() {
            ball = new Ball {x = 525, y = 225};
                //Left X: 0     Right X: 1050
                //Min Y: 0      Max Y: 650

            leftPaddle = new Paddle {y = 180}; 
                //0 is bottom, 600 is top

            rightPaddle = new Paddle {y = 180}; 
                //0 is bottom, 600 is top

            score = new Score {left = 0, right = 0};
            //Set both scores to zero
  
            timer.Interval = TimeSpan.FromMilliseconds(1);

            slope[0] = -1;
            slope[1] = 1;
        }
        
        public void Start() {
            timer.Start();
            timer.Tick += (MovingBall);
        }
        public void GameReset() {
            Reset();
            score.left = 0;
            score.right = 0;
            timer.Stop();
            

        }


        private void MovingBall(object sender, EventArgs e){

            if (((_ball.x >= 1050) || (_ball.x <= 0))) {
                slope[0] *= -1;
            }

            if (((_ball.y >= 450) || (_ball.y <= 0)) ) {
                slope[1] *= -1;
                //logic for bounce
            }

            //logic for hitpaddles

            _ball.x += (slope[0] * _ballSpeed);
            _ball.y += (slope[1] * _ballSpeed);

            if(_ball.x <= 20){
                if ((ball.y >= _leftPaddle.y-25) && (ball.y <= (_leftPaddle.y + 125))){
                    slope[1]++;
                    slope[0] *= -1;
                }
                else {
                    score.right++;
                    Reset();
                }

            }
            if (_ball.x >= 1040) {
                if ((ball.y >= _rightPaddle.y-25) && (ball.y <= (_rightPaddle.y + 125))) {
                    slope[1]++;
                    slope[0] *= -1;
                }
                else {
                    score.left++;
                    Reset();
                }
            }
        }

        public void Reset(){
            _ball.y = 225;
            _ball.x = 525;
            slope[0] *= -1;
            slope[1] *= -1;
            _leftPaddle.y = 180;
            _rightPaddle.y = 180;
        }

        public int PaddleSpeed {
            get { return _paddleInt; }
            set { _paddleInt = value; }
        }

        public Ball ball {
            get { return _ball; }
            set { _ball = value; }
        }

        public Paddle leftPaddle {
            get { return _leftPaddle; }
            set { _leftPaddle = value; }
        }

        public Paddle rightPaddle {
            get { return _rightPaddle; }
            set { _rightPaddle = value; }
        }

        public Score score {
            get { return _score; }
            set { _score = value; }
        }

        public int mode {
            get { return _mode;}
            set { _mode = value; }
        }

        public double[] slope {
            get { return _slope; }
            set { _slope = value; }
        }


        //Touch Controls
        // 1 = LeftUp
        // 2 = LeftDown
        // 3 = RightUp
        // 4 = RightDown
        public void TouchPaddle(int paddle) {
            switch (paddle) {
                case 1:
                    if (_leftPaddle.y < 360) {
                        leftPaddle.y +=  _paddleInt;
                    }
                    break;
                case 2:
                    if (_leftPaddle.y > 0) {
                        leftPaddle.y -= _paddleInt;
                    }
                    break;
                case 3:
                    if (_rightPaddle.y < 360) {
                        rightPaddle.y += _paddleInt;
                    }
                    break;

                case 4:
                    if (_rightPaddle.y > 0) {
                        _rightPaddle.y -= _paddleInt;
                    }
                    break;
            }
        }

        public void Input(object sender, KeyEventArgs e) {
            if ((mode == 0) || (mode == 2)) {
                switch (e.Key) {
                    case Key.Down:
                        if (_rightPaddle.y > 0) {
                            _rightPaddle.y -= _paddleInt;
                        }
                        break;
                    case Key.Up:
                        if (_rightPaddle.y < 360) {
                            rightPaddle.y += _paddleInt;
                        }
                        break;
                }
            }

            if ((mode == 0) || (mode == 1)) {
                switch (e.Key) {

                    case Key.S:
                        if (_leftPaddle.y > 0) {
                            leftPaddle.y = _leftPaddle.y - _paddleInt;
                        }
                        break;
                    case Key.W:
                        if (_leftPaddle.y < 360) {
                            leftPaddle.y = _leftPaddle.y + _paddleInt;
                        }
                        break;
                }
            }
        }
    }
}
