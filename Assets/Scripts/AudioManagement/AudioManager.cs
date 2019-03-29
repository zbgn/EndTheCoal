using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioSourceType
{
    Music = 0,
    Sound = 1,
    UI = 2,
    Voice = 3
};

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private float _GeneralVolume;
    [SerializeField]
    private float _MusicVolume;
    [SerializeField]
    private float _SoundVolume;
    [SerializeField]
    private float _UIVolume;
    [SerializeField]
    private float _VoiceVolume;


    void Awake()
    {
        Init();
    }

    private void ReadPrefs()
    {
        _GeneralVolume = Preferences.ReadGeneralAudioPrefs();
        _MusicVolume = Preferences.ReadMusicAudioPrefs();
        _SoundVolume = Preferences.ReadSoundAudioPrefs();
        _UIVolume = Preferences.ReadUIAudioPrefs();
        _VoiceVolume = Preferences.ReadVoiceAudioPrefs();
    }

    public static void WritePrefs()
    {
        CheckOrCreateManager().WritePrefsFrk();
    }


    // INTERNAL
    public void WritePrefsFrk()
    {
        Preferences.WriteGeneralAudioPrefs(_GeneralVolume);
        Preferences.WriteMusicAudioPrefs(_MusicVolume);
        Preferences.WriteSoundAudioPrefs(_SoundVolume);
        Preferences.WriteUIAudioPrefs(_UIVolume);
        Preferences.WriteVoiceAudioPrefs(_VoiceVolume);
    }

    void Start()
    {
        
    }

    public void Init()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
        ReadPrefs();
    }

    // CALL THINS FUNC TO GET GENERAL VOLUME
    public static float GetGeneralVolume()
    {
        return CheckOrCreateManager().GetGeneralVolumeFrk();
    }

    // INTERNAL ADD AUDIO CALLED BY STATIC FUNC
    public float GetGeneralVolumeFrk()
    {
        return _GeneralVolume;
    }

    // CALL THINS FUNC TO GET MUSIC VOLUME
    public static float GetMusicVolume()
    {
        return CheckOrCreateManager().GetMusicVolumeFrk();
    }

    // INTERNAL ADD AUDIO CALLED BY STATIC FUNC
    public float GetMusicVolumeFrk()
    {
        return _MusicVolume;
    }

    // CALL THINS FUNC TO GET SOUND VOLUME
    public static float GetSoundVolume()
    {
        return CheckOrCreateManager().GetSoundVolumeFrk();
    }

    // INTERNAL ADD AUDIO CALLED BY STATIC FUNC
    public float GetSoundVolumeFrk()
    {
        return _SoundVolume;
    }

    // CALL THINS FUNC TO GET UI VOLUME
    public static float GetUIVolume()
    {
        return CheckOrCreateManager().GetUIVolumeFrk();
    }

    // INTERNAL ADD AUDIO CALLED BY STATIC FUNC
    public float GetUIVolumeFrk()
    {
        return _UIVolume;
    }

    // CALL THINS FUNC TO GET VOICE VOLUME
    public static float GetVoiceVolume()
    {
        return CheckOrCreateManager().GetVoiceVolumeFrk();
    }

    // INTERNAL ADD AUDIO CALLED BY STATIC FUNC
    public float GetVoiceVolumeFrk()
    {
        return _VoiceVolume;
    }

    // CALL THIS TO CHANGE VOLUME
    public static void SetGeneralVolume(float NewValue)
    {
        CheckOrCreateManager().SetGeneralVolumeFrk(NewValue);
    }
    // INTERNAL CALLED BY  STATIC
    public void SetGeneralVolumeFrk(float NewValue)
    {
        _GeneralVolume = NewValue;
        for (int i = 0;i < GetAudioCount(); i++)
        {
            AudioInstance Inst = GetAudio(i);
            Inst.CalculateVolume();
        }
    }

    // CALL THIS TO CHANGE VOLUME
    public static void SetMusicVolume(float NewValue)
    {
        CheckOrCreateManager().SetMusicVolumeFrk(NewValue);
    }
    // INTERNAL CALLED BY  STATIC
    public void SetMusicVolumeFrk(float NewValue)
    {
        _MusicVolume = NewValue;
        for (int i = 0; i < GetAudioCount(); i++)
        {
            AudioInstance Inst = GetAudio(i);
            if (Inst._Type == AudioSourceType.Music)
                Inst.CalculateVolume();
        }
    }

    public static void SetSoundVolume(float NewValue)
    {
        CheckOrCreateManager().SetSoundVolumeFrk(NewValue);
    }
    // INTERNAL CALLED BY  STATIC
    public void SetSoundVolumeFrk(float NewValue)
    {
        _SoundVolume = NewValue;
        for (int i = 0; i < GetAudioCount(); i++)
        {
            AudioInstance Inst = GetAudio(i);
            if (Inst._Type == AudioSourceType.Sound)
                Inst.CalculateVolume();
        }
    }

    
    public static void SetUIVolume(float NewValue)
    {
        CheckOrCreateManager().SetUIVolumeFrk(NewValue);
    }
    // INTERNAL CALLED BY  STATIC
    public void SetUIVolumeFrk(float NewValue)
    {
        _UIVolume = NewValue;
        for (int i = 0; i < GetAudioCount(); i++)
        {
            AudioInstance Inst = GetAudio(i);
            if (Inst._Type == AudioSourceType.UI)
                Inst.CalculateVolume();
        }
    }


    public static void SetVoiceVolume(float NewValue)
    {
        CheckOrCreateManager().SetVoiceVolumeFrk(NewValue);
    }
    // INTERNAL CALLED BY  STATIC
    public void SetVoiceVolumeFrk(float NewValue)
    {
        _VoiceVolume = NewValue;
        for (int i = 0; i < GetAudioCount(); i++)
        {
            AudioInstance Inst = GetAudio(i);
            if (Inst._Type == AudioSourceType.Voice)
                Inst.CalculateVolume();
        }
    }


    // ADD AUDIO MANAGER AUTOMATICALLY IF NEEDED
    public static AudioManager CheckOrCreateManager()
    {
        if (Instance == null)
        {
            GameObject Prefab = (GameObject)Resources.Load("Audio/_AudioManager", typeof(GameObject)) as GameObject;
            if (Prefab == null)
                Debug.LogError("Audio Manager Prefab not Found !");
            GameObject Instance = Instantiate(
                Prefab,
                new Vector3(0, 0, 0),
                Quaternion.identity) as GameObject;
            Instance.transform.name = "AudioManager";
            Instance.GetComponent<AudioManager>().Init();
            return Instance.GetComponent<AudioManager>();
        }
        return Instance;
    }

    // CALL THIS FUNC TO PLAY A ADUIO FILE / REPLACE EXISTING AUDIO INSTANCE
    // AudioManager.FindOrAddAudio("TEST", "Audio/Music/Confrontation/Confrontation_001", true, 1.0f, AudioSourceType.Music);
    public static void FindOrAddAudio(string AudioId, string AudioPath, bool IsLooping, float Volume, AudioSourceType Type)
    {
        CheckOrCreateManager().FindOrAddAudioFrk(AudioId, AudioPath, IsLooping, Volume, Type);
    }

    // CALL THIS FUNC TO PLAY A NEW UNIQUE ADUIO FILE
    // AudioManager.AddAudio("TEST", "Audio/Music/Confrontation/Confrontation_001", true, 1.0f, AudioSourceType.Music);
    public static void AddAudio(string AudioId, string AudioPath, bool IsLooping, float Volume, AudioSourceType Type)
    {
        CheckOrCreateManager().AddAudioFrk(AudioId, AudioPath, IsLooping, Volume, Type);
    }


    // INTERNAL ADD AUDIO CALLED BY STATIC FUNC
    private void FindOrAddAudioFrk(string AudioId, string AudioPath, bool IsLooping, float Volume, AudioSourceType Type)
    {
       if (CheckAudioExist(AudioId) == false)
        {
            // ADD NEW AUDIO INSTANCE IF == NULL
            AddAudio(AudioId, AudioPath, IsLooping, Volume, Type);
        }
       else
        {
            // UPDATE AUDIO INSTANCE IF != NULL
            FindAudio(AudioId).InitInstance(AudioPath, IsLooping, Volume, Type);
        }
    }

    // INTERNAL ADD AUDIO CALLED BY STATIC FUNC
    private void AddAudioFrk(string AudioId, string AudioPath, bool IsLooping, float Volume, AudioSourceType Type)
    {
        string FullPath = "Audio/AudioInstance";
        GameObject Prefab = (GameObject)Resources.Load(FullPath, typeof(GameObject)) as GameObject;
        if (Prefab == null)
            Debug.LogError("Audio Instance Prefab not Found !");
        GameObject Instance = Instantiate(
            Prefab,
            new Vector3(0, 0, 0),
            Quaternion.identity) as GameObject;
        Instance.transform.parent = this.transform;
        Instance.transform.name = AudioId;
        Instance.transform.position = Vector3.zero;
        Instance.GetComponent<AudioInstance>().InitInstance(AudioPath, IsLooping, Volume, Type);
       // return Instance.GetComponent<AudioInstance>();
    }

    // CALCULATE AN INSTANCE VOLUME WITH CURRENT PLAYER SETTINGS
    public float CalculateVolume(float BaseVolume, AudioSourceType Type)
    {
        switch (Type)
        {
            case AudioSourceType.Music:
                return BaseVolume * _GeneralVolume * _MusicVolume;
            case AudioSourceType.Sound:
                return BaseVolume * _GeneralVolume * _SoundVolume;
            case AudioSourceType.UI:
                return BaseVolume * _GeneralVolume * _UIVolume;
            case AudioSourceType.Voice:
                return BaseVolume * _GeneralVolume * _VoiceVolume; ;
            default:
                return BaseVolume * _GeneralVolume;
        }
    }


    // INSTANCE HANDLERS
    public void RemoveAudio(string AudioId)
    {
        Destroy(this.transform.Find(AudioId).gameObject);
    }

    public AudioInstance FindAudio(string AudioId)
    {
        return this.transform.Find(AudioId).gameObject.GetComponent<AudioInstance>();
    }


    public AudioInstance GetAudio(int Idx)
    {
        return this.transform.GetChild(Idx).gameObject.GetComponent<AudioInstance>();
    }

    public int GetAudioCount()
    {
        return this.transform.childCount;
    }

    public bool CheckAudioExist(string AudioId)
    {
        if (this.transform.Find(AudioId) != null)
            return true;
        return false;
    }

}
