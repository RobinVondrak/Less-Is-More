using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform player;
    public Transform resetPos;
    public Transform minX, maxX, minY, maxY;

    private void Update()
    {
        if (player.position.x < minX.position.x ||
            player.position.x > maxX.position.x ||
            player.position.y < minY.position.y ||
            player.position.y > maxY.position.y)
        {
            player.position = resetPos.position;
            Debug.Log("Out of bounds");
        }
    }
}
