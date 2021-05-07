using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using GridSystem;
using GridSystem.Square;
using GridSystem.Square.Generator;

public enum SampleSquareGridSelectState
{
    Blank,
    Start,
    End,
    Start_End,
    Obstacle,
    Path
}

public class SampleSquareGridElement : GridElement
{
    #region Private Field

    private SampleSquareGridSelectState _selectState;

    private bool _isStart;
    private bool _isEnd;
    private bool _isObstacle;
    private bool _isPath;

    #endregion
    
    #region Public Field

    public bool isStart
    {
        get
        {
            return _isStart;
        }
        set
        {
            _isStart = value;
            OnChangeSelectBool();
        }
    }

    public bool isEnd
    {
        get
        {
            return _isEnd;
        }
        set
        {
            _isEnd = value;
            OnChangeSelectBool();
        }
    }

    public bool isObstacle
    {
        get
        {
            return _isObstacle;
        }
        set
        {
            _isObstacle = value;
            OnChangeSelectBool();
        }
    }

    public bool isPath
    {
        get
        {
            return _isPath;
        }
        set
        {
            _isPath = value;
            OnChangeSelectBool();
        }
    }

    /// <summary>
    /// the GridEventHandler of the current grid element
    /// </summary>
    public SquareGridEventHandler gridEventHandler
    {
        get
        {
            return (SquareGridEventHandler)_gridEventHandler;
        }
        set
        {
            _gridEventHandler = value;
        }
    }

    /// <summary>
    /// The text that display the coordinate of current grid
    /// </summary>
    public TMP_Text coordinateText;

    /// <summary>
    /// The background image of the GridElement
    /// </summary>
    public Image backgroundImg;

    #endregion
    
    #region Hide Public Field

    /// <summary>
    /// The SelectState of current Grid
    /// </summary>
    private SampleSquareGridSelectState selectState
    {
        get
        {
            return _selectState;
        }
        set
        {
            _selectState = value;
            OnChangeSelectState();
        }
    }
    
    #endregion

    #region Private Methods

    /// <summary>
    /// Call when the SelectState is changed
    /// </summary>
    private void OnChangeSelectState()
    {
        // change the background color to different color in different cases
        switch (_selectState)
        {
            case SampleSquareGridSelectState.Blank:
                backgroundImg.color = Color.white;
                break;
            case SampleSquareGridSelectState.Start:
                backgroundImg.color = Color.yellow;
                break;
            case SampleSquareGridSelectState.End:
                backgroundImg.color = Color.green;
                break;
            case SampleSquareGridSelectState.Start_End:
                backgroundImg.color = Color.blue;
                break;
            case SampleSquareGridSelectState.Obstacle:
                backgroundImg.color = Color.black;
                break;
            case SampleSquareGridSelectState.Path:
                backgroundImg.color = Color.magenta;
                break;
        }
    }

    /// <summary>
    /// Call when select bool changes
    /// </summary>
    private void OnChangeSelectBool()
    {
        if (_isStart && isEnd)
        {
            selectState = SampleSquareGridSelectState.Start_End;
        }
        else if (_isStart)
        {
            selectState = SampleSquareGridSelectState.Start;
        }
        else if (_isEnd)
        {
            selectState = SampleSquareGridSelectState.End;
        }
        else
        {
            if (_isPath)
            {
                selectState = SampleSquareGridSelectState.Path;
            }
            else if (_isObstacle)
            {
                selectState = SampleSquareGridSelectState.Obstacle;
            }
            else
            {
                selectState = SampleSquareGridSelectState.Blank;
            }
        }
    }

    #endregion

    #region Public Field

    /// <summary>
    /// Set the current object 
    /// </summary>
    public void SetCurrentObject()
    {
        _gridEventHandler.currentGridObject = gameObject;
    }

    #endregion

    #region GridElement

    protected override void OnCoordinateChange()
    {
        coordinateText.text = _coordinate.ToString();
    }

    #endregion
}