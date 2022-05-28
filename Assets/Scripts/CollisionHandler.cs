using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    GameObject other;
    [SerializeField] float delaySeconds = 1f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;



    AudioSource audioSource;

    bool isTransitioning = false; 
    bool collisionDisabled = false;


     void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        RespondToDebugKeys();   
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collision
        }
    }

    
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisabled){ return;}
            switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("We are at the home base.");
                break;
            case "Finish":
                Debug.Log("Woohoo! We made it to the finish!");
                LandingPadSequence();
                break;
            case "Obstacle":
                Debug.Log("We hit an obstacle.");
                StartCrashSequence();
                break;
            default:
                Debug.Log("Flying...");
                break;
        }
        
    }

    void StartCrashSequence()
    {
            isTransitioning = true;

            Invoke("ReloadLevel",delaySeconds);
    }



    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LandingPadSequence()
    {
            isTransitioning  = true;
            Invoke("LoadNextLevel", delaySeconds);
    }

    void LoadNextLevel()
    {
        Debug.Log("We crossed the finish line, loading next scene.");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }



}
