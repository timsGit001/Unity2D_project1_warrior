using UnityEngine;
using UnityEngine.Audio;

public class MusicMgr : MonoBehaviour
{
    [Header("音源管理器")]
    public AudioMixer mixer; 

    /// <summary>
    /// 背景音樂 音量
    /// </summary>
    public void VolumeBGM(float value)
    {
        mixer.SetFloat("VolumeBGM", value);
    }

    /// <summary>
    /// 音效 音量
    /// </summary>
    public void VolumeSFX(float value)
    {
        mixer.SetFloat("VolumeSFX", value);
    }
}
