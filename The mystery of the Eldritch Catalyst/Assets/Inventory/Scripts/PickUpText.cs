using System.Collections;
using TMPro;
using UnityEngine;

public class PickUpText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _pickUpText;

    [SerializeField]
    private GameObject _pickUpInfo;

    [SerializeField]
    private float _infoDuration = 1.5f;

    private Coroutine _coroutineToStop;

    public void SetText(string text)
    {
        _pickUpText.text = "You picked : " + text;
    }

    public void EnablePickUpInfo()
    {
        _pickUpInfo.SetActive(true);
    }

    public void DisablePickUpInfo()
    {
        _pickUpInfo.SetActive(false);
    }

    public IEnumerator ShowText(string text)
    {
        SetText(text);
        EnablePickUpInfo();
        yield return new WaitForSeconds(_infoDuration);
        print("niketoi");
        DisablePickUpInfo();
    }

    public void StartShowText()
    {
        if(_coroutineToStop != null)
        {
            StopCoroutine(_coroutineToStop);
        }
        _coroutineToStop = StartCoroutine(ShowText(ItemsOnFloor.Instance.ItemsCloseToThePlayer()[0].itemData.GetName()));
    }
}
