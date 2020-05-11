using System;
using UnityEngine;

public class PlaceDefender : MonoBehaviour
{
    [SerializeField] GameObject defender;
    private void OnMouseDown()
    {
        CreateDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        worldPos.x = (float) Math.Round(worldPos.x, 0);
        worldPos.y = (float) Math.Round(worldPos.y, 0);
        return worldPos;

    }

    private void CreateDefender(Vector2 position)
    {
        var spwanedDefender = Instantiate(defender, position, Quaternion.identity);
    }
}
