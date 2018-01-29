using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace SpaceInvaders.ViewModels
{
    public class VMGame: clsVMBase
    {
        public Double _posX { get; set; }
        public int _velocidad { get; set; }
        DispatcherTimer dispatcherTimer { get; set; }
        //private int 


        public VMGame()
        {
            _posX = 300;
            _velocidad = 50;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0,0,0,0,1);
            dispatcherTimer.Tick += timerTick;
            NotifyPropertyChanged("_posX");
            //dispatcherTimer.Start();
        }

        private void timerTick(object sender, object e)
        {
            move();
        }

        public void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.A)
            {
                // _posX = _posX - _velocidad; 
                left();
                dispatcherTimer.Start();             
                //NotifyPropertyChanged("_posX");
            }

            if (e.Key == VirtualKey.D)
            {
                right();
                dispatcherTimer.Start();
                //_posX = _posX + _velocidad;
                //NotifyPropertyChanged("_posX");               
            }
            
        }

        public void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.A || e.Key == VirtualKey.D)
            {
                //_velocidad = 0;
                dispatcherTimer.Stop();
            }
        }


        public void move()
        {
            /*if (_posX>0 && _posX<1288)
            {
                _posX += _velocidad;
                NotifyPropertyChanged("_posX");
            }           
            else
            {
                dispatcherTimer.Stop();
            }*/
            _posX += _velocidad;
            NotifyPropertyChanged("_posX");
        }

        public void right()
        {
            //_velocidad = 10;
             if (_posX <= 1288)
             {
                 _velocidad = 10;
             }
             else
             {
                 _velocidad = 0;
             }
        }
        public void left()
        {
            //_velocidad = -10;
             if (_posX > 0)
             {
                 _velocidad = -10;
             }
             else
             {
                 _velocidad = 0;
             }
        }


    }
}
