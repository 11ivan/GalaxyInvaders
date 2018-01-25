using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SpaceInvaders.ViewModels
{
   public class MainPageGameVM : clsVMBase
    {

        #region Atributos
        private ObservableCollection<String> _mDificultades;
        private DelegateCommand _cerrarAbrirSplit;
        private int _mIndexDificultadSeleccionada;
        private int _mVolume;
        private bool _splitAbierto;

        #endregion
        #region contructor
        public MainPageGameVM()
        {
            getLevels();
            _splitAbierto = false;
        }


        #endregion

        #region Propiedades Publicas
        public bool splitAbierto
        {
            set
            {
                _splitAbierto = value;
                NotifyPropertyChanged("splitAbierto");
            }
            get
            {
                return _splitAbierto;
            }
        }
        public DelegateCommand cerrarAbrirSplit
        {
            set
            {
                _cerrarAbrirSplit = value;
            }
            get
            {
                _cerrarAbrirSplit = new DelegateCommand(ExecuteSplit);
                return _cerrarAbrirSplit;
            }
        }
        public ObservableCollection<String> mDificultades
        {
            get { return this._mDificultades; }
            set
            {
                this._mDificultades = value;
                NotifyPropertyChanged("mDificultades");
            }
        }
        public void ExecuteSplit()
        {
            _splitAbierto = !_splitAbierto;
            NotifyPropertyChanged("splitAbierto");
        }
        public int mIndexDificultadSeleccionada
        {
            get { return this._mIndexDificultadSeleccionada; }
            set
            {
                this._mIndexDificultadSeleccionada = value;
                NotifyPropertyChanged("mIndexDificultadSeleccionada");
            }
        }

        public int mVolume
        {
            get { return this._mVolume; }
            set
            {
                this._mVolume = value;
                NotifyPropertyChanged("mVolume");
            }
        }


        #endregion

        public void getLevels()
        {
            _mDificultades = new ObservableCollection<String>();
            _mDificultades.Add("Fácil");
            _mDificultades.Add("Normal");
            _mDificultades.Add("Dificil");
            _mIndexDificultadSeleccionada = 1;

            NotifyPropertyChanged("mIndexDificultadSeleccionada");
            NotifyPropertyChanged("mDificultades");
        }

        public void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            var rootFrame = new Frame();
            rootFrame.Navigate(typeof(Game));

            // Place the frame in the current Window and ensure that it is active
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

    }
}

