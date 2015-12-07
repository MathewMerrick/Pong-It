using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using pongit.Model;

namespace pongit.ViewModel{

    class GameViewModel {

        private Ball _ball;
        private Paddle _leftPaddle;
        private Paddle _rightPaddle;
        private Score _score;
        private int _paddleInt = 45;

        public GameViewModel() {
            _ball = new Ball {x = 525, y = 225};
                //Left X: 0     Right X: 1050
                //Min Y: 0      Max Y: 650

            _leftPaddle = new Paddle {y = 175}; 
                //0 is bottom, 600 is top

            _rightPaddle = new Paddle {y = 175}; 
                //0 is bottom, 600 is top

            _score = new Score {left = 0, right = 0};
                //Set both scores to zero
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

        public void input(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Down:
                    _rightPaddle.y = _rightPaddle.y - _paddleInt;
                    Trace.WriteLine("test");
                    break;
                case Key.Up:
                    rightPaddle.y = rightPaddle.y + _paddleInt;
                    break;
                case Key.S:
                    leftPaddle.y = _leftPaddle.y - _paddleInt;
                    break;
                case Key.W:
                    leftPaddle.y = _leftPaddle.y + _paddleInt;
                    break;
            }
        }

    }
}
