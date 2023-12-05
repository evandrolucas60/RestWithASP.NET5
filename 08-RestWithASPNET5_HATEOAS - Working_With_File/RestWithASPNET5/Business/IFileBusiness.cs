using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<FileDetailVO> SaveFilesToDisk(IList<IFormFile> file);
    }
}
