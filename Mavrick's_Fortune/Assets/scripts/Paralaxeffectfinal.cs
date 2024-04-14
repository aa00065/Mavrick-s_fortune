using UnityEngine;

public class Parallax : MonoBehaviour
{
    public enum ScrollDirection { LeftToRight, RightToLeft, DownToUp, UpToDown };

    public ScrollDirection direction;
    public float minSpeed = 0.2f;
    public float maxSpeed = 0.6f;
    public float limitOffScreen = 1f;
    public BehaviourOnExit behaviourOnExit = BehaviourOnExit.Regenerate;

    private Transform cameraTransform;
    private float lastScrollValue;
    private Vector3 speed;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastScrollValue = GetInitialScrollValue();
        SetSpeed();
    }

    private void SetSpeed()
    {
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                speed = new Vector3(Random.Range(minSpeed, maxSpeed), 0f, 0f);
                break;
            case ScrollDirection.RightToLeft:
                speed = new Vector3(-Random.Range(minSpeed, maxSpeed), 0f, 0f);
                break;
            case ScrollDirection.DownToUp:
                speed = new Vector3(0f, -Random.Range(minSpeed, maxSpeed), 0f);
                break;
            case ScrollDirection.UpToDown:
                speed = new Vector3(0f, Random.Range(minSpeed, maxSpeed), 0f);
                break;
        }
    }

    private float GetInitialScrollValue()
    {
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
            case ScrollDirection.RightToLeft:
                return cameraTransform.position.x;
            case ScrollDirection.DownToUp:
            case ScrollDirection.UpToDown:
                return cameraTransform.position.y;
            default:
                return 0f;
        }
    }

    private void Regenerate()
    {
        float x = 0f, y = 0f;
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                x = 1f + limitOffScreen;
                y = Random.value;
                break;
            case ScrollDirection.RightToLeft:
                x = -limitOffScreen;
                y = Random.value;
                break;
            case ScrollDirection.DownToUp:
                x = Random.value;
                y = 1f + limitOffScreen;
                break;
            case ScrollDirection.UpToDown:
                x = Random.value;
                y = -limitOffScreen;
                break;
        }
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10f));
    }

    private void Update()
    {
        float scrollValue = GetScrollValue();
        transform.position += speed * scrollValue;
        if (IsOutOfBounds())
        {
            switch (behaviourOnExit)
            {
                case BehaviourOnExit.Destroy:
                    Destroy(gameObject);
                    break;
                case BehaviourOnExit.Regenerate:
                    Regenerate();
                    break;
            }
        }
    }

    private float GetScrollValue()
    {
        float currentScrollValue = 0f;
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
            case ScrollDirection.RightToLeft:
                currentScrollValue = cameraTransform.position.x;
                break;
            case ScrollDirection.DownToUp:
            case ScrollDirection.UpToDown:
                currentScrollValue = cameraTransform.position.y;
                break;
        }
        float scrollValue = currentScrollValue - lastScrollValue;
        lastScrollValue = currentScrollValue;
        return scrollValue;
    }

    private bool IsOutOfBounds()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                return viewportPos.x < -limitOffScreen || viewportPos.x > 1f + limitOffScreen;
            case ScrollDirection.RightToLeft:
                return viewportPos.x > 1f + limitOffScreen || viewportPos.x < -limitOffScreen;
            case ScrollDirection.DownToUp:
                return viewportPos.y < -limitOffScreen || viewportPos.y > 1f + limitOffScreen;
            case ScrollDirection.UpToDown:
                return viewportPos.y > 1f + limitOffScreen || viewportPos.y < -limitOffScreen;
            default:
                return false;
        }
    }

    public enum BehaviourOnExit { Destroy, Regenerate };
}
