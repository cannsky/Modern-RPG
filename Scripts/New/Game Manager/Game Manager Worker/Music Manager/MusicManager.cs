using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager
{
    public enum Type { BattleMusic, TravelMusic, VillageMusic, EventMusic }

    [System.Serializable]
    public class MusicManagerState
    {
        public MusicManagerSettings musicManagerSettings;

        public GameManagerWorker gameManagerWorker;

        public AudioSource backgroundMusicAudioSource, environmentAudioSource, spawnerAudioSource;

        public List<AudioClip> battleAudioClips;
        public List<AudioClip> travelAudioClips;
        public List<AudioClip> villageAudioClips;
        public List<AudioClip> eventAudioClips;
        public List<AudioClip> ambianceClips;

        public float backgroundMusicVolume;

        public MusicManagerState(GameManagerWorker gameManagerWorker, MusicManagerSettings musicManagerSettings)
        {
            this.gameManagerWorker = gameManagerWorker;
            this.musicManagerSettings = musicManagerSettings;
            battleAudioClips = musicManagerSettings.battleAudioClips;
            travelAudioClips = musicManagerSettings.travelAudioClips;
            villageAudioClips = musicManagerSettings.villageAudioClips;
            eventAudioClips = musicManagerSettings.eventAudioClips;
            ambianceClips = musicManagerSettings.ambianceClips;
            backgroundMusicAudioSource = musicManagerSettings.backgroundMusicAudioSource;
            backgroundMusicVolume = musicManagerSettings.backgroundMusicVolume;
        }

        public void SetRandomMusic(Type type)
        {
            backgroundMusicAudioSource.clip = this.GetAudioClip(type);
        }

        public bool SetEventMusic(int index)
        {
            if (index >= eventAudioClips.Count) return false;
            backgroundMusicAudioSource.clip = this.eventAudioClips[index];
            return true;
        }

        public AudioClip GetAudioClip(Type type)
        {
            int randomIndex = Random.Range(0, GetListCount(type));
            return type switch
            {
                Type.BattleMusic => battleAudioClips[randomIndex],
                Type.TravelMusic => travelAudioClips[randomIndex],
                Type.VillageMusic => villageAudioClips[randomIndex],
                Type.EventMusic => eventAudioClips[randomIndex]
            };
        }

        public int GetListCount(Type type)
        {
            return type switch
            {
                Type.BattleMusic => battleAudioClips.Count,
                Type.TravelMusic => travelAudioClips.Count,
                Type.VillageMusic => villageAudioClips.Count,
                Type.EventMusic => eventAudioClips.Count
            };
        }
    }

    public MusicManagerState musicManagerState;

    public bool playMusic;
    public bool stopMusic;
    public bool startMusic;

    public Type musicType;

    public MusicManager(GameManagerWorker gameManagerWorker) => musicManagerState = new MusicManagerState(gameManagerWorker, gameManagerWorker.gameManager.gameManagerSettings.musicManagerSettings);

    public void Start()
    {
        PlayMusic(Type.TravelMusic);
    }

    public void Update()
    {
        if (playMusic)
        {
            musicManagerState.backgroundMusicAudioSource.volume += Time.deltaTime * 0.05f;
            if (musicManagerState.backgroundMusicAudioSource.volume >= musicManagerState.backgroundMusicVolume / 100) playMusic = false;
        }
        else if (stopMusic)
        {
            musicManagerState.backgroundMusicAudioSource.volume -= Time.deltaTime * 0.2f;
            if (musicManagerState.backgroundMusicAudioSource.volume <= 0)
                if (startMusic) PlayMusic(musicType);
                else StopMusic();
        }
    }

    public void StartMusic(Type type)
    {
        startMusic = true;
        musicType = type;
        stopMusic = true;
    }

    public void PlayMusic(Type type)
    {
        musicManagerState.SetRandomMusic(type);
        playMusic = true;
        startMusic = false;
        stopMusic = false;
        musicManagerState.backgroundMusicAudioSource.Play();
        musicManagerState.backgroundMusicAudioSource.volume = 0f;
    }

    public void StopMusic()
    {
        stopMusic = true;
        musicManagerState.backgroundMusicAudioSource.Stop();
    }

    public bool PlayEventMusic(int index)
    {
        if (!musicManagerState.SetEventMusic(index)) return false;
        else
        {
            musicManagerState.backgroundMusicAudioSource.Play();
            return true;
        }
    }
}
