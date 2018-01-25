using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Input;

namespace SpaceInvaders.ViewModels
{
    public class VMGame: clsVMBase
    {
        public Double _posX { get; set; }
        public int _velocidad { get; set; }
        //private int 


        public VMGame()
        {
            _posX = 300;
            _velocidad = 5000;
            NotifyPropertyChanged("_posX");
        }


        public void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.A)
            {
                _posX = _posX + _velocidad;
                NotifyPropertyChanged("_posX");
              
            }

            if (e.Key == VirtualKey.D)
            {
                _posX = _posX - _velocidad;
                NotifyPropertyChanged("_posX");
            }
            
        }

    }
}
