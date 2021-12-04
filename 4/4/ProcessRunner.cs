namespace _4;

public class ProcessRunner : IProcessRunner
{
    private readonly IFileService fileService;
    private readonly IBoardCheckingService boardCheckingService;
    private readonly IBoardMakerService boardMakerService;

    public ProcessRunner(IFileService fileService, IBoardCheckingService boardCheckingService, IBoardMakerService boardMakerService)
    {
        this.fileService = fileService;
        this.boardCheckingService = boardCheckingService;
        this.boardMakerService = boardMakerService;
    }
    
    public async Task Run()
    {
        var boards = (await fileService.GetBoardNumbersAsync()).Select(boardMakerService.Make).ToList() ;
        var finishedBoards = new List<Board>();
        var numbers = await fileService.GetNumbersAsync();
        foreach (var number in numbers)
        {
            foreach (var board in boards)
            {
                boardCheckingService.MarkBoard(number, board);
                var result = boardCheckingService.CheckBoard(board);
                if (result && !finishedBoards.Contains(board))
                {
                    var points = boardCheckingService.CountPoints(board, int.Parse(number));
                    Console.WriteLine(points);
                    finishedBoards.Add(board);
                }
            }
            
        }
    }
}
