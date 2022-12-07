using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using TouristHouse.Application.Abstractions.Services;

namespace TouristHouse.Persistence.Services
{
    public class PhotoService : IPhotoService
    {

        private readonly Cloudinary? _cloudinary;
        public PhotoService()
        {
            var acc = new Account
            (
                ServiceRegistraton.GetCloudinarySettings.CloudName,
                ServiceRegistraton.GetCloudinarySettings.ApiKey,
                ServiceRegistraton.GetCloudinarySettings.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }



        //public bool ImageSize(IFormFile file, int size)
        //	=> file.Length / 1024 > size;


        //public bool IsImage(IFormFile file)
        //	=> file.ContentType.Contains("image/");


        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(300).Width(300).Crop("fill").Gravity("face")
            };

            uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

    }
}
