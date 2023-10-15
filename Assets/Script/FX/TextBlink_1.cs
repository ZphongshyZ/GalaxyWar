using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink_1 : PhongMonobehaviour
{
    public TextMeshProUGUI text;
    public Color startColor;
    public Color blinkColor;
    public float blinkInterval = 0.5f;

    private Coroutine blinkCoroutine;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        text = GetComponent<TextMeshProUGUI>();
    }

    protected override void Start()
    {
        base.Start();
        this.startColor = this.text.color;
        this.blinkCoroutine = StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            text.color = blinkColor;
            yield return new WaitForSeconds(blinkInterval);

            text.color = startColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
