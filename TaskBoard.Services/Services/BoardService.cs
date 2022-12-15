using TaskBoard.Core.Models;
using TaskBoard.DataAccess;
using TaskBoard.Services.Validators;

namespace TaskBoard.Services.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IValidator<Board> _boardValidator;

        public BoardService(IBoardRepository boardRepository, IValidator<Board> boardValidator)
        {
            _boardRepository = boardRepository;
            _boardValidator = boardValidator;
        }

        public bool Add(Board board)
        {
            try
            {
                if (!_boardValidator.Validate(board).FirstOrDefault())
                    throw new InvalidOperationException("You passed invalid board!");

                _boardRepository.Add(board);
                return true;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public bool Update(int id, string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new InvalidOperationException("You must pass valid name!");

                _boardRepository.Update(id, name);
                return true;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                _boardRepository.DeleteById(id);
                return true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Board> GetAll()
        {
            try
            {
                return _boardRepository.GetAll();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Board GetById(int id)
        {
            try
            {
                return _boardRepository.GetById(id);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}