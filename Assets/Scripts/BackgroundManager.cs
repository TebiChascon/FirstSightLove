using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Image background;

    [YarnCommand("Set")]
    public void SetBackground(string backgroundName)
    {
        Sprite newBackground = Resources.Load<Sprite>("Backgrounds/" + backgroundName);
        background.sprite = newBackground;
    }
}
