using UnityEngine;

public class CameraMove : MonoBehaviour {
    public GameObject player;

    Vector3 posEnd, posSmoth;

    // Update is called once per frame
    void Update() {
        posEnd = new Vector3(player.transform.position.x + 7f, 0, player.transform.position.z - 10f);

        posSmoth = Vector3.Lerp(transform.position, posEnd, 0.1f);

        transform.position = posSmoth;
    }
}
