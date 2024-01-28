using TMPro;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI thankYou;

    private void Awake()
    {
        thankYou.gameObject.SetActive(false);
    }

    [YarnCommand("GameOver")]
    public void GameOver()
    {
        thankYou.gameObject.SetActive(true);
    }
}
