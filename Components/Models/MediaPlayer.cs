using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MauiApp1.Components.Models
{
    // Класс, представляющий медиаплеер
    public class MediaPlayer
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private List<string> playlist;
        private int currentTrackIndex;

        // Конструктор
        public MediaPlayer()
        {
            playlist = new List<string>();
            currentTrackIndex = -1;
        }

        // Метод для добавления трека в плейлист
        public void AddToPlaylist(string audioFilePath)
        {
            playlist.Add(audioFilePath);
        }

        // Метод для загрузки аудиофайла
        public void Load(string audioFilePath)
        {
            if (waveOutDevice != null)
            {
                Stop(); // Остановка воспроизведения, если уже есть загруженный файл
            }

            audioFileReader = new AudioFileReader(audioFilePath);
            waveOutDevice = new WaveOutEvent();
            waveOutDevice.Init(audioFileReader);
        }

        // Метод для воспроизведения аудио
        public void Play()
        {
            if (waveOutDevice != null && audioFileReader != null)
            {
                waveOutDevice.Play();
            }
        }

        // Метод для остановки воспроизведения
        public void Stop()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }

        // Метод для увеличения громкости
        public void IncreaseVolume(float volumeIncrement)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume += volumeIncrement;
            }
        }

        // Метод для уменьшения громкости
        public void DecreaseVolume(float volumeDecrement)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume -= volumeDecrement;
            }
        }

        // Метод для переключения на следующий трек в плейлисте
        public void NextTrack()
        {
            if (playlist.Any())
            {
                currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
                Load(playlist[currentTrackIndex]);
                Play();
            }
        }

        // Метод для переключения на предыдущий трек в плейлисте
        public void PreviousTrack()
        {
            if (playlist.Any())
            {
                currentTrackIndex = (currentTrackIndex - 1 + playlist.Count) % playlist.Count;
                Load(playlist[currentTrackIndex]);
                Play();
            }
        }
    }
}
