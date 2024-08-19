using DataCore.Models.DataCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Services
{
    public class ImageService : IImageService
    {

        private readonly ApplicationDbContext _context;
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ImageService(ApplicationDbContext context, DbContextOptions<ApplicationDbContext> options)
        {
            _context = context;


        }
        public async Task<DataBaseRequest<IEnumerable<ImageModel>>> GetAllImageAsync()
        {
            var request = await _context.images.Where(x=>x.IsDeleted == false).ToListAsync();
            if (request != null)
            {
                return new DataBaseRequest<IEnumerable<ImageModel>>
                {
                    Data = request,
                    Message = "image retrieved successfully",
                    Success = true
                };
            }
            else
            {
                return new DataBaseRequest<IEnumerable<ImageModel>>
                {
                    Data = [],
                    Message = "there is no images or image",
                    Success = false

                };
            }
        }
        public async Task<DataBaseRequest> CreateImageAsync(ImageModel CreateImage)
        {
            ImageModel Image = new ImageModel
            {
                ImageName = CreateImage.ImageName,
                ImageData = CreateImage.ImageData,
                UploadDate = CreateImage.UploadDate,
                IsDeleted = CreateImage.IsDeleted,
                DeletedAt = CreateImage.DeletedAt,
            };
            _context.images.Add(Image);
            var resutl = await _context.SaveChangesAsync();
            if (resutl > 0)
            {
                return new DataBaseRequest
                {
                    Message = "Image Created Successfully",
                    Success = true,
                };
            }
            else
            {
                return new DataBaseRequest
                {
                    Message = "An error occurred while creating Image",
                    Success = false,
                };
            }
        }
        public async Task<DataBaseRequest> DeleteImageAsync(int id)
        {
            var image = await _context.images.FindAsync(id);

            if (image == null)
            {
                return new DataBaseRequest
                {
                    Message = $"The Image with {id} not found",
                    Success = false,
                };
            }
            else
            {
                _context.images.Remove(image);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return new DataBaseRequest
                    {
                        Message = $"The Image {image.ImageName} has been deleted successfully",
                        Success = true,
                    };
                }
                else
                {
                    return new DataBaseRequest
                    {
                        Message = "an error occurred while Deleting Image"
                    };
                }
            }

        }


    }
}
