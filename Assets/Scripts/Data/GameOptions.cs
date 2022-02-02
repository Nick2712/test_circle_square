using UnityEngine;


namespace CircleSquare
{
    [CreateAssetMenu(fileName = nameof(GameOptions), menuName = "CircleSqare/" + nameof(GameOptions))]
    public class GameOptions : ScriptableObject
    {
        [SerializeField, Range(0, 0.1f)] float _figureBorder = 0.1f;
        [SerializeField, Range(0.1f, 1.0f)] float _figureSizeStep = 0.2f;
        [SerializeField, Range(5.0f, 10.0f)] float _cameraMinSize = 5.0f;

        public float FigureBorder => _figureBorder;
        public float FigureSizeStep => _figureSizeStep;
        public float CameraMinSize => _cameraMinSize;
    }
}