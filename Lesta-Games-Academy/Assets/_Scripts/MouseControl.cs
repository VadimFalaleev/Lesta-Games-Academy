using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Vector3 _startPosition;
    public int PlaceHash { get; set; }

    private const float _movementSpeed = 5f;
    private const float _maxDistance = 0.6f;

    [SerializeField] private UpdateProgress checkCorrectPlaces;

    private void Awake()
    {
        _startPosition = GetComponent<Transform>().position;
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;
        checkCorrectPlaces.Check();
    }

    void OnMouseDrag()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        if (Vector3.Distance(transform.position, _startPosition) <= _maxDistance)
            transform.position = Vector3.Lerp(transform.position, new Vector3(mousePos.x, mousePos.y, 0), _movementSpeed * Time.deltaTime);
    }
}