using UnityEngine;

public class PointControl : MonoBehaviour
{
    [SerializeField] private MouseControl[] _cubes;
    private const float _maxDistance = 0.4f;
    private const float _movementSpeed = 5f;
    private bool busy = false;
    private int hash;

    private void Awake()
    {
        hash = GetHashCode();
    }

    private void Update()
    {
        if (_cubes.Length == 0)
            return;

        for (int i = 0; i < _cubes.Length; ++i)
        {
            var cube = _cubes[i];

            if (cube.PlaceHash != hash && !busy && Vector2.Distance(transform.position, cube.transform.position) <= _maxDistance)
                SetInPlace(cube, true);
            else if (cube.PlaceHash == hash && busy && Vector2.Distance(transform.position, cube.transform.position) > _maxDistance)
                SetInPlace(cube, false);

            if (cube.PlaceHash == hash && busy)
            {
                cube.transform.position = Vector3.Lerp(cube.transform.position, transform.position, _movementSpeed * Time.deltaTime);
                cube._startPosition = transform.position;
                break;
            }
        }
    }

    private void SetInPlace(MouseControl cube, bool value)
    {
        busy = value;

        if (value)
            cube.PlaceHash = hash;
        else
            cube.PlaceHash = 0;
    }
}