
using UnityEngine;

public class FromWorldPointTextPositioner : IFloatingTextPositioner
{
    private readonly Camera _camera;
    private readonly Vector3 _worldPosition;
    private readonly float _speed; 
    private float _timeToLive;
    private float _yOffset;


    public FromWorldPointTextPositioner(Camera camera, Vector3 worldPosition, float timeToLive, float speed)
    {
        _speed = speed;
        _timeToLive = timeToLive;
        _worldPosition = worldPosition;
        _camera = camera;
    }

    public bool GetPosition(ref UnityEngine.Vector2 position, UnityEngine.GUIContent content, UnityEngine.Vector2 size)
    {
        if ((_timeToLive -= Time.deltaTime) <= 0)
            return false;

        var screenPosition = _camera.WorldToScreenPoint(_worldPosition);
        position.x = screenPosition.x - (size.x/2);
        position.y = Screen.height - screenPosition.y - _yOffset;

        _yOffset += Time.deltaTime*_speed;
        return true;
    }
}
