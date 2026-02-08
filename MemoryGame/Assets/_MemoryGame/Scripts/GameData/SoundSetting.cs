using UnityEngine;

namespace MG
{
    [CreateAssetMenu(fileName = "SoundSettings", menuName = "MG/Sound Settings")]
    public class SoundSetting : ScriptableObject
    {
        [SerializeField] private AudioClip winClip;
        [SerializeField] private AudioClip loseClip;
        [SerializeField] private AudioClip flipClip;

        public AudioClip WinClip { get => winClip; private set => winClip = value; }
        public AudioClip LoseClip { get => loseClip; private set => loseClip = value; }
        public AudioClip FlipClip { get => flipClip; private set => flipClip = value; }
    }
}