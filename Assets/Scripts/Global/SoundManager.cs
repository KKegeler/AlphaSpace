using UnityEngine;
using System.Collections;

// Verwaltet Musik und Soundeffekte
// 0 - Player Shot, 1 - Enemy 1 Shot, 2 - Enemy Explosion,
// 3 - Impact 1, 4 - Player Explosion, 5 -> PowerUp

public class SoundManager : MonoBehaviour
{
    #region Variablen
    // Awake-Singleton
    public static SoundManager instance = null;

    public AudioSource efxSource;
    public AudioClip[] audioClips;
    public float volume;
    public float faktor = 1f;
    #endregion

    #region Init
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (!efxSource)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        efxSource.volume = volume;
        faktor = 1f;
    }
    #endregion

    #region Sounds
    // Einzelnen Sound abspielen (Clip)
    public void PlayEffect(AudioClip clip, float v = 0.3f)
    {
        efxSource.PlayOneShot(clip, v);
    }

    // Einzelnen Sound abspielen (Index)
    public void PlayEffect(int index, float v = 0.3f)
    {
        if (index < audioClips.Length)
            efxSource.PlayOneShot(audioClips[index], v);
        else
            Debug.LogError("IndexOutOfBounds in " + gameObject.name + "!");
    }

    // Mute
    public void MuteSound(float newFaktor)
    {
        faktor = newFaktor;

        if (faktor == 0)
            efxSource.volume = 0f;
        else
            efxSource.volume = volume * faktor;
    }
    #endregion

    #region Comment
    /* Zufälligen Sound abspielen (Clips)
    public void RandomSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        efxSource.PlayOneShot(clips[randomIndex]);
    }

    // Zufälligen Sound abspielen (Index)
    public void RandomSfx(params int[] index)
    {
        int rIndex = Random.Range(0, index.Length);

        int randomIndex = index[rIndex];

        efxSource.PlayOneShot(audioClips[randomIndex]);
    }*/
    #endregion

}