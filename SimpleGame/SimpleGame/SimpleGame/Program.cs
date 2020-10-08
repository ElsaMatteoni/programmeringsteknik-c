using System;
using System.Diagnostics;
using System.Threading;

namespace SimpleGame
{
    class Program
    {
        // Bröt ut lite och gjorde dem globala.
        // På detta sätt så kan man sätta readonly och definera vissa till konstanter, detta minskar resursanvändning
        static readonly Stopwatch _timer = new Stopwatch();
        static readonly Random _randomizer = new Random();

        const int _bufferWidth = 120;
        const int _bufferHeight = 20;
        const char _playerCharacter = '>';
        const int _charSize = sizeof(char);

        static char[,] _screenBuffer = new char[_bufferHeight + 1, _bufferWidth];

        // Hindren flyttade jag till en array med ValueTuples så att det skall gå att ändra hur många man vill ha
        static (int x, int uy, int ly)[] _obstacles;
        static (int x, int y) _playerPosition = (9, 10);

        static int _points = 0;
        static int _hp = 3;
      
        // Det är bättre att använda ConsoleKey än vilken char som tryckts ned på tangentbordet
        const ConsoleKey _upKey = ConsoleKey.W;
        const ConsoleKey _downKey = ConsoleKey.S;

        static void Main(string[] args)
        {
            _timer.Start();
            
            // Huvudloopen var ganska svårläst iom att den var längre än 100 rader, jag bröt ut logiken i lämpliga delar för läsbarhet.
            GenerateObstacles();

            do
            {
                // Denna del sköter rendering
                // Flyttade spelplanen till en skärmbuffer för att snabba upp utritningen, normalt använder man en sådan när man jobbar med spel.
                // Nu behöver man tillgång direkt till minnet om utritningen skall bli snabb, så detta räcker inte.
                Render();

                MoveObstacles();
                CheckCollissions();

                Thread.Sleep(50);

                HandleInput();
            }
            while (_hp > 0);

            _timer.Stop();

            Console.WriteLine("You lost...");
        }

        static void HandleInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            if (_upKey == input.Key && _playerPosition.y > 0)
            {
                _playerPosition.y--;
            }
            else if (_downKey == input.Key && _playerPosition.y < _bufferHeight)
            {
                _playerPosition.y++;
            }
        }

        static void Render()
        {
            for (int y = 0; y < _bufferHeight + 1; y++)
            {
                for (int x = 0; x < _bufferWidth; x++)
                {
                    _screenBuffer[y, x] = GetCharToRender(x, y);
                }
            }

            Console.Clear();

            for (var y = 0; y < _bufferHeight + 1; y++)
            {
                Console.WriteLine(GetRow(y));
            }
            
            Console.WriteLine($"Score: {_points}");
            Console.Write($"Health: {_hp}");
        }

        static void MoveObstacles()
        {
            for (var i = 0; i < _obstacles.Length; i++)
            {
                var obstacle = _obstacles[i];

                if (obstacle.x <= 0)
                {
                    obstacle.x = _bufferWidth;
                    
                    var bounds = GetObstacleBounds();

                    obstacle.uy = bounds.max;
                    obstacle.ly = bounds.min;
                }

                obstacle.x -= 2;

                _obstacles[i] = obstacle;
            }
        }

        static char[] GetRow(int y)
        {
            char[] row = new char[_bufferWidth];
            Buffer.BlockCopy(_screenBuffer, y * _bufferWidth * _charSize, row, 0, _bufferWidth * _charSize);

            return row;
        }

        static char GetCharToRender(int x, int y)
        {
            if (y == 0 || y >= _bufferHeight)
               return '▓';
                    
            if (y == _playerPosition.y && x == _playerPosition.x)
                return _playerCharacter;
            
            if (CollidesWithObstacle(x, y))
                return '░';
            
            return ' ';
        }

        static void CheckCollissions()
        {
            if (CollidesWithObstacle(_playerPosition.x + 1, _playerPosition.y))
            {
                _hp--;
            }
            else if (ShouldGetPoints(_playerPosition.x + 1))
            {
                _points++;
            }
        }
        
        static bool ShouldGetPoints(int x)
        {
            foreach (var obstacle in _obstacles)
            {
                if (obstacle.x == x)
                    return true;
            }
            
            return false;
        }

        static bool CollidesWithObstacle(int x, int y)
        {
            foreach (var obstacle in _obstacles)
            {
                if (x != obstacle.x)
                    continue;

                if (y >= obstacle.uy)
                    return true;

                if (y <= obstacle.ly)
                    return true;
            }

            return false;
        }

        static void GenerateObstacles()
        {
            _obstacles = new (int x, int uy, int ly)[4];

            for (var i = 0; i <= 3; i++)
            {
                var bounds = GetObstacleBounds();
                _obstacles[i] = ((i+1) * 30, bounds.max, bounds.min);
            }
        }

        static (int min, int max) GetObstacleBounds()
        {
            var position = _randomizer.Next(1, 16);
            return (position, position + 4);
        }
    }
}