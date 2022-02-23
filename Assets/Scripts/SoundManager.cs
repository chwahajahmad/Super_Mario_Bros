
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    private AudioSource audioSource;

    private AudioClip backgroundSource;

    public bool isOn;
    public float vol;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            isOn = true;
            vol = 1;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  

        backgroundSource = Resources.Load<AudioClip>("theme");
       

        audioSource.PlayOneShot(backgroundSource,0.7f);
    }

   
    void Update()
    {
        audioSource.volume = vol;
        audioSource.mute = !isOn;
    }

  
}
