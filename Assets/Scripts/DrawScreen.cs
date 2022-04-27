using UnityEngine.SceneManagement;

namespace TicTacToe
{
    public class DrawScreen : Screen
    {
        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}