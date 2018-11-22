using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterCreationManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameStateManager gameStateManager;
    public SubScene nextSubScene;

    Canvas canvas;
    public Text constitutionText;
    public Text perceptionText;
    public Text meleeText;
    public Text tirText;
    public Text pointsText;
    private float pointsRestants = 15f;

    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Start()
    {
        canvas = GetComponent<Canvas>();
        constitutionText.text = playerStats.GetConstitution().ToString("F1");
        perceptionText.text = playerStats.GetPerception().ToString("F1");
        meleeText.text = playerStats.GetMelee().ToString("F1");
        tirText.text = playerStats.GetTir().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void Validate()
    {
        gameStateManager.ChangeState(nextSubScene);
    }

    public void SetConstitution(float number)
    {
        float diff = number - playerStats.GetConstitution();
        pointsRestants -= diff;
        playerStats.SetConstitution(number);
        constitutionText.text = playerStats.GetConstitution().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetPerception(float number)
    {
        float diff = number - playerStats.GetPerception();
        pointsRestants -= diff;
        playerStats.SetPerception(number);
        perceptionText.text = playerStats.GetPerception().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetMelee(float number)
    {
        float diff = number - playerStats.GetMelee();
        pointsRestants -= diff;
        playerStats.SetMelee(number);
        meleeText.text = playerStats.GetMelee().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetTir(float number)
    {
        float diff = number - playerStats.GetTir();
        pointsRestants -= diff;
        playerStats.SetTir(number);
        tirText.text = playerStats.GetTir().ToString("F1");
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
