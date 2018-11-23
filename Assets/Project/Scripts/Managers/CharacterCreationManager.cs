using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterCreationManager : MonoBehaviour
{
    public PlayerAttributesManager playerAttr;

    Canvas canvas;
    public Text constitutionText;
    public Text perceptionText;
    public Text meleeText;
    public Text tirText;
    public Text pointsText;
    private float pointsRestants = 15f;

    private void Awake()
    {
        playerAttr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributesManager>();
    }

    void Start()
    {
        canvas = GetComponent<Canvas>();
        constitutionText.text = playerAttr.GetConstitution().ToString("F1");
        perceptionText.text = playerAttr.GetPerception().ToString("F1");
        meleeText.text = playerAttr.GetMelee().ToString("F1");
        tirText.text = playerAttr.GetTir().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void Validate()
    {
        SceneManager.LoadScene(1);
    }

    public void SetConstitution(float number)
    {
        float diff = number - playerAttr.GetConstitution();
        pointsRestants -= diff;
        playerAttr.SetConstitution(number);
        constitutionText.text = playerAttr.GetConstitution().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetPerception(float number)
    {
        float diff = number - playerAttr.GetPerception();
        pointsRestants -= diff;
        playerAttr.SetPerception(number);
        perceptionText.text = playerAttr.GetPerception().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetMelee(float number)
    {
        float diff = number - playerAttr.GetMelee();
        pointsRestants -= diff;
        playerAttr.SetMelee(number);
        meleeText.text = playerAttr.GetMelee().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetTir(float number)
    {
        float diff = number - playerAttr.GetTir();
        pointsRestants -= diff;
        playerAttr.SetTir(number);
        tirText.text = playerAttr.GetTir().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public float GetPointsRestants()
    {
        return pointsRestants;
    }



    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
