using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BusinessCharacterController : MonoBehaviour
{

    [Header("CharacterController")]
    [SerializeField] private float Speed;
    public float limitX;
    public float xSpeed;
    Rigidbody rb;

    [Header("Animator")]
    Animator anim;

    [Header("Particle Effects")]
    [SerializeField] GameObject WindParticleEffect;

    [Header("Post-Pro")]
    [SerializeField] private Volume volume;
    Vignette Vignette;

    [Header("Energy Controller")]
    public Slider EnergySlider;
    private int Energy;

    [Header("Camera Controller")]
    public Camera FinishCamera;

    [Header("UI PANEL")]
    public GameObject MainPanel;
    public GameObject GameOverPanel;
    public GameObject VictoryPanel;
    public GameObject SuccessPanel;
    public Text SuccessTEXT;
    int Success;

    [Header("Zirilion")]
    public int Zirilion;
    public Text zirilionTEXT;

    [Header("HighScore")]
    public int HighScore;
    private int HighScoreRandom;
    public Text HighScoreText;

    [Header("Time")]
    public float time;

    [Header("AudioSources")]
    public AudioSource aSourceBurn;
    public AudioSource aSourceEnergy;
    public AudioSource aSourceVictory;
    public AudioSource aSourceRuning;
    public AudioSource aSourceIron;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // PARTICLE EFFECT
        WindParticleEffect.SetActive(false);
        // CAMERA
        FinishCamera.enabled = false;

        //UI
        MainPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        SuccessPanel.SetActive(false);

        // Audio Source
        aSourceRuning.Play();

        // SLIDER
        EnergySlider.value = 1;

        // Post-PROC
        volume.profile.TryGet<Vignette>(out Vignette);

       
    }


    void Update()
    {
        time += Time.deltaTime;
        Success = Random.Range(1, 4 + 1);
        HighScoreRandom = Random.Range(60, 89 + 1);

        // Slider Controller
        SliderController();

        // PLAYERPREFS
        Zirilion = PlayerPrefs.GetInt("Zirilion", Zirilion);
        PlayerPrefs.GetInt("HighScore", HighScore);
    }

    void FixedUpdate()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) //e�er touchcount 0 dan fazlaysa telefonda parmakla dokunulmu� ve ekrana dokululan parmak haraket halinde ise
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            //parma��n bilgilerini almak i�in Input.GetTouch(0) �a��r�l�r ve �nceki pozisyonundan �u anki pozistonunua eri�mek i�in .deltaPosition.x kullan�lr ve sa�a sola ne kadar kayd�r�ld��� ��renili
            //iyi bir oraan yapabilmek i�in ekran�n geni�li�ine b�l�n�r
        }
        else if (Input.GetMouseButton(0)) //fareyle oynuyosa
        {
            touchXDelta = Input.GetAxis("Mouse X");//mouse �n x de ne kadar haraket etti�ini touchxdeltaya aktard�k
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z); // karakteri sadece z ekseninde haraket ettirmek i�in
        transform.position = newPosition;

        transform.Translate(0, 0, Speed * Time.deltaTime);
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            Energy++;
            aSourceEnergy.Play();
            EnergySlider.value += 0.20f;
            SuccessPanel.SetActive(true);
            SuccessTEXT.text = "x" + Success.ToString();
            StartCoroutine(SuccesssPanel());
            Destroy(collision.gameObject);
            Zirilion += 10;
            zirilionTEXT.text = "" + Zirilion.ToString();
            PlayerPrefs.SetInt("Zirilion", Zirilion);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Speed = 0f * Time.deltaTime;
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);
            aSourceBurn.Play();
            aSourceRuning.Stop();
        }

        if (collision.gameObject.tag == "Lid")
        {
            Vibrator.Vibrate(2000);
            Speed = 0 * Time.deltaTime;
            anim.SetBool("BeGiddy", true);
            StartCoroutine(LidController());
            aSourceIron.Play();
            aSourceRuning.Stop();
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
        }

        if (collision.gameObject.tag == "Finish")
        {
            aSourceVictory.Play();
            aSourceRuning.Stop();
            aSourceBurn.Stop();
            Speed = 0 * Time.deltaTime;
            MainPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            anim.SetBool("Dance", true);
            FinishCamera.enabled = true;
            StartCoroutine(FinishCameraController());
            EnergySlider.value = 1;
            Vignette.intensity.value = 0f;

            Zirilion += 100;
            zirilionTEXT.text = "" + Zirilion.ToString();
            PlayerPrefs.SetInt("Zirilion", Zirilion);

            HighScore += HighScoreRandom;
            HighScoreText.text = "" + HighScore.ToString();
            PlayerPrefs.SetInt("HighScore", HighScore);

            CloudOnceServices.instance.SubmitScoreLeaderBoard(HighScore);
        }

    }
    void SliderController()  //  Slider Controller
    {
        for (int i = 0; i < time; i++)
        {
            EnergySlider.value -= 0.0025f * Time.deltaTime;
        }

        if (EnergySlider.value > 0.3f)
        {
            Vignette.intensity.value = 0f;
        }

        if (EnergySlider.value <= 0.3f)
        {
            Vignette.intensity.value = 0.6f;
        }

        if (EnergySlider.value == 0)
        {
            Speed = 0f * Time.deltaTime;
            aSourceRuning.Stop();
            GameOverPanel.SetActive(true);
        }

    }

    IEnumerator SuccesssPanel()
    {
        yield return new WaitForSeconds(1);
        SuccessPanel.SetActive(false);
    }
    IEnumerator FinishCameraController()
    {
        yield return new WaitForSeconds(7);
        MainPanel.SetActive(false);
        VictoryPanel.SetActive(true);

    }
    IEnumerator LidController()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("BeGiddy", false);
        Speed = 25;
        aSourceRuning.Play();
    }

}
