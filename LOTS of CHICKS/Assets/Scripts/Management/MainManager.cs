using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    [SerializeField] GameObject goSoundManager;
    [SerializeField] GameObject goSceneManager;
    SoundManager s_SoundManager;
    SceneChangeManager s_SceneManager;
    public List<GameObject> uiObjects;
    [SerializeField] List<AudioClip> musicClips;
    [SerializeField] List<AudioClip> soundClips;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Debug.Log("Space bar pressed");
           ChangeSceneTo(1);
           MainManager.Instance.PlayBGM("1");
        }
    }

    void Initialize()
    {
        // set scripts
        s_SoundManager = Instance.GetComponentInChildren<SoundManager>();
        s_SceneManager = Instance.GetComponentInChildren<SceneChangeManager>();
        
        // add sounds
        AddMusicClips();
        AddSFXClips();
        InitializeSoundFunctions();
    }
    // setup functions for main controller
    private void AddMusicClips()
    {
        int i = 0;
        foreach(AudioClip clip in musicClips)
        {
            s_SoundManager.AddSound(i.ToString(), musicClips[i], SoundManager.SoundType.SOUND_MUSIC);
            //Debug.Log("Successfully added sound " + i);
            i++;
        }
    }

    private void AddSFXClips()
    {
        int i = 0;
        foreach(AudioClip clip in soundClips)
        {
            s_SoundManager.AddSound(i.ToString(), soundClips[i], SoundManager.SoundType.SOUND_SFX);
            //Debug.Log("Successfully added sound " + i);
            i++;
        }
    }
    
    // sound manager functions
    public void InitializeSoundFunctions()
    {
        s_SoundManager.Initialize();
    }
    public void PlaySFX(string soundKey)
    {
       s_SoundManager.PlaySound(soundKey);
    }

    public void PlayBGM(string soundKey)
    {
       s_SoundManager.PlayMusic(soundKey);
    }

    public void AdjustBGM(float value)
    {
        s_SoundManager.SetBGMVolume(value);
    }
    public void AdjustSFX(float value)
    {
        s_SoundManager.SetSFXVolume(value);
    }
    public void AdjustMain(float value)
    {
        s_SoundManager.SetMainVolumeScalar(value);
    }
    public void AdjustPan(float value)
    {
        s_SoundManager.SetStereoPan(value);
    }

    // scene manager funcs
    public void ChangeSceneTo(int sceneIndexToLoad)
    {
        // Call the static method from the SceneManagerHelper class
        SceneChangeManager.LoadSceneByIndex(sceneIndexToLoad);
    }
}
