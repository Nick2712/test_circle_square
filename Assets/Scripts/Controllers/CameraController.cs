using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CircleSquare
{
    public class CameraController
    {
        private Camera _camera;
        private GameOptions _gameOptions;

        public CameraController(GameOptions gameOptions, Camera camera)
        {
            _gameOptions = gameOptions;
            _camera = camera;
        }

        public void LateUpdate(List<FigureView> figures)
        {
            float aspectRatio = (float)Screen.width / (float)Screen.height;
            float screenHeightInUnits = _camera.orthographicSize * 2;
            float screenWidthInUnits = screenHeightInUnits * aspectRatio;
            float topFigurePositionY = 0;
            float bottomFigurePositionY = 0;
            float leftmostFigurePositionX = 0;
            float rightmostFigurePositionX = 0;

            foreach (var figure in figures)
            {
                if (topFigurePositionY < figure.FigurePosition.y + figure.FigureSizeInUnits / 2)
                {
                    topFigurePositionY = figure.FigurePosition.y + figure.FigureSizeInUnits / 2;
                }
                if (bottomFigurePositionY > figure.FigurePosition.y - figure.FigureSizeInUnits / 2)
                {
                    bottomFigurePositionY = figure.FigurePosition.y - figure.FigureSizeInUnits / 2;
                }
                if (leftmostFigurePositionX > figure.FigurePosition.x - figure.FigureSizeInUnits / 2)
                {
                    leftmostFigurePositionX = figure.FigurePosition.x - figure.FigureSizeInUnits / 2;
                }
                if (rightmostFigurePositionX < figure.FigurePosition.x + figure.FigureSizeInUnits / 2)
                {
                    rightmostFigurePositionX = figure.FigurePosition.x + figure.FigureSizeInUnits / 2;
                }
            }

            float minRequiredCameraSizeXInUnits = Mathf.Abs(leftmostFigurePositionX - rightmostFigurePositionX);
            float minRequiredCameraSizeYInUnits = Mathf.Abs(topFigurePositionY - bottomFigurePositionY);

            if (minRequiredCameraSizeXInUnits > screenWidthInUnits)
            {
                float difference = (minRequiredCameraSizeXInUnits - screenWidthInUnits) / 2;
                difference /= aspectRatio;
                _camera.orthographicSize += difference;
                screenHeightInUnits = minRequiredCameraSizeYInUnits;

                Debug.Log("correcting width");
            }
            if (minRequiredCameraSizeYInUnits > screenHeightInUnits)
            {
                float difference = (minRequiredCameraSizeYInUnits - screenHeightInUnits) / 2;
                _camera.orthographicSize += difference;
                
                Debug.Log("correcting hight");
            }

            Vector3 currentCameraPosition = _camera.transform.position;
            float requiredCameraPositionX = leftmostFigurePositionX + minRequiredCameraSizeXInUnits / 2;
            float requiredCameraPositionY = bottomFigurePositionY + minRequiredCameraSizeYInUnits / 2;
            currentCameraPosition.x = requiredCameraPositionX;
            currentCameraPosition.y = requiredCameraPositionY;

            _camera.transform.position = currentCameraPosition;
        }
    }
}