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

        public Camera CameraUpdate(FigureView[] figures)
        {
            float visibleScreenWidth = (float)Screen.width - _gameOptions.CameraBorder * 2;
            float visibleScreenHeight = (float)Screen.height - (float)Screen.height * _gameOptions.CameraUiSpace - _gameOptions.CameraBorder;
            float unitSize = (float)Screen.height / (_camera.orthographicSize * 2);
            float cameraBorderInUnits = _gameOptions.CameraBorder / unitSize;
            float cameraUiSpaceInUnits = (_gameOptions.CameraUiSpace * (float)Screen.height) / unitSize;

            float aspectRatio = visibleScreenWidth / visibleScreenHeight;
            float screenHeightInUnits = _camera.orthographicSize * 2;
            float screenWidthInUnits = screenHeightInUnits * aspectRatio;
            
            float visibleScreenWidthInUnits = visibleScreenWidth / unitSize;
            float visibleScreenHeightInUnits = visibleScreenHeight / unitSize;

            Debug.Log($"unit size = {unitSize}");
            Debug.Log($"scren {Screen.width} x {Screen.height}");
            Debug.Log($"width = {visibleScreenWidth}");
            Debug.Log($"height = {visibleScreenHeight}");
            Debug.Log($"visible width = {visibleScreenWidthInUnits}");
            Debug.Log($"visible height = {visibleScreenHeightInUnits}");
            Debug.Log($"camera border = {cameraBorderInUnits}");
            Debug.Log($"camera UI = {cameraUiSpaceInUnits}");

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

            Debug.Log($"Required camera size x {minRequiredCameraSizeXInUnits}");
            Debug.Log($"Required camera size y {minRequiredCameraSizeYInUnits}");

            if (minRequiredCameraSizeYInUnits > visibleScreenHeightInUnits)
            {
                float difference = (minRequiredCameraSizeYInUnits - visibleScreenHeightInUnits) / 2;
                _camera.orthographicSize += difference;

                Debug.Log($"y changing difference {difference}");
                visibleScreenWidthInUnits = minRequiredCameraSizeXInUnits * aspectRatio;
            }

            if (minRequiredCameraSizeXInUnits > visibleScreenWidthInUnits)
            {
                float difference = (minRequiredCameraSizeXInUnits - visibleScreenWidthInUnits) / 2;
                difference = difference / aspectRatio;
                _camera.orthographicSize += difference;

                Debug.Log($"x changing difference {difference}");
                //visibleScreenHeightInUnits = minRequiredCameraSizeXInUnits / aspectRatio;
            }
            

            Vector3 currentCameraPosition = _camera.transform.position;
            float cameraPositionYOfset = cameraUiSpaceInUnits - cameraBorderInUnits;
            float requiredCameraPositionX = leftmostFigurePositionX + minRequiredCameraSizeXInUnits / 2;
            float requiredCameraPositionY = bottomFigurePositionY + minRequiredCameraSizeYInUnits / 2;
            currentCameraPosition.x = requiredCameraPositionX;
            currentCameraPosition.y = requiredCameraPositionY + cameraPositionYOfset;

            _camera.transform.position = currentCameraPosition;
            return _camera;
        }
    }
}