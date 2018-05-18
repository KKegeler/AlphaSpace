using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Verwaltet die Hintergrundmusik
// 0 -> Title Screen, 1 -> Level 1, 2 -> Level 2, 3 -> Level 3, 4 -> Ending

public class MusicManager : MonoBehaviour
{
    #region Variablen
    // Singleton
    public static MusicManager instance = null;

    public AudioSource musicSource;
    public AudioClip[] audioClips;

    public float volume = 0.008f;
    private const float timeStep = 0.02f;

    public bool isMuted = false;
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
        if (!musicSource || audioClips.Length < 1)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        musicSource.loop = true;
        musicSource.volume = volume;
        faktor = 1f;

#if UNITY_EDITOR
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
            PlayRandomMusic();
#endif
    }
    #endregion

    #region Audio
    // Musik abspielen (Clip)
    public void PlayMusic(AudioClip clip)
    {
        StartCoroutine("FadeIn");
        musicSource.clip = clip;
        musicSource.Play();
    }

    // Musik abspielen (Index)
    public void PlayMusic(int index)
    {
        if (index >= audioClips.Length || index < 0)
        {
            Debug.LogError("Falscher Index in PlayMusic()");
            return;
        }

        if (!isMuted)
        {
            if (musicSource.clip != audioClips[index])
            {
                StartCoroutine("FadeIn");
                musicSource.clip = audioClips[index];
                musicSource.Play();
            }
        }
    }

    // Zufälligen Titel abspielen (Clips)
    public void PlayRandomMusic()
    {
        if (!isMuted)
        {
            StartCoroutine("FadeIn");
            int randomIndex = Random.Range(1, audioClips.Length - 1);

            musicSource.clip = audioClips[randomIndex];
            musicSource.Play();
        }
    }

    // Mute
    public void MuteMusic(float newFaktor)
    {
        faktor = newFaktor;

        if (faktor == 0)
            musicSource.volume = 0f;
        else
            musicSource.volume = volume * faktor;
    }
    #endregion

    #region Coroutine
    // Coroutine
    private IEnumerator FadeIn()
    {
        for (float i = 0f; i <= faktor; i += timeStep)
        {
            musicSource.volume = volume * i;
            yield return null;
        }
    }
    #endregion

}