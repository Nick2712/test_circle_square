using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CircleSquare
{
    public class Main : MonoBehaviour
    {
        private int _currentScaleCoefficient;
        private Camera _mainCamera;
        private GameOptions _gameOptions;

        void Start()
        {
            _gameOptions = Resources.Load<GameOptions>(Constants.GameOptions);
        }

        void Update()
        {
            
        }

        //private bool MouseInObject()
        //{
        //    var mousePositionInWorld = GetMousePositionInWorld();
        //    Debug.Log($"мышка на позиции  {mousePositionInWorld}");
        //    var result = Mathf.Abs(_square.transform.position.x - mousePositionInWorld.x) < _scaleCoefficient / 2 &&
        //        Mathf.Abs(_square.transform.position.y - mousePositionInWorld.y) < _scaleCoefficient / 2;

        //    return result;
        //}

        //private void MakeScale()
        //{
        //    _circle.transform.localScale = Vector3.one;
        //    _square.transform.localScale = Vector3.one;
        //    float circleScaleCoefficient = (Mathf.Sqrt(_scaleCoefficient * _scaleCoefficient * 2));
        //    _circle.transform.localScale *= circleScaleCoefficient;
        //    _square.transform.localScale *= _scaleCoefficient;
        //}

        //private Vector2 GetMousePositionInWorld()
        //{
        //    var mousePositionInScreen = Input.mousePosition;
        //    var cameraVerticalSizeInUnits = _mainCamera.orthographicSize * 2;
        //    var unitSize = _mainCamera.pixelHeight / cameraVerticalSizeInUnits;
        //    var cameraCenter = new Vector2(_mainCamera.pixelWidth / 2, _mainCamera.pixelHeight / 2);
        //    var result = new Vector2((mousePositionInScreen.x - cameraCenter.x) /
        //        unitSize, (mousePositionInScreen.y - cameraCenter.y) / unitSize);
        //    return result;
        //}
    }
}