using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4;

public class FileService : IFileService
{
    public async Task<IEnumerable<string[]>> GetBoardNumbersAsync()
    {
        var lines = await File.ReadAllLinesAsync("Input.txt");
        return lines.Skip(1).ToList().Where(x => !string.IsNullOrWhiteSpace(x)).Chunk(5);
    }

    public async Task<string[]> GetNumbersAsync()
    {
        var lines = await File.ReadAllLinesAsync("Input.txt");
        return lines.FirstOrDefault().Split(",");
    }
}
