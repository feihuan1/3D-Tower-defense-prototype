using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 1000;
    [SerializeField] int currentBalance;
    [SerializeField] TMP_Text goldText;

    public int CurrentBalance{get {return currentBalance;}}

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        goldText.text = $"Gold: {currentBalance.ToString()}";
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalance < 0)
        {
            // game over
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
