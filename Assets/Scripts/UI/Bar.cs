using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {
    public enum FillDirection {
        Right,
        Left,
        Up,
        Down
    }

    [SerializeField]
    FillDirection fillDirection;
    [SerializeField]
    RectTransform fill;
    private Image fillImage;


    void Start() {
        fillImage = fill.GetComponent<Image>();
    }

    public void SetValue(float value) {
        if (fillDirection == FillDirection.Right) {
            fill.anchorMin = new Vector2(0, 0);
            fill.anchorMax = new Vector2(value, 1);
        } else if (fillDirection == FillDirection.Left) {
            fill.anchorMin = new Vector2(0, 0);
            fill.anchorMax = new Vector2(value, 1);
        } else if (fillDirection == FillDirection.Up) {
            fill.anchorMin = new Vector2(0, 0);
            fill.anchorMax = new Vector2(1, value);
        } else if (fillDirection == FillDirection.Down) {
            fill.anchorMin = new Vector2(0, 1 - value);
            fill.anchorMax = new Vector2(1, 1);
        }

        UpdateFill(value);
    }

    void UpdateFill(float value) {
        if (fillImage == null) return;

        if (value > 0.66f) {
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#00FF15", out newColor)) {
                fillImage.color = newColor;
            }
        } else if (value > 0.33f) {
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#FFA800", out newColor)) {
                fillImage.color = newColor;
            }
        } else {
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#FF3100", out newColor)) {
                fillImage.color = newColor;
            }
        }
    }
}
