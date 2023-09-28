
using System;
using System.Drawing;
using System.ComponentModel;
using System.Threading;
using System.IO;
using System.Drawing.Drawing2D;

  namespace  LangtonsAnt

 { 

#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion





    public class Ant
    {
        public enum CardinalDirection
        {
            North = 10,
            East = 20,
            South = 30,
            West = 40
        }

        private Point position;
        public Point Position
        {
            get { return position; }
            set
            {
                if (value != position)
                {
                    position = value;
                    OnPositionChanged(this, new PositionArgs(value));
                }
            }
        }

        private CardinalDirection direction;
        public CardinalDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Ant(int x, int y) : this(x, y, CardinalDirection.North) {}

        public Ant(int x, int y, CardinalDirection direction)
        {
            this.position = new Point(x, y);
            this.direction = direction;
        }

        public event EventHandler<PositionArgs> PositionChanged;
        protected virtual void OnPositionChanged(object sender, PositionArgs e)
        {
            EventHandler<PositionArgs> eh = PositionChanged;
            if (eh != null)
            {
                eh(sender, e);
            }
        }

        public void Move()
        {
            Point newPoint = this.Position;

            switch (this.Direction)
            {
                // Move right.
                case (Ant.CardinalDirection)20:
                    newPoint.X++;
                    break;
                // Move left.
                case (Ant.CardinalDirection)40:
                    newPoint.X--;
                    break;
                // Move Up.
                case (Ant.CardinalDirection)10:
                    newPoint.Y++;
                    break;
                // Move Down.
                case (Ant.CardinalDirection)30:
                    newPoint.Y--;
                    break;
            }

            this.Position = newPoint;
        }
    }


#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion







    public enum GridStyle
    {
        Standard,
        CheckerBoard,
        Random
    }

    public class GridVirtual
    {
        private int? speed;
        public int? Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private BackgroundWorker backgroundWorker;

        private string lastLoadPath;

        private bool doWork = false;

        private int gridScale;
        public int GridScale
        {
            get { return gridScale; }
        }

        private const int minScale = 4;
        private const int maxScale = 10;

        private const string gameBoardStartTag = @"<GameBoard>";
        private const string gameBoardEndTag = @"</GameBoard>";

        private int[,] virtualGrid;
        public int[,] VirtualGrid
        {
            get { return virtualGrid; }
        }

        private Ant ant;
        public Ant Ant
        {
            get { return ant; }
        }

        private Random randCell;

        public GridVirtual() {}

        public GridVirtual(int gridScale) : this(gridScale, GridStyle.Standard) {}

        public GridVirtual(int gridScale, GridStyle gridStyle)
        {
            if (backgroundWorker == null)
            {
                InitializeBackgroundWorker();
            }

            if (gridScale < minScale)
            {
                this.gridScale = (int)Math.Pow(2, minScale);
            }
            else if (gridScale > maxScale)
            {
                this.gridScale = (int)Math.Pow(2, maxScale);
            }
            else
            {
                this.gridScale = (int)Math.Pow(2, gridScale);
            }

            this.virtualGrid = new int[this.gridScale, this.gridScale];

            this.ant = new Ant(((this.gridScale / 2) + 1), ((this.gridScale / 2) + 1));

            if (gridStyle == GridStyle.Standard)
            {
                return;
            }
            if (gridStyle == GridStyle.CheckerBoard)
            {
                for (int i = 0; i < this.gridScale; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < this.gridScale; j++)
                        {
                            if (j % 2 != 0)
                            {
                                this.virtualGrid[i, j] = 1;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < this.gridScale; j++)
                        {
                            if (j % 2 == 0)
                            {
                                this.virtualGrid[i, j] = 1;
                            }
                        }
                    }
                }
            }
            if (gridStyle == GridStyle.Random)
            {
                this.randCell = new Random();

                for (int i = 0; i < this.gridScale; i++)
                {
                    for (int j = 0; j < this.gridScale; j++)
                    {
                        this.virtualGrid[i, j] = randCell.Next(2);
                    }
                }
            }
        }

        public void SaveGrid(string savePath)
        {
            string stringToWrite;

            using (StreamWriter _streamWriter = new StreamWriter(savePath))
            {
                _streamWriter.WriteLine(gameBoardStartTag);

                for (int i = 0; i < this.gridScale; i++)
                {
                    stringToWrite = "";

                    for (int j = 0; j < this.gridScale; j++)
                    {
                        if ((ant.Position.Y == i) && (ant.Position.X == j))
                        {
                            stringToWrite = stringToWrite + (Convert.ToInt32(ant.Direction) + virtualGrid[i, j]);
                        }
                        else
                        {
                            stringToWrite = stringToWrite + virtualGrid[i, j];
                        }
                        if (j != (this.gridScale - 1))
                        {
                            stringToWrite = stringToWrite + ", ";
                        }
                    }

                    _streamWriter.WriteLine(stringToWrite);
                }

                _streamWriter.WriteLine(gameBoardEndTag);
            }
        }

        public void LoadGrid(string loadPath)
        {
            if (backgroundWorker == null)
            {
                InitializeBackgroundWorker();
            }

            this.lastLoadPath = loadPath;

            string dataFromFile;
            string[] gameBoardRows;
            string[] gameBoardCols;

            using (StreamReader _streamReader = new StreamReader(loadPath))
            {
                dataFromFile = _streamReader.ReadToEnd();
            }

            gameBoardRows = dataFromFile.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            gridScale = (gameBoardRows.Length - 1);

            while (gameBoardRows[gridScale] == String.Empty)
            {
                gridScale--;
            }

            if ((gameBoardRows[0] != gameBoardStartTag) || (gameBoardRows[gridScale] != gameBoardEndTag))
            {
                throw new InvalidGameBoardException("The file: \"" + loadPath + "\" is not a valid GameBoard.");
            }
            else
            {
                this.gridScale = (gridScale - 1);
                virtualGrid = new int[this.gridScale, this.gridScale];

                for (int i = 0; i < this.gridScale; i++)
                {
                    gameBoardCols  = gameBoardRows[i + 1].Split(new string[] { ", " }, StringSplitOptions.None);

                    if (gameBoardCols.Length != this.gridScale)
                    {
                        throw new InvalidGameBoardException("The file: \"" + loadPath + "\" is not a valid GameBoard.");
                    }
                    else
                    {
                        for (int j = 0; j < this.gridScale; j++)
                        {
                            virtualGrid[i, j] = Convert.ToInt32(gameBoardCols[j]);

                            if (virtualGrid[i, j] > 1)
                            {
                                int cellValue = (virtualGrid[i, j] % 10);
                                ant = new Ant(j, i, (Ant.CardinalDirection)(virtualGrid[i, j] - cellValue));
                                virtualGrid[i, j] = cellValue;
                            }
                        }
                    }
                }
                if (ant == null)
                {
                    ant = new Ant(((this.gridScale / 2) + 1), ((this.gridScale / 2) + 1));
                }
            }
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = false;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += UpdateAnt;
            backgroundWorker.RunWorkerCompleted += BackgroundWorkerCompleted;
        }

        private void BackgroundWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) { }

        public void Start()
        {
            doWork = true;
            speed = 110;
            backgroundWorker.RunWorkerAsync();
        }

        public void Stop()
        {
            doWork = false;
            backgroundWorker.CancelAsync();
        }

        public void Restart()
        {
            Stop();
            LoadGrid(lastLoadPath);
        }

        private void UpdateAnt(object sender, DoWorkEventArgs e)
        {
            while (doWork)
            {
                if (e.Cancel)
                {
                    return;
                }
                try
                {
                    // Ant is on a white cell.
                    // Turn right.
                    if (this.virtualGrid[this.ant.Position.X, this.ant.Position.Y] == 0)
                    {
                        // Change cell value to black.
                        this.virtualGrid[this.ant.Position.X, this.ant.Position.Y] = 1;

                        if ((int)this.ant.Direction > (int)Ant.CardinalDirection.North)
                        {
                            this.ant.Direction = (Ant.CardinalDirection)((int)this.ant.Direction - 10);
                        }
                        else
                        {
                            this.ant.Direction = Ant.CardinalDirection.West;
                        }
                    }
                    // Ant is on a black cell.
                    // Turn left.
                    else
                    {
                        // Change cell value to white.
                        this.virtualGrid[this.ant.Position.X, this.ant.Position.Y] = 0;

                        if ((int)this.ant.Direction < (int)Ant.CardinalDirection.West)
                        {
                            this.ant.Direction = (Ant.CardinalDirection)((int)this.ant.Direction + 10);
                        }
                        else
                        {
                            this.ant.Direction = Ant.CardinalDirection.North;
                        }
                    }
                    this.ant.Move();

                    if (speed != null)
                    {
                        System.Threading.Thread.Sleep((int)speed);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    if (this.ant.Position.X < this.virtualGrid.GetLowerBound(0))
                    {
                        this.ant.Position = new System.Drawing.Point((this.ant.Position.X + 1), this.ant.Position.Y);
                    }
                    else if(this.ant.Position.X > this.virtualGrid.GetLowerBound(0))
                    {
                        this.ant.Position = new System.Drawing.Point((this.ant.Position.X - 1), this.ant.Position.Y);
                    }

                    if (this.ant.Position.Y < this.virtualGrid.GetLowerBound(1))
                    {
                        this.ant.Position = new System.Drawing.Point(this.ant.Position.X, (this.ant.Position.Y + 1));
                    }
                    else if (this.ant.Position.Y > this.virtualGrid.GetLowerBound(1))
                    {
                        this.ant.Position = new System.Drawing.Point(this.ant.Position.X, (this.ant.Position.Y - 1));
                    }

                    if (this.ant.Direction == Ant.CardinalDirection.North)
                    {
                        this.ant.Direction = Ant.CardinalDirection.South;
                    }
                    if (this.ant.Direction == Ant.CardinalDirection.East)
                    {
                        this.ant.Direction = Ant.CardinalDirection.West;
                    }
                    if (this.ant.Direction == Ant.CardinalDirection.South)
                    {
                        this.ant.Direction = Ant.CardinalDirection.North;
                    }
                    if (this.ant.Direction == Ant.CardinalDirection.West)
                    {
                        this.ant.Direction = Ant.CardinalDirection.East;
                    }
                }
            }
        }
    }


#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion




    class InvalidGameBoardException : ApplicationException
    {
        public InvalidGameBoardException() : base() {}
        public InvalidGameBoardException(string s) : base(s) {}
        public InvalidGameBoardException(string s, Exception ex) : base(s, ex) {}
    }


#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion





    public class PositionArgs : EventArgs
    {
        public Point Point { get; private set; }

        public PositionArgs(Point Point)
        {
            this.Point = Point;
        }
    }


#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion






    class Utilities
    {
        public static string IsoDate(DateTime dateTime)
        {
            string dateFormat = "yyyyMMdd";
            return dateTime.ToString(dateFormat);
        }

        public static string IsoTime(DateTime dateTime)
        {
            string dateFormat = "HHmmss";
            return dateTime.ToString(dateFormat);
        }

        public static string IsoDateTime(DateTime dateTime)
        {
            return IsoDate(dateTime) + IsoTime(dateTime);
        }

        public static Image ImageResize(Image SourceImage, int NewHeight, int NewWidth)
        {
            Bitmap bitmap = new Bitmap(NewWidth, NewHeight, SourceImage.PixelFormat);
            Graphics graphicsImage = Graphics.FromImage(bitmap);

            graphicsImage.SmoothingMode = SmoothingMode.HighQuality;
            graphicsImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphicsImage.DrawImage(SourceImage, 0, 0, bitmap.Width, bitmap.Height);
            graphicsImage.Dispose();

            return bitmap;
        }
    }

}