﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Sound;

namespace TGC.Group.Model
{
    public class Reproductor
    {
        private const string levelPrincipal = "Thumper/Mp3/Thumper OST - Pulser.mp3";
        private const string startMenu = "Thumper/Mp3/Thumper OST - Logos.mp3";
        private const string endMenu = "Thumper/Mp3/Thumper OST - Beetle.mp3";

        private const string recolectar = "Thumper/Mp3/laserBeat.wav";
        private const string obstaculoDestruido = "Thumper/Mp3/beat.wav";
        private const string curvaTomada = "Thumper/Mp3/Curva.wav";
        private const string curvaFallida = "Thumper/Mp3/Fail.wav";
        private const string disparar = "Thumper/Mp3/Poder.wav";
		private const string explosion = "Thumper/Mp3/explosion.wav";
		private const string perder = "Thumper/Mp3/loss.wav";
        private const string missReco = "Thumper/Mp3/missReco.wav";
        private const string ganarEscudo = "Thumper/Mp3/winShield.wav";

        private String mediaDir;
        private TgcMp3Player mp3PlayerMusica;
        private TgcStaticSound sound;
        private TgcDirectSound device;

        public Reproductor(String _mediaDir, TgcDirectSound _device)
        {
            mediaDir = _mediaDir;
            mp3PlayerMusica = new TgcMp3Player();
            sound = new TgcStaticSound();
            device = _device;
        }

        public void ReproducirLevelPrincipal()
        {
            mp3PlayerMusica.FileName = mediaDir + levelPrincipal;
            ReproducirMp3();

        }


        public void ReproducirStartMenu()
        {
            mp3PlayerMusica.FileName = mediaDir + startMenu;
            ReproducirMp3();

        }

        public void ReproducirEndMenu()
        {
            mp3PlayerMusica.FileName = mediaDir + endMenu;
            ReproducirMp3();

        }

        private void ReproducirMp3()
        {
            var currentState = mp3PlayerMusica.getStatus();
            if (currentState == TgcMp3Player.States.Open)
            {
                //Reproducir MP3
                mp3PlayerMusica.play(true);
            }
            if (currentState == TgcMp3Player.States.Stopped)
            {
                //Parar y reproducir MP3
                mp3PlayerMusica.closeFile();
                mp3PlayerMusica.play(true);
            }
            if (currentState == TgcMp3Player.States.Playing)
            {
                mp3PlayerMusica.closeFile();
                mp3PlayerMusica.play(true);

            }
        }

        public void Recolectar()
        {
            Reproducir(mediaDir + recolectar);
        }

        public void NoRecolectar()
        {
            Reproducir(mediaDir + missReco);
        }

        public void ObstaculoDestruido()
        {     
            Reproducir(mediaDir + obstaculoDestruido);
        }

        public void CurvaTomada()
        {
            Reproducir(mediaDir + curvaTomada); 
        }

        public void CurvaFallida()
        {
            Reproducir(mediaDir + curvaFallida);

        }

        public void Disparar()
        {
            Reproducir(mediaDir + disparar);
        }
		
		public void Explosion()
        {
            Reproducir(mediaDir + explosion);
        }
		
		
		public void Perder()
        {
            Reproducir(mediaDir + perder);
        }
		
		public void GanarEscudo()
        {
            Reproducir(mediaDir + ganarEscudo);
        }
		
		private void Reproducir(String sonido)
		{
			sound.dispose();
            sound.loadSound(sonido, device.DsDevice);
            sound.play(false);
		}

        public void Dispose()
        {
            mp3PlayerMusica.closeFile();
            sound.dispose();
        }
    }
}
