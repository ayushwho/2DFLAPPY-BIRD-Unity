using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicscript : MonoBehaviour
{
    public int playerscore;
    public Text scoreText;
    public GameObject gameOverScreen;
    [ContextMenu("Increase Score")]

    // Add to score
    public void addscore(int scoreToAdd){
        playerscore = playerscore + scoreToAdd;
        scoreText.text = playerscore.ToString();
    }

    // Restart current game
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Show Game Over screen
    public void gameOver(){
        gameOverScreen.SetActive(true);
    }

    // 👉 Go back to Main Menu (scene index 0)
    public void goToMainMenu(){
        SceneManager.LoadScene(0);
    }
}