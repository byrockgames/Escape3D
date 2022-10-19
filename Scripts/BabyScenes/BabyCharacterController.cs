using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class BabyCharacterController : MonoBehaviour
{
    [Header("CharacterController")]
    public float limitX;
    public float Speed;
    public float xSpeed;
    public float MilkSpeed;
    [Header("Animator")]
    Animator anim;

    [Header("Particle Effects")]
    public GameObject WindParticleEffect;
    public GameObject ExplosionEffect;

   [Header("Energy Controller")]
    public Slider EnergySlider;
    private int Energy;

    [Header("Camera Controller")]
    public Camera SecondCamera;
    public Camera FinishCamera;

    [Header("UI PANEL")]
    public GameObject MainPanel;
    public GameObject GameOverPanel;
    public GameObject VictoryPanel;
    public GameObject SuccessPanel;
    public Text SuccessTEXT;
    int Success;

    [Header("Time")]
    public float time;

    [Header("AudioSources")]
    public AudioSource aSourceBurn;
    public AudioSource aSourceEnergy;
    public AudioSource aSourceVictory;
    public AudioSource aSourceSlippery;
    public AudioSource aSourceFlying;
    public AudioSource aSourceExplosion;
    public AudioSource aSourceStertcher;

    [Header("Volume Post-Proc")]
    public Volume volume;
    Vignette Vignette;

    [Header("Zirilion")]
    public int Zirilion;
    public Text zirilionTEXT;

    [Header("HighScore")]
    public int HighScore;
    private int HighScoreRandom;
    public Text HighScoreText;

    [Header(" AI SCRIPT")]
    AIController AIController;

    [Header("Parachute")]
    [SerializeField] GameObject Parachute;

    void Start()
    {
        anim = GetComponent<Animator>();

        // PARTICLE EFFECT
        WindParticleEffect.SetActive(false);
        ExplosionEffect.SetActive(false);

        //CAMERA
        SecondCamera.enabled = false;
        FinishCamera.enabled = false;

        //UI
        MainPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        SuccessPanel.SetActive(false);
         
         // Post-PROC
        volume.profile.TryGet<Vignette>(out Vignette);
       

        // PARCAHUTE
        Parachute.SetActive(false);
         
         // Audio Source
        aSourceStertcher.Play();
    }


    void Update()
    {

        time += Time.deltaTime;
        Success = Random.Range(1, 4 + 1);
        HighScoreRandom = Random.Range(60, 89 + 1);

        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.DeleteKey("Zirilion");
            PlayerPrefs.DeleteKey("HighScore");
        }
 
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

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + Speed * Time.deltaTime); // karakteri sadece z ekseninde haraket ettirmek i�in
        transform.position = newPosition;

        TimeController();

    }

    void TimeController()
    {

        if ((int)time == 0f)
        {
            anim.SetBool("Start", true);
        }
        if ((int)time == 3)
        {
            Speed += 5f * Time.deltaTime;
        }

        if ((int)time == 10)
        {
            Speed += 5f * Time.deltaTime;
            anim.SetBool("Run", true);

        }

        if ((int)time == 20)
        {
            Speed += 10f * Time.deltaTime;
            anim.SetBool("Run2", true);
            SuccessPanel.SetActive(true);
            SuccessTEXT.text = "x20 BRAVOO!!";
            StartCoroutine(SuccesssPanel());

        }

        if ((int)time == 35)
        {
            Speed += 5f * Time.deltaTime;
            anim.SetBool("Run3", true);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            Energy++;
            aSourceEnergy.Play();
            EnergySlider.value += 0.20f;
            transform.localScale += (Vector3.one * MilkSpeed);
            SuccessPanel.SetActive(true);
            SuccessTEXT.text = "x" + Success.ToString();
            StartCoroutine(SuccesssPanel());
            Destroy(collision.gameObject);
            Zirilion += 10;
            zirilionTEXT.text = "" + Zirilion.ToString();
            PlayerPrefs.SetInt("Zirilion", Zirilion);
        }

        if (collision.gameObject.name == "Sedye")
        {
            SecondCamera.enabled = true;
        }
        else
        {
            StartCoroutine(SecondCameraController());
        }

        if (collision.gameObject.tag == "Explosion")
        {
            aSourceExplosion.Play();
            Speed = 0f * Time.deltaTime;
            time = 0F;
            anim.SetBool("Start", false);
            ExplosionEffect.SetActive(true);
            StartCoroutine(ExplosionParticleStop());
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Speed = 0f * Time.deltaTime;
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);
            aSourceBurn.Play();
            aSourceFlying.Stop();
            aSourceStertcher.Stop();

        }

        if (collision.gameObject.tag == "Medicine")
        {
            transform.localScale += (Vector3.one * 1f);
            StartCoroutine(CharacterMedicine());
            Destroy(collision.gameObject);
            Vignette.intensity.value = 0.5f;
            StartCoroutine(VignetteControl());
         
        }

        if (collision.gameObject.name == "SlipperyGround")
        {
            Speed += 5f * Time.deltaTime;
            aSourceSlippery.Play();
            aSourceStertcher.Stop();
            transform.DOMoveY(40, 0.5f).OnComplete(
            () =>
            {
                aSourceFlying.Play();
                Parachute.SetActive(true);
                transform.DOMoveY(14.21f, 2f);
                StartCoroutine(ParachuteController());
            });

        }

        if (collision.gameObject.tag == "Finish")
        {
            aSourceVictory.Play();
            aSourceStertcher.Stop();
            Speed = 0f * Time.deltaTime;
            anim.SetBool("Dance", true);
            FinishCamera.enabled = true;
            StartCoroutine(FinishCameraController());
            Zirilion += 80;
            zirilionTEXT.text = "" + Zirilion.ToString();
            PlayerPrefs.SetInt("Zirilion", Zirilion);

            HighScore += HighScoreRandom;
            HighScoreText.text = "" + HighScore.ToString();
            PlayerPrefs.SetInt("HighScore", HighScore);

            CloudOnceServices.instance.SubmitScoreLeaderBoard(HighScore);
        }

    }

    IEnumerator ExplosionParticleStop()
    {
        yield return new WaitForSeconds(0.5f);
        ExplosionEffect.SetActive(false);
        Speed = 0f * Time.deltaTime;
        GameOverPanel.SetActive(true);
    }
    IEnumerator SecondCameraController()
    {
        yield return new WaitForSeconds(1.5f);
        SecondCamera.enabled = false;
    }
    IEnumerator FinishCameraController()
    {
        yield return new WaitForSeconds(2);
        MainPanel.SetActive(false);
        VictoryPanel.SetActive(true);

    }
    IEnumerator CharacterMedicine()
    {
        yield return new WaitForSeconds(3);
        transform.localScale -= (Vector3.one * 1f);
    }
    IEnumerator SuccesssPanel()
    {
        yield return new WaitForSeconds(1);
        SuccessPanel.SetActive(false);
    }
    IEnumerator VignetteControl()
    {
        yield return new WaitForSeconds(3);
        Vignette.intensity.value = 0f;
     
    }
    IEnumerator ParachuteController(){

        yield return new WaitForSeconds(2);
        Parachute.SetActive(false);
        aSourceFlying.Stop();
        aSourceStertcher.Play();
    }
}
