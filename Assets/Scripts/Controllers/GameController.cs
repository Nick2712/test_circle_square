using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CircleSquare
{
    public class GameController
    {
        private Color _selectedColor = Color.red;
        private Color _unselectedColor = Color.white;

        private PlayerInputController _playerInputController;
        private List<FigureView> _squares = new List<FigureView>();
        private List<FigureView> _circles = new List<FigureView>();
        private FigureView _squareSelected;
        private Camera _mainCamera;


        public GameController(Camera camera, GameOptions gameOptions, FigureView[] figures)
        {
            _mainCamera = camera;
            var cameraController = new CameraController(gameOptions, _mainCamera);
            _mainCamera = cameraController.CameraUpdate(figures);
            _playerInputController = new PlayerInputController();
            foreach (var figure in figures)
            {
                switch (figure.FigureType)
                {
                    case FigureType.Circle:
                        figure.IsEnabled = true;
                        _circles.Add(figure);
                        break;
                    case FigureType.Square:
                        figure.IsEnabled = true;
                        _squares.Add(figure);
                        break;
                }
            }
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = _playerInputController.GetMousePositionInWorld(_mainCamera);
                if (_squareSelected == null)
                {
                    _squareSelected = GetSquare(mousePosition);
                }
                else
                {
                    TryPlaceScuareInCircle(_squareSelected, mousePosition);
                }
            }
        }

        private FigureView GetSquare(Vector2 mousePosition)
        {
            foreach (var square in _squares)
            {
                if (MouseInObject(square, mousePosition) && square.IsEnabled)
                {
                    ChangeFigureColor(square, _selectedColor);
                    return square;
                }
            }
            return null;
        }

        private void TryPlaceScuareInCircle(FigureView square, Vector2 mousePosition)
        {
            foreach (var circle in _circles)
            {
                if (MouseInObject(circle, mousePosition) && circle.IsEnabled)
                {
                    if (square.FigureSize == circle.FigureSize)
                    {
                        square.transform.position = circle.transform.position;
                        square.IsEnabled = false;
                        circle.IsEnabled = false;
                    }
                    ChangeFigureColor(_squareSelected, _unselectedColor);
                    _squareSelected = null;
                    return;
                }
            }
            ChangeFigureColor(_squareSelected, _unselectedColor);
            _squareSelected = null;
        }

        private bool MouseInObject(FigureView figure, Vector2 mousePosition)
        {
            var result = Mathf.Abs(figure.transform.position.x - mousePosition.x) < figure.FigureSizeInUnits / 2 &&
                Mathf.Abs(figure.transform.position.y - mousePosition.y) < figure.FigureSizeInUnits / 2;
            return result;
        }

        private void ChangeFigureColor(FigureView figure, Color color)
        {
            if (figure != null) figure.GetComponent<SpriteRenderer>().color = color;
        }
    }
}