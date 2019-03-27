using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInstance : MonoBehaviour {

    public float        _Volume;
    public AudioSourceType    _Type;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitInstance(string AudioPath, bool IsLooping, float Volume, AudioSourceType Type)
    {
        this.GetComponent<AudioSource>().clip = GetClip(AudioPath);
        this._Type = Type;
        SetVolume(Volume);
        this.GetComponent<AudioSource>().loop = IsLooping;
        this.GetComponent<AudioSource>().Play();
        if (IsLooping == false)
            StartCoroutine(waitForSound()); //Start Coroutine
    }

    IEnumerator waitForSound()
    {
        //Wait Until Sound has finished playing
        while (this.GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }

    private AudioClip GetClip(string SourcePath)
    {
        AudioClip Asset = Resources.Load(SourcePath) as AudioClip;
        if (Asset == null)
            Debug.LogError("Audio File[" + SourcePath + "] not Found !");
        return Asset;

    }

    public void SetVolume(float NewVolume)
    {
        this._Volume = NewVolume;
        CalculateVolume();
       
    }

    public void CalculateVolume()
    {
        this.GetComponent<AudioSource>().volume = AudioManager.Instance.CalculateVolume(_Volume, _Type);
    }

    public string GetId()
    {
        return this.transform.name;
    }

}
