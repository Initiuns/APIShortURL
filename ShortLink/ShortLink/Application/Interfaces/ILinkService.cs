using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLink.Application.Interfaces
{
    interface ILinkService
    {
        Task<bool> DoesKeyExist(string key);
        Task Add(string key, string url);
        Task<string> GetUrl(string key);
        Task<ValidationResult> Validate(TRequest request);
    }
}
