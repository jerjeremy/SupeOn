using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

// This is a helper class that is not instantiated in the scene
// `static` means that it is globally accessible by the class name
public class SoundManager : MonoBehaviour
{
    [SerializeField] public Slider sfxSlider; // Reference field to slider component
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider mainVolSlider;
    [SerializeField] public float mainVolumeScalar;
    

    // enumerated list of flags for sound types
    public enum SoundType
    {
        SOUND_SFX,
        SOUND_MUSIC
    }
    // Define the reference value property that will grant access to the class.
    // Instance holds the address of the smObj address
    //public static SoundManager Instance { get; private set; } // can public access, but setting is private

    // Create Dictionary for sfx.
    private Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>();
    // Create Dictionary for music.
    private Dictionary<string, AudioClip> musicDictionary = new Dictionary<string, AudioClip>();
    // Create AudioSource for sfx.
    private AudioSource sfxSource;
    // Create AudioSource for music.
    private AudioSource musicSource;

    // not-so-efficient update method
    /* private void Update()
    {
        sfxSource.volume = sfxSlider.value;
    } */

    public void Initialize()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        // add audiosource component to game objects
        musicSource.volume /* = musicSlider.value */ = 0.25f; // align slider with volume value
        musicSource.loop = true;
        sfxSource.volume /* = sfxSlider.value */ = 1.0f; // align slider with volume value

        //mainVolSlider.value = 1.0f;
        MainManager.Instance.PlayBGM("0");
    }

    public void SetSFXVolume(float value) // Value is a dynamic parameter set by the Slider
    {
        sfxSource.volume = value * mainVolumeScalar;
    }

    public void SetBGMVolume(float value)
    {
        musicSource.volume = value * mainVolumeScalar;
    }

    public void SetMainVolumeScalar(float value)
    {
        mainVolumeScalar = value;
        sfxSource.volume = value * sfxSlider.value;
        musicSource.volume = value * musicSlider.value;
    }

    public void SetStereoPan(float value)
    {
        sfxSource.panStereo = value;
        musicSource.panStereo = value;
    }

    // Add a sound to the dictionary.
    public void AddSound(string soundKey, AudioClip audioClip, SoundType soundType)
    {
        // by using a temporary field, reduces duplicate code for sfx and music
        Dictionary<string, AudioClip> targetDictionary = GetDictionaryByType(soundType);
        if (!targetDictionary.ContainsKey(soundKey)) // targetDictionary does `not` contain soundKey
        {
            targetDictionary.Add(soundKey, audioClip);
        }
        else
        {
            Debug.LogWarning("Sound key " + soundKey + " already exists in dictionary.");
        }
    }

    // Play a sound by key interface.
    public void PlaySound(string soundKey)
    {
        Play(soundKey, SoundType.SOUND_SFX);
    }

    // Play music by key interface.
    public void PlayMusic(string soundKey)
    {
        musicSource.Stop();
        Play(soundKey, SoundType.SOUND_MUSIC);
    }

    // Play utility.
    private void Play(string soundKey, SoundType soundType)
    {
        // temporary reference values holding addresses to the appropriate dictionary and source
        Dictionary<string, AudioClip> targetDictionary;
        AudioSource targetSource;
        SetTargetsByType(soundType, out targetDictionary, out targetSource);
        if (targetDictionary.ContainsKey(soundKey))
        {
            targetSource.PlayOneShot(targetDictionary[soundKey]);
        }
        else
        {
            Debug.LogWarning("Sound key " + soundKey + " not found.");
        }
    }

    private void SetTargetsByType(SoundType soundType, out Dictionary<string, AudioClip> targetDictionary, out AudioSource targetSource)
    {
        switch(soundType)
        {
            case SoundType.SOUND_SFX:
                targetDictionary = sfxDictionary; 
                targetSource = sfxSource;
                break;
            case SoundType.SOUND_MUSIC:
                targetDictionary = musicDictionary;
                targetSource = musicSource;
                break;
            default:
                targetDictionary = null;
                targetSource = null;
                Debug.LogError("unknown sound type: "  + soundType);
                break;
        }
    }
    private Dictionary<string, AudioClip> GetDictionaryByType(SoundType soundType)
    {
        switch(soundType)
        {
            case SoundType.SOUND_SFX:
                return sfxDictionary; // returns address of sfxDictionary to temp field

            case SoundType.SOUND_MUSIC:
                return musicDictionary; // returns address of musicDictionary to temp field

            default:
                Debug.LogError("Unknown Sound");
                break;
        }
        return null;
    }
}