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

        public void Add(Board board)
        {
            if (!_boardValidator.Validate(board).FirstOrDefault())
                throw new InvalidOperationException("You passed invalid board!");
                
            _boardRepository.Add(board);
        }

        public bool Update(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("You must pass valid name!");
            try
            {
                _boardRepository.Update(id, name);
                return true;
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