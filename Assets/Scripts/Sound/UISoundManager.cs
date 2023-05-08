using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    AmbientVolumeManager avm;
    MenuMusicManager mmm;
    private void Start()
    {
        avm = GetComponent<AmbientVolumeManager>();
        mmm = GetComponent<MenuMusicManager>();
    }
    public void PlayButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/ButtonClick");
    }

    public void FadeInSound()
    {
        avm.FadeAmbientVolume(1, 5f);
        mmm.FadeMenuMusicVolume(1, 5f);
    }
    public void FadeOutSound()
    {
        if (avm != null)
            avm.FadeAmbientVolume(0, 3f);

        mmm.FadeMenuMusicVolume(0, 3f);
    }
}
