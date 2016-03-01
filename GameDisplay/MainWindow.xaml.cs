using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameOfLife;


namespace GameDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Life board;
        Cell[,] startingBoard;
        int rows, cols, _width, _height;

        Rectangle[,] drawingArray;

        SolidColorBrush aliveBrush, deadBrush;

        public MainWindow()
        {
            InitializeComponent();

            NextButton.Click += delegate { _nextClicked(); };
            ResetButton.Click += delegate { _resetClicked(); };

            Random rand = new Random();
            rows = 40;
            cols = 40;

            _width = 10;
            _height = 10;

            startingBoard = new Cell[rows, cols];
            drawingArray = new Rectangle[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        startingBoard[i, j] = new Cell(true, i, j);

                    }
                    else
                    {
                        startingBoard[i, j] = new Cell(false, i, j);
                    }

                    drawingArray[i, j] = new Rectangle();
                    drawingArray[i, j].Width = _width;
                    drawingArray[i, j].Height = _height;
                    drawingArray[i, j].Margin = new Thickness(j * _width, i * _height, 0, 0);
                    MainCanvas.Children.Add(drawingArray[i, j]);
                }
            }
            board = new Life(rows, cols, startingBoard);

            aliveBrush = new SolidColorBrush();
            aliveBrush.Color = Color.FromRgb(255, 0, 0);
            deadBrush = new SolidColorBrush();
            deadBrush.Color = Color.FromRgb(0, 0, 0);

            updateCanvas();
            
        }

        private void updateCanvas()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(board.board[i, j].isAlive)
                    {
                        drawingArray[i, j].Fill = aliveBrush;
                    }
                    else
                    {
                        drawingArray[i, j].Fill = deadBrush;
                    }
                    
                }
            }
        }

        private void _nextClicked()
        {
            board.updateBoard();
            updateCanvas();
        }

        private void _resetClicked()
        {
            Random rand = new Random();
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        startingBoard[i, j] = new Cell(true, i, j);

                    }
                    else
                    {
                        startingBoard[i, j] = new Cell(false, i, j);
                    }
                }
            }

            board = new Life(rows, cols, startingBoard);
            updateCanvas();
        }
    }
}
