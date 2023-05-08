using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientVolumeManager : MonoBehaviour
{
    [Header("Ambient")]
    public EventReference SelectAudio;
    public new FMOD.Studio.EventInstance audio;
    private PARAMETER_ID ambientVolumeParameter;

    [Header("Volume Options")]
    [Range(0f, 1f)]
    public float volumeValue = 1f;

    private Tween ambientVolumeTween;

    private void Start()
    {
        audio = FMODUnity.RuntimeManager.CreateInstance(SelectAudio);

        FMOD.Studio.EventDescription volumeDescription;
        audio.getDescription(out volumeDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION volumeParameterDescription;
        volumeDescription.getParameterDescriptionByName("AmbientVolume", out volumeParameterDescription);
        ambientVolumeParameter = volumeParameterDescription.id;

        FMOD.Studio.PLAYBACK_STATE PbState;
        audio.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            audio.start();
        }

    }
    private void FixedUpdate()
    {
        audio.setParameterByID(ambientVolumeParameter, volumeValue);
    }
    public void SetVolume(float volume)
    {
        volumeValue = volume;
        audio.setParameterByID(ambientVolumeParameter, volumeValue);
    }

    public float GetVolume()
    {
        float volume;
        audio.getParameterByID(ambientVolumeParameter, out volume);
        return volume;
    }

    public void FadeAmbientVolume(float volumeValue, float duration = 5f)
    {
        ambientVolumeTween?.Kill();
        if (duration == 0.0f)
        {
            SetVolume(volumeValue);
        }
        else
        {
            ambientVolumeTween = DOTween
                .To(() => GetVolume(), x => SetVolume(x), volumeValue, 1f)
                .SetEase(Ease.Linear);
        }
    }
}
