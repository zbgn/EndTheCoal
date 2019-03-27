using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{

    /* ---------------- */
    // WRITING AUDIO PREFS
    /* ---------------- */

    public static void WriteGeneralAudioPrefs(float MasterVolume)
    {
        PlayerPrefs.SetFloat("GeneralVolume", MasterVolume);
    }

    public static void WriteMusicAudioPrefs(float MusicVolume)
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
    }

    public static void WriteSoundAudioPrefs(float SoundVolume)
    {
        PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
    }

    public static void WriteUIAudioPrefs(float UIVolume)
    {
        PlayerPrefs.SetFloat("UIVolume", UIVolume);
    }

    public static void WriteVoiceAudioPrefs(float VoiceVolume)
    {
        PlayerPrefs.SetFloat("VoiceVolume", VoiceVolume);
    }

    /* ---------------- */
    // READING AUDIO PREFS
    /* ---------------- */

    public static float ReadGeneralAudioPrefs()
    {
        return PlayerPrefs.GetFloat("GeneralVolume", 1.0f);
    }

    public static float ReadMusicAudioPrefs()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 1.0f);
    }

    public static float ReadSoundAudioPrefs()
    {
        return PlayerPrefs.GetFloat("SoundVolume", 1.0f);
    }

    public static float ReadUIAudioPrefs()
    {
        return PlayerPrefs.GetFloat("UIVolume", 1.0f);
    }

    public static float ReadVoiceAudioPrefs()
    {
        return PlayerPrefs.GetFloat("VoiceVolume", 1.0f);
    }

}
