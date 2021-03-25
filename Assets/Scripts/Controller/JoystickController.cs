using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Transform player;
    Vector3 move;
    public float speed;
    public RectTransform pad;
    public RectTransform stick;
    public void OnDrag(PointerEventData eventData)
    {
        stick.position = eventData.position;
        stick.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);

        move = new Vector3(stick.localPosition.x, 0, stick.localPosition.y).normalized;

        if (stick.transform.localPosition.magnitude <= 35)
        {
            player.GetComponent<Animator>().SetFloat("PlayerSpeed", 0.1f);
        }
        else if (stick.transform.localPosition.magnitude >= 35)
        {
            player.GetComponent<Animator>().SetFloat("PlayerSpeed", 0.6f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pad.position = eventData.position;
        pad.gameObject.SetActive(true);
        StartCoroutine("Movement");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.localPosition = Vector2.zero;
        pad.gameObject.SetActive(false);
        StopCoroutine("Movement");
        move = Vector3.zero;
        player.GetComponent<Animator>().SetFloat("PlayerSpeed", 0.0f);

    }

    IEnumerator Movement()
    {
        while (true)
        {
            player.Translate(move * speed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);

            yield return null;
        }
    
    }

}
