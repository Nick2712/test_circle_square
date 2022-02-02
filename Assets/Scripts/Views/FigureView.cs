using UnityEngine;


namespace CircleSquare
{
    public class FigureView : MonoBehaviour
    {
        [SerializeField] private FigureType _figureType;
        [SerializeField, Range(1, 5)] private int _figureSize = 1;

        public FigureType FigureType => _figureType;
        public int FigureSize => _figureSize;
        public Vector2 FigurePosition => transform.position;
        public float FigureSizeInUnits { get; private set; }

        private GameOptions _gameOptions;


        private void OnValidate()
        {
            if(_gameOptions == null)
            {
                _gameOptions = Resources.Load<GameOptions>(Constants.GameOptions);
                if(_gameOptions == null)
                {
                    Debug.LogError("Game options not found!");
                }
            }
            if(_gameOptions != null)
            {
                switch(_figureType)
                {
                    case FigureType.Circle:
                        MakeScaleCircle();
                        break;
                    case FigureType.Square:
                        MakeScaleSquare();
                        break;
                    default:
                        Debug.LogError($"Figure {name} must be assigned!");
                        break;
                }
            }
        }

        private void MakeScaleCircle()
        {
            transform.localScale = Vector3.one;
            float figureSize = 1 + _figureSize * _gameOptions.FigureSizeStep + _gameOptions.FigureBorder;
            float circleSize = (Mathf.Sqrt(figureSize * figureSize * 2));
            transform.localScale *= circleSize;
            FigureSizeInUnits = circleSize;
        }

        private void MakeScaleSquare()
        {
            transform.localScale = Vector3.one;
            float figureSize = 1 + _figureSize * _gameOptions.FigureSizeStep;
            transform.localScale *= figureSize;
            FigureSizeInUnits = figureSize;
        }
    }
}