
using UnityEngine;

public class VFXSOUNDMANAGER : MonoBehaviour
{

    public static VFXSOUNDMANAGER Instance;

    private AudioSource audioSource;

    private AudioClip jumpSource,tileBreakSource,deathSource;

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

        jumpSource =  Resources.Load<AudioClip>("smb_jump-super");
        tileBreakSource =  Resources.Load<AudioClip>("smb_breakblock");
        deathSource = Resources.Load<AudioClip>("smb_mariodie");
       

        
    }

    void Update()
    {
        audioSource.volume = vol;
        audioSource.mute = !isOn;
    }
    public void PlaySound(string name)
    {
        if(name == "jump")
        {
            audioSource.PlayOneShot(jumpSource);
        }
        else if(name == "tileBreak")
        {
            audioSource.PlayOneShot(tileBreakSource);
        }
        else if(name == "death")
        {
            audioSource.PlayOneShot(deathSource);
        }
        
    }

  
}
