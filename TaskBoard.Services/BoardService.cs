using TaskBoard.Core.Models;
using TaskBoard.DataAccess;

namespace TaskBoard.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            this._boardRepository = boardRepository;
        }

        public void Add(Board board)
        {
            if (!ValidateBoard(board))
                throw new InvalidOperationException("You passed invalid board!");
            if (ValidatePresenceofTheBoard(board.Id))
                throw new InvalidOperationException("This board already exists");
            _boardRepository.Add(board);
        }

        public void Update(int id, string name)
        {
            if(!ValidatePresenceofTheBoard(id))
                throw new InvalidOperationException("You passed invalid board!");
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("You must pass valid name!");
            _boardRepository.Update(id, name);
        }

        public void Delete(Board board)
        {
            if (!ValidatePresenceofTheBoard(board))
                throw new InvalidOperationException("You passed invalid board!");
            _boardRepository.Delete(board);
        }

        public void DeleteById(int id)
        {
            if (!ValidatePresenceofTheBoard(id))
                throw new InvalidOperationException("You passed invalid identificator of the board!");
            _boardRepository.DeleteById(id);
        }

        public List<Board> GetAll()
        {
            return _boardRepository.GetAll();
        }

        public Board GetById(int id)
        {
            if (!ValidatePresenceofTheBoard(id))
                throw new InvalidOperationException("You passed invalid identificator of the board!");
            return _boardRepository.GetById(id);
        }

        private static bool ValidateBoard(Board board)
        {
            if (board == null) return false;
            if(board.Id < 0) return false;
            if (string.IsNullOrWhiteSpace(board.Name)) return false;

            return true;
        }

        private bool ValidatePresenceofTheBoard(Board board)
        {
            if(!ValidateBoard(board)) return false;
            
            return GetAll().Contains(board);
        }

        public bool ValidatePresenceofTheBoard(int boardId)
        {
            return boardId >= 0 && boardId < GetAll().Count;
        }
    }
}