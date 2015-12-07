using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using pongit.Model;

namespace pongit.ViewModel{

    class GameViewModel {

        private Ball _ball;
        private Paddle _leftPaddle;
        private Paddle _rightPaddle;
        private Score _score;
        private int _paddleInt = 45;
        private double _ballSpeed = 4;
        private int _mode = 0;

        //Modes
        // 0 = Local
        // 1 = Client
        // 2 = Server

        public GameViewModel() {
            _ball = new Ball {x = 525, y = 225};
                //Left X: 0     Right X: 1050
                //Min Y: 0      Max Y: 650

            _leftPaddle = new Paddle {y = 180}; 
                //0 is bottom, 600 is top

            _rightPaddle = new Paddle {y = 180}; 
                //0 is bottom, 600 is top

            _score = new Score {left = 0, right = 0};
                //Set both scores to zero
        }



        public void start() {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Start();

            timer.Tick += (_movingBall);
        }


        private void _movingBall(object sender, EventArgs e){
            if(_ball.y <= 0){
                //logic for bounce
            }

            if(_ball.y >= 475){
               //logic for bounce
            }

            //logic for hitpaddles

            _ball.y += _ballSpeed;
            _ball.x += _ballSpeed;

            if(_ball.x <= 5){
                score.left++;
                reset();
            }
            if(_ball.y >= 1075){
                score.right++;
                reset();
            }

        }

        public void reset(){
            _ball.y = 225;
            ball.x = 525;
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

        //Touch Controls
        // 1 = LeftUp
        // 2 = LeftDown
        // 3 = RightUp
        // 4 = RightDown

        public void TouchPaddle(int paddle) {
            switch (paddle) {
                case 1:
                    if (_leftPaddle.y > 0) {
                        leftPaddle.y = _leftPaddle.y - _paddleInt;
                    }
                    break;
                case 2:
                    if (_leftPaddle.y < 360) {
                        leftPaddle.y = _leftPaddle.y + _paddleInt;
                    }
                    break;

                case 3:
                    if (_rightPaddle.y > 0) {
                        _rightPaddle.y -= _paddleInt;
                    }
                    break;
                case 4:
                    if (_rightPaddle.y < 360) {
                        rightPaddle.y += _paddleInt;
                    }
                    break;
            }
        }

        public void input(object sender, KeyEventArgs e) {
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
