using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace FilesUploadApi.Dtos.Validation
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        //implementuojam validavimo metoda
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"max size is {_maxFileSize}");
                }

            }
            return ValidationResult.Success;
        }
    }
}
