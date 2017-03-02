using UnityEngine;

public class PlumeBehavior : ItemPickable {
    [SerializeField]
    private float TimeToDestroy;

    private void Start()
    {
        Invoke("DestroyItem", TimeToDestroy);
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}
