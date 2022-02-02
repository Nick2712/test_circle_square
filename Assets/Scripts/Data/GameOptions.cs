using UnityEngine;


namespace CircleSquare
{
    [CreateAssetMenu(fileName = nameof(GameOptions), menuName = "CircleSqare/" + nameof(GameOptions))]
    public class GameOptions : ScriptableObject
    {
        [SerializeField, Range(0, 0.1f)] private float _figureBorder = 0.1f;
        [SerializeField, Range(0.1f, 1.0f)] private float _figureSizeStep = 0.2f;
        [SerializeField, Range(5.0f, 10.0f)] private float _cameraMinSize = 5.0f;
        [SerializeField, Range(0, 20.0f)] private float _cameraBorder = 10.0f;
        [SerializeField, Range(0, 0.5f)] private float _cameraUiSpace = 0.1f;

        public float FigureBorder => _figureBorder;
        public float FigureSizeStep => _figureSizeStep;
        public float CameraMinSize => _cameraMinSize;
        public float CameraBorder => _cameraBorder;
        public float CameraUiSpace => _cameraUiSpace;
    }
}