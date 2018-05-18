using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : GenericWindow
{
    public Slider soundSlider;
    public Slider musicSlider;

    void Start()
    {
        if (!soundSlider || !musicSlider)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        soundSlider.value = SoundManager.instance.faktor;
        musicSlider.value = MusicManager.instance.faktor;
    }

    public void muteSound()
    {
        SoundManager.instance.MuteSound(soundSlider.value);
    }

    public void muteMusic()
    {
        MusicManager.instance.MuteMusic(musicSlider.value);
    }

    public void Back()
    {
        manager.Open(0);
    }
}
