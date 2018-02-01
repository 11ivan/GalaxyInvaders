using SpaceInvaders.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using SpaceInvaders.Models;
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;
using Entities;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SpaceInvaders
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        public VMGame vMGame { get; }
        public List<NaveEnemiga> listaEnemigos;

        public Game()
        {
            this.InitializeComponent();
            listaEnemigos = new List<NaveEnemiga>();
            vMGame =(VMGame) this.DataContext;
            cargaNaves();
        }

        //Getter Setter ListaEnemigos

        /// <summary>
        /// Si este evento no hace caso al KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allowfocus_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.Content.KeyDown += this.vMGame.Grid_KeyDown;
            Window.Current.Content.KeyUp += this.vMGame.Grid_KeyUp;
            Window.Current.Content.KeyUp += Disparo_KeyUp;
        }

        private void Disparo_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Space)
            {
                disparar();
            }
        }

        private void Disparo_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Space)
            {
                disparar();
            }
        }
        private async void moveBullet(int velocidad, Image playerBullet)
        {
            while (Canvas.GetTop(playerBullet) > 0)
            {

                Canvas.SetTop(playerBullet, Canvas.GetTop(playerBullet) - velocidad);
                await Task.Delay(50);
            }
            this.canvas.Children.Remove(playerBullet);
        }
        private void disparar()
        {
            Disparo disparo = new Disparo(vMGame.posYMisil, vMGame.player.posicionX, 20, 10, new Uri("ms-appx:///Assets/Images/MisilPro.png"));
            Image playerBullet = new Image();
            playerBullet.Source = new BitmapImage(disparo.imagen);
            playerBullet.Height = 20;
            playerBullet.Width = 10;
            Canvas.SetTop(playerBullet, Canvas.GetTop(this.player));
            Canvas.SetLeft(playerBullet, Canvas.GetLeft(this.player) + 35);
            this.canvas.Children.Add(playerBullet);
            moveBullet(disparo.velocidad, playerBullet);
        }


        private void cargaNaves()
        {
            NaveEnemiga nave = null;
            Image imagenNave=null;
            int posX = 20;
            int posY = 50;
            

            for (int i=0;i<60;i++)
            {
                nave = new NaveEnemiga();
                imagenNave = new Image();
                if (i == 0 || i==12 || i==24 || i==36 || i==48)
                {
                    nave.posX = 20;
                }
                else
                {
                    nave.posX = posX+70;
                }

                //Fila 1
                if (i>=0 && i<=11)
                {
                    nave.posY = posY-30;                    
                    nave.imagen = new Uri("ms-appx:///Assets/Images/Alien1Pro.png");
                }//Fila 2
                else if(i>=12 && i<=23)
                {
                    nave.posY = posY*2+20 - 30;                    
                    nave.imagen = new Uri("ms-appx:///Assets/Images/Alien2Pro.png");
                }//Fila 3
                else if (i >= 24 && i <= 35)
                {
                    nave.posY = posY *3+20 - 30;                   
                    nave.imagen = new Uri("ms-appx:///Assets/Images/Alien2Pro.png");
                }//Fila 4
                else if (i >= 36 && i <= 47)
                {
                    nave.posY = posY *4+40 - 30;
                    nave.imagen = new Uri("ms-appx:///Assets/Images/Alien3Pro.png");
                }
                else //Fila 5
                {
                    nave.posY = posY*5+60 - 30;
                    nave.imagen = new Uri("ms-appx:///Assets/Images/Alien3Pro.png");
                }

                //Actualizamos valor de posX
                posX = nave.posX;

                imagenNave.Source = new BitmapImage(nave.imagen);
                imagenNave.Height = 50;
                imagenNave.Width = 60;
                this.canvas.Children.Add(imagenNave);
                Canvas.SetTop(imagenNave, nave.posY);
                Canvas.SetLeft(imagenNave, nave.posX);

                listaEnemigos.Add(nave);
            }          
        }



    }
}
