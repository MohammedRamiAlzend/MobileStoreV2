using DataCore.Models.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Services.Interfaces
{
    public interface IImageService

    {
        Task<DataBaseRequest<IEnumerable<ImageModel>>> GetAllImageAsync();
        
        Task<DataBaseRequest> CreateImageAsync(ImageModel createimage);

        Task<DataBaseRequest> DeleteImageAsync(int id);
        Task<DataBaseRequest<ImageModel>> GetImageByNameAsync(string name);

        Task<DataBaseRequest<ImageModel>> GetImageByIdAsync(int id);


    }
}

